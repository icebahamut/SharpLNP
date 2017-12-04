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
	/// Description of frm_ledgroupsetup.
	/// </summary>
	public partial class frm_ledgroupsetup : Form{
		int left = 0;
		public frm_ledgroupsetup(int type, int start, int left){
			InitializeComponent();
			nm_index.Value = start;
			this.left = left;
			txt_left.Text = ""+this.left;
			
			if(type==0){
				cb_type.SelectedIndex = cb_type.Items.Count-1;
			}else{
				cb_type.SelectedIndex = type-1;
			}
			
		}
		void Cb_typeSelectedIndexChanged(object sender, EventArgs e){
			pnl_count.Enabled = false;
			switch(cb_type.SelectedIndex){
				case 0:
					nm_count.Value = 1;
					break;
				case 1:
					nm_count.Value = 12;
					break;
				case 2:
					nm_count.Value = 16;
					break;
				case 3:
					nm_count.Value = 4;
					break;
				case 4:
					nm_count.Value = 10;
					break;
				case 5:
					pnl_count.Enabled=true;
					nm_count.Value = 1;
					break;
			}
		}
		
		
		void Nm_indexValueChanged(object sender, EventArgs e){
			CountLeftOver();
		}
		void Nm_countValueChanged(object sender, EventArgs e){
			CountLeftOver();
		}
		
		void CountLeftOver(){
			int tmp = left - (int)nm_count.Value;
			if(tmp<0){
				txt_left.ForeColor = Color.Red;
			}else{
				txt_left.ForeColor = Color.Black;
			}
			txt_left.Text = ""+tmp;
		}
		
		
		public int SelectedType{
			get{
				if(cb_type.SelectedIndex == cb_type.Items.Count-1){
					return 0;
				}else{
					return cb_type.SelectedIndex+1;
				}
			}
		}
		
		public int Index{
			get{
				return (int)nm_index.Value;
			}
		}
		
		public int Count{
			get{
				return (int)nm_count.Value;
			}
		}
		void Btn_CancelClick(object sender, EventArgs e){
			DialogResult = DialogResult.Cancel;
			Close();
		}
		void Btn_OKClick(object sender, EventArgs e){
			DialogResult = DialogResult.OK;
			Close();
		}

	}
}
