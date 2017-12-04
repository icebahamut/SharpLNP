 /*
Copyright (c) 2017 icebahamut (icebahamut[at]hotmail[dot]com)

Permission is hereby granted, free of charge, to any person obtaining a copy of this
software and associated documentation files (the "Software"), to deal in the Software
without restriction, including without limitation the rights to use, copy, modify, merge,
publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons
to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or
substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE
FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR
OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
DEALINGS IN THE SOFTWARE.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using LNPcmd;
using NLua;

namespace SharpLNP
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form{
		
		int TMP_MAXLED = 0;
		
		Mutex mutex = null;
		const string MutexName = "Global\\CorsairLinkReadWriteGuardMutex";
		
		static BindingList<Structs.Device> devices = new BindingList<Structs.Device>();
		BindingList<Structs.LEDGroup> ledgroup = new BindingList<Structs.LEDGroup>();
		
		static Thread CLupdateThread = null;
		Lua LuaScript = null;
		Thread LUAThread = null;
		Thread AnimFrameThread = null;
		Thread audioUIThread = null;
		AudioCapture audiocapture = null;
		float[] audio_value = new float[2];
		float[] audio_vubar = new float[2];
		float audio_capture_vol = 1f;
		int faderspeed = 20;
		int framedelay = 100;
		static bool allblack = false;

		//led group audio effect 
		//device/channel/ledgroup
		List<List<Structs.LEDGroup[]>> ledgroupAudioEfxType = new List<List<Structs.LEDGroup[]>>();
		
		Random random = new Random();
		
		BindingList<Structs.DataItem> dgv_device = new BindingList<Structs.DataItem>(){new Structs.DataItem(){index=-1,Name="-"}};
		BindingList<Structs.DataItem> dgv_chan = new BindingList<Structs.DataItem>(){new Structs.DataItem(){index=-1,Name="-"}, new Structs.DataItem(){index=0,Name="1"}, new Structs.DataItem(){index=1,Name="2"}};
		
		List<Structs.Pattern> lst_pattern = new List<Structs.Pattern>();
		
		static bool luascriptrun = false;
		bool play=false;
		int anim_curpos = 0;
		//int anim_playpos = 0;
		int anim_maxpos = 0;
		int[] customcolor = new int[0];
		Color clipboard_color = Color.Black;
		Color[] clipboard_frame = null;
		
		string patternlist_file = "";
		
		public MainForm(){
			Console.WriteLine("List available LNP...");
			Dictionary<string,string> lnps = LNP.GetListOfLNP();
			foreach(string devicepath in lnps.Keys){
				Console.WriteLine(devicepath+" -> " + lnps[devicepath]);
				try{
					var lnp = LNP.Connect(devicepath);
					devices.Add(new Structs.Device(lnp));
				}catch(Exception e){
					Console.WriteLine(e);
					MessageBox.Show(e.ToString(),"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			
			//add Ungroup data
			ledgroup.Add(
				new Structs.LEDGroup(){
					id = -1,
					device = -1,
					channel = -1,
					startindex = -1,
					type = Structs.LEDGroupTypes.None,
				}
			);
			
			

			InitializeComponent();
			
			typeof(DataGridView).InvokeMember(
				"DoubleBuffered",BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,null,dgv_anim,new object[] { true });
			
			
			
			lstLNP.DataSource = devices;
			lst_audio_ledgroup.DataSource = ledgroup;
			
			
			
			ledgroup.ListChanged += delegate {
				//reset to ungroup first
				
				
				foreach(var dev in ledgroupAudioEfxType){
				
					foreach(var ch in dev){
						
						for(int led=0;led<ch.Length;led++){
							ch[led] = ledgroup[0];
						}
					}
				}
				
				
				foreach(var group in ledgroup){
					if(group.device!=-1 && group.channel != -1 && group.startindex != -1){
						if(group.device<ledgroupAudioEfxType.Count){//device
							if(group.channel<ledgroupAudioEfxType[group.device].Count){//channel
								for(int i=0;i<group.type.ledcount;i++){
									if((group.startindex + i) < ledgroupAudioEfxType[group.device][group.channel].Length){
										ledgroupAudioEfxType[group.device][group.channel][group.startindex + i] = group;
									}
								}
							}
						}
					}
				}
			};
			

			//Update LED Grouping Form Tab
			for(int dev=0;dev<devices.Count;dev++){
				Panel pnl = new Panel();
				pnl.Name = "DEV_"+devices[dev].LNPDevice.GetSerial();
				pnl.BorderStyle = BorderStyle.Fixed3D;
				pnl.Size = new Size(pnl_ledgroup.Width,300);
				pnl.Location = new Point(0,300*dev);
				pnl.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
				pnl.AutoScroll = true;
				
				for(int i=0;i<Program.ChannelCount;i++){
					
					Panel pnlch = new Panel();
					pnlch.Name = "DEV_"+devices[dev].LNPDevice.GetSerial()+":CH_"+i;
					pnlch.BorderStyle = BorderStyle.FixedSingle;
					pnlch.Size = new Size(pnl.Width,165);
					pnlch.Location = new Point(0,165*i);
					pnlch.AutoScroll=true;
					pnlch.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;

					pnlch.ControlRemoved += delegate(object sender, ControlEventArgs e) {
						if(e.Control is LED){
							LED led = (LED)e.Control;
							if(led.Tag!=null){
								ledgroup.Remove((Structs.LEDGroup)led.Tag);
							}
						}
						
						int ledindex = 0;
						for(int c=0;c<pnlch.Controls.Count;c++){
							Control control = pnlch.Controls[c];
							control.Location = new Point(c*150,0);
							if(control is LED){
								LED led = (LED)control;
								
								led.StartIndex = ledindex;
								int ledcount = led.LEDColor.Length;
								if(led.Tag!=null){
									Structs.LEDGroup lg = (Structs.LEDGroup) led.Tag;
									lg.startindex = led.StartIndex;
									
								}
								
								led.Text = "LED "+(led.StartIndex+1);
								if(ledcount>1){
									led.Text += " -> "+(led.StartIndex+ledcount);
								}
								ledindex += ledcount;
							}
							
						}
						ledgroup.ResetBindings();
						AnimUpdatePos();
					};
					pnl.Controls.Add(pnlch);
				}
				
				pnl_ledgroup.Controls.Add(pnl);
			}
			
			//initialize LED's group audio effect type and make them belong to ungroup led
			for(int dev=0;dev<devices.Count;dev++){
				var devlst = new List<Structs.LEDGroup[]>();
				for(int ch=0;ch<Program.ChannelCount;ch++){
					var chlst = new Structs.LEDGroup[devices[dev].LEDCount[ch]];
					for(int led=0;led<devices[dev].LEDCount[ch];led++){
						chlst[led] = ledgroup[0];
					}
					
					devlst.Add(chlst);
				}
				ledgroupAudioEfxType.Add(devlst);
			}

			//list all available Audio Device
			var list = new BindingList<AudioCapture.AudioDevice>(AudioCapture.ListDevice());
			
			cb_audio_list.DataSource = list;
			cb_audio_list.Tag = list;
			if(cb_audio_list.Items.Count>0)cb_audio_list.SelectedIndex = 0;

			
			
			
			var dgvc = (DataGridViewComboBoxColumn)dgv_patlist.Columns[1];
			for(int i=0;i<devices.Count;i++){
				dgv_device.Add(new Structs.DataItem(){index=i,Name=devices[i].ToString()});
			}
			dgvc.DataSource = dgv_device;
			
			dgvc = (DataGridViewComboBoxColumn)dgv_patlist.Columns[2];
			dgvc.DataSource = dgv_chan;
			RefreshPatternViewer(-1);

		}
		
		void MainFormLoad(object sender, EventArgs e){
			LoadConfig();
		}
		
		void MainFormFormClosing(object sender, FormClosingEventArgs e){
			if(CLupdateThread!=null){
				if(MessageBox.Show("CL is running, are you sure you want to exit program?", "Exit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.No){
					e.Cancel = true;
					return;
				}
			}
			
			SaveConfig();
			
			PatternFile.SaveToFile(AppDomain.CurrentDomain.BaseDirectory+"/default.pat", new List<Structs.Device>(devices), lst_pattern, tb_anim_delay.Value);
			StopCLThread();
			
			
			notifyIcon.Dispose();
			try{
				if(mutex!=null){
					mutex.ReleaseMutex();
					mutex.Dispose();
				}
			}catch(Exception){}
		}

		void MainFormSizeChanged(object sender, EventArgs e){
			if(WindowState == FormWindowState.Minimized){
				Hide();
			}
		}
		
		void RecalculateLEDSize(){
			
			for(int dev=0;dev<devices.Count;dev++){
				
				for(int i=0;i<Program.ChannelCount;i++){
					Control[] c = pnl_ledgroup.Controls.Find("DEV_"+devices[dev].LNPDevice.GetSerial()+":CH_"+i, true);
					if(c.Length>0){
						c[0].Controls.Clear();
					}
				}
			}
			
			int maxled = 0;
			
			for(int dev=0;dev<devices.Count;dev++){
				var devlst = new List<Structs.LEDGroup[]>();
				for(int ch=0;ch<Program.ChannelCount;ch++){
					var chlst = new Structs.LEDGroup[devices[dev].LEDCount[ch]];
					maxled = Math.Max(devices[dev].LEDCount[ch],maxled);
					for(int led=0;led<devices[dev].LEDCount[ch];led++){
						chlst[led] = ledgroup[0];
					}
					
					devlst.Add(chlst);
				}
				ledgroupAudioEfxType.Add(devlst);
			}
			
			//Resize pattern track led count
			foreach(var pat in lst_pattern){
				for(int f=0;f<pat.led.Count;f++){
					if(maxled>pat.led[f].Length){
						
						Color[] newsize = new Color[maxled];
						
						Array.Copy(pat.led[f],newsize,pat.led[f].Length);
						pat.led[f] = newsize;
					}else if(maxled<pat.led[f].Length){
						Color[] newsize = new Color[maxled];
						Array.Copy(pat.led[f],newsize,maxled);
						pat.led[f] = newsize;
					}
				}
			}
			
			if(dgv_patlist.SelectedCells.Count>0){
				RefreshPatternViewer(dgv_patlist.SelectedCells[0].RowIndex);
			}
			
		}
		
		void Btn_colorClick(object sender, EventArgs e){
			
			if(CLupdateThread!=null){
				
				using(var cd = new ColorDialog()){
					cd.AllowFullOpen=true;
					cd.FullOpen = true;
					cd.CustomColors = customcolor;
					if(cd.ShowDialog()==DialogResult.OK){
						if(CLupdateThread.ThreadState == ThreadState.WaitSleepJoin){
							foreach(var dev in devices){
								for(int i=0;i<Program.ChannelCount;i++){
									Color[] c = new Color[dev.LEDCount[i]];
									for(int l=0;l<c.Length;l++){
										c[l] = cd.Color;
									}
									dev.LNPDevice.SetLEDColorRange(i,0,c);
								}
							}
							CLupdateThread.Interrupt();
						}
						
						
					}
					
					customcolor = cd.CustomColors;
					
				}
			
				
			}
		}
		
		void btn_RunClick(object sender, EventArgs e){
			if(CLupdateThread==null){
				
				if(devices.Count==0){
					MessageBox.Show("No LNP devices found! Please insert LNP device!", "No Lighting Node Pro", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
				
				mutex = AcquireMutexLock();
				if(mutex == null){
					return;
				}

				
				CLupdateThread = new Thread(new ThreadStart(
					delegate{
						
						
						bool running = true;
						float[] audio_vu_stereo = new float[2];
						float audio_vu_mono = 0;
						int[] vucolorslice = new int[3];
						float fader = 1.0f;
						float r = 0;
						float g = 0;
						float b = 0;
						
						var resetEvent = new ManualResetEvent[devices.Count];
						
						
						
						//reinitializing LNP device and channel
						foreach(Structs.Device dev in devices){
							for(int ch=0;ch<Program.ChannelCount;ch++){
								dev.EmptyLEDColor(ch);
								dev.LNPDevice.ResetChannel(ch);
								dev.LNPDevice.EnterManualMode(ch);
								dev.LNPDevice.SendACK();
							}
						}
						
						allblack = false;
						long starttick = 0;
						long endtick = 0;
						long deltatick = 0;
						int sleeptick = 0;
						
						
						
						while(running){
							try{
								GC.KeepAlive(mutex);
								if(play || audiocapture!=null || luascriptrun){
									allblack=false;
								}
								
								if(allblack){
									
									if(InvokeRequired){
										BeginInvoke((MethodInvoker)delegate{ lbl_currentRate.Text = "Idle"; });
									}
									for(int i=0;i<devices.Count;i++){
										resetEvent[i] = new ManualResetEvent(false);
										ThreadPool.QueueUserWorkItem(
											x => {
												int index = (int)x;
												devices[index].LNPDevice.SendACK();
												resetEvent[index].Set();
											},i
										);
									}
									WaitHandle.WaitAll(resetEvent);
									
									Thread.Sleep(1000);
									
								}else{
									starttick = DateTime.Now.Ticks/10000;
									if(audiocapture!=null){
										for(int i=0;i<audio_value.Length;i++){
											
											
											float newval = Math.Abs(audio_value[i]*(audio_capture_vol));
											//for stereo
											if(newval>audio_vu_stereo[i]){
												audio_vu_stereo[i] = newval;
											}else{
												audio_vu_stereo[i] -= 0.05f;
												if(audio_vu_stereo[i]<0) audio_vu_stereo[i] = 0;
											}
											vucolorslice[i] = (int)(audio_vu_stereo[i]*3f);
											if(vucolorslice[i]<0)vucolorslice[i] = 0;
											if(vucolorslice[i]>3)vucolorslice[i] = 3;
											
											//for monoraul
											if(newval>audio_vu_mono){
												audio_vu_mono = newval;
											}else{
												audio_vu_mono -= 0.05f;
            									if(audio_vu_mono<0)audio_vu_mono = 0;
											}
											
											
											
											audio_value[i] = 0;
										}
										
										vucolorslice[2] = (int)(audio_vu_mono*3f);
										if(vucolorslice[2]<0)vucolorslice[2] = 0;
										if(vucolorslice[2]>3)vucolorslice[2] = 3;
										
										
										if(!play){
											//for(int dev=0;dev<devices.Count;dev++){
											foreach(Structs.Device dev in devices){
												for(int ch=0;ch<Program.ChannelCount;ch++){
													Color[] leds = dev.GetChannelLED(ch);
													for(int l=0;l<leds.Length;l++){
														var group = ledgroupAudioEfxType[devices.IndexOf(dev)][ch][l];
														if(group.audioStyle == 1 || group.audioStyle == 2){//audio loudness or with animation only
															Color c1 = leds[l];
															fader = 1.0f;
															fader += 0.05f * faderspeed;
															r = (c1.R/fader);
															g = (c1.G/fader);
															b = (c1.B/fader);
															
															switch(group.audioChannel){
																case 1:
																	r += (group.audioStyleEfxColor[vucolorslice[0]].R*audio_vu_stereo[0]);
																	g += (group.audioStyleEfxColor[vucolorslice[0]].G*audio_vu_stereo[0]);
																	b += (group.audioStyleEfxColor[vucolorslice[0]].B*audio_vu_stereo[0]);
																	break;
																case 2:
																	r += (group.audioStyleEfxColor[vucolorslice[1]].R*audio_vu_stereo[1]);
																	g += (group.audioStyleEfxColor[vucolorslice[1]].G*audio_vu_stereo[1]);
																	b += (group.audioStyleEfxColor[vucolorslice[1]].B*audio_vu_stereo[1]);
																	break;
																default:
																	r += (group.audioStyleEfxColor[vucolorslice[2]].R*audio_vu_mono);
																	g += (group.audioStyleEfxColor[vucolorslice[2]].G*audio_vu_mono);
																	b += (group.audioStyleEfxColor[vucolorslice[2]].B*audio_vu_mono);
																	break;
																	
															}
															
															
															if(r>255)r=255;
															if(r<0)r=0;
															
															if(g>255)g=255;
															if(g<0)g=0;
															
															if(b>255)b=255;
															if(b<0)b=0;
															leds[l] = Color.FromArgb((int)r,(int)g,(int)b);
														}

													}
												}
												
											}
										}//else{//for VU meter only
										for(int grp=0;grp<ledgroup.Count;grp++){
											
											var group = ledgroup[grp];
											if(group.device != -1 && group.channel !=-1 && group.startindex != -1){//not ungroup LED
												if(group.audioStyle == 3){//VU meter audio style
													Color[] led = devices[group.device].GetChannelLED(group.channel);
													int vu = 0;
													if(group.type.Equals(Structs.LEDGroupTypes.HD)){
														if(audio_vu_mono>0){
															switch(group.audioChannel){
																case 1:
																	vu = (int)(10f*(audio_vu_stereo[0]));
																	break;
																case 2:
																	vu = (int)(10f*(audio_vu_stereo[1]));
																	break;
																default:
																	vu = (int)(10f*(audio_vu_mono));
																	break;
															}
															if(vu>10)vu=10;
															for(int i=0;i<=vu;i++){
																//remapping HD led
																if(i>=0 && i<=3){
																	led[(group.startindex+6)-i] = group.audioStyleEfxColor[0];
																}else if(i>=4 && i<=5){
																	led[(group.startindex+6)-i] = group.audioStyleEfxColor[1];
																}else if(i==6){
																	led[(group.startindex)] = group.audioStyleEfxColor[2];
																}else if(i==7){
																	led[(group.startindex+11)] = group.audioStyleEfxColor[2];
																}else if(i>=8){
																	led[(group.startindex+11)-i] = group.audioStyleEfxColor[3];
																}
															}
														}
														
													}else if(group.type.Equals(Structs.LEDGroupTypes.LL)){
														if(audio_vu_mono>0){
															switch(group.audioChannel){
																case 1:
																	vu = (int)(11f*(audio_vu_stereo[0]));
																	break;
																case 2:
																	vu = (int)(11f*(audio_vu_stereo[1]));
																	break;
																default:
																	vu = (int)(11f*(audio_vu_mono));
																	break;
															}
															if(vu>11)vu=11;
															for(int i=0;i<=vu;i++){
																//remapping LL led
																if(i>=0 && i<=3){
																	led[(group.startindex+7)-i] = group.audioStyleEfxColor[0];
																}else if(i>=4 && i<=6){
																	led[(group.startindex+15)-(i-4)] = group.audioStyleEfxColor[1];
																}else if(i>=7 && i<=10){
																	led[(group.startindex+15)-(i-4)] = group.audioStyleEfxColor[2];
																}else if(i>=11){
																	led[group.startindex] = group.audioStyleEfxColor[3];
																	led[group.startindex+1] = group.audioStyleEfxColor[3];
																	led[group.startindex+2] = group.audioStyleEfxColor[3];
																	led[group.startindex+3] = group.audioStyleEfxColor[3];
																}
																
																
															}
														}
													}else if(group.type.Equals(Structs.LEDGroupTypes.LEDPro)){
														if(audio_vu_mono>0){
															switch(group.audioChannel){
																case 1:
																	vu = (int)(10f*(audio_vu_stereo[0]));
																	break;
																case 2:
																	vu = (int)(10f*(audio_vu_stereo[1]));
																	break;
																default:
																	vu = (int)(10f*(audio_vu_mono));
																	break;
															}
															if(vu>10)vu=10;
															for(int i=0;i<=vu;i++){
																//remapping HD led
																if(i>=0 && i<=3){
																	led[group.startindex+i] = group.audioStyleEfxColor[0];
																}else if(i>=4 && i<=5){
																	led[group.startindex+i] = group.audioStyleEfxColor[1];
																}else if(i>=6 && i<=7){
																	led[group.startindex+i] = group.audioStyleEfxColor[2];
																}else if(i>=8){
																	led[group.startindex+i] = group.audioStyleEfxColor[3];
																}
															}
														}
														
													}
												}else if(group.audioStyle == 4){//VU meter mix
													Color[] led = devices[group.device].GetChannelLED(group.channel);
													int vul = 0, vur = 0;;
													if(group.type.Equals(Structs.LEDGroupTypes.HD)){
														if(audio_vu_mono>0){
															switch(group.audioChannel){
																case 1:
																	vul = (int)(5f*(audio_vu_stereo[0]));
																	vur = vul;
																	break;
																case 2:
																	vul = (int)(5f*(audio_vu_stereo[1]));
																	vur = vul;
																	break;
																default:
																	vul = (int)(5f*(audio_vu_stereo[0]));
																	vur = (int)(5f*(audio_vu_stereo[1]));
																	break;
															}
															
															
															if(vul>5)vul=5;
															if(vur>5)vur=5;
															for(int i=0;i<=vul;i++){
																if(i>=0 && i<=2){
																	led[(group.startindex+7)-i] = group.audioStyleEfxColor[0];
																}else if(i==3){
																	led[group.startindex+4] = group.audioStyleEfxColor[1];
																}else if(i==4){
																	led[group.startindex+3] = group.audioStyleEfxColor[2];
																}else if(i>=5){
																	led[group.startindex+2] = group.audioStyleEfxColor[3];
																}
															}
															for(int i=0;i<=vur;i++){
																if(i>=0 && i<=2){
																	led[(group.startindex+8)+i] = group.audioStyleEfxColor[0];
																}else if(i==3){
																	led[group.startindex+11] = group.audioStyleEfxColor[1];
																}else if(i==4){
																	led[group.startindex] = group.audioStyleEfxColor[2];
																}else if(i>=5){
																	led[group.startindex+1] = group.audioStyleEfxColor[3];
																}
															}
															
															
														}
														
													}else if(group.type.Equals(Structs.LEDGroupTypes.LL)){
														if(audio_vu_mono>0){
															switch(group.audioChannel){
																case 1:
																	vul = (int)(5f*(audio_vu_stereo[0]));
																	vur = vul;
																	break;
																case 2:
																	vul = (int)(5f*(audio_vu_stereo[1]));
																	vur = vul;
																	break;
																default:
																	vul = (int)(5f*(audio_vu_stereo[0]));
																	vur = (int)(5f*(audio_vu_stereo[1]));
																	break;
															}
															
															if(vul>5)vul=5;
															if(vur>5)vur=5;
															for(int i=0;i<=vul;i++){
																if(i>=0 && i<=2){
																	led[(group.startindex+7)-i] = group.audioStyleEfxColor[0];
																}else if(i==3){
																	led[group.startindex+4] = group.audioStyleEfxColor[1];
																}else if(i==4){
																	led[group.startindex+15] = group.audioStyleEfxColor[2];
																}else if(i>=5){
																	led[group.startindex+1] = group.audioStyleEfxColor[3];
																}
															}
															for(int i=0;i<=vur;i++){
																if(i>=0 && i<=2){
																	led[(group.startindex+9)+i] = group.audioStyleEfxColor[0];
																}else if(i==3){
																	led[group.startindex+12] = group.audioStyleEfxColor[1];
																}else if(i==4){
																	led[group.startindex+13] = group.audioStyleEfxColor[2];
																}else if(i>=5){
																	led[group.startindex+3] = group.audioStyleEfxColor[3];
																}
															}
														}
													}else if(group.type.Equals(Structs.LEDGroupTypes.LEDPro)){
														if(audio_vu_mono>0){
															switch(group.audioChannel){
																case 1:
																	vul = (int)(4f*(audio_vu_stereo[0]));
																	vur = vul;
																	break;
																case 2:
																	vul = (int)(4f*(audio_vu_stereo[1]));
																	vur = vul;
																	break;
																default:
																	vul = (int)(4f*(audio_vu_stereo[0]));
																	vur = (int)(4f*(audio_vu_stereo[1]));
																	break;
															}
															
															if(vul>4)vul=4;
															if(vur>4)vur=4;
															for(int i=0;i<=vul;i++){
																if(i>=0 && i<=1){
																	led[(group.startindex+4)-i] = group.audioStyleEfxColor[0];
																}else if(i==2){
																	led[group.startindex+2] = group.audioStyleEfxColor[1];
																}else if(i==3){
																	led[group.startindex+1] = group.audioStyleEfxColor[2];
																}else if(i>=4){
																	led[group.startindex] = group.audioStyleEfxColor[3];
																}
															}
															for(int i=0;i<=vur;i++){
																if(i>=0 && i<=1){
																	led[(group.startindex+5)+i] = group.audioStyleEfxColor[0];
																}else if(i==2){
																	led[group.startindex+7] = group.audioStyleEfxColor[1];
																}else if(i==3){
																	led[group.startindex+8] = group.audioStyleEfxColor[2];
																}else if(i>=4){
																	led[group.startindex+9] = group.audioStyleEfxColor[3];
																}
															}
															
														}
														
													}
												}
											}
										}
										
										
									}
									
									
									if(play){
										//foreach(Structs.Device dev in devices){
										for(int dev=0;dev<devices.Count;dev++){
											for(int ch=0;ch<Program.ChannelCount;ch++){
												
												Color[] leds = devices[dev].GetChannelLED(ch);
												for(int l=0;l<leds.Length;l++){
													Color c1 = leds[l];
													fader = 1.0f;
													fader += 0.05f * faderspeed;
													r = (c1.R/fader);
													g = (c1.G/fader);
													b = (c1.B/fader);
													
													if(audiocapture==null){
														if(anim_maxpos>0){
															Structs.Pattern pattern = null;
															foreach(var pat in lst_pattern){
																if(pat.device == dev && pat.channel == ch){
																	pattern = pat;
																	break;
																}
															}
															if(pattern!=null){
																Color c2 = pattern.led[anim_curpos][l];
																r += (c2.R);
																g += (c2.G);
																b += (c2.B);
															}
														}
														if(r<0)r=0;
														if(r>255)r=255;
														if(g<0)g=0;
														if(g>255)g=255;
														if(b<0)b=0;
														if(b>255)b=255;
														leds[l] = Color.FromArgb((int)r,(int)g,(int)b);
														
													}else{//Audio Capture mode
														var group = ledgroupAudioEfxType[dev][ch][l];
														
														if(group.audioStyle == 1){//audio loudness only
															switch(group.audioChannel){
																case 1:
																	r += (group.audioStyleEfxColor[vucolorslice[0]].R*audio_vu_stereo[0]);
																	g += (group.audioStyleEfxColor[vucolorslice[0]].G*audio_vu_stereo[0]);
																	b += (group.audioStyleEfxColor[vucolorslice[0]].B*audio_vu_stereo[0]);
																	break;
																case 2:
																	r += (group.audioStyleEfxColor[vucolorslice[1]].R*audio_vu_stereo[1]);
																	g += (group.audioStyleEfxColor[vucolorslice[1]].G*audio_vu_stereo[1]);
																	b += (group.audioStyleEfxColor[vucolorslice[1]].B*audio_vu_stereo[1]);
																	break;
																default:
																	r += (group.audioStyleEfxColor[vucolorslice[2]].R*audio_vu_mono);
																	g += (group.audioStyleEfxColor[vucolorslice[2]].G*audio_vu_mono);
																	b += (group.audioStyleEfxColor[vucolorslice[2]].B*audio_vu_mono);
																	break;
															}
															
														}else if(group.audioStyle == 2){//audio loudness + animation only
															if(anim_maxpos>0){
																Structs.Pattern pattern = null;
																foreach(var pat in lst_pattern){
																	if(pat.device == dev && pat.channel == ch){
																		pattern = pat;
																		break;
																	}
																}
																if(pattern!=null){
																	Color c2 = pattern.led[anim_curpos][l];
																	switch(group.audioChannel){
																		case 1:
																			r += (c2.R*audio_vu_stereo[0]);
																			g += (c2.G*audio_vu_stereo[0]);
																			b += (c2.B*audio_vu_stereo[0]);
																			break;
																		case 2:
																			r += (c2.R*audio_vu_stereo[1]);
																			g += (c2.G*audio_vu_stereo[1]);
																			b += (c2.B*audio_vu_stereo[1]);
																			break;
																		default:
																			r += (c2.R*audio_vu_mono);
																			g += (c2.G*audio_vu_mono);
																			b += (c2.B*audio_vu_mono);
																			break;
																	}
																}
																
															}else{
																switch(group.audioChannel){
																	case 1:
																		r += (group.audioStyleEfxColor[vucolorslice[0]].R*audio_vu_stereo[0]);
																		g += (group.audioStyleEfxColor[vucolorslice[0]].G*audio_vu_stereo[0]);
																		b += (group.audioStyleEfxColor[vucolorslice[0]].B*audio_vu_stereo[0]);
																		break;
																	case 2:
																		r += (group.audioStyleEfxColor[vucolorslice[1]].R*audio_vu_stereo[1]);
																		g += (group.audioStyleEfxColor[vucolorslice[1]].G*audio_vu_stereo[1]);
																		b += (group.audioStyleEfxColor[vucolorslice[1]].B*audio_vu_stereo[1]);
																		break;
																	default:
																		r += (group.audioStyleEfxColor[vucolorslice[2]].R*audio_vu_mono);
																		g += (group.audioStyleEfxColor[vucolorslice[2]].G*audio_vu_mono);
																		b += (group.audioStyleEfxColor[vucolorslice[2]].B*audio_vu_mono);
																		break;
																}
															}
															
														}
														
														
														if(group.audioStyle!=3){//VU meter doesn't need any update
															if(r<0)r=0;
															if(r>255)r=255;
															if(g<0)g=0;
															if(g>255)g=255;
															if(b<0)b=0;
															if(b>255)b=255;
															leds[l] = Color.FromArgb((int)r,(int)g,(int)b);
														}
													}
													
												}
											}
										}
									
										/*
										if(chk_reverse.Checked){
											anim_curpos--;
										}else{
											anim_curpos++;
										}
										if(anim_curpos<0){
											anim_curpos = anim_maxpos-1;
										}
										if(anim_curpos>=anim_maxpos){
											anim_curpos = 0;
										}
										if(InvokeRequired){
											BeginInvoke((MethodInvoker)delegate{AnimUpdatePos();});
										}
										*/
									}
									
									if(chk_ledcurrent.Checked){
										if(InvokeRequired){
											BeginInvoke((MethodInvoker)delegate{ UpdateVisualLEDPosition(-1); });
										}
									}
									
									/*
									foreach(Structs.Device dev in devices){
										
										for(int ch=0;ch<Program.ChannelCount;ch++){
											dev.LNPDevice.SetLEDColorRange(ch,0,dev.GetChannelLED(ch));
										}
										dev.LNPDevice.SendACK();
									}
									*/
									
									for(int i=0;i<devices.Count;i++){
										resetEvent[i] = new ManualResetEvent(false);
										ThreadPool.QueueUserWorkItem(
											x => {
												int index = (int)x;
												for(int ch=0;ch<Program.ChannelCount;ch++){
													devices[index].LNPDevice.SetLEDColorRange(ch,0,devices[index].GetChannelLED(ch));
												}
												devices[index].LNPDevice.SendACK();
												resetEvent[index].Set();
											},i
										);
									}
									WaitHandle.WaitAll(resetEvent);

									allblack = true;
									foreach(Structs.Device dev in devices){
										for(int ch =0;ch<Program.ChannelCount;ch++){
											Color[] leds = dev.GetChannelLED(ch);
											for(int l=0;l<leds.Length;l++){
												Color c = leds[l];
												if(c.R != 0 || c.G != 0 || c.B != 0){
													fader = 1.0f;
													fader += 0.05f * faderspeed;
													r = (c.R/fader);
													g = (c.G/fader);
													b = (c.B/fader);
													
													if(r<0)r=0;
													if(g<0)g=0;
													if(b<0)b=0;
													leds[l] = Color.FromArgb((int)r,(int)g,(int)b);
													allblack = false;
												}
											}
										}
									}
									
									
									//calculate refresh rate time
									endtick = DateTime.Now.Ticks/10000;
									deltatick = endtick - starttick;
									if(InvokeRequired){
										BeginInvoke((MethodInvoker)delegate{ lbl_currentRate.Text = deltatick+"ms"; });
									}
									//Console.WriteLine("Update Time: "+deltatick);
									if(deltatick<=nm_refresh.Value){//if update time is less than target refresh rate
										Thread.Sleep((int)nm_refresh.Value);
									}else{//variable sleep time if update time took too long
										sleeptick = (int)(nm_refresh.Value-deltatick+nm_refresh.Value);
										if(sleeptick<0)sleeptick = 0;
										Thread.Sleep(sleeptick);
									}
								}
								
								
								
							}catch(ThreadAbortException){
								running = false;
								
								Console.WriteLine("Stopping CL Thread");
								foreach(Structs.Device dev in devices){
									for(int ch=0;ch<Program.ChannelCount;ch++){
										dev.EmptyLEDColor(ch);
										dev.LNPDevice.ResetChannel(ch);
										dev.LNPDevice.ConfigDemoMode(ch, 0, 0, false);
										dev.LNPDevice.SetDemoOnOff(ch, false);
										dev.LNPDevice.EnterDemoMode(ch);
									}
									dev.LNPDevice.SendACK();
								}
								
								if(InvokeRequired){
									BeginInvoke((MethodInvoker)delegate{ lbl_currentRate.Text = "Off"; });
								}
								
								
							}catch(ThreadInterruptedException){
								Console.WriteLine("interrupt");
								//for(int i=0;i<resetEvent.Length;i++){
								//	resetEvent[i] = new ManualResetEvent(false);
								//}
							}
						}
						
					}
				));
				CLupdateThread.Start();
				btn_devconfig.Enabled = false;
				btn_run.Text = "Stop";
			}else{
				StopCLThread();
			}
		}
		
		void StopCLThread(){
			if(CLupdateThread!=null){
				if(CLupdateThread.IsAlive){
					
					
					
					if(AnimFrameThread!=null){
						AnimFrameThread.Abort();
						AnimFrameThread.Join();
						AnimFrameThread = null;
					}
					//play = false;
					StopAudioCapture();
					CLupdateThread.Abort();
					CLupdateThread.Join();
					CLupdateThread = null;
					
					if(luascriptrun){
						Ts_btn_runluaClick(null,null);
					}
					
					try{
						if(mutex!=null){
							Console.WriteLine("Release Mutex");
							mutex.ReleaseMutex();
							mutex.Dispose();
						}
					}catch(Exception){}
					btn_devconfig.Enabled = true;
					btn_run.Text = "Run";
				}
			}
		}
		
		void Btn_devconfigClick(object sender, EventArgs e){
			if(lstLNP.SelectedIndex==-1){
				MessageBox.Show("Select LNP device to config LED", "LNP Device Config", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			var dev = (Structs.Device)lstLNP.SelectedItem;
			using(var frm = new frm_config(dev.LEDCount[0],dev.LEDCount[1])){
				if(frm.ShowDialog() == DialogResult.OK){
					dev.LEDCount[0] = frm.Channel1;
					dev.LEDCount[1] = frm.Channel2;
					RecalculateLEDSize();
				}
			}
		}
		
		void Tb_fadespeedValueChanged(object sender, EventArgs e){
			faderspeed = tb_fadespeed.Value;
		}
		
		void Btn_saveconfigClick(object sender, EventArgs e){
			SaveConfig();
		}
		
		void RefreshPatternViewer(int index){
			
			split.Panel2.Enabled = false;
			if(index==-1){
				dgv_anim.Rows.Clear();
				dgv_anim.Columns.Clear();
			}
			
			if(index<0 || index>=lst_pattern.Count){
				return;
			}
			
			split.Panel2.Enabled = true;
			
			
			var pat = lst_pattern[index];
			
			int maxled = TMP_MAXLED;
			if(pat.device == -1 || pat.channel == -1){
				foreach(var dev in devices){
					for(int i=0;i<dev.LEDCount.Length;i++){
						maxled = Math.Max(dev.LEDCount[i],maxled);
					}
				}
			}else{
				maxled = devices[pat.device].LEDCount[pat.channel];
			}
			
			dgv_anim.Rows.Clear();
			//dgv_anim.Columns.Clear();
			
			
			int colcount = dgv_anim.Columns.Count;
			
			if(colcount<pat.led.Count){
				//colcount--;
				//if(colcount<0)colcount = 0;
				for(int i=colcount;i<pat.led.Count;i++){//frame
					DataGridViewTextBoxColumn dgvc = new DataGridViewTextBoxColumn();
					dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
					dgvc.ReadOnly = true;
					dgvc.DefaultCellStyle.BackColor = Color.Black;
					dgvc.HeaderText = ""+(i+1);
					dgvc.Resizable = DataGridViewTriState.False;
					dgvc.ReadOnly = true;
					dgvc.Width=30;
					dgv_anim.Columns.Add(dgvc);
				}
				
			}else{
				while(dgv_anim.Columns.Count>pat.led.Count){
					dgv_anim.Columns.RemoveAt(pat.led.Count-1);
				}
				
				for(int i=0;i<dgv_anim.Columns.Count;i++){
					dgv_anim.Columns[i].HeaderText = ""+(i+1);
				}
			}
			
			
			
			if(dgv_anim.Columns.Count>0){
				
				if(dgv_anim.Rows.Count<maxled){
					for(int i=dgv_anim.Rows.Count;i<maxled;i++){
						DataGridViewRow dgvr = new DataGridViewRow();
						dgvr.HeaderCell.Value = ""+(i+1);
						dgv_anim.Rows.Add(dgvr);
					}
				}else{
					while(dgv_anim.Rows.Count>maxled){
						dgv_anim.Rows.RemoveAt(maxled-1);
					}
					for(int i=0;i<dgv_anim.Rows.Count;i++){
						dgv_anim.Rows[i].HeaderCell.Value = ""+(i+1);
					}
				}
				
				
				
				
				for(int i=0;i<dgv_anim.Columns.Count;i++){
					for(int j=0;j<maxled;j++){
						dgv_anim[i,j].Style.BackColor = pat.led[i][j];
					}
				}
			}
		}
		
		int GetAnimMaxPos(){
			int maxpos = 0;
			foreach(var pat in lst_pattern){
				maxpos = Math.Max(pat.led.Count,maxpos);
			}
			if(anim_curpos>=maxpos){
				anim_curpos=maxpos-1;
			}
			if(anim_curpos<0)anim_curpos=0;
			return maxpos;
		}
		
		void Btn_anim_addClick(object sender, EventArgs e){
			if(play){
				MessageBox.Show("Is Playing now!");
				return;
			}
			

			int maxled = TMP_MAXLED;
			foreach(var dev in devices){
				for(int i=0;i<dev.LEDCount.Length;i++){
					maxled = Math.Max(dev.LEDCount[i],maxled);
				}
			}
			
			foreach(var pat in lst_pattern){
				Color[] c = new Color[maxled];
				for(int i=0;i<c.Length;i++){
					c[i] = Color.Black;
				}
				pat.led.Add(c);
			}
			
			if(dgv_patlist.SelectedCells.Count>0){
				int selectedRow = 0;
				if(dgv_anim.SelectedCells.Count>0){
					selectedRow = dgv_anim.SelectedCells[0].RowIndex;
				}
				RefreshPatternViewer(dgv_patlist.SelectedCells[0].RowIndex);
				dgv_anim.ClearSelection();
				dgv_anim[dgv_anim.Columns.Count-1, selectedRow].Selected = true;
				dgv_anim.FirstDisplayedScrollingColumnIndex = dgv_anim.Columns.Count-1;
				dgv_anim.FirstDisplayedScrollingRowIndex = selectedRow;
				
			}
			
			AnimUpdatePos();
		}
		
		
		
		void Btn_anim_delClick(object sender, EventArgs e){
			if(play){
				MessageBox.Show("Is Playing now!");
				return;
			}
			
			
			if(anim_curpos>=0 && anim_curpos<anim_maxpos){
				int lastpos = anim_curpos;
				int selectedRow = 0;
				if(dgv_anim.SelectedCells.Count>0){
					selectedRow = dgv_anim.SelectedCells[0].RowIndex;
				}
				
				foreach(var pat in lst_pattern){
					pat.led.RemoveAt(anim_curpos);
				}
				RefreshPatternViewer(dgv_patlist.SelectedCells[0].RowIndex);
				//if(dgv_anim
				AnimUpdatePos();
				dgv_anim.ClearSelection();
				if(lastpos>=anim_maxpos){
					lastpos = anim_maxpos-1;
				}

				
				
				
				
				if(lastpos>=0 && lastpos<anim_maxpos){
					dgv_anim[lastpos,selectedRow].Selected = true;
					dgv_anim.FirstDisplayedScrollingColumnIndex = lastpos;
					dgv_anim.FirstDisplayedScrollingRowIndex = selectedRow;
				}
			}
	
		}
		
		void AnimUpdatePos(){
			anim_maxpos = GetAnimMaxPos();
			if(anim_maxpos==0){
				txt_anim_pos.Text = "0/0";
				tb_anim_pos.Value = 0;
				tb_anim_pos.Minimum = 0;
				tb_anim_pos.Maximum = 0;
			}else{
				if(anim_curpos>=anim_maxpos){
					anim_curpos=anim_maxpos-1;
				}
				tb_anim_pos.Maximum =anim_maxpos-1;
				tb_anim_pos.Value = anim_curpos;
				
				txt_anim_pos.Text = (anim_curpos+1)+"/"+anim_maxpos;

				if(!chk_ledcurrent.Checked)UpdateVisualLEDPosition(anim_curpos);
			}
			
		}
		
		void Dgv_animCellDoubleClick(object sender, DataGridViewCellEventArgs e){
			if(e.RowIndex==-1){
				return;
			}
			if(e.ColumnIndex!=-1){
				if(dgv_patlist.SelectedCells.Count==0){
					return;
				}
				
				using(var cd = new ColorDialog()){
					cd.AllowFullOpen=true;
					cd.FullOpen = true;
					cd.CustomColors = customcolor;
					
					var pat = lst_pattern[dgv_patlist.SelectedCells[0].RowIndex];
					cd.Color = pat.led[e.ColumnIndex][e.RowIndex];
					
					if(cd.ShowDialog()==DialogResult.OK){
						DataGridViewCell cell = (DataGridViewCell)dgv_anim[e.ColumnIndex, e.RowIndex];
						cell.Style.BackColor = cd.Color;
						
						pat.led[e.ColumnIndex][e.RowIndex] = cd.Color;
						
						UpdateVisualLEDPosition(anim_curpos);
					}
					
					customcolor = cd.CustomColors;
				}
			}
		}

		
		
		void Btn_anim_copyClick(object sender, EventArgs e){
			if(play){
				MessageBox.Show("Is Playing now!");
				return;
			}
			
			if(dgv_patlist.SelectedCells.Count>0){
				if(anim_curpos<anim_maxpos){
					clipboard_frame = lst_pattern[dgv_patlist.SelectedCells[0].RowIndex].led[anim_curpos];
				}
			}
			
		}
		
		void Btn_anim_pasteClick(object sender, EventArgs e){
			if(play){
				MessageBox.Show("Is Playing now!");
				return;
			}
			
			if(clipboard_frame!=null){
				if(dgv_patlist.SelectedCells.Count>0){
					if(anim_curpos<anim_maxpos){//paste into frame
						Color[] c = lst_pattern[dgv_patlist.SelectedCells[0].RowIndex].led[anim_curpos];
						if(c.Length>clipboard_frame.Length){
							for(int i=0;i<c.Length;i++){
								if(i<clipboard_frame.Length){
									c[i] = clipboard_frame[i];
								}else{
									c[i] = Color.Black;
								}
								dgv_anim[anim_curpos, i].Style.BackColor = c[i];
							}
						}else{
							for(int i=0;i<clipboard_frame.Length;i++){
								if(i<c.Length){
									c[i] = clipboard_frame[i];
									dgv_anim[anim_curpos, i].Style.BackColor = c[i];
								}else{
									break;
								}
							}
						}
						AnimUpdatePos();
					}
				}
			}
			
		}
		
		
		
		
		void UpdateVisualLEDPosition(int framepos){
			
			for(int i=1;i<ledgroup.Count;i++){
				
				Control[] controls = pnl_ledgroup.Controls.Find(""+ledgroup[i].id, true);
				if(controls.Length>0){
					if(controls[0] is LED){
						var led = ((LED)controls[0]);
						Color[] cled = led.LEDColor;
						
						if(chk_ledcurrent.Checked){
							if(ledgroup[i].device != -1 && ledgroup[i].channel != -1){
								var dev = devices[ledgroup[i].device];
								Color[] c = dev.GetChannelLED(ledgroup[i].channel);
								for(int pos=0;pos<cled.Length;pos++){
									if(pos+led.StartIndex<c.Length){
										cled[pos] = c[pos+led.StartIndex];
									}else{
										cled[pos] = Color.Black;
									}
								}
							}
						}else{
							Structs.Pattern pat = null;
							foreach(var p in lst_pattern){
								if(ledgroup[i].device == p.device && ledgroup[i].channel == p.channel){
									pat = p;
									break;
								}
							}
							
							if(pat==null){
								for(int pos=0;pos<cled.Length;pos++){
									cled[pos] = Color.Black;
								}
							}else{
								if(framepos>=0 && framepos<pat.led.Count){
									Color[] cframe = pat.led[framepos];
									
									
									for(int pos=0;pos<cled.Length;pos++){
										if(pos+led.StartIndex < cframe.Length){
											cled[pos] = cframe[pos+led.StartIndex];
										}else{
											cled[pos] = Color.Black;
										}
									}
								}else{
									for(int pos=0;pos<cled.Length;pos++){
										cled[pos] = Color.Black;
									}
								}
							}
							
							
						}
						led.LEDColor = cled;
					}
				}
			}
			
			
			
			foreach(var p in lst_pattern){
				if(p.device == -1 || p.channel == -1)continue;
				for(int i=1;i<ledgroup.Count;i++){
					
					if(ledgroup[i].device == p.device && ledgroup[i].channel == p.channel){
						Control[] controls = pnl_ledgroup.Controls.Find(""+ledgroup[i].id, true);
						if(controls.Length>0){
							if(controls[0] is LED){
								var led = ((LED)controls[0]);
								Color[] cled = led.LEDColor;
								if(framepos>=0 && framepos<p.led.Count){
									Color[] cframe = p.led[framepos];
									
									
									
									for(int pos=0;pos<cled.Length;pos++){
										if(pos+led.StartIndex < cframe.Length){
											cled[pos] = cframe[pos+led.StartIndex];
										}else{
											cled[pos] = Color.Black;
										}
									}
									led.LEDColor = cled;
								}else{
									for(int pos=0;pos<cled.Length;pos++){
										cled[pos] = Color.Black;
									}
								}
							}
						}
						break;
					}
				}
			}
			
			
		}
		
		void Btn_anim_playClick(object sender, EventArgs e){
			if(CLupdateThread!=null){
				
				if(AnimFrameThread==null){
					anim_maxpos=GetAnimMaxPos();
					if(anim_maxpos==0)return;
					
					
					AnimFrameThread = new Thread(new ThreadStart(
						delegate{
							play = true;
							if(CLupdateThread==null){
								return;
							}
							CLupdateThread.Interrupt();
							
							while(play){
								try{
									if(chk_reverse.Checked){
										anim_curpos--;
									}else{
										anim_curpos++;
									}
									if(anim_curpos<0){
										anim_curpos = anim_maxpos-1;
									}
									if(anim_curpos>=anim_maxpos){
										anim_curpos = 0;
									}
									if(InvokeRequired){
										BeginInvoke((MethodInvoker)delegate{AnimUpdatePos();});
									}
									
									
									Thread.Sleep(framedelay);
								}catch(ThreadAbortException){
									
									play = false;
								}
							}
						}
					));
					
					AnimFrameThread.Start();
					
					
					
				}else{
					AnimFrameThread.Abort();
					AnimFrameThread.Join();
					AnimFrameThread = null;
					AnimUpdatePos();
				}
				
			}
		}
		
		void Tb_anim_delayValueChanged(object sender, EventArgs e){
			framedelay = tb_anim_delay.Value;
		}
		
		void Tb_anim_posScroll(object sender, EventArgs e){
			anim_curpos = tb_anim_pos.Value;
			AnimUpdatePos();
		}
		
		void Btn_anim_nextClick(object sender, EventArgs e){
			if(anim_curpos<anim_maxpos){
				anim_curpos++;
				AnimUpdatePos();
			}
		}
		
		void Btn_anim_prevClick(object sender, EventArgs e){
			if(anim_curpos>0){
				anim_curpos--;
				AnimUpdatePos();
			}
		}

		void Btn_group_addClick(object sender, EventArgs e){
	
			using(var frm = new frm_ledconfig(devices,0)){
				while(frm.ShowDialog() == DialogResult.OK){
					
					int ledcount = 0;
					foreach(var lg in ledgroup){
						if(lg.device==frm.SelectedDevice && lg.channel == frm.SelectedChannel){
							Control[] controls = pnl_ledgroup.Controls.Find(""+lg.id, true);
							if(controls.Length>0){
								ledcount += ((LED)controls[0]).LEDColor.Length;
							}
						}
					}
					
					Structs.LEDGroupType ledtype = Structs.LEDGroupTypes.GetLEDType(frm.SelectedType);
					if(ledtype.ledcount+ledcount>=devices[frm.SelectedDevice].LEDCount[frm.SelectedChannel]){
						MessageBox.Show("Total LED count is over than selected device's channel capable!", "Too much", MessageBoxButtons.OK, MessageBoxIcon.Information);
						continue;
					}
					AddLEDGroup(frm.SelectedDevice, frm.SelectedChannel, frm.SelectedType);
					AnimUpdatePos();
					break;
				}
			}
		}
		
		long AddLEDGroup(int dev, int ch, int type){
			string controlname = "DEV_"+devices[dev].LNPDevice.GetSerial()+":CH_"+ch;
			Control[] controls = pnl_ledgroup.Controls.Find(controlname, true);
			if(controls.Length==0){
				Console.WriteLine("Cannot find "+controlname+"!");
				return -1;
			}
			
			Panel pnlch = controls[0] as Panel;
			if(pnlch==null){
				Console.WriteLine("Cannot find "+controlname+"!");
				return -1;
			}
			Control control = null;
			
			//generate new ID
			long newid = 0;
			//loop led group list to find non similar ID
			bool exist = false;
			while(true){
				newid = random.Next();
				foreach(Structs.LEDGroup lg in ledgroup){
					if(lg.id==newid){
						exist = true;
						break;
					}
				}
				if(!exist)break;
			}
			
			

			Structs.LEDGroupType ledgrouptype = Structs.LEDGroupTypes.None;
			
			if(type == Structs.LEDGroupTypes.GetLEDTypeIndex(Structs.LEDGroupTypes.SP)){
				control = new LED_SP();
				ledgrouptype = Structs.LEDGroupTypes.SP;
			}else if(type == Structs.LEDGroupTypes.GetLEDTypeIndex(Structs.LEDGroupTypes.HD)){
				control = new LED_HD();
				ledgrouptype = Structs.LEDGroupTypes.HD;
			}else if(type == Structs.LEDGroupTypes.GetLEDTypeIndex(Structs.LEDGroupTypes.LL)){
				control = new LED_LL();
				ledgrouptype = Structs.LEDGroupTypes.LL;
			}else if(type == Structs.LEDGroupTypes.GetLEDTypeIndex(Structs.LEDGroupTypes.ML)){
				control = new LED_ML();
				ledgrouptype = Structs.LEDGroupTypes.ML;
			}else if(type == Structs.LEDGroupTypes.GetLEDTypeIndex(Structs.LEDGroupTypes.LEDPro)){
				control = new LED_Strip();
				ledgrouptype = Structs.LEDGroupTypes.LEDPro;
			}
			
			
			
			
			//ledgroup.FindAll(x=> x.device == frm.SelectedDevice && x.channel == frm.SelectedChannel);
			
			if(control!=null){
				
				control.Name = ""+newid;
				
				int x=0;
				int ledindex = 0;
				foreach(Control c in pnlch.Controls){
					if(c is LED){
						ledindex+=((LED)c).LEDColor.Length;
					}
					if(c.Location.X == x){
						x+=c.Width;
					}
					
				}
				
				var led = (LED)control;
				led.StartIndex = ledindex;
				
				led.LEDEditChangeEvent += delegate(string id, int index, int ledpos, Color color) {
					if(anim_maxpos>0){
						if(anim_curpos<anim_maxpos){
							Structs.Pattern pattern = null;
							foreach(var _lg in ledgroup){
								if((_lg.id+"").Equals(id)){
									
									foreach(var pat in lst_pattern){
										if(pat.device==_lg.device && pat.channel==_lg.channel){
											pattern = pat;
											break;
										}
									}
									break;
								}
							}
							
							if(pattern!=null){
								
								Color[] frame = pattern.led[anim_curpos];
								if(index+ledpos<frame.Length){
									frame[index+ledpos] = color;
									if(index+ledpos<dgv_anim.Rows.Count)dgv_anim[anim_curpos, index+ledpos].Style.BackColor = color;
									AnimUpdatePos();
								}
							}
						}
					}
				};
				
				led.Text = "LED "+(ledindex+1);
				int ledcount = led.LEDColor.Length;
				if(ledcount>1){
					led.Text += " -> "+(ledcount+led.StartIndex);
				}
				
				
				Structs.LEDGroup lg = new Structs.LEDGroup(){
					id=newid,
					type=ledgrouptype,
					startindex=ledindex,
					device=dev,
					channel=ch
				};
				
				ledgroup.Add(lg);
				
				control.Tag = lg;

				control.Location = new Point(x,0);
				pnlch.Controls.Add(control);
				AnimUpdatePos();
				return newid;
			}
			
			return -1;
		}
		
		
		void Ts_patlist_newClick(object sender, EventArgs e){
			
			if(MessageBox.Show("New pattern track list?", "New", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes){
				if(play)play=false;
				if(CLupdateThread!=null)CLupdateThread.Interrupt();
				tb_anim_delay.Value = 100;
				lst_pattern.Clear();
				dgv_patlist.Rows.Clear();
				
				RefreshPatternViewer(-1);
				AnimUpdatePos();
			}
		}
		
		void Ts_patlist_saveClick(object sender, EventArgs e){
			using(var sfd = new SaveFileDialog()){
				sfd.Filter = "Pattern File(*.pat)|*.pat";
				sfd.FileOk += delegate {
					string errmsg = null;
					if((errmsg = PatternFile.SaveToFile(sfd.FileName, new List<Structs.Device>(devices), lst_pattern, tb_anim_delay.Value))!=null){
						MessageBox.Show(errmsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				};
				
				sfd.ShowDialog();
			}
			
		}
		
		
		void Btn_patlist_openClick(object sender, EventArgs e){
			
			using(var frm = new frm_patternlist(new List<Structs.Device>(devices), lst_pattern, framedelay, patternlist_file)){
				if(frm.ShowDialog() == DialogResult.OK){
					
					
					LoadPattern(AppDomain.CurrentDomain.BaseDirectory+"/pattern/"+frm.Selected+".pat", false);
					
					//play = tmpplay;
					//if(CLupdateThread!=null)CLupdateThread.Interrupt();
					
					/*
					string errmsg = null;
					List<Structs.Pattern> tmp_pat = new List<Structs.Pattern>();
					int tmp_delay = 100;
					if((errmsg = PatternFile.LoadFromFile(AppDomain.CurrentDomain.BaseDirectory+"/pattern/"+frm.Selected+".pat", new List<Structs.Device>(devices), out tmp_pat, out tmp_delay))!=null){
						MessageBox.Show(errmsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					
					if(tmp_pat!=null){
						patternlist_file = frm.Selected;
						
						bool tmpplay = play;
						play=false;
						if(CLupdateThread!=null)CLupdateThread.Interrupt();
						
						tb_anim_delay.Value = tmp_delay;
						lst_pattern.Clear();
						lst_pattern = tmp_pat;
						dgv_patlist.Rows.Clear();
						foreach(var pat in lst_pattern){
							Structs.DataItem dev = dgv_device[0];
							Structs.DataItem ch = dgv_chan[0];
							
							foreach(var d in dgv_device){
								if(d.index == pat.device){
									dev = d;
									break;
								}
							}
							
							foreach(var c in dgv_chan){
								if(c.index == pat.channel){
									ch = c;
									break;
								}
							}
							
							
							dgv_patlist.Rows.Add(new object[]{pat.name,dev,ch});
							dgv_patlist.Rows[dgv_patlist.Rows.Count-1].Tag = pat;
							dgv_patlist.Rows[dgv_patlist.Rows.Count-1].HeaderCell.Value = ""+dgv_patlist.Rows.Count;
						}
						if(lst_pattern.Count>0){
							RefreshPatternViewer(0);
						}else{
							RefreshPatternViewer(-1);
						}
						AnimUpdatePos();
						play = tmpplay;
						if(CLupdateThread!=null)CLupdateThread.Interrupt();
					}
					 */
					
				}
				return;
			}
			
			
			
		}
		
		bool LoadPattern(string filepath, bool noerrdialog){
			string errmsg = null;
			List<Structs.Pattern> tmp_pat = new List<Structs.Pattern>();
			int tmp_delay = 100;
			if((errmsg = PatternFile.LoadFromFile(filepath, new List<Structs.Device>(devices), out tmp_pat, out tmp_delay))!=null){
				if(!noerrdialog)MessageBox.Show(errmsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			
			if(tmp_pat!=null){
				patternlist_file = filepath;
				
				if(play){
					Btn_anim_playClick(null,null);
				}
				if(CLupdateThread!=null)CLupdateThread.Interrupt();
				
				tb_anim_delay.Value = tmp_delay;
				lst_pattern.Clear();
				lst_pattern = tmp_pat;
				dgv_patlist.Rows.Clear();
				foreach(var pat in lst_pattern){
					Structs.DataItem dev = dgv_device[0];
					Structs.DataItem ch = dgv_chan[0];
					
					foreach(var d in dgv_device){
						if(d.index == pat.device){
							dev = d;
							break;
						}
					}
					
					foreach(var c in dgv_chan){
						if(c.index == pat.channel){
							ch = c;
							break;
						}
					}
					
					
					dgv_patlist.Rows.Add(new object[]{pat.name,dev,ch});
					dgv_patlist.Rows[dgv_patlist.Rows.Count-1].Tag = pat;
					dgv_patlist.Rows[dgv_patlist.Rows.Count-1].HeaderCell.Value = ""+dgv_patlist.Rows.Count;
				}
				
				if(lst_pattern.Count>0){
					RefreshPatternViewer(0);
				}else{
					RefreshPatternViewer(-1);
				}
				AnimUpdatePos();
				
				//play = tmpplay;
				
				Btn_anim_playClick(null,null);
				
				if(CLupdateThread!=null)CLupdateThread.Interrupt();
				return true;
			}
			
			return false;
		}
		
		
		void ts_pat_addClick(object sender, EventArgs e){
			int maxframe = 0;
			int maxled = TMP_MAXLED;
			foreach(var dev in devices){
				for(int i=0;i<dev.LEDCount.Length;i++){
					maxled = Math.Max(dev.LEDCount[i],maxled);
				}
			}
			
			foreach(var pat in lst_pattern){
				maxframe = Math.Max(pat.led.Count,maxframe);
			}
			
			List<Color[]> _led = new List<Color[]>();
			for(int i=0;i<maxframe;i++){
				_led.Add(new Color[maxled]);
			}
			
			lst_pattern.Add(new Structs.Pattern(){name="",device=-1,channel=-1, led = _led});
			dgv_patlist.Rows.Add(new object[]{"",dgv_device[0],dgv_chan[0]});
			dgv_patlist.Rows[dgv_patlist.Rows.Count-1].Tag = lst_pattern[lst_pattern.Count-1];
			dgv_patlist.Rows[dgv_patlist.Rows.Count-1].HeaderCell.Value = ""+dgv_patlist.Rows.Count;
			RefreshPatternViewer(dgv_patlist.SelectedCells[0].RowIndex);
		}
		
		void Ts_pat_delClick(object sender, EventArgs e){
			if(dgv_patlist.SelectedCells.Count>0){
				if(MessageBox.Show("Are you sure you want to delete this pattern track?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes){
					lst_pattern.RemoveAt(dgv_patlist.SelectedCells[0].RowIndex);
					dgv_patlist.Rows.RemoveAt(dgv_patlist.SelectedCells[0].RowIndex);
				}
			}
		}
		
		void Dgv_patlistCellParsing(object sender, DataGridViewCellParsingEventArgs e){
			if (dgv_patlist.CurrentCell.OwningColumn is DataGridViewComboBoxColumn) {
				DataGridViewComboBoxEditingControl editingControl =
					(DataGridViewComboBoxEditingControl)dgv_patlist.EditingControl;
				e.Value = editingControl.SelectedItem;
				e.ParsingApplied = true;
			}
		}
		
		void Dgv_patlistCellEndEdit(object sender, DataGridViewCellEventArgs e){
			if(e.RowIndex==-1 || e.ColumnIndex==-1){
				return;
			}

			if(dgv_patlist.Rows[e.RowIndex].Tag is Structs.Pattern){
				var pattern = (Structs.Pattern)dgv_patlist.Rows[e.RowIndex].Tag;
				if(e.ColumnIndex==0){
					string name = dgv_patlist[e.ColumnIndex,e.RowIndex].Value as string;
					if(string.IsNullOrEmpty(name)){
						name = "";
					}
					pattern.name = name;
				}else if(e.ColumnIndex==1){
					var dgvcc = ((DataGridViewComboBoxCell)dgv_patlist[1,e.RowIndex]);
					var seldev = ((Structs.DataItem)dgvcc.Value);
					if(seldev.index!=-1){
						for(int i=0;i< lst_pattern.Count; i++){
							if(pattern!=lst_pattern[i]){
								if(lst_pattern[i].device == seldev.index && lst_pattern[i].channel == pattern.channel){
									MessageBox.Show("Already have track assigned same device and channel!", "Same device/channel", MessageBoxButtons.OK, MessageBoxIcon.Information);
									foreach(var dev in dgv_device){
										if(pattern.device == dev.index){
											seldev = dev;
											break;
										}
									}
									dgvcc.Value = seldev;
									return;
								}
							}
						}
					}

					pattern.device = seldev.index;
				}else if(e.ColumnIndex==2){
					var dgvcc = ((DataGridViewComboBoxCell)dgv_patlist[2,e.RowIndex]);
					var selchan = ((Structs.DataItem)dgvcc.Value);
					if(selchan.index!=-1){
						for(int i=0;i< lst_pattern.Count; i++){
							if(pattern!=lst_pattern[i]){
								if(lst_pattern[i].device == pattern.device && lst_pattern[i].channel == selchan.index){
									MessageBox.Show("Already have track assigned same device and channel!", "Same device/channel", MessageBoxButtons.OK, MessageBoxIcon.Information);
									
									foreach(var chan in dgv_chan){
										if(pattern.channel == chan.index){
											selchan = chan;
											break;
										}
									}
									dgvcc.Value = selchan;
									return;
								}
							}
						}
					}
					
					pattern.channel = selchan.index;
				}

				dgv_patlist.Invalidate();
				
				if(dgv_anim.SelectedCells.Count>0){
					UpdateVisualLEDPosition(dgv_anim.SelectedCells[0].ColumnIndex);
				}else{
					UpdateVisualLEDPosition(-1);
				}
			}
		}
		
		void Dgv_patlistSelectionChanged(object sender, EventArgs e){
			ts_pat_del.Enabled = false;
			
			if(dgv_patlist.SelectedCells.Count>0){
				ts_pat_del.Enabled = true;
				RefreshPatternViewer(dgv_patlist.SelectedCells[0].RowIndex);
			}
		}
		
		void Dgv_patlistRowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e){
			if(dgv_patlist.Rows.Count==0){
				RefreshPatternViewer(-1);
			}
		}
	

		void Dgv_animSelectionChanged(object sender, EventArgs e){
			ts_btn_copy.Enabled = false;
			ts_btn_paste.Enabled = false;
			ts_btn_set.Enabled = false;
			ts_btn_fill.Enabled = false;
			if(dgv_anim.SelectedCells.Count>0){
				int pos = dgv_anim.SelectedCells[0].ColumnIndex;
				
				ts_btn_copy.Enabled = true;
				ts_btn_paste.Enabled = true;
				ts_btn_set.Enabled = true;
				ts_btn_fill.Enabled = true;
				
				if(pos<0)pos = 0;
				anim_curpos = pos;
				
				
				AnimUpdatePos();
				UpdateVisualLEDPosition(anim_curpos);
			}
		}
		
		
		void Ts_btn_copyClick(object sender, EventArgs e){
			if(dgv_anim.SelectedCells.Count>0 && dgv_patlist.SelectedCells.Count>0){
				foreach(DataGridViewCell c in dgv_anim.SelectedCells){
					if(c.ColumnIndex !=-1 && c.RowIndex!=-1){
						clipboard_color = dgv_anim[c.ColumnIndex,c.RowIndex].Style.BackColor;
						break;
					}
				}
			}
		}
		
		void Ts_btn_pasteClick(object sender, EventArgs e){
			if(dgv_anim.SelectedCells.Count>0 && dgv_patlist.SelectedCells.Count>0){
				var pat = (Structs.Pattern)dgv_patlist.Rows[dgv_patlist.SelectedCells[0].RowIndex].Tag;
				foreach(DataGridViewCell c in dgv_anim.SelectedCells){
					if(c.ColumnIndex != -1 && c.RowIndex!=-1){
						pat.led[c.ColumnIndex][c.RowIndex] = clipboard_color;
						dgv_anim[c.ColumnIndex,c.RowIndex].Style.BackColor = clipboard_color;
						
					}
				}
				dgv_anim.ClearSelection();
				UpdateVisualLEDPosition(0);
			}
		}
		
		void Ts_btn_setClick(object sender, EventArgs e){
			if(dgv_anim.SelectedCells.Count>0 && dgv_patlist.SelectedCells.Count>0){
				using(var cd = new ColorDialog()){
					cd.AllowFullOpen=true;
					cd.FullOpen = true;
					cd.CustomColors = customcolor;

					if(cd.ShowDialog()==DialogResult.OK){
						var pat = (Structs.Pattern)dgv_patlist.Rows[dgv_patlist.SelectedCells[0].RowIndex].Tag;
						foreach(DataGridViewCell c in dgv_anim.SelectedCells){
							if(c.ColumnIndex !=-1 && c.RowIndex!=-1){
								pat.led[c.ColumnIndex][c.RowIndex] = cd.Color;
								dgv_anim[c.ColumnIndex,c.RowIndex].Style.BackColor = cd.Color;
							}
						}
						dgv_anim.ClearSelection();
						UpdateVisualLEDPosition(anim_curpos);
					}
					
					customcolor = cd.CustomColors;
				}
			}
		}
		
		void Ts_btn_fillClick(object sender, EventArgs e){
			if(dgv_anim.SelectedCells.Count>0 && dgv_patlist.SelectedCells.Count>0){
				using(var frm = new frm_fillcolor()){
					if(frm.ShowDialog()==DialogResult.OK){
						var pat = (Structs.Pattern)dgv_patlist.Rows[dgv_patlist.SelectedCells[0].RowIndex].Tag;
						
						int begin = dgv_anim.Columns.Count-1;
						int end = 0;
						//get most end column first
						foreach(DataGridViewCell c in dgv_anim.SelectedCells){
							if(c.ColumnIndex>=0 && c.ColumnIndex<begin){
								begin = c.ColumnIndex;
							}
							
							if(c.ColumnIndex>=0 && c.ColumnIndex>end){
								end = c.ColumnIndex;
							}
						}

						if(end>begin){
							end -= begin;
							double h_step = (frm.EndColor.h - frm.StartColor.h)/(double)(end);
							double s_step = (frm.EndColor.s - frm.StartColor.s)/(double)(end);
							double v_step = (frm.EndColor.v - frm.StartColor.v)/(double)(end);
							
							foreach(DataGridViewCell c in dgv_anim.SelectedCells){
								if(c.ColumnIndex !=-1 && c.RowIndex!=-1){
									Structs.HSV newhsv = new Structs.HSV();
									newhsv.h = (frm.StartColor.h) + (h_step * (c.ColumnIndex-begin));
									newhsv.s = (frm.StartColor.s) + (s_step * (c.ColumnIndex-begin));
									newhsv.v = (frm.StartColor.v) + (v_step * (c.ColumnIndex-begin));
									if(newhsv.h<0)newhsv.h = 0;
									if(newhsv.h>1)newhsv.h = 1;
									if(newhsv.s<0)newhsv.s = 0;
									if(newhsv.s>1)newhsv.s = 1;
									if(newhsv.v<0)newhsv.v = 0;
									if(newhsv.v>1)newhsv.v = 1;
									pat.led[c.ColumnIndex][c.RowIndex] = ColorToolkit.rgb2color(ColorToolkit.hsv2rgb(newhsv));
									//int[] tag = (int[])dgv_anim.Rows[c.RowIndex].Tag;
									//animList[c.ColumnIndex-3][tag[0]][tag[1]][tag[2]] = ColorToolkit.rgb2color(ColorToolkit.hsv2rgb(newhsv));
									dgv_anim[c.ColumnIndex,c.RowIndex].Style.BackColor = ColorToolkit.rgb2color(ColorToolkit.hsv2rgb(newhsv));
								}
							}
							
						}else{
							Color color = ColorToolkit.rgb2color(ColorToolkit.hsv2rgb(frm.StartColor));
							foreach(DataGridViewCell c in dgv_anim.SelectedCells){
								if(c.ColumnIndex != -1 && c.RowIndex!=-1){
									//int[] tag = (int[])dgv_anim.Rows[c.RowIndex].Tag;
									//animList[c.ColumnIndex-3][tag[0]][tag[1]][tag[2]] = color;
									pat.led[c.ColumnIndex][c.RowIndex] = color;
									dgv_anim[c.ColumnIndex,c.RowIndex].Style.BackColor = color;
								}
							}
						}
						dgv_anim.ClearSelection();
						UpdateVisualLEDPosition(anim_curpos);
					}
				}
			}
		}
		
		void Ts_btn_expandClick(object sender, EventArgs e){
			if(dgv_anim.SelectedCells.Count>0 && dgv_patlist.SelectedCells.Count>0){
				var pat = (Structs.Pattern)dgv_patlist.Rows[dgv_patlist.SelectedCells[0].RowIndex].Tag;
				
				List<DataGridViewCell> cells = new List<DataGridViewCell>();
				foreach(DataGridViewCell c in dgv_anim.SelectedCells){
					cells.Add(c);
				}
				cells.Sort((x1,x2) => x1.RowIndex.CompareTo(x2.RowIndex));
				
				int startrow = dgv_anim.Rows.Count-1;
				int endrow = 0;
				foreach(var c in cells){
					startrow = Math.Min(c.RowIndex, startrow);
					endrow = Math.Max(c.RowIndex, endrow);
				}
				
				for(int i=startrow;i<=endrow;i++){
					int begin = dgv_anim.Columns.Count-1;
					int end = 0;
					
					foreach(var c in cells){
						if(c.RowIndex == i){
							begin = Math.Min(c.ColumnIndex,begin);
							end = Math.Max(c.ColumnIndex,end);
						}
					}

					if(begin!=end){
						int delta=end-begin;
						for(int x=delta;x>0;x--){
							if(begin+(x*2)>=pat.led.Count){
								continue;
							}
							
							Color c = pat.led[begin+x][i];
							pat.led[begin+(x*2)][i] = c;
							dgv_anim[begin+(x*2),i].Style.BackColor = pat.led[begin+(x*2)][i];
							
							pat.led[begin+x][i] = Color.Black;
							
						}
						
						for(int x=0;x<delta*2;x+=2){
							if(begin+(x+2) <pat.led.Count){
								Structs.HSV hsv1 = ColorToolkit.rgb2hsv(ColorToolkit.color2rgb(pat.led[begin+x][i]));
								Structs.HSV hsv2 = ColorToolkit.rgb2hsv(ColorToolkit.color2rgb(pat.led[begin+(x+2)][i]));
								
								double h_half = 0;
								h_half = ((hsv2.h - hsv1.h)/2d)+hsv1.h;
								
								
								
								double s_half = ((hsv2.s - hsv1.s)/2d)+hsv1.s;
								double v_half = ((hsv2.v - hsv1.v)/2d)+hsv1.v;
								
								Console.WriteLine(h_half);
								
								if(h_half<0)h_half+=1d;
								if(h_half>1)h_half-=1d;
								if(s_half<0)s_half=0;
								if(s_half>1)s_half=1;
								if(v_half<0)v_half=0;
								if(v_half>1)v_half=1;
								
								Structs.HSV hsvhalf = new Structs.HSV(){h = h_half, s = s_half, v = v_half};
								pat.led[begin+x+1][i] = ColorToolkit.rgb2color(ColorToolkit.hsv2rgb(hsvhalf));
								dgv_anim[begin+x+1,i].Style.BackColor = pat.led[begin+x+1][i];
							}
							
						}
					}
					
					
				}
				
				dgv_anim.ClearSelection();
				UpdateVisualLEDPosition(anim_curpos);
				
			}
		}
		
		void Ts_btn_halfClick(object sender, EventArgs e){
			if(dgv_anim.SelectedCells.Count>0 && dgv_patlist.SelectedCells.Count>0){
				var pat = (Structs.Pattern)dgv_patlist.Rows[dgv_patlist.SelectedCells[0].RowIndex].Tag;
				
				List<DataGridViewCell> cells = new List<DataGridViewCell>();
				foreach(DataGridViewCell c in dgv_anim.SelectedCells){
					cells.Add(c);
				}
				cells.Sort((x1,x2) => x1.RowIndex.CompareTo(x2.RowIndex));
				
				int startrow = dgv_anim.Rows.Count-1;
				int endrow = 0;
				foreach(var c in cells){
					startrow = Math.Min(c.RowIndex, startrow);
					endrow = Math.Max(c.RowIndex, endrow);
				}
				
				for(int i=startrow;i<=endrow;i++){
					int begin = dgv_anim.Columns.Count-1;
					int end = 0;
					
					foreach(var c in cells){
						if(c.RowIndex == i){
							begin = Math.Min(c.ColumnIndex,begin);
							end = Math.Max(c.ColumnIndex,end);
						}
					}

					if(begin!=end){
						int delta=end-begin;
						for(int x=0;x<=delta;x++){
							if((x*2)<delta){
								if(begin+(x*2)<pat.led.Count){
									Color c = pat.led[begin+(x*2)][i];
									pat.led[begin+x][i] = c;
									dgv_anim[begin+x,i].Style.BackColor = c;
									
								}
							}else{
								pat.led[begin+x][i] = Color.Black;
								dgv_anim[begin+x,i].Style.BackColor = Color.Black;
							}
						}
					}
				}
				
				dgv_anim.ClearSelection();
				UpdateVisualLEDPosition(anim_curpos);
				
			}
		}
		
		void Ts_btn_flipClick(object sender, EventArgs e){
			if(dgv_anim.SelectedCells.Count>0 && dgv_patlist.SelectedCells.Count>0){
				var pat = (Structs.Pattern)dgv_patlist.Rows[dgv_patlist.SelectedCells[0].RowIndex].Tag;
				
				List<DataGridViewCell> cells = new List<DataGridViewCell>();
				foreach(DataGridViewCell c in dgv_anim.SelectedCells){
					cells.Add(c);
				}
				cells.Sort((x1,x2) => x1.RowIndex.CompareTo(x2.RowIndex));
				
				int startrow = dgv_anim.Rows.Count-1;
				int endrow = 0;
				foreach(var c in cells){
					startrow = Math.Min(c.RowIndex, startrow);
					endrow = Math.Max(c.RowIndex, endrow);
				}
				
				
				for(int i=startrow;i<=endrow;i++){
					int begin = dgv_anim.Columns.Count-1;
					int end = 0;
					
					foreach(var c in cells){
						if(c.RowIndex == i){
							begin = Math.Min(c.ColumnIndex,begin);
							end = Math.Max(c.ColumnIndex,end);
						}
					}

					if(begin!=end){
						
						int delta=end-begin;
						for(int x=0;x<=delta/2;x++){
							Color c = pat.led[begin+x][i];
							pat.led[begin+x][i] = pat.led[end-x][i];
							pat.led[end-x][i] = c;
							dgv_anim[begin+x,i].Style.BackColor = pat.led[begin+x][i];
							dgv_anim[end-x,i].Style.BackColor = pat.led[end-x][i];
						}
						
					}
				}
				
				
				dgv_anim.ClearSelection();
				UpdateVisualLEDPosition(anim_curpos);
			}
		}
		
		void Dgv_animKeyDown(object sender, KeyEventArgs e){

			if(e.Control){
				if(e.KeyCode == Keys.C){
					if(dgv_anim.SelectedCells.Count>0 && dgv_patlist.SelectedCells.Count>0){
						foreach(DataGridViewCell c in dgv_anim.SelectedCells){
							if(c.ColumnIndex != -1 && c.RowIndex!=-1){
								clipboard_color = lst_pattern[dgv_patlist.SelectedCells[0].RowIndex].led[c.ColumnIndex][c.RowIndex];
								break;
							}
						}
					}
				}else if(e.KeyCode == Keys.V){
					if(dgv_anim.SelectedCells.Count>0 && dgv_patlist.SelectedCells.Count>0){
						foreach(DataGridViewCell c in dgv_anim.SelectedCells){
							if(c.ColumnIndex != -1 && c.RowIndex!=-1){
								lst_pattern[dgv_patlist.SelectedCells[0].RowIndex].led[c.ColumnIndex][c.RowIndex] = clipboard_color;
								dgv_anim[c.ColumnIndex,c.RowIndex].Style.BackColor = clipboard_color;
							}
						}
						dgv_anim.ClearSelection();
						UpdateVisualLEDPosition(anim_curpos);
					}
				}
				
			}else{
				if(e.KeyCode == Keys.Delete){
					foreach(DataGridViewCell c in dgv_anim.SelectedCells){
						if(c.ColumnIndex != -1 && c.RowIndex!=-1){
							lst_pattern[dgv_patlist.SelectedCells[0].RowIndex].led[c.ColumnIndex][c.RowIndex] = Color.Black;
							dgv_anim[c.ColumnIndex,c.RowIndex].Style.BackColor = Color.Black;
						}
					}
					dgv_anim.ClearSelection();
					UpdateVisualLEDPosition(anim_curpos);
				}
			}
				
		}
		
		void Btn_audio_captureClick(object sender, EventArgs e){
			if(audiocapture==null){
				
				if(CLupdateThread==null)return;
				
				if(cb_audio_list.SelectedIndex == -1){
					MessageBox.Show("Please select Audio Capture device first!", "No Audio Capture Device Selected!", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
				cb_audio_list.Enabled = false;
				var device = (AudioCapture.AudioDevice)cb_audio_list.SelectedItem;
				
				audiocapture = new AudioCapture(device);
				audiocapture.OnSampleCaptured += delegate(float left, float right) {
					audio_value[0] = left;
					audio_value[1] = right;
					audio_vubar[0] = left;
					audio_vubar[1] = right;
				};
				
				if(audiocapture.StartCapture()){
					audioUIThread = new Thread(new ThreadStart(
						delegate{
							bool running = true;
							float[] vu = new float[2];
							while(running){
								try{
									for(int i=0;i<audio_vubar.Length;i++){
										float newval = Math.Abs(audio_vubar[i]*(audio_capture_vol));
										if(newval>vu[i]){
											vu[i] = newval;
											if(vu[i]>1)vu[i]=1;
										}else{
											vu[i] -= 0.05f;
											if(vu[i]<0)vu[i] = 0;
										}
										audio_vubar[i] = 0;
									}
									
									if(InvokeRequired){
										BeginInvoke(
											(MethodInvoker)delegate{
												pb_audio_left.Value = (int)(vu[0]*100f);
												pb_audio_right.Value = (int)(vu[1]*100f);
											}
										);
									}
									Thread.Sleep(16);
								}catch(ThreadAbortException){
									running = false;
								}
							}
						}
					));
					audioUIThread.Start();
					CLupdateThread.Interrupt();
					btn_audio_capture.Text = "Stop";
				}else{
					StopAudioCapture();
					MessageBox.Show("Failed to open Audio Capture device!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					cb_audio_list.Enabled = true;
				}
				
				
			}else{
				StopAudioCapture();
			}
			
		}
		
		void StopAudioCapture(){
			if(audiocapture==null)return;
			if(audioUIThread !=null){
				audioUIThread.Abort();
				audioUIThread.Join();
				audioUIThread = null;
			}
			try{
				audiocapture.StopCapture();
			}catch(Exception){}
			audiocapture = null;
			pb_audio_left.Value = 0;
			pb_audio_right.Value = 0;
			btn_audio_capture.Text = "Start";
			cb_audio_list.Enabled = true;
		}
		
		void Tb_audio_volValueChanged(object sender, EventArgs e){
			audio_capture_vol = (tb_audio_vol.Value / 100f);
		}
		
		void Lst_audio_ledgroupSelectedIndexChanged(object sender, EventArgs e){
			if(lst_audio_ledgroup.SelectedIndex==-1){
				pnl_ledgroup.Enabled = false;
			}
			pnl_ledgroup.Enabled = true;
			cb_audio_ledstyle.Items.Clear();
			cb_audio_ledstyle.Items.Add(Structs.LEDAudioStyles[0]);//off
			cb_audio_ledstyle.Items.Add(Structs.LEDAudioStyles[1]);//audio loud
			cb_audio_ledstyle.Items.Add(Structs.LEDAudioStyles[2]);//loud+anim
			cb_audio_ledstyle.SelectedIndex = 1;
			cb_audio_ldestyle_channel.SelectedIndex = 0;
			
			
			
			
			var item = (Structs.LEDGroup)lst_audio_ledgroup.SelectedItem;
			
			for(int i=0;i<4;i++){
				//item.audioStyleEfxColor[i]
				Control[] c = pnl_audio_ledstyle.Controls.Find("pnl_audio_ledstyle_config_color_"+i, true);
				if(c.Length>0){
					c[0].BackColor = item.audioStyleEfxColor[i];
				}
			}
			
			if(item.audioChannel<cb_audio_ldestyle_channel.Items.Count){
				cb_audio_ldestyle_channel.SelectedIndex = item.audioChannel;
			}
	
			if(item.type.Equals(Structs.LEDGroupTypes.LL) || item.type.Equals(Structs.LEDGroupTypes.HD) || item.type.Equals(Structs.LEDGroupTypes.LEDPro)){
				cb_audio_ledstyle.Items.Add(Structs.LEDAudioStyles[3]);//vu
				cb_audio_ledstyle.Items.Add(Structs.LEDAudioStyles[4]);//vu
			}
			
			if(item.audioStyle<cb_audio_ledstyle.Items.Count){
				cb_audio_ledstyle.SelectedIndex = item.audioStyle;
			}
			
		}
		
		void Pnl_audio_ledstyle_config_0_colorClick(object sender, EventArgs e){
			if(lst_audio_ledgroup.SelectedIndex!=-1){
				using(var cd = new ColorDialog()){
					Control control = (Control)(sender);
					
					cd.Color = control.BackColor;
					cd.CustomColors = customcolor;
					cd.AnyColor = true;
					cd.FullOpen = true;
					if(cd.ShowDialog() == DialogResult.OK){
						var item = (Structs.LEDGroup)lst_audio_ledgroup.SelectedItem;
						if(control.Tag != null){
							if(control.Tag is string){
								int tagidx = 0;
								if(int.TryParse((string)control.Tag, out tagidx)){
									item.audioStyleEfxColor[tagidx] = cd.Color;
									control.BackColor = cd.Color;
								}
							}
							
						}
					}
					customcolor = cd.CustomColors;
				}
			}
		}
		
		void Cb_audio_ledstyleSelectionChangeCommitted(object sender, EventArgs e){
			if(lst_audio_ledgroup.SelectedIndex!=-1){
				var item = (Structs.LEDGroup)lst_audio_ledgroup.SelectedItem;
				item.audioStyle = cb_audio_ledstyle.SelectedIndex;
				
			}
		}
		void Cb_audio_ldestyle_channelSelectionChangeCommitted(object sender, EventArgs e){
			if(lst_audio_ledgroup.SelectedIndex!=-1){
				var item = (Structs.LEDGroup)lst_audio_ledgroup.SelectedItem;
				item.audioChannel = cb_audio_ldestyle_channel.SelectedIndex;
			}
		}
		
		
		void Ts_btn_newluaClick(object sender, EventArgs e){
			if(MessageBox.Show("New Lua script?", "New", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes){
				if(luascriptrun){
					Ts_btn_runluaClick(null,null);
				}
				txt_lua.Text = "";
			}
		}
		
		void Ts_btn_openluaClick(object sender, EventArgs e){
			using(var ofd = new OpenFileDialog()){
				ofd.Filter = "Lua file (*.lua)|*.lua";
				ofd.FileOk += delegate {
					if(luascriptrun){
						Ts_btn_runluaClick(null,null);
					}
					try{
						txt_lua.Text = File.ReadAllText(ofd.FileName);
					}catch(Exception ex){
						MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				};
				ofd.ShowDialog();
			}
		}
		
		void Ts_btn_saveluaClick(object sender, EventArgs e){
			using(var sfd = new SaveFileDialog()){
				sfd.Filter = "Lua file (*.lua)|*.lua";
				sfd.FileOk += delegate {
					try{
						File.WriteAllText(sfd.FileName, txt_lua.Text);
					}catch(Exception ex){
						MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				};
				sfd.ShowDialog();
			}
		}
		
		void Ts_btn_runluaClick(object sender, EventArgs e){
			
			if(luascriptrun){
				try{
					if(LUAThread!=null && LuaScript!=null){
						
						LuaScript.Close();
						LuaScript.Dispose();
						luascriptrun = false;
						LuaScript = null;
						ts_btn_runlua.Text = "Run Script";
					}
					LUAThread = null;
				}catch(Exception){}
			}else{
				
				if(CLupdateThread==null){
					return;
				}
				LUAThread = null;
				LUAThread = new Thread(new ThreadStart(
					delegate{
						Invoke(
							(MethodInvoker)delegate{
								ts_btn_runlua.Text = "Stop Script";
							});
						
						LuaScript = null;
						try{
							try{
								luascriptrun = true;
								LuaScript = new Lua();
								LuaScript.LoadCLRPackage();
								LuaScript["LNP"] = new LuaFunction();
								LuaScript.DoString(txt_lua.Text);
							}catch(NullReferenceException){}
						}catch(Exception ex){
							MessageBox.Show(this,ex.ToString(), "Lua Script Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}finally{
							if(LuaScript != null){
								LuaScript.Dispose();
								LuaScript = null;
							}
							luascriptrun = false;
							Invoke(
								(MethodInvoker)delegate{
									ts_btn_runlua.Text = "Run Script";
								});
						}
					}
				));
				LUAThread.Start();
			}
			
			
		}
		
		
		

		void NotifyIconDoubleClick(object sender, EventArgs e){
			//MethodInfo mi = typeof(NotifyIcon).GetMethod("ShowContextMenu", BindingFlags.Instance | BindingFlags.NonPublic);
        	//mi.Invoke(notifyIcon, null);
        	
        	Show();
        	if(WindowState == FormWindowState.Minimized){
        		WindowState = FormWindowState.Normal;
        	}
        	BringToFront();
		}

		void NotifyIcon_menuOpening(object sender, CancelEventArgs e){
			ts_runLNP.Checked = CLupdateThread!=null;
			ts_audiocap.Checked = audioUIThread != null;
			ts_pat_play.Checked = play;
			ts_pat_reverse.Checked = chk_reverse.Checked;
			
			
			ts_patternmenu.DropDownItems.Clear();
			ts_patternmenu.DropDownItems.Add(ts_pat_play);
			ts_patternmenu.DropDownItems.Add(ts_pat_reverse);
			ts_patternmenu.DropDownItems.Add(new ToolStripSeparator());
			
			
			if(Directory.Exists(AppDomain.CurrentDomain.BaseDirectory+"/pattern")){
				string[] files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory+"/pattern");
				if(files.Length == 0){
					ToolStripMenuItem ts_none = new ToolStripMenuItem();
					ts_none.Text = "(Empty)";
					ts_none.Enabled = false;
					ts_patternmenu.DropDownItems.Add(ts_none);
				}
				foreach(var file in files){
					
					string uri = Path.GetFileNameWithoutExtension(file);
					string name = Uri.UnescapeDataString(uri);
					ToolStripMenuItem ts_patitem = new ToolStripMenuItem();
					ts_patitem.Text = name;
					ts_patitem.Checked |= file == patternlist_file;
					ts_patitem.Click += delegate {
						LoadPattern(file, true);
					};
					ts_patternmenu.DropDownItems.Add(ts_patitem);

				}
			}else{
				ToolStripMenuItem ts_none = new ToolStripMenuItem();
				ts_none.Text = "(Empty)";
				ts_none.Enabled = false;
				ts_patternmenu.DropDownItems.Add(ts_none);
			}
		}
		
		void Ts_showhideClick(object sender, EventArgs e){
			if(Visible){
				Hide();
			}else{
				Show();
				if(WindowState == FormWindowState.Minimized){
					WindowState = FormWindowState.Normal;
				}
				BringToFront();
			}
		}
		
		void Ts_pat_reverseClick(object sender, EventArgs e){
			chk_reverse.Checked = !chk_reverse.Checked;
		}
		void Ts_pat_playClick(object sender, EventArgs e){
			Btn_anim_playClick(null,null);
		}
		void Ts_runLNPClick(object sender, EventArgs e){
			btn_RunClick(null,null);
		}
		
		void Ts_audiocapClick(object sender, EventArgs e){
			Btn_audio_captureClick(null,null);
		}
		
		void ExitToolStripMenuItemClick(object sender, EventArgs e){
			Close();
		}
		
		void LoadConfig(){
			Console.WriteLine("Loading Config");
			
			if(SettingConfUtils.GetConfig("IsHide",false)){
				BeginInvoke(
					(MethodInvoker)delegate{
						Hide();
						Opacity = 1f;
					}
				);
			}else{
				Opacity = 1f;
			}
			
			nm_refresh.Value = Math.Max(Math.Min(SettingConfUtils.GetConfig("RefreshRate", 33),1000),0);
			tb_fadespeed.Value = Math.Max(Math.Min(SettingConfUtils.GetConfig("FadeSpeed", 20),100),1);
			
			foreach(var dev in devices){
				string conf = SettingConfUtils.GetConfig("LED_"+dev.LNPDevice.GetSerial(), "");
				if(!string.IsNullOrEmpty(conf.Trim())){
					string[] ledcount = conf.Split(new char[]{',',},2);
					if(ledcount.Length==2){
						
						for(int i=0;i<ledcount.Length;i++){
							int val = 0;
							if(int.TryParse(ledcount[i].Trim(), out val)){
								val = val/50;
								val = val*50;
								if(val<50)val = 50;
								if(val>150)val = 150;
								dev.LEDCount[i] = val;
							}
						}
					}else{
						dev.LEDCount[0] = 50;
						dev.LEDCount[1] = 50;
					}
				}
			}
			
			RecalculateLEDSize();
			
			try{
				string ledgroupconfig = Encoding.UTF8.GetString(SettingConfUtils.GetConfig("LEDGroup"));
				string[] ledgrouppart = ledgroupconfig.Split(new char[]{'\n'});
				foreach(string conf in ledgrouppart){
					
					//serialnum, channel, led type, audio style, audio channel source, audio color[4]
					string[] confpart = conf.Split(new char[]{'\t'}, 6);
					if(confpart.Length==6){
						try{
							int audiostyle = int.Parse(confpart[3]);
							int audiosource = int.Parse(confpart[4]);
							Color[] colors = {Color.Green,Color.Yellow, Color.Orange, Color.Red};
							
							
							if(audiostyle<0 || audiostyle >4){
								audiostyle = 0;
							}
							if(audiosource<0 || audiosource>2){
								audiosource = 0;
							}
							
							string[] colorstr = confpart[5].Split(new char[]{','});
							for(int i=0;i<colorstr.Length;i++){
								if(i<colors.Length){
									colors[i] = Color.FromArgb(int.Parse(colorstr[i]));
								}
							}
							
							if(confpart[0].Equals("-1") && confpart[1].Equals("-1")){//Ungroup LED setting
								if(audiostyle>=2){
									audiostyle=0;
								}
								
								var lg = ledgroup[0];
								lg.audioStyle = audiostyle;
								lg.audioChannel = audiosource;
								lg.audioStyleEfxColor = colors;
							}else{
								for(int dev=0;dev<devices.Count;dev++){
								
									
									if(devices[dev].LNPDevice.GetSerial().Equals(confpart[0])){//sernum
										
										Structs.LEDGroupType ledtype = Structs.LEDGroupTypes.GetLEDType(int.Parse(confpart[2]));
										if(ledtype.Equals(Structs.LEDGroupTypes.None)){
											throw new Exception("LED Type = None is bad LED group config!");
										}
										
										int channel = int.Parse(confpart[1]);
										if(channel<0 || channel>=Program.ChannelCount){
											throw new Exception("LED Group Channel Config Out of Range!");
										}
										
										
										
										
										
										int ledcount = 0;
										foreach(var lg in ledgroup){
											if(lg.device==dev && lg.channel == channel){
												Control[] controls = pnl_ledgroup.Controls.Find(""+lg.id, true);
												if(controls.Length>0){
													ledcount += ((LED)controls[0]).LEDColor.Length;
												}
											}
										}
										
										
										//check led total size if enough space then we add it otherwise skip it
										if(ledtype.ledcount+ledcount<devices[dev].LEDCount[channel]){
											//MessageBox.Show("Total LED count is over than selected device's channel capable!", "Too much", MessageBoxButtons.OK, MessageBoxIcon.Information);
											//continue;
											
											if(ledtype.Equals(Structs.LEDGroupTypes.SP) || ledtype.Equals(Structs.LEDGroupTypes.ML)){
												if(audiostyle>=2){
													audiostyle=0;
												}
											}
											
											long id = AddLEDGroup(dev, channel, Structs.LEDGroupTypes.GetLEDTypeIndex(ledtype));
											
											foreach(var lg in ledgroup){
												if(lg.id == id){
													lg.audioStyle = audiostyle;
													lg.audioChannel = audiosource;
													lg.audioStyleEfxColor = colors;
													break;
												}
											}
										}else{
											Console.WriteLine("Warning! LED count is too much, skip add. Max LED size is "+ devices[dev].LEDCount[channel]+", current occupied is "+ledcount+" LED(s), need to add for "+ledtype.ledcount+" LED(s)!");
										}

										break;
									}
								}
							}
							}catch(Exception e){
								Console.WriteLine(e);
							}
					}
				}
				
				ledgroup.ResetBindings();
				
					
			}catch(Exception){}
			
			string AuddevID = SettingConfUtils.GetConfig("AudioCaptureDevID","");
			if(!string.IsNullOrEmpty(AuddevID) && cb_audio_list.Items.Count>0){
				foreach(AudioCapture.AudioDevice capture in cb_audio_list.Items){
					if(capture.DeviceID == AuddevID){
						cb_audio_list.SelectedItem = capture;
						break;
					}
				}
			}
			
			tb_audio_vol.Value = Math.Max(Math.Min(SettingConfUtils.GetConfig("AudioCaptureVolume", 100),300),1);
			
			
			chk_reverse.Checked = SettingConfUtils.GetConfig("ReversePattern", false);
			chk_ledcurrent.Checked = SettingConfUtils.GetConfig("CurrentLEDView", false);
			
			patternlist_file = SettingConfUtils.GetConfig("LastPatternFile", "");
			
			
			try{
				string loadpatternfile = "";
				if(File.Exists(AppDomain.CurrentDomain.BaseDirectory+"/default.pat")){
					loadpatternfile = AppDomain.CurrentDomain.BaseDirectory+"/default.pat";
				}else if(File.Exists(patternlist_file)){
					loadpatternfile = patternlist_file;
				}
				if(!string.IsNullOrEmpty(loadpatternfile)){
					List<Structs.Pattern> tmp_pat = new List<Structs.Pattern>();
					int tmp_delay = 100;
					string errmsg = PatternFile.LoadFromFile(loadpatternfile, new List<Structs.Device>(devices), out tmp_pat, out tmp_delay);
					if(tmp_pat!=null){
						tb_anim_delay.Value = tmp_delay;
						lst_pattern.Clear();
						lst_pattern = tmp_pat;
						dgv_patlist.Rows.Clear();
						foreach(var pat in lst_pattern){
							Structs.DataItem dev = dgv_device[0];
							Structs.DataItem ch = dgv_chan[0];
							
							foreach(var d in dgv_device){
								if(d.index == pat.device){
									dev = d;
									break;
								}
							}
							
							foreach(var c in dgv_chan){
								if(c.index == pat.channel){
									ch = c;
									break;
								}
							}
							dgv_patlist.Rows.Add(new object[]{pat.name,dev,ch});
							dgv_patlist.Rows[dgv_patlist.Rows.Count-1].Tag = pat;
							dgv_patlist.Rows[dgv_patlist.Rows.Count-1].HeaderCell.Value = ""+dgv_patlist.Rows.Count;
						}
						if(lst_pattern.Count>0){
							RefreshPatternViewer(0);
						}else{
							RefreshPatternViewer(-1);
						}
						AnimUpdatePos();
					}
					if(errmsg!=null)Console.WriteLine(errmsg);
				}
			}catch(Exception e){
				Console.WriteLine(e);
			}
			
			
			try{
				string luatxt = Encoding.UTF8.GetString(SettingConfUtils.GetConfig("LuaScript"));
				if(luatxt.Trim().Length>0){
					txt_lua.Text = luatxt;
				}
			}catch(Exception e){
				Console.WriteLine(e);
			}
			
			
			if(SettingConfUtils.GetConfig("RunState", false))btn_RunClick(null,null);
			if(SettingConfUtils.GetConfig("PlayPattern", false))Btn_anim_playClick(null,null);
			if(SettingConfUtils.GetConfig("AudioCaptureState", false))Btn_audio_captureClick(null,null);
			
		}
		
		void SaveConfig(){
			Console.WriteLine("Saving Config");
			SettingConfUtils.SetConfig("IsHide", !Visible);
			SettingConfUtils.SetConfig("RefreshRate", (int)nm_refresh.Value);
			SettingConfUtils.SetConfig("FadeSpeed", (int)tb_fadespeed.Value);
			
			foreach(var dev in devices){
				SettingConfUtils.SetConfig("LED_"+dev.LNPDevice.GetSerial(), dev.LEDCount[0]+","+dev.LEDCount[1]);
			}
			
			string ledgroupconfig = "";
			for(int i=0;i<ledgroup.Count;i++){
				Structs.LEDGroup lg = ledgroup[i];
				
				
				if(lg.device == -1){
					ledgroupconfig += "-1\t";
					ledgroupconfig += "-1\t";
					ledgroupconfig += "0\t";
				}else{
					int type = Structs.LEDGroupTypes.GetLEDTypeIndex(lg.type);
					ledgroupconfig += devices[lg.device].LNPDevice.GetSerial() + "\t";
					ledgroupconfig += lg.channel + "\t";
					ledgroupconfig += type + "\t";
				}
				ledgroupconfig += lg.audioStyle + "\t";
				ledgroupconfig += lg.audioChannel + "\t";
				ledgroupconfig += lg.audioStyleEfxColor[0].ToArgb()+"," + lg.audioStyleEfxColor[1].ToArgb()+ "," + lg.audioStyleEfxColor[2].ToArgb() +"," + lg.audioStyleEfxColor[3].ToArgb();
				if(i<ledgroup.Count-1){
					ledgroupconfig += "\n";
				}
				
			}
			
			SettingConfUtils.SetConfig("LEDGroup", Encoding.UTF8.GetBytes(ledgroupconfig));
			
			if(cb_audio_list.SelectedIndex==-1){
				SettingConfUtils.SetConfig("AudioCaptureDevID","");
			}else{
				SettingConfUtils.SetConfig("AudioCaptureDevID",((AudioCapture.AudioDevice)cb_audio_list.Items[cb_audio_list.SelectedIndex]).DeviceID);
			}
			
			SettingConfUtils.SetConfig("AudioCaptureVolume", tb_audio_vol.Value);
			
			
			SettingConfUtils.SetConfig("LuaScript", Encoding.UTF8.GetBytes(txt_lua.Text));
			SettingConfUtils.SetConfig("LastPatternFile", patternlist_file);
			SettingConfUtils.SetConfig("PlayPattern", play);
			SettingConfUtils.SetConfig("ReversePattern", chk_reverse.Checked);
			SettingConfUtils.SetConfig("CurrentLEDView", chk_ledcurrent.Checked);
			SettingConfUtils.SetConfig("RunState", CLupdateThread!=null);
			SettingConfUtils.SetConfig("AudioCaptureState", audiocapture!=null);
		}
		
		
		class LuaFunction{
			
			public Color NewColor(int r, int g, int b){
				return Color.FromArgb(r,g,b);
			}
			
			public int DeviceCount(){
				
				return devices.Count;
			}
			

			public string GetDeviceSerial(int device){
				return devices[device].LNPDevice.GetSerial();
			}
			
			public string GetDeviceName(int device){
				return devices[device].LNPDevice.GetDescription();
			}
			
			public string GetDeviceVersion(int device){
				return devices[device].LNPDevice.GetLNPDeviceVer();
			}
			
			public bool DirectSendLED(int device,int channel, int index, LuaTable table){
				List<Color> c = new List<Color>();
				foreach(var k in table.Keys){
					c.Add((Color)table[k]);
				}
				return devices[device].LNPDevice.SetLEDColorRange(channel, index, c.ToArray());
			}
			
			public bool DirectSendLED(string sernum,int channel, int index, LuaTable table){
				foreach(var dev in devices){
					if(dev.LNPDevice.GetSerial().Equals(sernum)){
						List<Color> c = new List<Color>();
						foreach(var k in table.Keys){
							c.Add((Color)table[k]);
						}
						return dev.LNPDevice.SetLEDColorRange(channel, index, c.ToArray());
						
						//return dev.LNPDevice.SetLEDColorRange(channel, index, colors);
					}
				}
				return false;
			}

			public bool SendConfirm(int device){
				return devices[device].LNPDevice.SendACK();
			}
			
			public bool SendConfirm(string sernum){
				foreach(var dev in devices){
					if(dev.LNPDevice.GetSerial().Equals(sernum)){
						return dev.LNPDevice.SendACK();
					}
				}
				return false;
			}
			
			
			public void SetColor(int device, int channel, LuaTable table){
				if(CLupdateThread!=null){
					List<Color> c = new List<Color>();
					foreach(var k in table.Keys){
						c.Add((Color)table[k]);
					}
					Color[] cc = devices[device].GetChannelLED(channel);
					for(int i=0;i<c.Count;i++){
						if(i<cc.Length){
							cc[i] = c[i];
						}
					}
					if(allblack){allblack=false;CLupdateThread.Interrupt();}
				}
				
			}
			
			public void SetColor(string sernum, int channel, LuaTable table){
				if(CLupdateThread!=null){
					foreach(var dev in devices){
						if(dev.LNPDevice.GetSerial().Equals(sernum)){
							List<Color> c = new List<Color>();
							foreach(var k in table.Keys){
								c.Add((Color)table[k]);
							}
							
							Color[] cc = dev.GetChannelLED(channel);
							for(int i=0;i<c.Count;i++){
								if(i<cc.Length){
									cc[i] = c[i];
								}
							}
							break;
						}
					}
					if(allblack){allblack=false;CLupdateThread.Interrupt();}
				}
				
				
			}
			
			public void ResetColor(int device, int channel){
				devices[device].EmptyLEDColor(channel);
			}
			
			public void ResetColor(string sernum, int channel){
				foreach(var dev in devices){
					if(dev.LNPDevice.GetSerial().Equals(sernum)){
						dev.EmptyLEDColor(channel);
						break;
					}
				}
			}
			
		}
		

		Mutex AcquireMutexLock(){
			try{
				
				while(true){
					bool createNew = false;
					Mutex _mutex = new Mutex(false, MutexName, out createNew);
					bool acquired = _mutex.WaitOne(5000);
					if(!(createNew && acquired)){
						DialogResult result = MessageBox.Show("Another process is using LNP device(s)!\nPlease close the process and retry again.\nOr you can ignore it(Not recommended)", "Fight for LNP", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);
						if(result==DialogResult.Ignore){
							return _mutex;
						}
						if(result==DialogResult.Retry){
							try{
								_mutex.ReleaseMutex();
								_mutex.Dispose();
							}catch(Exception){}
						}
						if(result==DialogResult.Abort){
							return null;
						}
					}else{
						return _mutex;
					}
				}
			}catch(Exception){}
			return null;
		}
		

		

		
		
		
		
		
		
		
		
		
		
		
		
		

		
		
		
		
		
		
		
		
		
	}
}
