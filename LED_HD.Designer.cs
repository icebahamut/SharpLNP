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

namespace SharpLNP
{
	partial class LED_HD
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label lbl_x;
		private System.Windows.Forms.Label lbl_title;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btn_led10;
		private System.Windows.Forms.Button btn_led1;
		private System.Windows.Forms.Button btn_led0;
		private System.Windows.Forms.Button btn_led2;
		private System.Windows.Forms.Button btn_led3;
		private System.Windows.Forms.Button btn_led7;
		private System.Windows.Forms.Button btn_led9;
		private System.Windows.Forms.Button btn_led6;
		private System.Windows.Forms.Button btn_led5;
		private System.Windows.Forms.Button btn_led8;
		private System.Windows.Forms.Button btn_led4;
		private System.Windows.Forms.Button btn_led11;
		
		/// <summary>
		/// Disposes resources used by the control.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.lbl_x = new System.Windows.Forms.Label();
			this.lbl_title = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btn_led10 = new System.Windows.Forms.Button();
			this.btn_led7 = new System.Windows.Forms.Button();
			this.btn_led9 = new System.Windows.Forms.Button();
			this.btn_led6 = new System.Windows.Forms.Button();
			this.btn_led5 = new System.Windows.Forms.Button();
			this.btn_led8 = new System.Windows.Forms.Button();
			this.btn_led4 = new System.Windows.Forms.Button();
			this.btn_led11 = new System.Windows.Forms.Button();
			this.btn_led3 = new System.Windows.Forms.Button();
			this.btn_led0 = new System.Windows.Forms.Button();
			this.btn_led2 = new System.Windows.Forms.Button();
			this.btn_led1 = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lbl_x
			// 
			this.lbl_x.BackColor = System.Drawing.Color.Red;
			this.lbl_x.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbl_x.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_x.ForeColor = System.Drawing.Color.White;
			this.lbl_x.Location = new System.Drawing.Point(135, 0);
			this.lbl_x.Name = "lbl_x";
			this.lbl_x.Size = new System.Drawing.Size(15, 15);
			this.lbl_x.TabIndex = 3;
			this.lbl_x.Text = "X";
			this.lbl_x.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lbl_x.Click += new System.EventHandler(this.Lbl_xClick);
			// 
			// lbl_title
			// 
			this.lbl_title.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbl_title.Location = new System.Drawing.Point(0, 0);
			this.lbl_title.Name = "lbl_title";
			this.lbl_title.Size = new System.Drawing.Size(135, 15);
			this.lbl_title.TabIndex = 5;
			this.lbl_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lbl_title.Click += new System.EventHandler(this.Lbl_titleClick);
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.btn_led10);
			this.panel1.Controls.Add(this.btn_led7);
			this.panel1.Controls.Add(this.btn_led9);
			this.panel1.Controls.Add(this.btn_led6);
			this.panel1.Controls.Add(this.btn_led5);
			this.panel1.Controls.Add(this.btn_led8);
			this.panel1.Controls.Add(this.btn_led4);
			this.panel1.Controls.Add(this.btn_led11);
			this.panel1.Controls.Add(this.btn_led3);
			this.panel1.Controls.Add(this.btn_led0);
			this.panel1.Controls.Add(this.btn_led2);
			this.panel1.Controls.Add(this.btn_led1);
			this.panel1.Location = new System.Drawing.Point(0, 15);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(150, 150);
			this.panel1.TabIndex = 4;
			this.panel1.Click += new System.EventHandler(this.Panel1Click);
			// 
			// btn_led10
			// 
			this.btn_led10.BackColor = System.Drawing.Color.Black;
			this.btn_led10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_led10.Location = new System.Drawing.Point(130, 85);
			this.btn_led10.Name = "btn_led10";
			this.btn_led10.Size = new System.Drawing.Size(20, 20);
			this.btn_led10.TabIndex = 0;
			this.btn_led10.UseVisualStyleBackColor = false;
			// 
			// btn_led7
			// 
			this.btn_led7.BackColor = System.Drawing.Color.Black;
			this.btn_led7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_led7.Location = new System.Drawing.Point(45, 130);
			this.btn_led7.Name = "btn_led7";
			this.btn_led7.Size = new System.Drawing.Size(20, 20);
			this.btn_led7.TabIndex = 0;
			this.btn_led7.UseVisualStyleBackColor = false;
			// 
			// btn_led9
			// 
			this.btn_led9.BackColor = System.Drawing.Color.Black;
			this.btn_led9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_led9.Location = new System.Drawing.Point(115, 115);
			this.btn_led9.Name = "btn_led9";
			this.btn_led9.Size = new System.Drawing.Size(20, 20);
			this.btn_led9.TabIndex = 0;
			this.btn_led9.UseVisualStyleBackColor = false;
			// 
			// btn_led6
			// 
			this.btn_led6.BackColor = System.Drawing.Color.Black;
			this.btn_led6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_led6.Location = new System.Drawing.Point(15, 115);
			this.btn_led6.Name = "btn_led6";
			this.btn_led6.Size = new System.Drawing.Size(20, 20);
			this.btn_led6.TabIndex = 0;
			this.btn_led6.UseVisualStyleBackColor = false;
			// 
			// btn_led5
			// 
			this.btn_led5.BackColor = System.Drawing.Color.Black;
			this.btn_led5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_led5.Location = new System.Drawing.Point(0, 85);
			this.btn_led5.Name = "btn_led5";
			this.btn_led5.Size = new System.Drawing.Size(20, 20);
			this.btn_led5.TabIndex = 0;
			this.btn_led5.UseVisualStyleBackColor = false;
			// 
			// btn_led8
			// 
			this.btn_led8.BackColor = System.Drawing.Color.Black;
			this.btn_led8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_led8.Location = new System.Drawing.Point(85, 130);
			this.btn_led8.Name = "btn_led8";
			this.btn_led8.Size = new System.Drawing.Size(20, 20);
			this.btn_led8.TabIndex = 0;
			this.btn_led8.UseVisualStyleBackColor = false;
			// 
			// btn_led4
			// 
			this.btn_led4.BackColor = System.Drawing.Color.Black;
			this.btn_led4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_led4.Location = new System.Drawing.Point(0, 45);
			this.btn_led4.Name = "btn_led4";
			this.btn_led4.Size = new System.Drawing.Size(20, 20);
			this.btn_led4.TabIndex = 0;
			this.btn_led4.UseVisualStyleBackColor = false;
			// 
			// btn_led11
			// 
			this.btn_led11.BackColor = System.Drawing.Color.Black;
			this.btn_led11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_led11.Location = new System.Drawing.Point(130, 45);
			this.btn_led11.Name = "btn_led11";
			this.btn_led11.Size = new System.Drawing.Size(20, 20);
			this.btn_led11.TabIndex = 0;
			this.btn_led11.UseVisualStyleBackColor = false;
			// 
			// btn_led3
			// 
			this.btn_led3.BackColor = System.Drawing.Color.Black;
			this.btn_led3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_led3.Location = new System.Drawing.Point(15, 15);
			this.btn_led3.Name = "btn_led3";
			this.btn_led3.Size = new System.Drawing.Size(20, 20);
			this.btn_led3.TabIndex = 0;
			this.btn_led3.UseVisualStyleBackColor = false;
			// 
			// btn_led0
			// 
			this.btn_led0.BackColor = System.Drawing.Color.Black;
			this.btn_led0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_led0.Location = new System.Drawing.Point(115, 15);
			this.btn_led0.Name = "btn_led0";
			this.btn_led0.Size = new System.Drawing.Size(20, 20);
			this.btn_led0.TabIndex = 0;
			this.btn_led0.UseVisualStyleBackColor = false;
			// 
			// btn_led2
			// 
			this.btn_led2.BackColor = System.Drawing.Color.Black;
			this.btn_led2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_led2.Location = new System.Drawing.Point(45, 0);
			this.btn_led2.Name = "btn_led2";
			this.btn_led2.Size = new System.Drawing.Size(20, 20);
			this.btn_led2.TabIndex = 0;
			this.btn_led2.UseVisualStyleBackColor = false;
			// 
			// btn_led1
			// 
			this.btn_led1.BackColor = System.Drawing.Color.Black;
			this.btn_led1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_led1.Location = new System.Drawing.Point(85, 0);
			this.btn_led1.Name = "btn_led1";
			this.btn_led1.Size = new System.Drawing.Size(20, 20);
			this.btn_led1.TabIndex = 0;
			this.btn_led1.UseVisualStyleBackColor = false;
			// 
			// LED_HD
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.lbl_x);
			this.Controls.Add(this.lbl_title);
			this.Controls.Add(this.panel1);
			this.Name = "LED_HD";
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
	}
}
