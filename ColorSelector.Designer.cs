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
	partial class ColorSelector
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Panel pnl_color_view;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox txt_v;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txt_s;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txt_h;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TrackBar tb_v;
		private System.Windows.Forms.TrackBar tb_s;
		private System.Windows.Forms.TrackBar tb_h;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txt_b;
		private System.Windows.Forms.TextBox txt_g;
		private System.Windows.Forms.TextBox txt_r;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TrackBar tb_b;
		private System.Windows.Forms.TrackBar tb_g;
		private System.Windows.Forms.TrackBar tb_r;
		private System.Windows.Forms.Panel panel1;
		
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
			this.pnl_color_view = new System.Windows.Forms.Panel();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.txt_v = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txt_s = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txt_h = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.tb_v = new System.Windows.Forms.TrackBar();
			this.tb_s = new System.Windows.Forms.TrackBar();
			this.tb_h = new System.Windows.Forms.TrackBar();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txt_b = new System.Windows.Forms.TextBox();
			this.txt_g = new System.Windows.Forms.TextBox();
			this.txt_r = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.tb_b = new System.Windows.Forms.TrackBar();
			this.tb_g = new System.Windows.Forms.TrackBar();
			this.tb_r = new System.Windows.Forms.TrackBar();
			this.panel1 = new System.Windows.Forms.Panel();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tb_v)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_s)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_h)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tb_b)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_g)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_r)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnl_color_view
			// 
			this.pnl_color_view.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnl_color_view.Location = new System.Drawing.Point(265, 5);
			this.pnl_color_view.Name = "pnl_color_view";
			this.pnl_color_view.Size = new System.Drawing.Size(80, 210);
			this.pnl_color_view.TabIndex = 5;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.txt_v);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.txt_s);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.txt_h);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.tb_v);
			this.groupBox2.Controls.Add(this.tb_s);
			this.groupBox2.Controls.Add(this.tb_h);
			this.groupBox2.Location = new System.Drawing.Point(5, 110);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(255, 105);
			this.groupBox2.TabIndex = 3;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Hue Saturation Value";
			// 
			// txt_v
			// 
			this.txt_v.Location = new System.Drawing.Point(210, 70);
			this.txt_v.Name = "txt_v";
			this.txt_v.Size = new System.Drawing.Size(35, 20);
			this.txt_v.TabIndex = 2;
			this.txt_v.Text = "0";
			this.txt_v.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txt_v.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_vKeyDown);
			this.txt_v.Leave += new System.EventHandler(this.Txt_vLeave);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(10, 70);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(25, 20);
			this.label4.TabIndex = 1;
			this.label4.Text = "V";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txt_s
			// 
			this.txt_s.Location = new System.Drawing.Point(210, 45);
			this.txt_s.Name = "txt_s";
			this.txt_s.Size = new System.Drawing.Size(35, 20);
			this.txt_s.TabIndex = 2;
			this.txt_s.Text = "0";
			this.txt_s.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txt_s.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_sKeyDown);
			this.txt_s.Leave += new System.EventHandler(this.Tb_sValueChanged);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(10, 45);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(25, 20);
			this.label5.TabIndex = 1;
			this.label5.Text = "S";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txt_h
			// 
			this.txt_h.Location = new System.Drawing.Point(210, 20);
			this.txt_h.Name = "txt_h";
			this.txt_h.Size = new System.Drawing.Size(35, 20);
			this.txt_h.TabIndex = 2;
			this.txt_h.Text = "0";
			this.txt_h.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txt_h.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_hKeyDown);
			this.txt_h.Leave += new System.EventHandler(this.Txt_hLeave);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(10, 20);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(25, 20);
			this.label6.TabIndex = 1;
			this.label6.Text = "H";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tb_v
			// 
			this.tb_v.AutoSize = false;
			this.tb_v.Location = new System.Drawing.Point(35, 70);
			this.tb_v.Maximum = 255;
			this.tb_v.Name = "tb_v";
			this.tb_v.Size = new System.Drawing.Size(175, 20);
			this.tb_v.TabIndex = 0;
			this.tb_v.TickFrequency = 0;
			this.tb_v.ValueChanged += new System.EventHandler(this.Tb_vValueChanged);
			// 
			// tb_s
			// 
			this.tb_s.AutoSize = false;
			this.tb_s.Location = new System.Drawing.Point(35, 45);
			this.tb_s.Maximum = 255;
			this.tb_s.Name = "tb_s";
			this.tb_s.Size = new System.Drawing.Size(175, 20);
			this.tb_s.TabIndex = 0;
			this.tb_s.TickFrequency = 0;
			this.tb_s.ValueChanged += new System.EventHandler(this.Tb_sValueChanged);
			// 
			// tb_h
			// 
			this.tb_h.AutoSize = false;
			this.tb_h.Location = new System.Drawing.Point(35, 20);
			this.tb_h.Maximum = 255;
			this.tb_h.Name = "tb_h";
			this.tb_h.Size = new System.Drawing.Size(175, 20);
			this.tb_h.TabIndex = 0;
			this.tb_h.TickFrequency = 0;
			this.tb_h.ValueChanged += new System.EventHandler(this.Tb_hValueChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txt_b);
			this.groupBox1.Controls.Add(this.txt_g);
			this.groupBox1.Controls.Add(this.txt_r);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.tb_b);
			this.groupBox1.Controls.Add(this.tb_g);
			this.groupBox1.Controls.Add(this.tb_r);
			this.groupBox1.Location = new System.Drawing.Point(5, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(255, 105);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Red Green Blue";
			// 
			// txt_b
			// 
			this.txt_b.Location = new System.Drawing.Point(210, 70);
			this.txt_b.Name = "txt_b";
			this.txt_b.Size = new System.Drawing.Size(35, 20);
			this.txt_b.TabIndex = 2;
			this.txt_b.Text = "0";
			this.txt_b.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txt_b.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_bKeyDown);
			this.txt_b.Leave += new System.EventHandler(this.Tb_bValueChanged);
			// 
			// txt_g
			// 
			this.txt_g.Location = new System.Drawing.Point(210, 45);
			this.txt_g.Name = "txt_g";
			this.txt_g.Size = new System.Drawing.Size(35, 20);
			this.txt_g.TabIndex = 2;
			this.txt_g.Text = "0";
			this.txt_g.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txt_g.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_gKeyDown);
			this.txt_g.Leave += new System.EventHandler(this.Txt_gLeave);
			// 
			// txt_r
			// 
			this.txt_r.Location = new System.Drawing.Point(210, 20);
			this.txt_r.Name = "txt_r";
			this.txt_r.Size = new System.Drawing.Size(35, 20);
			this.txt_r.TabIndex = 2;
			this.txt_r.Text = "0";
			this.txt_r.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txt_r.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_rKeyDown);
			this.txt_r.Leave += new System.EventHandler(this.Txt_rLeave);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(5, 70);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(25, 20);
			this.label3.TabIndex = 1;
			this.label3.Text = "B";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(5, 45);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(25, 20);
			this.label2.TabIndex = 1;
			this.label2.Text = "G";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(5, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(25, 20);
			this.label1.TabIndex = 1;
			this.label1.Text = "R";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tb_b
			// 
			this.tb_b.AutoSize = false;
			this.tb_b.Location = new System.Drawing.Point(35, 70);
			this.tb_b.Maximum = 255;
			this.tb_b.Name = "tb_b";
			this.tb_b.Size = new System.Drawing.Size(175, 20);
			this.tb_b.TabIndex = 0;
			this.tb_b.TickFrequency = 0;
			this.tb_b.ValueChanged += new System.EventHandler(this.Tb_bValueChanged);
			// 
			// tb_g
			// 
			this.tb_g.AutoSize = false;
			this.tb_g.Location = new System.Drawing.Point(35, 45);
			this.tb_g.Maximum = 255;
			this.tb_g.Name = "tb_g";
			this.tb_g.Size = new System.Drawing.Size(175, 20);
			this.tb_g.TabIndex = 0;
			this.tb_g.TickFrequency = 0;
			this.tb_g.ValueChanged += new System.EventHandler(this.Tb_gValueChanged);
			// 
			// tb_r
			// 
			this.tb_r.AutoSize = false;
			this.tb_r.Location = new System.Drawing.Point(35, 20);
			this.tb_r.Maximum = 255;
			this.tb_r.Name = "tb_r";
			this.tb_r.Size = new System.Drawing.Size(175, 20);
			this.tb_r.TabIndex = 0;
			this.tb_r.TickFrequency = 0;
			this.tb_r.ValueChanged += new System.EventHandler(this.Tb_rValueChanged);
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.groupBox1);
			this.panel1.Controls.Add(this.pnl_color_view);
			this.panel1.Controls.Add(this.groupBox2);
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(350, 220);
			this.panel1.TabIndex = 3;
			// 
			// ColorSelector
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.panel1);
			this.MaximumSize = new System.Drawing.Size(350, 220);
			this.MinimumSize = new System.Drawing.Size(350, 220);
			this.Name = "ColorSelector";
			this.Size = new System.Drawing.Size(350, 220);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.tb_v)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_s)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_h)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.tb_b)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_g)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_r)).EndInit();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
	}
}
