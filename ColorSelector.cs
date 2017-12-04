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
	/// Description of ColorSelector.
	/// </summary>
	public partial class ColorSelector : UserControl{
		
		public delegate void ColorSelected(Color c);
		public event ColorSelected OnColorChanged;
		
		
		public ColorSelector(){
			InitializeComponent();
			UpdateRGBToHSVView();
			UpdateHSVToRGBView();
		}

		void UpdateHSVToRGBView(){
			Structs.HSV hsv = new Structs.HSV();
			
			hsv.h = (tb_h.Value / 255d);
			hsv.s = tb_s.Value / 255d;
			hsv.v = tb_v.Value / 255d;
			
			Structs.RGB rgb = ColorToolkit.hsv2rgb(hsv);
			
			Color c = ColorToolkit.rgb2color(rgb);
			if(!tb_r.Focused)tb_r.Value = c.R;
			if(!tb_g.Focused)tb_g.Value = c.G;
			if(!tb_b.Focused)tb_b.Value = c.B;

			UpdateTextBox();
			
			pnl_color_view.BackColor = c;
			
		}

		void UpdateRGBToHSVView(){
			Structs.RGB rgb = ColorToolkit.color2rgb(Color.FromArgb(tb_r.Value, tb_g.Value, tb_b.Value));
			
			Structs.HSV hsv = ColorToolkit.rgb2hsv(rgb);
			if(!tb_h.Focused)tb_h.Value = (int)((hsv.h)*255d);
			if(!tb_s.Focused)tb_s.Value = (int)((hsv.s)*255d);
			if(!tb_v.Focused)tb_v.Value = (int)((hsv.v)*255d);
			
			Color c = ColorToolkit.rgb2color(ColorToolkit.hsv2rgb(hsv));
			
			UpdateTextBox();
			
			pnl_color_view.BackColor = Color.FromArgb(tb_r.Value,tb_g.Value,tb_b.Value);
		}
		
		void UpdateTextBox(){
			txt_r.Text = ""+tb_r.Value;
			txt_g.Text = ""+tb_g.Value;
			txt_b.Text = ""+tb_b.Value;
			
			txt_h.Text = string.Format("{0:F2}", tb_h.Value/255f * 100f);
			txt_s.Text = string.Format("{0:F2}", tb_s.Value/255f * 100f);
			txt_v.Text = string.Format("{0:F2}", tb_v.Value/255f * 100f);
			
			if(OnColorChanged!=null){
				OnColorChanged(pnl_color_view.BackColor);
			}
			
		}
		
		void Tb_rValueChanged(object sender, EventArgs e){
			if(tb_r.Focused)UpdateRGBToHSVView();
		}
		
		void Tb_gValueChanged(object sender, EventArgs e){
			if(tb_g.Focused)UpdateRGBToHSVView();
		}
		
		void Tb_bValueChanged(object sender, EventArgs e){
			if(tb_b.Focused)UpdateRGBToHSVView();
		}
		
		void Tb_hValueChanged(object sender, EventArgs e){
			if(tb_h.Focused)UpdateHSVToRGBView();
		}
		
		void Tb_sValueChanged(object sender, EventArgs e){
			if(tb_s.Focused)UpdateHSVToRGBView();
		}
		
		void Tb_vValueChanged(object sender, EventArgs e){
			if(tb_v.Focused)UpdateHSVToRGBView();
		}
		void Txt_rKeyDown(object sender, KeyEventArgs e){
			if(e.KeyCode == Keys.Enter){
				int value = 0;
				if(int.TryParse(txt_r.Text.Trim(), out value)){
					
					if(value>=0 && value<=255){
						tb_r.Value = value;
						UpdateRGBToHSVView();
						return;
					}
				}
				MessageBox.Show("Invalid Value! Only 0-255 allowed!", "Bad Value", MessageBoxButtons.OK, MessageBoxIcon.Error);
				txt_r.Text = ""+tb_r.Value;
			}else if(e.KeyCode == Keys.Escape){
				txt_r.Text = ""+tb_r.Value;
			}
			
		}
		void Txt_rLeave(object sender, EventArgs e){
			int value = 0;
			if(int.TryParse(txt_r.Text.Trim(), out value)){
				
				if(value>=0 && value<=255){
					tb_r.Value = value;
					UpdateRGBToHSVView();
					return;
				}
			}
			MessageBox.Show("Invalid Value! Only 0-255 allowed!", "Bad Value", MessageBoxButtons.OK, MessageBoxIcon.Error);
			txt_r.Text = ""+tb_r.Value;
		}
		
		void Txt_gKeyDown(object sender, KeyEventArgs e){
			if(e.KeyCode == Keys.Enter){
				int value = 0;
				if(int.TryParse(txt_g.Text.Trim(), out value)){
					
					if(value>=0 && value<=255){
						tb_g.Value = value;
						UpdateRGBToHSVView();
						return;
					}
				}
				MessageBox.Show("Invalid Value! Only 0-255 allowed!", "Bad Value", MessageBoxButtons.OK, MessageBoxIcon.Error);
				txt_g.Text = ""+tb_g.Value;
				
			}else if(e.KeyCode == Keys.Escape){
				txt_g.Text = ""+tb_g.Value;
			}
		}
		void Txt_gLeave(object sender, EventArgs e){
			int value = 0;
			if(int.TryParse(txt_g.Text.Trim(), out value)){
				
				if(value>=0 && value<=255){
					tb_g.Value = value;
					UpdateRGBToHSVView();
					return;
				}
			}
			MessageBox.Show("Invalid Value! Only 0-255 allowed!", "Bad Value", MessageBoxButtons.OK, MessageBoxIcon.Error);
			txt_g.Text = ""+tb_g.Value;
		}
		
		void Txt_bKeyDown(object sender, KeyEventArgs e){
			if(e.KeyCode == Keys.Enter){
				int value = 0;
				if(int.TryParse(txt_b.Text.Trim(), out value)){
					
					if(value>=0 && value<=255){
						tb_b.Value = value;
						UpdateRGBToHSVView();
						return;
					}
				}
				MessageBox.Show("Invalid Value! Only 0-255 allowed!", "Bad Value", MessageBoxButtons.OK, MessageBoxIcon.Error);
				txt_b.Text = ""+tb_b.Value;
			}else{
				txt_b.Text = ""+tb_b.Value;
			}
		}
		void Txt_bLeave(object sender, EventArgs e){
			int value = 0;
			if(int.TryParse(txt_b.Text.Trim(), out value)){
				
				if(value>=0 && value<=255){
					tb_b.Value = value;
					UpdateRGBToHSVView();
					return;
				}
			}
			MessageBox.Show("Invalid Value! Only 0-255 allowed!", "Bad Value", MessageBoxButtons.OK, MessageBoxIcon.Error);
			txt_b.Text = ""+tb_b.Value;
		}
		
		void Txt_hKeyDown(object sender, KeyEventArgs e){
			if(e.KeyCode == Keys.Enter){
				float value = 0;
				if(float.TryParse(txt_h.Text.Trim(), out value)){
					if(value>=0 && value<=100f){
						tb_h.Value = (int)((value/100f) * 255f);
						UpdateHSVToRGBView();
						return;
					}
				}
				MessageBox.Show("Invalid Value! Only 0%-100% allowed!", "Bad Value", MessageBoxButtons.OK, MessageBoxIcon.Error);
				txt_h.Text = string.Format("{0:F2}", tb_h.Value/255f * 100f);
			}else if(e.KeyCode == Keys.Escape){
				txt_h.Text = string.Format("{0:F2}", tb_h.Value/255f * 100f);
			}
		}
		void Txt_hLeave(object sender, EventArgs e){
			float value = 0;
			if(float.TryParse(txt_h.Text.Trim(), out value)){
				if(value>=0 && value<=100f){
					tb_h.Value = (int)((value/100f) * 255f);
					UpdateHSVToRGBView();
					return;
				}
			}
			MessageBox.Show("Invalid Value! Only 0%-100% allowed!", "Bad Value", MessageBoxButtons.OK, MessageBoxIcon.Error);
			txt_h.Text = string.Format("{0:F2}", tb_h.Value/255f * 100f);
		}
		
		void Txt_sKeyDown(object sender, KeyEventArgs e){
			if(e.KeyCode == Keys.Enter){
				float value = 0;
				if(float.TryParse(txt_s.Text.Trim(), out value)){
					if(value>=0 && value<=100f){
						tb_s.Value = (int)((value/100f) * 255f);
						UpdateHSVToRGBView();
						return;
					}
				}
				MessageBox.Show("Invalid Value! Only 0%-100% allowed!", "Bad Value", MessageBoxButtons.OK, MessageBoxIcon.Error);
				txt_s.Text = string.Format("{0:F2}", tb_s.Value/255f * 100f);
			}else if(e.KeyCode == Keys.Escape){
				txt_s.Text = string.Format("{0:F2}", tb_s.Value/255f * 100f);
			}
		}
		void Txt_sLeave(object sender, EventArgs e){
			float value = 0;
			if(float.TryParse(txt_s.Text.Trim(), out value)){
				if(value>=0 && value<=100f){
					tb_s.Value = (int)((value/100f) * 255f);
					UpdateHSVToRGBView();
					return;
				}
			}
			MessageBox.Show("Invalid Value! Only 0%-100% allowed!", "Bad Value", MessageBoxButtons.OK, MessageBoxIcon.Error);
			txt_s.Text = string.Format("{0:F2}", tb_s.Value/255f * 100f);
		}
		
		void Txt_vKeyDown(object sender, KeyEventArgs e){
			if(e.KeyCode == Keys.Enter){
				float value = 0;
				if(float.TryParse(txt_v.Text.Trim(), out value)){
					if(value>=0 && value<=100f){
						tb_v.Value = (int)((value/100f) * 255f);
						UpdateHSVToRGBView();
						return;
					}
				}
				MessageBox.Show("Invalid Value! Only 0%-100% allowed!", "Bad Value", MessageBoxButtons.OK, MessageBoxIcon.Error);
				txt_v.Text = string.Format("{0:F2}", tb_v.Value/255f * 100f);
			}else if(e.KeyCode == Keys.Escape){
				txt_v.Text = string.Format("{0:F2}", tb_v.Value/255f * 100f);
			}
		}
		void Txt_vLeave(object sender, EventArgs e){
			float value = 0;
			if(float.TryParse(txt_v.Text.Trim(), out value)){
				if(value>=0 && value<=100f){
					tb_v.Value = (int)((value/100f) * 255f);
					UpdateHSVToRGBView();
					return;
				}
			}
			MessageBox.Show("Invalid Value! Only 0%-100% allowed!", "Bad Value", MessageBoxButtons.OK, MessageBoxIcon.Error);
			txt_v.Text = string.Format("{0:F2}", tb_v.Value/255f * 100f);
		}
		
		public Color SelectedColor{
			get{
				return pnl_color_view.BackColor;
			}
			set{
				tb_r.Value = value.R;
				tb_g.Value = value.G;
				tb_b.Value = value.B;
				UpdateRGBToHSVView();
			}
		}
		
		public Structs.HSV SelectedHSV{
			get{
				Structs.HSV hsv = new Structs.HSV();
				hsv.h = (tb_h.Value / 255d);
				hsv.s = tb_s.Value / 255d;
				hsv.v = tb_v.Value / 255d;
				return hsv;
			}
			set{
				
				tb_h.Value = (int)((value.h)*255d);
				tb_s.Value = (int)((value.s)*255d);
				tb_v.Value = (int)((value.v)*255d);
				UpdateHSVToRGBView();
			}
		}
	}
}
