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
	partial class frm_ledconfig
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.ComboBox cb_ledtype;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btn_ok;
		private System.Windows.Forms.Button btn_cancel;
		private System.Windows.Forms.ComboBox cb_dev;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cb_ch;
		private System.Windows.Forms.Label label3;
		
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
			this.cb_ledtype = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btn_ok = new System.Windows.Forms.Button();
			this.btn_cancel = new System.Windows.Forms.Button();
			this.cb_dev = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cb_ch = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// cb_ledtype
			// 
			this.cb_ledtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cb_ledtype.FormattingEnabled = true;
			this.cb_ledtype.Location = new System.Drawing.Point(90, 10);
			this.cb_ledtype.Name = "cb_ledtype";
			this.cb_ledtype.Size = new System.Drawing.Size(155, 20);
			this.cb_ledtype.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(5, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(70, 20);
			this.label1.TabIndex = 1;
			this.label1.Text = "LED Type";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btn_ok
			// 
			this.btn_ok.Location = new System.Drawing.Point(50, 105);
			this.btn_ok.Name = "btn_ok";
			this.btn_ok.Size = new System.Drawing.Size(75, 23);
			this.btn_ok.TabIndex = 2;
			this.btn_ok.Text = "OK";
			this.btn_ok.UseVisualStyleBackColor = true;
			this.btn_ok.Click += new System.EventHandler(this.btn_OKClick);
			// 
			// btn_cancel
			// 
			this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_cancel.Location = new System.Drawing.Point(130, 105);
			this.btn_cancel.Name = "btn_cancel";
			this.btn_cancel.Size = new System.Drawing.Size(75, 23);
			this.btn_cancel.TabIndex = 2;
			this.btn_cancel.Text = "Cancel";
			this.btn_cancel.UseVisualStyleBackColor = true;
			this.btn_cancel.Click += new System.EventHandler(this.btn_CancelClick);
			// 
			// cb_dev
			// 
			this.cb_dev.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cb_dev.FormattingEnabled = true;
			this.cb_dev.Location = new System.Drawing.Point(90, 35);
			this.cb_dev.Name = "cb_dev";
			this.cb_dev.Size = new System.Drawing.Size(155, 20);
			this.cb_dev.TabIndex = 0;
			this.cb_dev.SelectedIndexChanged += new System.EventHandler(this.Cb_devSelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(5, 35);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(85, 20);
			this.label2.TabIndex = 1;
			this.label2.Text = "To Device";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cb_ch
			// 
			this.cb_ch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cb_ch.FormattingEnabled = true;
			this.cb_ch.Location = new System.Drawing.Point(90, 60);
			this.cb_ch.Name = "cb_ch";
			this.cb_ch.Size = new System.Drawing.Size(155, 20);
			this.cb_ch.TabIndex = 0;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(5, 60);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(85, 20);
			this.label3.TabIndex = 1;
			this.label3.Text = "To Channel";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// frm_ledconfig
			// 
			this.AcceptButton = this.btn_ok;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btn_cancel;
			this.ClientSize = new System.Drawing.Size(256, 135);
			this.Controls.Add(this.btn_cancel);
			this.Controls.Add(this.btn_ok);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cb_ch);
			this.Controls.Add(this.cb_dev);
			this.Controls.Add(this.cb_ledtype);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frm_ledconfig";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "LED Config";
			this.ResumeLayout(false);

		}
	}
}
