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
using System.Reflection;
using System.Windows.Forms;

namespace SharpLNP
{
	/// <summary>
	/// Description of LED_SP.
	/// </summary>
	public partial class LED_SP : LED{
		public override event LEDEditChangeEventHandler LEDEditChangeEvent;
		
		//Button[] btnled = new Button[1];
		
		public LED_SP(){
			InitializeComponent();
			btnled = new Button[1];
			btnled[0] = btn_led0;
			for(int i=0;i<btnled.Length;i++){
				btnled[i].Click += BtnClick;
				btnled[i].Tag = i;
				typeof(DataGridView).InvokeMember(
					"DoubleBuffered",BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,null,btnled[i],new object[] { true });
				
			}
			OnSelectedChangeEvent += delegate(object sender, bool selected) {
				if(selected){
					lbl_title.BackColor = Color.Blue;
					lbl_title.ForeColor = Color.White;
				}else{
					lbl_title.BackColor = SystemColors.Control;
					lbl_title.ForeColor = SystemColors.ControlText;
				}
			};
		}
		
		public override void BtnClick(object sender, EventArgs e){
			
			Button btn = (Button)sender;
			using(var cd = new ColorDialog()){
				cd.AllowFullOpen = true;
				cd.FullOpen = true;
				cd.Color = btn.BackColor;
				if(cd.ShowDialog() == DialogResult.OK){
					
					
					btn.BackColor = cd.Color;
					if(LEDEditChangeEvent!=null){
						LEDEditChangeEvent(Name, StartIndex,(int)btn.Tag, cd.Color);
					}
				}
			}
		}
		
		public override string Text{
			get{
				return lbl_title.Text;
			}
			set{
				lbl_title.Text = value;
			}
		}

		public override Color[] LEDColor{
			get{
				Color[] colors = new Color[btnled.Length];
				for(int i=0;i<colors.Length;i++){
					colors[i] = btnled[i].BackColor;
				}
				return colors;
			}
			set{
				for(int i=0;i<value.Length;i++){
					if(i<btnled.Length){
						btnled[i].BackColor = value[i];
					}
				}
			}
		}
		void Lbl_titleClick(object sender, EventArgs e){
			Focus();
		}
		void Panel1Click(object sender, EventArgs e){
			Focus();
		}
		void Lbl_xClick(object sender, EventArgs e){
			Parent.Controls.Remove(this);
		}
	}
}
