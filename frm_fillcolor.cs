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
	/// Description of frm_fillcolor.
	/// </summary>
	public partial class frm_fillcolor : Form{
		Bitmap bitmap;
		
		
		public frm_fillcolor(){
			InitializeComponent();
			
			PropertyInfo aProp =typeof(Control).GetProperty("DoubleBuffered",BindingFlags.NonPublic |BindingFlags.Instance);
			aProp.SetValue(pnl_grad, true, null);
			
			bitmap = new Bitmap(pnl_grad.Width,1);
			pnl_grad.BackgroundImage = bitmap;
			
			//color_from.SelectedHSV = Structs
			Structs.HSV color = new Structs.HSV();
			color.h = 0;
			color.s = 1;
			color.v = 1;
			color_from.SelectedHSV = color;
			
			color = new Structs.HSV();
			color.h = 1;
			color.s = 1;
			color.v = 1;
			color_to.SelectedHSV = color;
			
			color_from.OnColorChanged += delegate {
				UpdateGradient(color_from.SelectedHSV, color_to.SelectedHSV);
			};
			
			color_to.OnColorChanged += delegate {
				UpdateGradient(color_from.SelectedHSV, color_to.SelectedHSV);
			};
			
			UpdateGradient(color_from.SelectedHSV, color_to.SelectedHSV);
		}
		
		void UpdateGradient(Structs.HSV start , Structs.HSV end){
			using(Graphics g = Graphics.FromImage(bitmap)){
				
				using(SolidBrush brush = new SolidBrush(Color.Black)){
					double h_step = (end.h - start.h)/(double)pnl_grad.Width;
					double s_step = (end.s - start.s)/(double)pnl_grad.Width;
					double v_step = (end.v - start.v)/(double)pnl_grad.Width;

					Structs.HSV newhsv = new Structs.HSV();
					newhsv.h = start.h;
					newhsv.s = start.s;
					newhsv.v = start.v;
					
					for(int x=0;x<bitmap.Width;x++){

						
						brush.Color = ColorToolkit.rgb2color(ColorToolkit.hsv2rgb(newhsv));
						
						g.FillRectangle(brush, x,0,1,1);
						
						newhsv.h += h_step;
						newhsv.s += s_step;
						newhsv.v += v_step;
						
						if(newhsv.h<0)newhsv.h = 0;
						if(newhsv.h>1)newhsv.h = 1;
						if(newhsv.s<0)newhsv.s = 0;
						if(newhsv.s>1)newhsv.s = 1;
						if(newhsv.v<0)newhsv.v = 0;
						if(newhsv.v>1)newhsv.v = 1;
						
					}
					
				}
			}

			pnl_grad.Refresh();
		
		}
		
		public Structs.HSV StartColor{
			get{
				return color_from.SelectedHSV;
			}
		}
		
		public Structs.HSV EndColor{
			get{
				return color_to.SelectedHSV;
			}
		}
		void Btn_okClick(object sender, EventArgs e){
			DialogResult = DialogResult.OK;
		}
		void Btn_cancelClick(object sender, EventArgs e){
			DialogResult = DialogResult.Cancel;
		}
		

		
			
	}
}
