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
using System.Windows.Forms;

namespace SharpLNP
{
	/// <summary>
	/// Description of frm_patternlist.
	/// </summary>
	public partial class frm_patternlist : Form{
		BindingList<string> patternlist = new BindingList<string>();
		List<Structs.Device> devices = new List<Structs.Device>();
		List<Structs.Pattern> pattern = new List<Structs.Pattern>();
		int framedelay = 100;
		
		
		public frm_patternlist(List<Structs.Device> devices, List<Structs.Pattern> pattern, int framedelay, string selected){
			InitializeComponent();
			
			this.devices = devices;
			this.pattern = pattern;
			this.framedelay = framedelay;
			lst_pattern.DataSource = patternlist;
			
			RefreshList();
			try{
				
				string name = Uri.UnescapeDataString(Path.GetFileNameWithoutExtension(selected));
				for(int i=0;i<patternlist.Count;i++){
					if(name.Equals(patternlist[i])){
						lst_pattern.SelectedIndex = i;
						break;
					}
				}
			}catch(Exception){}
		}
		
		void Btn_loadClick(object sender, EventArgs e){
			if(lst_pattern.SelectedIndex==-1){
				return;
			}
			
			DialogResult = DialogResult.OK;
		}
		
		public string Selected{
			get{
				return Uri.EscapeUriString(patternlist[lst_pattern.SelectedIndex]);
			}
		}
		
		void Btn_saveClick(object sender, EventArgs e){
			using(var frm = new Form()){
				frm.Text = "Enter Name";
				frm.Size = new Size(200,100);
				frm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
				frm.StartPosition = FormStartPosition.CenterParent;
				frm.ShowIcon = false;
				frm.ShowInTaskbar = false;
				frm.MaximizeBox = false;
				frm.MinimizeBox = false;
				TextBox txt = new TextBox();
				txt.Location = new Point(5,10);
				txt.Size = new Size(180,25);
				
				if(lst_pattern.SelectedIndex!=-1){
					txt.Text = patternlist[lst_pattern.SelectedIndex];
				}
				
				Button btn1 = new Button();
				btn1.Text = "OK";
				btn1.Size = new Size(70,25);
				btn1.Location = new Point(30,35);
				Button btn2 = new Button();
				btn2.Text = "Cancel";
				btn2.Size = new Size(70,25);
				btn2.Location = new Point(115,35);
				
				frm.Controls.Add(txt);
				frm.Controls.Add(btn1);
				frm.Controls.Add(btn2);
				
				frm.AcceptButton = btn1;
				frm.CancelButton = btn2;
				
				
				btn1.Click += delegate {
					try{
						if(string.IsNullOrEmpty(txt.Text)){
							MessageBox.Show("Name cannot be empty!", "Enter Name", MessageBoxButtons.OK, MessageBoxIcon.Information);
							return;
						}
						
						if(!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory+"/pattern")){
							Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory+"/pattern");
						}
						
						string uri = Uri.EscapeDataString(txt.Text);
						string filename = AppDomain.CurrentDomain.BaseDirectory+"/pattern/"+uri+".pat";
						if(File.Exists(filename)){
							if(MessageBox.Show("Same name exist, replace it?", "Replace?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.No){
								return;
							}
						}
						
						
						
						File.Delete(filename);
						PatternFile.SaveToFile(filename, devices, pattern, framedelay);
						RefreshList();
						frm.Close();
					}catch(Exception ex){
						MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				};
				
				frm.ShowDialog();
			}
		}
		
		void Btn_deleteClick(object sender, EventArgs e){
			if(lst_pattern.SelectedIndex==-1){
				return;
			}
			
			try{
				if(MessageBox.Show("Are you sure you want to delete '"+lst_pattern.SelectedItem+"'?", "Delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes){
					string name = patternlist[lst_pattern.SelectedIndex];
					string uri = Uri.EscapeDataString(name);
					string filename = AppDomain.CurrentDomain.BaseDirectory+"/pattern/"+uri+".pat";
					File.Delete(filename);
					RefreshList();
				}
			}catch(Exception ex){
				MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		
		
		void RefreshList(){
			try{
				int selected = lst_pattern.SelectedIndex;
				patternlist.Clear();
				
				if(!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory+"/pattern")){
					Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory+"/pattern");
				}
				
				string[] files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory+"/pattern");
				foreach(var file in files){
					string uri = Path.GetFileNameWithoutExtension(file);
					string name = Uri.UnescapeDataString(uri);
					patternlist.Add(name);
				}
				
				//patternlist.ResetBindings();
				
				if(selected!=-1){
					if(selected<patternlist.Count){
						lst_pattern.SelectedIndex = selected;
					}else{
						lst_pattern.SelectedIndex = patternlist.Count-1;
					}
				}
			}catch(Exception e){
				MessageBox.Show(e.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		
		void Lst_patternSelectedIndexChanged(object sender, EventArgs e){
			btn_delete.Enabled = false;
			btn_load.Enabled = false;
			if(lst_pattern.SelectedIndex != -1){
				btn_load.Enabled = true;
				btn_delete.Enabled = true;
			}
		}
		
		
		
		
	}
}
