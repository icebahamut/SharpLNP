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
	partial class frm_config
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cb_ch1;
		private System.Windows.Forms.ComboBox cb_ch2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btn_ok;
		private System.Windows.Forms.Button btn_cancel;
		private System.Windows.Forms.Label label4;
		
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
			this.label1 = new System.Windows.Forms.Label();
			this.cb_ch1 = new System.Windows.Forms.ComboBox();
			this.cb_ch2 = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.btn_ok = new System.Windows.Forms.Button();
			this.btn_cancel = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(15, 5);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(180, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "LED per Channel";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cb_ch1
			// 
			this.cb_ch1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cb_ch1.FormattingEnabled = true;
			this.cb_ch1.Items.AddRange(new object[] {
			"50",
			"100",
			"150"});
			this.cb_ch1.Location = new System.Drawing.Point(90, 25);
			this.cb_ch1.Name = "cb_ch1";
			this.cb_ch1.Size = new System.Drawing.Size(106, 20);
			this.cb_ch1.TabIndex = 1;
			// 
			// cb_ch2
			// 
			this.cb_ch2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cb_ch2.FormattingEnabled = true;
			this.cb_ch2.Items.AddRange(new object[] {
			"50",
			"100",
			"150"});
			this.cb_ch2.Location = new System.Drawing.Point(90, 50);
			this.cb_ch2.Name = "cb_ch2";
			this.cb_ch2.Size = new System.Drawing.Size(106, 20);
			this.cb_ch2.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(15, 25);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(60, 20);
			this.label2.TabIndex = 2;
			this.label2.Text = "Channel 1";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(15, 50);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(60, 20);
			this.label3.TabIndex = 2;
			this.label3.Text = "Channel 2";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btn_ok
			// 
			this.btn_ok.Location = new System.Drawing.Point(60, 165);
			this.btn_ok.Name = "btn_ok";
			this.btn_ok.Size = new System.Drawing.Size(75, 23);
			this.btn_ok.TabIndex = 3;
			this.btn_ok.Text = "OK";
			this.btn_ok.UseVisualStyleBackColor = true;
			this.btn_ok.Click += new System.EventHandler(this.Btn_okClick);
			// 
			// btn_cancel
			// 
			this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_cancel.Location = new System.Drawing.Point(140, 165);
			this.btn_cancel.Name = "btn_cancel";
			this.btn_cancel.Size = new System.Drawing.Size(75, 23);
			this.btn_cancel.TabIndex = 3;
			this.btn_cancel.Text = "Cancel";
			this.btn_cancel.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(5, 80);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(225, 85);
			this.label4.TabIndex = 4;
			this.label4.Text = "More LED longer time to finish transfer and refresh rate will be slower\r\n\r\n\r\nWarn" +
	"ing: All LED group will be remove, include audio LED group. Pattern size will be" +
	" update as well.";
			// 
			// frm_config
			// 
			this.AcceptButton = this.btn_ok;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btn_cancel;
			this.ClientSize = new System.Drawing.Size(234, 196);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.btn_cancel);
			this.Controls.Add(this.btn_ok);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cb_ch2);
			this.Controls.Add(this.cb_ch1);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frm_config";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Device LED Config";
			this.ResumeLayout(false);

		}
	}
}
