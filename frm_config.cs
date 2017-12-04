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
using System.Drawing;
using System.Windows.Forms;

namespace SharpLNP
{
	/// <summary>
	/// Description of frm_config.
	/// </summary>
	public partial class frm_config : Form{
		
		
		public frm_config(int ch1, int ch2){
			InitializeComponent();
			int _ch1 = ((ch1/50)+(ch1%50==0?0:1))-1;
			int _ch2 = ((ch2/50)+(ch2%50==0?0:1))-1;
			if(_ch1>2)_ch1=2;
			if(_ch2>2)_ch2=2;
			
			cb_ch1.SelectedIndex = _ch1;
			cb_ch2.SelectedIndex = _ch2;
		}
		void Btn_okClick(object sender, EventArgs e){
			if(MessageBox.Show("All LED group will be remove, including audio LED group\nPattern size will be resize too!\nThe changes not able to undo!\nAre you sure you want to change LED number?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No){
				return;
			}
			DialogResult = DialogResult.OK;
		}
		
		public int Channel1{
			get{
				return (cb_ch1.SelectedIndex+1)*50;
			}
		}
		public int Channel2{
			get{
				return (cb_ch2.SelectedIndex+1)*50;
			}
		}
	}
}
