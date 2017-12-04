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
	partial class frm_fillcolor
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button btn_ok;
		private System.Windows.Forms.Button btn_cancel;
		private System.Windows.Forms.Panel pnl_grad;
		private SharpLNP.ColorSelector color_from;
		private SharpLNP.ColorSelector color_to;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		
		/// <summary>
		/// Disposes resources used by the form.
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
			this.btn_ok = new System.Windows.Forms.Button();
			this.btn_cancel = new System.Windows.Forms.Button();
			this.pnl_grad = new System.Windows.Forms.Panel();
			this.color_from = new SharpLNP.ColorSelector();
			this.color_to = new SharpLNP.ColorSelector();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btn_ok
			// 
			this.btn_ok.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_ok.Location = new System.Drawing.Point(555, 275);
			this.btn_ok.Name = "btn_ok";
			this.btn_ok.Size = new System.Drawing.Size(75, 23);
			this.btn_ok.TabIndex = 0;
			this.btn_ok.Text = "OK";
			this.btn_ok.UseVisualStyleBackColor = true;
			this.btn_ok.Click += new System.EventHandler(this.Btn_okClick);
			// 
			// btn_cancel
			// 
			this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_cancel.Location = new System.Drawing.Point(635, 275);
			this.btn_cancel.Name = "btn_cancel";
			this.btn_cancel.Size = new System.Drawing.Size(75, 23);
			this.btn_cancel.TabIndex = 2;
			this.btn_cancel.Text = "Cancel";
			this.btn_cancel.UseVisualStyleBackColor = true;
			this.btn_cancel.Click += new System.EventHandler(this.Btn_cancelClick);
			// 
			// pnl_grad
			// 
			this.pnl_grad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.pnl_grad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnl_grad.Location = new System.Drawing.Point(5, 230);
			this.pnl_grad.Name = "pnl_grad";
			this.pnl_grad.Size = new System.Drawing.Size(705, 35);
			this.pnl_grad.TabIndex = 2;
			// 
			// color_from
			// 
			this.color_from.Location = new System.Drawing.Point(5, 20);
			this.color_from.MaximumSize = new System.Drawing.Size(350, 203);
			this.color_from.MinimumSize = new System.Drawing.Size(350, 203);
			this.color_from.Name = "color_from";
			this.color_from.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.color_from.Size = new System.Drawing.Size(350, 203);
			this.color_from.TabIndex = 3;
			// 
			// color_to
			// 
			this.color_to.Location = new System.Drawing.Point(360, 20);
			this.color_to.MaximumSize = new System.Drawing.Size(350, 203);
			this.color_to.MinimumSize = new System.Drawing.Size(350, 203);
			this.color_to.Name = "color_to";
			this.color_to.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.color_to.Size = new System.Drawing.Size(350, 203);
			this.color_to.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label1.Location = new System.Drawing.Point(5, 5);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(350, 15);
			this.label1.TabIndex = 4;
			this.label1.Text = "From Color";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label2.Location = new System.Drawing.Point(360, 5);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(350, 15);
			this.label2.TabIndex = 4;
			this.label2.Text = "To Color";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// frm_fillcolor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btn_cancel;
			this.ClientSize = new System.Drawing.Size(720, 308);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.color_to);
			this.Controls.Add(this.color_from);
			this.Controls.Add(this.pnl_grad);
			this.Controls.Add(this.btn_cancel);
			this.Controls.Add(this.btn_ok);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frm_fillcolor";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Color Filler";
			this.ResumeLayout(false);

		}
	}
}
