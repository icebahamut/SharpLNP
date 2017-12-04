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
using System.Windows.Forms;

namespace SharpLNP
{
	/// <summary>
	/// Description of frm_ledconfig.
	/// </summary>
	public partial class frm_ledconfig : Form{
		BindingList<Structs.Device> devices;
		public frm_ledconfig(BindingList<Structs.Device> devices, int type){
			this.devices = devices;
			
			InitializeComponent();
			
			cb_dev.DataSource = devices;

			if(cb_dev.Items.Count>0){
				cb_dev.SelectedIndex = 0;
			}
			
			if(cb_ch.Items.Count>0){
				cb_ch.SelectedIndex = 0;
			}
			
			List<Structs.LEDGroupType> _list = Structs.LEDGroupTypes.GetTypeList;
			
			BindingList<Structs.LEDGroupType> list = new BindingList<Structs.LEDGroupType>();
			for(int i=1;i<_list.Count;i++){
				list.Add(_list[i]);
			}
			
			cb_ledtype.DataSource = list;
			
			if(type<0)type = 0;
			if(type>=cb_ledtype.Items.Count)type = 0;
			
			cb_ledtype.SelectedIndex = type;
		}
		
		public int SelectedType{
			get{
				return Structs.LEDGroupTypes.GetLEDTypeIndex((Structs.LEDGroupType)cb_ledtype.SelectedItem);
			}
		}
		
		public int SelectedChannel{
			get{
				return cb_ch.SelectedIndex;
			}
		}
		
		public int SelectedDevice{
			get{
				return cb_dev.SelectedIndex;
			}
		}
		
		void btn_OKClick(object sender, EventArgs e){
			if(cb_ledtype.SelectedIndex==-1){
				MessageBox.Show("Select LED Type!");
				return;
			}
			if(cb_dev.SelectedIndex==-1){
				MessageBox.Show("Select Device!");
				return;
			}
			if(cb_ch.SelectedIndex==-1){
				MessageBox.Show("Select Channel!");
				return;
			}
			DialogResult = DialogResult.OK;
			Close();
		}
		void btn_CancelClick(object sender, EventArgs e){
			DialogResult = DialogResult.Cancel;
			Close();
		}
		
		void Cb_devSelectedIndexChanged(object sender, EventArgs e){
			if(cb_dev.SelectedIndex!=-1){
				cb_ch.Items.Clear();
				for(int i=0;i<Program.ChannelCount;i++){
					cb_ch.Items.Add((i+1)+"");
				}
				if(cb_ch.Items.Count>0){
					cb_ch.SelectedIndex = 0;
				}
			}
		}
	}
}
