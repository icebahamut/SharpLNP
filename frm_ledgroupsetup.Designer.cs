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
	partial class frm_ledgroupsetup
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.ComboBox cb_type;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown nm_index;
		private System.Windows.Forms.Panel pnl_count;
		private System.Windows.Forms.NumericUpDown nm_count;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txt_left;
		private System.Windows.Forms.Button btn_OK;
		private System.Windows.Forms.Button btn_Cancel;
		
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
			this.cb_type = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.nm_index = new System.Windows.Forms.NumericUpDown();
			this.pnl_count = new System.Windows.Forms.Panel();
			this.nm_count = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txt_left = new System.Windows.Forms.TextBox();
			this.btn_OK = new System.Windows.Forms.Button();
			this.btn_Cancel = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.nm_index)).BeginInit();
			this.pnl_count.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nm_count)).BeginInit();
			this.SuspendLayout();
			// 
			// cb_type
			// 
			this.cb_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cb_type.FormattingEnabled = true;
			this.cb_type.Items.AddRange(new object[] {
			"RGB SP Fan",
			"RGB HD Fan",
			"RGB LL Fan",
			"RGB ML Fan",
			"RGB Strip",
			"Custom"});
			this.cb_type.Location = new System.Drawing.Point(90, 10);
			this.cb_type.Name = "cb_type";
			this.cb_type.Size = new System.Drawing.Size(130, 20);
			this.cb_type.TabIndex = 0;
			this.cb_type.SelectedIndexChanged += new System.EventHandler(this.Cb_typeSelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(5, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 20);
			this.label1.TabIndex = 1;
			this.label1.Text = "LED Type";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(5, 35);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 20);
			this.label2.TabIndex = 2;
			this.label2.Text = "Start Index";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// nm_index
			// 
			this.nm_index.Location = new System.Drawing.Point(90, 35);
			this.nm_index.Maximum = new decimal(new int[] {
			127,
			0,
			0,
			0});
			this.nm_index.Name = "nm_index";
			this.nm_index.Size = new System.Drawing.Size(130, 19);
			this.nm_index.TabIndex = 3;
			this.nm_index.ValueChanged += new System.EventHandler(this.Nm_indexValueChanged);
			// 
			// pnl_count
			// 
			this.pnl_count.Controls.Add(this.nm_count);
			this.pnl_count.Controls.Add(this.label3);
			this.pnl_count.Enabled = false;
			this.pnl_count.Location = new System.Drawing.Point(225, 10);
			this.pnl_count.Name = "pnl_count";
			this.pnl_count.Size = new System.Drawing.Size(125, 20);
			this.pnl_count.TabIndex = 4;
			// 
			// nm_count
			// 
			this.nm_count.Location = new System.Drawing.Point(65, 0);
			this.nm_count.Maximum = new decimal(new int[] {
			127,
			0,
			0,
			0});
			this.nm_count.Minimum = new decimal(new int[] {
			1,
			0,
			0,
			0});
			this.nm_count.Name = "nm_count";
			this.nm_count.Size = new System.Drawing.Size(55, 19);
			this.nm_count.TabIndex = 3;
			this.nm_count.Value = new decimal(new int[] {
			1,
			0,
			0,
			0});
			this.nm_count.ValueChanged += new System.EventHandler(this.Nm_countValueChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(0, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(45, 20);
			this.label3.TabIndex = 2;
			this.label3.Text = "Count";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(5, 70);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(60, 20);
			this.label4.TabIndex = 2;
			this.label4.Text = "LED Left:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txt_left
			// 
			this.txt_left.ForeColor = System.Drawing.Color.Black;
			this.txt_left.Location = new System.Drawing.Point(90, 70);
			this.txt_left.Name = "txt_left";
			this.txt_left.ReadOnly = true;
			this.txt_left.Size = new System.Drawing.Size(50, 19);
			this.txt_left.TabIndex = 5;
			this.txt_left.Text = "0";
			this.txt_left.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// btn_OK
			// 
			this.btn_OK.Location = new System.Drawing.Point(195, 70);
			this.btn_OK.Name = "btn_OK";
			this.btn_OK.Size = new System.Drawing.Size(75, 23);
			this.btn_OK.TabIndex = 6;
			this.btn_OK.Text = "OK";
			this.btn_OK.UseVisualStyleBackColor = true;
			this.btn_OK.Click += new System.EventHandler(this.Btn_OKClick);
			// 
			// btn_Cancel
			// 
			this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_Cancel.Location = new System.Drawing.Point(275, 70);
			this.btn_Cancel.Name = "btn_Cancel";
			this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
			this.btn_Cancel.TabIndex = 6;
			this.btn_Cancel.Text = "Cancel";
			this.btn_Cancel.UseVisualStyleBackColor = true;
			this.btn_Cancel.Click += new System.EventHandler(this.Btn_CancelClick);
			// 
			// frm_ledgroupsetup
			// 
			this.AcceptButton = this.btn_OK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btn_Cancel;
			this.ClientSize = new System.Drawing.Size(356, 103);
			this.Controls.Add(this.btn_Cancel);
			this.Controls.Add(this.btn_OK);
			this.Controls.Add(this.txt_left);
			this.Controls.Add(this.pnl_count);
			this.Controls.Add(this.nm_index);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cb_type);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frm_ledgroupsetup";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "LED Group Setup";
			((System.ComponentModel.ISupportInitialize)(this.nm_index)).EndInit();
			this.pnl_count.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nm_count)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
