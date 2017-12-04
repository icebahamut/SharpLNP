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
	/// Description of LED.
	/// </summary>
	public partial class LED : UserControl{
		
		
		public delegate void SelectedEventHandler(object sender, bool selected);
		public virtual event SelectedEventHandler OnSelectedChangeEvent;
		
		public delegate void LEDEditChangeEventHandler(string id, int index, int led, Color color);
		public virtual event LEDEditChangeEventHandler LEDEditChangeEvent;
		
		public bool Selected;
		public Button[] btnled = new Button[0];
		
		public LED(){
			InitializeComponent();
		}
		
		public virtual void BtnClick(object sender, EventArgs e){}
		
		public virtual string Text{
			get;
			set;
		}
		
		public int StartIndex{
			get;set;
		}
		
		public virtual Color[] LEDColor{
			get;
			set;
		}
		
		public void LEDLeave(object sender, EventArgs e){
			Selected = false;
			if(OnSelectedChangeEvent!=null){
				OnSelectedChangeEvent(this, Selected);
			}
		}
		public void LEDEnter(object sender, EventArgs e){
			Selected = true;
			if(OnSelectedChangeEvent!=null){
				OnSelectedChangeEvent(this, Selected);
			}
		}

		
	}
}
