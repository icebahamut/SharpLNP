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
using System.Drawing;
using System.IO;
using System.Text;

namespace SharpLNP
{
	/// <summary>
	/// Description of PatternFile.
	/// </summary>
	public class PatternFile{
		
		
		public static string LoadFromFile(string filename, List<Structs.Device> devices, out List<Structs.Pattern> lst_pattern, out int delay){
			string[] lines = File.ReadAllLines(filename,Encoding.Unicode);
			
			List<Structs.Pattern> tmp_pat = new List<Structs.Pattern>();
			
			
			int maxled = 0;
			
			bool overmaxled = false;
			
			foreach(var dev in devices){
				for(int i=0;i<dev.LEDCount.Length;i++){
					maxled = Math.Max(dev.LEDCount[i], maxled);
				}
			}
			
			int maxframe = 0;
			int framedelay = 100;
			delay = framedelay;
			lst_pattern = null;
			if(lines.Length==0){
				return "Not valid pattern animation file!";
			}
			
			string[] frameheader = lines[0].Split(new char[]{':'},2);
			
			
			if(frameheader.Length!=2){
				return "Missing frame header info!";
			}
			if(!int.TryParse(frameheader[0].Trim(), out maxframe)){
				return "Bad Max frame value!";
			}
			if(!int.TryParse(frameheader[1].Trim(), out delay)){
				return "Bad frame delay value!";
			}
			
			
			delay = framedelay;
			
			if(maxframe<=0){
				lst_pattern = tmp_pat;
				return null;
			}
			
			if(framedelay<16)framedelay = 16;
			if(framedelay>1000)framedelay = 1000;
			
			
			for(int line=1;line<lines.Length;line++){
				try{
					if(!string.IsNullOrEmpty(lines[line].Trim())){
						string[] headtrackframe = lines[line].Split(new char[]{'='},2);
						if(headtrackframe.Length==2){
							string[] header = headtrackframe[0].Split(new char[]{'\t'},3);
							if(header.Length==3){
								int device = -1;
								int channel = -1;
								
								if(!header[1].Equals("-1")){
									channel = int.Parse(header[2].Trim());
								
									for(int i=0;i<devices.Count;i++){
										if(devices[i].LNPDevice.GetSerial().Equals(header[1])){
											device = i;
											break;
										}
									}
									
									if(device==-1){
										
										channel = -1;
									}else{
										if(channel == -1){
											device = -1;
										}else{
											if(channel>2){
												device = -1;
												channel = -1;
											}
										}
									}
									
									if(device !=-1 && channel !=-1){
										foreach(var pat in tmp_pat){
											if(pat.device == device && pat.channel == channel){
												device = -1;
												channel = -1;
												break;
											}
										}
									}
								}
								
								
								//alloc empty led
								var pattern = new Structs.Pattern();
								pattern.name = header[0];
								pattern.device = device;
								pattern.channel = channel;
								pattern.led = new List<Color[]>();
								for(int i=0;i<maxframe;i++){
									Color[] color = new Color[maxled];
									for(int j=0;j<color.Length;j++){
										color[j] = Color.Black;
									}
									pattern.led.Add(color);
								}
								
								//populate led
								string[] frames = headtrackframe[1].Split(new char[]{'|'});
								int framepos = 0;
								foreach(string frame in frames){
									string[] seekleds = frame.Split(new char[]{'@'},2);
									if(seekleds.Length==2){
										int seek = int.Parse(seekleds[0].Trim());
										if(seek<0)seek=0;
										
										
										if(seek+framepos<maxframe){
										
											Color[] color = pattern.led[framepos+seek];
											
											string[] leds = seekleds[1].Split(new char[]{','});
											//fill LED color
											foreach(string led in leds){
												string[] ledpos = led.Split(new char[]{':'},2);
												if(ledpos.Length==2){
													int pos = int.Parse(ledpos[0].Trim());
													int argb = int.Parse(ledpos[1].Trim());
													if(pos>=0 && pos<maxled){
														color[pos] = Color.FromArgb(255,((argb>>16)&0xFF),((argb>>8)&0xFF),(argb&0xFF));
													}
													if(pos>=maxled){
														overmaxled = true;
													}
												}
											}
											
											pattern.led[framepos+seek] = color;
											
											
											
											framepos += seek;
											framepos++;
										}
									}
									
								}
								
								tmp_pat.Add(pattern);

							}
						}
					}
				}catch(Exception e){
					Console.WriteLine(e);
				}
			}
			lst_pattern = tmp_pat;
			if(overmaxled){
				return "File is load but over LED size limit, will load partial!";
			}else{
				return null;
			}
		}

		public static string SaveToFile(string filename, List<Structs.Device> devices, List<Structs.Pattern> lst_pattern, int framedelay){
			using(var ms = new MemoryStream()){
				try{
					int maxframe = 0;
					foreach(var pat in lst_pattern){
						maxframe = Math.Max(pat.led.Count,maxframe);
					}
					
					byte[] _tmp = Encoding.Unicode.GetBytes(""+maxframe+":"+framedelay+"\n");
					ms.Write(_tmp,0,_tmp.Length);
					
					if(lst_pattern!=null && devices!=null){
						
					
					
						foreach(var pat in lst_pattern){
							string device = "-1";
							string channel = "-1";
							
							if(pat.device!=-1 && pat.channel!=-1){
								if(pat.device<devices.Count){
									device=devices[pat.device].LNPDevice.GetSerial();
									channel=""+pat.channel;
								}
							}
							
							string pat_head = pat.name+"\t"+device+"\t"+pat.channel;
							
							int seek = 0;
							
							string frame = "";
							for(int i=0;i<pat.led.Count;i++){
								//string frame = seek+"\t";
								string led = "";
								for(int l=0;l<pat.led[i].Length;l++){
									if(pat.led[i][l]!=Color.Black){
										//Color c = Color.FromArgb(255,(pat.led[i][l].ToArgb()>>16)&0xFF,(pat.led[i][l].ToArgb()>>8)&0xFF,pat.led[i][l].ToArgb()&0xFF);
										led += l+":"+pat.led[i][l].ToArgb()+",";
									}
								}
								
								if(led.Length>0){
									
									if(led.EndsWith(",",StringComparison.InvariantCultureIgnoreCase)){
										led = led.Remove(led.Length-1,1);
									}
									
									frame += seek+"@"+led+"|";
									seek = 0;
								}else{
									seek++;
								}
								
								
							}
							if(frame.Length>0){
								if(frame.EndsWith("|", StringComparison.InvariantCultureIgnoreCase)){
									frame = frame.Remove(frame.Length-1,1);
								}
							}
							
							string output = pat_head+"="+frame+"\n";
							
							byte[] b = Encoding.Unicode.GetBytes(output);
							ms.Write(b,0,b.Length);
						}
					}
					//return ms;
					File.WriteAllBytes(filename, ms.ToArray());
					return null;
				}catch(Exception e){
					return e.ToString();
				}
				
			}
			
		}
	}
}
