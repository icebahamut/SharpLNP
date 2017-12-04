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
	partial class frm_patternlist
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.ListBox lst_pattern;
		private System.Windows.Forms.Button btn_save;
		private System.Windows.Forms.Button btn_delete;
		private System.Windows.Forms.Button btn_load;
		
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
			this.lst_pattern = new System.Windows.Forms.ListBox();
			this.btn_save = new System.Windows.Forms.Button();
			this.btn_delete = new System.Windows.Forms.Button();
			this.btn_load = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lst_pattern
			// 
			this.lst_pattern.FormattingEnabled = true;
			this.lst_pattern.ItemHeight = 12;
			this.lst_pattern.Location = new System.Drawing.Point(5, 5);
			this.lst_pattern.Name = "lst_pattern";
			this.lst_pattern.Size = new System.Drawing.Size(295, 268);
			this.lst_pattern.TabIndex = 0;
			this.lst_pattern.SelectedIndexChanged += new System.EventHandler(this.Lst_patternSelectedIndexChanged);
			// 
			// btn_save
			// 
			this.btn_save.Location = new System.Drawing.Point(115, 280);
			this.btn_save.Name = "btn_save";
			this.btn_save.Size = new System.Drawing.Size(75, 23);
			this.btn_save.TabIndex = 1;
			this.btn_save.Text = "Save";
			this.btn_save.UseVisualStyleBackColor = true;
			this.btn_save.Click += new System.EventHandler(this.Btn_saveClick);
			// 
			// btn_delete
			// 
			this.btn_delete.Location = new System.Drawing.Point(225, 280);
			this.btn_delete.Name = "btn_delete";
			this.btn_delete.Size = new System.Drawing.Size(75, 23);
			this.btn_delete.TabIndex = 1;
			this.btn_delete.Text = "Delete";
			this.btn_delete.UseVisualStyleBackColor = true;
			this.btn_delete.Click += new System.EventHandler(this.Btn_deleteClick);
			// 
			// btn_load
			// 
			this.btn_load.Location = new System.Drawing.Point(5, 280);
			this.btn_load.Name = "btn_load";
			this.btn_load.Size = new System.Drawing.Size(75, 23);
			this.btn_load.TabIndex = 1;
			this.btn_load.Text = "Load";
			this.btn_load.UseVisualStyleBackColor = true;
			this.btn_load.Click += new System.EventHandler(this.Btn_loadClick);
			// 
			// frm_patternlist
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(308, 310);
			this.Controls.Add(this.btn_load);
			this.Controls.Add(this.btn_delete);
			this.Controls.Add(this.btn_save);
			this.Controls.Add(this.lst_pattern);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frm_patternlist";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Pattern List";
			this.ResumeLayout(false);

		}
	}
}
