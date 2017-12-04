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
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.ListBox lstLNP;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btn_run;
		private System.Windows.Forms.Button btn_color;
		private System.Windows.Forms.DataGridView dgv_anim;
		private System.Windows.Forms.Label txt_anim_pos;
		private System.Windows.Forms.Button btn_anim_del;
		private System.Windows.Forms.Button btn_anim_add;
		private System.Windows.Forms.Button btn_anim_play;
		private System.Windows.Forms.Button btn_anim_copy;
		private System.Windows.Forms.Button btn_anim_paste;
		private System.Windows.Forms.Panel pnl_ledgroup;
		private System.Windows.Forms.Button btn_group_add;
		private System.Windows.Forms.NumericUpDown nm_refresh;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TrackBar tb_fadespeed;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.CheckBox chk_reverse;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.TrackBar tb_anim_pos;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton ts_btn_copy;
		private System.Windows.Forms.ToolStripButton ts_btn_paste;
		private System.Windows.Forms.ToolStripButton ts_btn_set;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.Button btn_anim_next;
		private System.Windows.Forms.Button btn_anim_prev;
		private System.Windows.Forms.ToolStripButton ts_btn_fill;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.Button btn_audio_capture;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cb_audio_list;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TrackBar tb_audio_vol;
		private System.Windows.Forms.ProgressBar pb_audio_right;
		private System.Windows.Forms.ProgressBar pb_audio_left;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.ListBox lst_audio_ledgroup;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ComboBox cb_audio_ledstyle;
		private System.Windows.Forms.Panel pnl_audio_ledstyle;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Panel pnl_audio_ledstyle_config_color_0;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Panel pnl_audio_ledstyle_config_color_1;
		private System.Windows.Forms.Panel pnl_audio_ledstyle_config_color_3;
		private System.Windows.Forms.Panel pnl_audio_ledstyle_config_color_2;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.ComboBox cb_audio_ldestyle_channel;
		private System.Windows.Forms.Button btn_saveconfig;
		private System.Windows.Forms.DataGridView dgv_patlist;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.DataGridViewComboBoxColumn Column2;
		private System.Windows.Forms.DataGridViewComboBoxColumn Column3;
		private System.Windows.Forms.ToolStrip toolStrip2;
		private System.Windows.Forms.Button btn_devconfig;
		private System.Windows.Forms.ToolStripButton ts_pat_add;
		private System.Windows.Forms.ToolStripButton ts_pat_del;
		private System.Windows.Forms.SplitContainer split;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.CheckBox chk_ledcurrent;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton ts_btn_expand;
		private System.Windows.Forms.ToolStripButton ts_btn_half;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TrackBar tb_anim_delay;
		private System.Windows.Forms.Label lbl_currentRate;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Button btn_patlist;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.NotifyIcon notifyIcon;
		private System.Windows.Forms.ContextMenuStrip notifyIcon_menu;
		private System.Windows.Forms.ToolStripMenuItem ts_showhide;
		private System.Windows.Forms.ToolStripMenuItem ts_runLNP;
		private System.Windows.Forms.ToolStripMenuItem ts_patternmenu;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ts_pat_play;
		private System.Windows.Forms.ToolStripMenuItem ts_pat_reverse;
		private System.Windows.Forms.ToolStripMenuItem ts_audiocap;
		private System.Windows.Forms.ToolStripButton ts_btn_flip;
		private System.Windows.Forms.RichTextBox txt_lua;
		private System.Windows.Forms.ToolStrip toolStrip3;
		private System.Windows.Forms.ToolStripButton ts_btn_runlua;
		private System.Windows.Forms.ToolStripButton ts_btn_newlua;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripButton ts_btn_openlua;
		private System.Windows.Forms.ToolStripButton ts_btn_savelua;
		private System.Windows.Forms.ImageList imageList1;
		
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.lstLNP = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btn_run = new System.Windows.Forms.Button();
			this.btn_color = new System.Windows.Forms.Button();
			this.dgv_anim = new System.Windows.Forms.DataGridView();
			this.txt_anim_pos = new System.Windows.Forms.Label();
			this.btn_anim_del = new System.Windows.Forms.Button();
			this.btn_anim_add = new System.Windows.Forms.Button();
			this.btn_anim_play = new System.Windows.Forms.Button();
			this.btn_anim_copy = new System.Windows.Forms.Button();
			this.btn_anim_paste = new System.Windows.Forms.Button();
			this.pnl_ledgroup = new System.Windows.Forms.Panel();
			this.btn_group_add = new System.Windows.Forms.Button();
			this.nm_refresh = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.tb_fadespeed = new System.Windows.Forms.TrackBar();
			this.label5 = new System.Windows.Forms.Label();
			this.chk_reverse = new System.Windows.Forms.CheckBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.split = new System.Windows.Forms.SplitContainer();
			this.dgv_patlist = new System.Windows.Forms.DataGridView();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.Column3 = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.toolStrip2 = new System.Windows.Forms.ToolStrip();
			this.ts_pat_add = new System.Windows.Forms.ToolStripButton();
			this.ts_pat_del = new System.Windows.Forms.ToolStripButton();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.ts_btn_copy = new System.Windows.Forms.ToolStripButton();
			this.ts_btn_paste = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.ts_btn_set = new System.Windows.Forms.ToolStripButton();
			this.ts_btn_fill = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.ts_btn_expand = new System.Windows.Forms.ToolStripButton();
			this.ts_btn_half = new System.Windows.Forms.ToolStripButton();
			this.ts_btn_flip = new System.Windows.Forms.ToolStripButton();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.chk_ledcurrent = new System.Windows.Forms.CheckBox();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.pnl_audio_ledstyle = new System.Windows.Forms.Panel();
			this.label15 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.cb_audio_ldestyle_channel = new System.Windows.Forms.ComboBox();
			this.cb_audio_ledstyle = new System.Windows.Forms.ComboBox();
			this.label12 = new System.Windows.Forms.Label();
			this.pnl_audio_ledstyle_config_color_0 = new System.Windows.Forms.Panel();
			this.label11 = new System.Windows.Forms.Label();
			this.pnl_audio_ledstyle_config_color_1 = new System.Windows.Forms.Panel();
			this.pnl_audio_ledstyle_config_color_3 = new System.Windows.Forms.Panel();
			this.pnl_audio_ledstyle_config_color_2 = new System.Windows.Forms.Panel();
			this.lst_audio_ledgroup = new System.Windows.Forms.ListBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.pb_audio_left = new System.Windows.Forms.ProgressBar();
			this.pb_audio_right = new System.Windows.Forms.ProgressBar();
			this.label7 = new System.Windows.Forms.Label();
			this.tb_audio_vol = new System.Windows.Forms.TrackBar();
			this.label6 = new System.Windows.Forms.Label();
			this.btn_audio_capture = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.cb_audio_list = new System.Windows.Forms.ComboBox();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.toolStrip3 = new System.Windows.Forms.ToolStrip();
			this.ts_btn_newlua = new System.Windows.Forms.ToolStripButton();
			this.ts_btn_openlua = new System.Windows.Forms.ToolStripButton();
			this.ts_btn_savelua = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.ts_btn_runlua = new System.Windows.Forms.ToolStripButton();
			this.txt_lua = new System.Windows.Forms.RichTextBox();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.lbl_currentRate = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.btn_devconfig = new System.Windows.Forms.Button();
			this.btn_saveconfig = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label21 = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.tb_anim_delay = new System.Windows.Forms.TrackBar();
			this.tb_anim_pos = new System.Windows.Forms.TrackBar();
			this.label2 = new System.Windows.Forms.Label();
			this.btn_anim_next = new System.Windows.Forms.Button();
			this.btn_anim_prev = new System.Windows.Forms.Button();
			this.btn_patlist = new System.Windows.Forms.Button();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.notifyIcon_menu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.ts_showhide = new System.Windows.Forms.ToolStripMenuItem();
			this.ts_runLNP = new System.Windows.Forms.ToolStripMenuItem();
			this.ts_patternmenu = new System.Windows.Forms.ToolStripMenuItem();
			this.ts_pat_play = new System.Windows.Forms.ToolStripMenuItem();
			this.ts_pat_reverse = new System.Windows.Forms.ToolStripMenuItem();
			this.ts_audiocap = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)(this.dgv_anim)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nm_refresh)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_fadespeed)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.split)).BeginInit();
			this.split.Panel1.SuspendLayout();
			this.split.Panel2.SuspendLayout();
			this.split.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv_patlist)).BeginInit();
			this.toolStrip2.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.pnl_audio_ledstyle.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tb_audio_vol)).BeginInit();
			this.tabPage4.SuspendLayout();
			this.toolStrip3.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tb_anim_delay)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_anim_pos)).BeginInit();
			this.notifyIcon_menu.SuspendLayout();
			this.SuspendLayout();
			// 
			// lstLNP
			// 
			this.lstLNP.FormattingEnabled = true;
			this.lstLNP.ItemHeight = 12;
			this.lstLNP.Location = new System.Drawing.Point(95, 0);
			this.lstLNP.Name = "lstLNP";
			this.lstLNP.Size = new System.Drawing.Size(195, 40);
			this.lstLNP.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(95, 40);
			this.label1.TabIndex = 1;
			this.label1.Text = "Connected LNP:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btn_run
			// 
			this.btn_run.Location = new System.Drawing.Point(290, 0);
			this.btn_run.Name = "btn_run";
			this.btn_run.Size = new System.Drawing.Size(110, 20);
			this.btn_run.TabIndex = 3;
			this.btn_run.Text = "Run";
			this.btn_run.UseVisualStyleBackColor = true;
			this.btn_run.Click += new System.EventHandler(this.btn_RunClick);
			// 
			// btn_color
			// 
			this.btn_color.Location = new System.Drawing.Point(400, 0);
			this.btn_color.Name = "btn_color";
			this.btn_color.Size = new System.Drawing.Size(95, 41);
			this.btn_color.TabIndex = 1;
			this.btn_color.Text = "Send Static Color";
			this.btn_color.UseVisualStyleBackColor = true;
			this.btn_color.Click += new System.EventHandler(this.Btn_colorClick);
			// 
			// dgv_anim
			// 
			this.dgv_anim.AllowUserToAddRows = false;
			this.dgv_anim.AllowUserToDeleteRows = false;
			this.dgv_anim.AllowUserToResizeRows = false;
			this.dgv_anim.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
			this.dgv_anim.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv_anim.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgv_anim.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.dgv_anim.Location = new System.Drawing.Point(0, 25);
			this.dgv_anim.Name = "dgv_anim";
			this.dgv_anim.RowHeadersWidth = 60;
			this.dgv_anim.RowTemplate.Height = 21;
			this.dgv_anim.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.ColumnHeaderSelect;
			this.dgv_anim.Size = new System.Drawing.Size(564, 297);
			this.dgv_anim.TabIndex = 8;
			this.dgv_anim.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_animCellDoubleClick);
			this.dgv_anim.SelectionChanged += new System.EventHandler(this.Dgv_animSelectionChanged);
			this.dgv_anim.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Dgv_animKeyDown);
			// 
			// txt_anim_pos
			// 
			this.txt_anim_pos.Location = new System.Drawing.Point(425, 20);
			this.txt_anim_pos.Name = "txt_anim_pos";
			this.txt_anim_pos.Size = new System.Drawing.Size(58, 20);
			this.txt_anim_pos.TabIndex = 10;
			this.txt_anim_pos.Text = "0/0";
			this.txt_anim_pos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btn_anim_del
			// 
			this.btn_anim_del.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.btn_anim_del.Location = new System.Drawing.Point(715, 0);
			this.btn_anim_del.Name = "btn_anim_del";
			this.btn_anim_del.Size = new System.Drawing.Size(50, 39);
			this.btn_anim_del.TabIndex = 9;
			this.btn_anim_del.Text = "Delete\r\nFrame";
			this.toolTip1.SetToolTip(this.btn_anim_del, "Delete selected Animation frame");
			this.btn_anim_del.UseVisualStyleBackColor = true;
			this.btn_anim_del.Click += new System.EventHandler(this.Btn_anim_delClick);
			// 
			// btn_anim_add
			// 
			this.btn_anim_add.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.btn_anim_add.Location = new System.Drawing.Point(665, 0);
			this.btn_anim_add.Name = "btn_anim_add";
			this.btn_anim_add.Size = new System.Drawing.Size(50, 39);
			this.btn_anim_add.TabIndex = 9;
			this.btn_anim_add.Text = "Add\r\nFrame";
			this.toolTip1.SetToolTip(this.btn_anim_add, "Add new animation frame into pattern");
			this.btn_anim_add.UseVisualStyleBackColor = true;
			this.btn_anim_add.Click += new System.EventHandler(this.Btn_anim_addClick);
			// 
			// btn_anim_play
			// 
			this.btn_anim_play.Location = new System.Drawing.Point(93, 0);
			this.btn_anim_play.Name = "btn_anim_play";
			this.btn_anim_play.Size = new System.Drawing.Size(65, 39);
			this.btn_anim_play.TabIndex = 9;
			this.btn_anim_play.Text = "Play";
			this.toolTip1.SetToolTip(this.btn_anim_play, "Play animation");
			this.btn_anim_play.UseVisualStyleBackColor = true;
			this.btn_anim_play.Click += new System.EventHandler(this.Btn_anim_playClick);
			// 
			// btn_anim_copy
			// 
			this.btn_anim_copy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.btn_anim_copy.Location = new System.Drawing.Point(765, 0);
			this.btn_anim_copy.Name = "btn_anim_copy";
			this.btn_anim_copy.Size = new System.Drawing.Size(50, 39);
			this.btn_anim_copy.TabIndex = 9;
			this.btn_anim_copy.Text = "Copy Frame";
			this.toolTip1.SetToolTip(this.btn_anim_copy, "Copy selected animation frame");
			this.btn_anim_copy.UseVisualStyleBackColor = true;
			this.btn_anim_copy.Click += new System.EventHandler(this.Btn_anim_copyClick);
			// 
			// btn_anim_paste
			// 
			this.btn_anim_paste.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.btn_anim_paste.Location = new System.Drawing.Point(816, 0);
			this.btn_anim_paste.Name = "btn_anim_paste";
			this.btn_anim_paste.Size = new System.Drawing.Size(50, 39);
			this.btn_anim_paste.TabIndex = 9;
			this.btn_anim_paste.Text = "Paste Frame";
			this.toolTip1.SetToolTip(this.btn_anim_paste, "Paste and replace selected animation frame");
			this.btn_anim_paste.UseVisualStyleBackColor = true;
			this.btn_anim_paste.Click += new System.EventHandler(this.Btn_anim_pasteClick);
			// 
			// pnl_ledgroup
			// 
			this.pnl_ledgroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.pnl_ledgroup.AutoScroll = true;
			this.pnl_ledgroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnl_ledgroup.Location = new System.Drawing.Point(3, 25);
			this.pnl_ledgroup.Name = "pnl_ledgroup";
			this.pnl_ledgroup.Size = new System.Drawing.Size(857, 303);
			this.pnl_ledgroup.TabIndex = 11;
			// 
			// btn_group_add
			// 
			this.btn_group_add.Location = new System.Drawing.Point(4, 0);
			this.btn_group_add.Name = "btn_group_add";
			this.btn_group_add.Size = new System.Drawing.Size(75, 24);
			this.btn_group_add.TabIndex = 12;
			this.btn_group_add.Text = "Add";
			this.btn_group_add.UseVisualStyleBackColor = true;
			this.btn_group_add.Click += new System.EventHandler(this.Btn_group_addClick);
			// 
			// nm_refresh
			// 
			this.nm_refresh.Location = new System.Drawing.Point(5, 20);
			this.nm_refresh.Maximum = new decimal(new int[] {
			1000,
			0,
			0,
			0});
			this.nm_refresh.Name = "nm_refresh";
			this.nm_refresh.Size = new System.Drawing.Size(55, 19);
			this.nm_refresh.TabIndex = 13;
			this.toolTip1.SetToolTip(this.nm_refresh, "Set refresh rate for update to LNP device.\r\nThis is not guarantee as it need to d" +
		"epend total LED command transmit speed.");
			this.nm_refresh.Value = new decimal(new int[] {
			16,
			0,
			0,
			0});
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(5, 5);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(110, 15);
			this.label4.TabIndex = 14;
			this.label4.Text = "Refresh Rate";
			this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// tb_fadespeed
			// 
			this.tb_fadespeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.tb_fadespeed.AutoSize = false;
			this.tb_fadespeed.Location = new System.Drawing.Point(632, 0);
			this.tb_fadespeed.Maximum = 100;
			this.tb_fadespeed.Minimum = 1;
			this.tb_fadespeed.Name = "tb_fadespeed";
			this.tb_fadespeed.Size = new System.Drawing.Size(165, 21);
			this.tb_fadespeed.TabIndex = 15;
			this.tb_fadespeed.TickFrequency = 10;
			this.toolTip1.SetToolTip(this.tb_fadespeed, "Set LED fade out duration speed");
			this.tb_fadespeed.Value = 20;
			this.tb_fadespeed.ValueChanged += new System.EventHandler(this.Tb_fadespeedValueChanged);
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.Location = new System.Drawing.Point(673, 25);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(90, 15);
			this.label5.TabIndex = 14;
			this.label5.Text = "Fade Out Speed";
			// 
			// chk_reverse
			// 
			this.chk_reverse.Appearance = System.Windows.Forms.Appearance.Button;
			this.chk_reverse.Location = new System.Drawing.Point(158, 0);
			this.chk_reverse.Name = "chk_reverse";
			this.chk_reverse.Size = new System.Drawing.Size(65, 39);
			this.chk_reverse.TabIndex = 16;
			this.chk_reverse.Text = "Reverse";
			this.chk_reverse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.chk_reverse, "Reverse animation playback");
			this.chk_reverse.UseVisualStyleBackColor = true;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Controls.Add(this.tabPage4);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.ImageList = this.imageList1;
			this.tabControl1.ItemSize = new System.Drawing.Size(134, 36);
			this.tabControl1.Location = new System.Drawing.Point(0, 85);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(870, 376);
			this.tabControl1.TabIndex = 20;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.split);
			this.tabPage1.ImageKey = "img_patterneditor.png";
			this.tabPage1.Location = new System.Drawing.Point(4, 40);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(862, 332);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Animation Pattern";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// split
			// 
			this.split.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.split.Dock = System.Windows.Forms.DockStyle.Fill;
			this.split.Location = new System.Drawing.Point(3, 3);
			this.split.Name = "split";
			// 
			// split.Panel1
			// 
			this.split.Panel1.Controls.Add(this.dgv_patlist);
			this.split.Panel1.Controls.Add(this.toolStrip2);
			// 
			// split.Panel2
			// 
			this.split.Panel2.Controls.Add(this.dgv_anim);
			this.split.Panel2.Controls.Add(this.toolStrip1);
			this.split.Panel2.Enabled = false;
			this.split.Size = new System.Drawing.Size(856, 326);
			this.split.SplitterDistance = 284;
			this.split.TabIndex = 18;
			// 
			// dgv_patlist
			// 
			this.dgv_patlist.AllowUserToAddRows = false;
			this.dgv_patlist.AllowUserToDeleteRows = false;
			this.dgv_patlist.AllowUserToResizeRows = false;
			this.dgv_patlist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv_patlist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
			this.Column1,
			this.Column2,
			this.Column3});
			this.dgv_patlist.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgv_patlist.Location = new System.Drawing.Point(0, 25);
			this.dgv_patlist.MultiSelect = false;
			this.dgv_patlist.Name = "dgv_patlist";
			this.dgv_patlist.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			this.dgv_patlist.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dgv_patlist.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgv_patlist.Size = new System.Drawing.Size(280, 297);
			this.dgv_patlist.TabIndex = 0;
			this.dgv_patlist.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_patlistCellEndEdit);
			this.dgv_patlist.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.Dgv_patlistCellParsing);
			this.dgv_patlist.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.Dgv_patlistRowsRemoved);
			this.dgv_patlist.SelectionChanged += new System.EventHandler(this.Dgv_patlistSelectionChanged);
			// 
			// Column1
			// 
			this.Column1.HeaderText = "Name";
			this.Column1.Name = "Column1";
			this.Column1.Width = 150;
			// 
			// Column2
			// 
			this.Column2.HeaderText = "Device";
			this.Column2.Name = "Column2";
			// 
			// Column3
			// 
			this.Column3.HeaderText = "Channel";
			this.Column3.Items.AddRange(new object[] {
			"1",
			"2"});
			this.Column3.Name = "Column3";
			// 
			// toolStrip2
			// 
			this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.ts_pat_add,
			this.ts_pat_del});
			this.toolStrip2.Location = new System.Drawing.Point(0, 0);
			this.toolStrip2.Name = "toolStrip2";
			this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.toolStrip2.Size = new System.Drawing.Size(280, 25);
			this.toolStrip2.TabIndex = 1;
			this.toolStrip2.Text = "toolStrip2";
			// 
			// ts_pat_add
			// 
			this.ts_pat_add.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.ts_pat_add.Image = ((System.Drawing.Image)(resources.GetObject("ts_pat_add.Image")));
			this.ts_pat_add.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ts_pat_add.Name = "ts_pat_add";
			this.ts_pat_add.Size = new System.Drawing.Size(64, 22);
			this.ts_pat_add.Text = "Add Track";
			this.ts_pat_add.Click += new System.EventHandler(this.ts_pat_addClick);
			// 
			// ts_pat_del
			// 
			this.ts_pat_del.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.ts_pat_del.Enabled = false;
			this.ts_pat_del.Image = ((System.Drawing.Image)(resources.GetObject("ts_pat_del.Image")));
			this.ts_pat_del.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ts_pat_del.Name = "ts_pat_del";
			this.ts_pat_del.Size = new System.Drawing.Size(75, 22);
			this.ts_pat_del.Text = "Delete Track";
			this.ts_pat_del.Click += new System.EventHandler(this.Ts_pat_delClick);
			// 
			// toolStrip1
			// 
			this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.ts_btn_copy,
			this.ts_btn_paste,
			this.toolStripSeparator1,
			this.ts_btn_set,
			this.ts_btn_fill,
			this.toolStripSeparator2,
			this.ts_btn_expand,
			this.ts_btn_half,
			this.ts_btn_flip});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.toolStrip1.Size = new System.Drawing.Size(564, 25);
			this.toolStrip1.TabIndex = 19;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// ts_btn_copy
			// 
			this.ts_btn_copy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.ts_btn_copy.Image = ((System.Drawing.Image)(resources.GetObject("ts_btn_copy.Image")));
			this.ts_btn_copy.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ts_btn_copy.Name = "ts_btn_copy";
			this.ts_btn_copy.Size = new System.Drawing.Size(71, 22);
			this.ts_btn_copy.Text = "Copy Color";
			this.ts_btn_copy.ToolTipText = "Copy Color from selected LED";
			this.ts_btn_copy.Click += new System.EventHandler(this.Ts_btn_copyClick);
			// 
			// ts_btn_paste
			// 
			this.ts_btn_paste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.ts_btn_paste.Image = ((System.Drawing.Image)(resources.GetObject("ts_btn_paste.Image")));
			this.ts_btn_paste.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ts_btn_paste.Name = "ts_btn_paste";
			this.ts_btn_paste.Size = new System.Drawing.Size(71, 22);
			this.ts_btn_paste.Text = "Paste Color";
			this.ts_btn_paste.ToolTipText = "Paste Color into selceted LED";
			this.ts_btn_paste.Click += new System.EventHandler(this.Ts_btn_pasteClick);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// ts_btn_set
			// 
			this.ts_btn_set.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.ts_btn_set.Image = ((System.Drawing.Image)(resources.GetObject("ts_btn_set.Image")));
			this.ts_btn_set.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ts_btn_set.Name = "ts_btn_set";
			this.ts_btn_set.Size = new System.Drawing.Size(59, 22);
			this.ts_btn_set.Text = "Set Color";
			this.ts_btn_set.ToolTipText = "Set Color into selected LED";
			this.ts_btn_set.Click += new System.EventHandler(this.Ts_btn_setClick);
			// 
			// ts_btn_fill
			// 
			this.ts_btn_fill.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.ts_btn_fill.Image = ((System.Drawing.Image)(resources.GetObject("ts_btn_fill.Image")));
			this.ts_btn_fill.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ts_btn_fill.Name = "ts_btn_fill";
			this.ts_btn_fill.Size = new System.Drawing.Size(58, 22);
			this.ts_btn_fill.Text = "Fill Color";
			this.ts_btn_fill.ToolTipText = "Fill Gradient Color into selected LED";
			this.ts_btn_fill.Click += new System.EventHandler(this.Ts_btn_fillClick);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// ts_btn_expand
			// 
			this.ts_btn_expand.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.ts_btn_expand.Image = ((System.Drawing.Image)(resources.GetObject("ts_btn_expand.Image")));
			this.ts_btn_expand.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ts_btn_expand.Name = "ts_btn_expand";
			this.ts_btn_expand.Size = new System.Drawing.Size(49, 22);
			this.ts_btn_expand.Text = "Expand";
			this.ts_btn_expand.ToolTipText = "Expand selection and fill gradient empty space";
			this.ts_btn_expand.Click += new System.EventHandler(this.Ts_btn_expandClick);
			// 
			// ts_btn_half
			// 
			this.ts_btn_half.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.ts_btn_half.Image = ((System.Drawing.Image)(resources.GetObject("ts_btn_half.Image")));
			this.ts_btn_half.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ts_btn_half.Name = "ts_btn_half";
			this.ts_btn_half.Size = new System.Drawing.Size(33, 22);
			this.ts_btn_half.Text = "Half";
			this.ts_btn_half.ToolTipText = "Shrink selection";
			this.ts_btn_half.Click += new System.EventHandler(this.Ts_btn_halfClick);
			// 
			// ts_btn_flip
			// 
			this.ts_btn_flip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.ts_btn_flip.Image = ((System.Drawing.Image)(resources.GetObject("ts_btn_flip.Image")));
			this.ts_btn_flip.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ts_btn_flip.Name = "ts_btn_flip";
			this.ts_btn_flip.Size = new System.Drawing.Size(30, 22);
			this.ts_btn_flip.Text = "Flip";
			this.ts_btn_flip.ToolTipText = "Flip frames from selected range";
			this.ts_btn_flip.Click += new System.EventHandler(this.Ts_btn_flipClick);
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.chk_ledcurrent);
			this.tabPage2.Controls.Add(this.pnl_ledgroup);
			this.tabPage2.Controls.Add(this.btn_group_add);
			this.tabPage2.ImageKey = "img_ledgroup.png";
			this.tabPage2.Location = new System.Drawing.Point(4, 40);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(862, 332);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "LED Grouping";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// chk_ledcurrent
			// 
			this.chk_ledcurrent.Appearance = System.Windows.Forms.Appearance.Button;
			this.chk_ledcurrent.Location = new System.Drawing.Point(80, 0);
			this.chk_ledcurrent.Name = "chk_ledcurrent";
			this.chk_ledcurrent.Size = new System.Drawing.Size(100, 24);
			this.chk_ledcurrent.TabIndex = 13;
			this.chk_ledcurrent.Text = "Show Update";
			this.chk_ledcurrent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.chk_ledcurrent.UseVisualStyleBackColor = true;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.groupBox2);
			this.tabPage3.Controls.Add(this.groupBox1);
			this.tabPage3.Controls.Add(this.btn_audio_capture);
			this.tabPage3.Controls.Add(this.label3);
			this.tabPage3.Controls.Add(this.cb_audio_list);
			this.tabPage3.ImageKey = "img_audiocap.png";
			this.tabPage3.Location = new System.Drawing.Point(4, 40);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(862, 332);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Audio Capture";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.pnl_audio_ledstyle);
			this.groupBox2.Controls.Add(this.lst_audio_ledgroup);
			this.groupBox2.Location = new System.Drawing.Point(10, 105);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(465, 195);
			this.groupBox2.TabIndex = 9;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "LED Grouping Style";
			// 
			// pnl_audio_ledstyle
			// 
			this.pnl_audio_ledstyle.Controls.Add(this.label15);
			this.pnl_audio_ledstyle.Controls.Add(this.label14);
			this.pnl_audio_ledstyle.Controls.Add(this.label16);
			this.pnl_audio_ledstyle.Controls.Add(this.label10);
			this.pnl_audio_ledstyle.Controls.Add(this.label13);
			this.pnl_audio_ledstyle.Controls.Add(this.cb_audio_ldestyle_channel);
			this.pnl_audio_ledstyle.Controls.Add(this.cb_audio_ledstyle);
			this.pnl_audio_ledstyle.Controls.Add(this.label12);
			this.pnl_audio_ledstyle.Controls.Add(this.pnl_audio_ledstyle_config_color_0);
			this.pnl_audio_ledstyle.Controls.Add(this.label11);
			this.pnl_audio_ledstyle.Controls.Add(this.pnl_audio_ledstyle_config_color_1);
			this.pnl_audio_ledstyle.Controls.Add(this.pnl_audio_ledstyle_config_color_3);
			this.pnl_audio_ledstyle.Controls.Add(this.pnl_audio_ledstyle_config_color_2);
			this.pnl_audio_ledstyle.Location = new System.Drawing.Point(180, 20);
			this.pnl_audio_ledstyle.Name = "pnl_audio_ledstyle";
			this.pnl_audio_ledstyle.Size = new System.Drawing.Size(275, 160);
			this.pnl_audio_ledstyle.TabIndex = 10;
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(10, 60);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(110, 15);
			this.label15.TabIndex = 10;
			this.label15.Text = "Volume Color";
			// 
			// label14
			// 
			this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label14.Location = new System.Drawing.Point(205, 75);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(60, 15);
			this.label14.TabIndex = 1;
			this.label14.Text = "Peak";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(5, 30);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(85, 20);
			this.label16.TabIndex = 9;
			this.label16.Text = "Audio Channel";
			this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(5, 5);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(40, 20);
			this.label10.TabIndex = 9;
			this.label10.Text = "Style";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label13
			// 
			this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label13.Location = new System.Drawing.Point(140, 75);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(60, 15);
			this.label13.TabIndex = 1;
			this.label13.Text = "High";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// cb_audio_ldestyle_channel
			// 
			this.cb_audio_ldestyle_channel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cb_audio_ldestyle_channel.FormattingEnabled = true;
			this.cb_audio_ldestyle_channel.Items.AddRange(new object[] {
			"Mix",
			"Left",
			"Right"});
			this.cb_audio_ldestyle_channel.Location = new System.Drawing.Point(95, 30);
			this.cb_audio_ldestyle_channel.Name = "cb_audio_ldestyle_channel";
			this.cb_audio_ldestyle_channel.Size = new System.Drawing.Size(125, 20);
			this.cb_audio_ldestyle_channel.TabIndex = 8;
			this.cb_audio_ldestyle_channel.SelectionChangeCommitted += new System.EventHandler(this.Cb_audio_ldestyle_channelSelectionChangeCommitted);
			// 
			// cb_audio_ledstyle
			// 
			this.cb_audio_ledstyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cb_audio_ledstyle.FormattingEnabled = true;
			this.cb_audio_ledstyle.Location = new System.Drawing.Point(95, 5);
			this.cb_audio_ledstyle.Name = "cb_audio_ledstyle";
			this.cb_audio_ledstyle.Size = new System.Drawing.Size(125, 20);
			this.cb_audio_ledstyle.TabIndex = 8;
			this.cb_audio_ledstyle.SelectionChangeCommitted += new System.EventHandler(this.Cb_audio_ledstyleSelectionChangeCommitted);
			// 
			// label12
			// 
			this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label12.Location = new System.Drawing.Point(75, 75);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(60, 15);
			this.label12.TabIndex = 1;
			this.label12.Text = "Med";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// pnl_audio_ledstyle_config_color_0
			// 
			this.pnl_audio_ledstyle_config_color_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnl_audio_ledstyle_config_color_0.Location = new System.Drawing.Point(10, 90);
			this.pnl_audio_ledstyle_config_color_0.Name = "pnl_audio_ledstyle_config_color_0";
			this.pnl_audio_ledstyle_config_color_0.Size = new System.Drawing.Size(60, 60);
			this.pnl_audio_ledstyle_config_color_0.TabIndex = 0;
			this.pnl_audio_ledstyle_config_color_0.Tag = "0";
			this.pnl_audio_ledstyle_config_color_0.Click += new System.EventHandler(this.Pnl_audio_ledstyle_config_0_colorClick);
			// 
			// label11
			// 
			this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label11.Location = new System.Drawing.Point(10, 75);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(60, 15);
			this.label11.TabIndex = 1;
			this.label11.Text = "Low";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// pnl_audio_ledstyle_config_color_1
			// 
			this.pnl_audio_ledstyle_config_color_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnl_audio_ledstyle_config_color_1.Location = new System.Drawing.Point(75, 90);
			this.pnl_audio_ledstyle_config_color_1.Name = "pnl_audio_ledstyle_config_color_1";
			this.pnl_audio_ledstyle_config_color_1.Size = new System.Drawing.Size(60, 60);
			this.pnl_audio_ledstyle_config_color_1.TabIndex = 0;
			this.pnl_audio_ledstyle_config_color_1.Tag = "1";
			this.pnl_audio_ledstyle_config_color_1.Click += new System.EventHandler(this.Pnl_audio_ledstyle_config_0_colorClick);
			// 
			// pnl_audio_ledstyle_config_color_3
			// 
			this.pnl_audio_ledstyle_config_color_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnl_audio_ledstyle_config_color_3.Location = new System.Drawing.Point(205, 90);
			this.pnl_audio_ledstyle_config_color_3.Name = "pnl_audio_ledstyle_config_color_3";
			this.pnl_audio_ledstyle_config_color_3.Size = new System.Drawing.Size(60, 60);
			this.pnl_audio_ledstyle_config_color_3.TabIndex = 0;
			this.pnl_audio_ledstyle_config_color_3.Tag = "3";
			this.pnl_audio_ledstyle_config_color_3.Click += new System.EventHandler(this.Pnl_audio_ledstyle_config_0_colorClick);
			// 
			// pnl_audio_ledstyle_config_color_2
			// 
			this.pnl_audio_ledstyle_config_color_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnl_audio_ledstyle_config_color_2.Location = new System.Drawing.Point(140, 90);
			this.pnl_audio_ledstyle_config_color_2.Name = "pnl_audio_ledstyle_config_color_2";
			this.pnl_audio_ledstyle_config_color_2.Size = new System.Drawing.Size(60, 60);
			this.pnl_audio_ledstyle_config_color_2.TabIndex = 0;
			this.pnl_audio_ledstyle_config_color_2.Tag = "2";
			this.pnl_audio_ledstyle_config_color_2.Click += new System.EventHandler(this.Pnl_audio_ledstyle_config_0_colorClick);
			// 
			// lst_audio_ledgroup
			// 
			this.lst_audio_ledgroup.FormattingEnabled = true;
			this.lst_audio_ledgroup.ItemHeight = 12;
			this.lst_audio_ledgroup.Location = new System.Drawing.Point(10, 20);
			this.lst_audio_ledgroup.Name = "lst_audio_ledgroup";
			this.lst_audio_ledgroup.Size = new System.Drawing.Size(160, 160);
			this.lst_audio_ledgroup.TabIndex = 7;
			this.lst_audio_ledgroup.SelectedIndexChanged += new System.EventHandler(this.Lst_audio_ledgroupSelectedIndexChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.pb_audio_left);
			this.groupBox1.Controls.Add(this.pb_audio_right);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.tb_audio_vol);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Location = new System.Drawing.Point(260, 5);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(370, 90);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Audio Capture Volume";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(5, 20);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(25, 10);
			this.label8.TabIndex = 5;
			this.label8.Text = "L";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(5, 70);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(25, 10);
			this.label9.TabIndex = 5;
			this.label9.Text = "R";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// pb_audio_left
			// 
			this.pb_audio_left.Location = new System.Drawing.Point(30, 20);
			this.pb_audio_left.Name = "pb_audio_left";
			this.pb_audio_left.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.pb_audio_left.Size = new System.Drawing.Size(310, 10);
			this.pb_audio_left.TabIndex = 3;
			// 
			// pb_audio_right
			// 
			this.pb_audio_right.Location = new System.Drawing.Point(30, 70);
			this.pb_audio_right.Name = "pb_audio_right";
			this.pb_audio_right.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.pb_audio_right.Size = new System.Drawing.Size(310, 10);
			this.pb_audio_right.TabIndex = 3;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(5, 40);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(25, 23);
			this.label7.TabIndex = 5;
			this.label7.Text = "0%";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tb_audio_vol
			// 
			this.tb_audio_vol.AutoSize = false;
			this.tb_audio_vol.Location = new System.Drawing.Point(30, 30);
			this.tb_audio_vol.Maximum = 300;
			this.tb_audio_vol.Name = "tb_audio_vol";
			this.tb_audio_vol.Size = new System.Drawing.Size(310, 40);
			this.tb_audio_vol.TabIndex = 4;
			this.tb_audio_vol.TickFrequency = 10;
			this.tb_audio_vol.TickStyle = System.Windows.Forms.TickStyle.Both;
			this.tb_audio_vol.Value = 100;
			this.tb_audio_vol.ValueChanged += new System.EventHandler(this.Tb_audio_volValueChanged);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(340, 40);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(35, 23);
			this.label6.TabIndex = 5;
			this.label6.Text = "300%";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btn_audio_capture
			// 
			this.btn_audio_capture.Location = new System.Drawing.Point(180, 10);
			this.btn_audio_capture.Name = "btn_audio_capture";
			this.btn_audio_capture.Size = new System.Drawing.Size(75, 45);
			this.btn_audio_capture.TabIndex = 2;
			this.btn_audio_capture.Text = "Start";
			this.btn_audio_capture.UseVisualStyleBackColor = true;
			this.btn_audio_capture.Click += new System.EventHandler(this.Btn_audio_captureClick);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(10, 10);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(120, 20);
			this.label3.TabIndex = 1;
			this.label3.Text = "Audio Capture Device";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cb_audio_list
			// 
			this.cb_audio_list.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cb_audio_list.FormattingEnabled = true;
			this.cb_audio_list.Location = new System.Drawing.Point(10, 35);
			this.cb_audio_list.Name = "cb_audio_list";
			this.cb_audio_list.Size = new System.Drawing.Size(165, 20);
			this.cb_audio_list.TabIndex = 0;
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.toolStrip3);
			this.tabPage4.Controls.Add(this.txt_lua);
			this.tabPage4.ImageKey = "img_luascript.png";
			this.tabPage4.Location = new System.Drawing.Point(4, 40);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage4.Size = new System.Drawing.Size(862, 332);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "Lua Script";
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// toolStrip3
			// 
			this.toolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.ts_btn_newlua,
			this.ts_btn_openlua,
			this.ts_btn_savelua,
			this.toolStripSeparator4,
			this.ts_btn_runlua});
			this.toolStrip3.Location = new System.Drawing.Point(3, 3);
			this.toolStrip3.Name = "toolStrip3";
			this.toolStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.toolStrip3.Size = new System.Drawing.Size(856, 25);
			this.toolStrip3.TabIndex = 3;
			this.toolStrip3.Text = "toolStrip3";
			// 
			// ts_btn_newlua
			// 
			this.ts_btn_newlua.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.ts_btn_newlua.Image = ((System.Drawing.Image)(resources.GetObject("ts_btn_newlua.Image")));
			this.ts_btn_newlua.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ts_btn_newlua.Name = "ts_btn_newlua";
			this.ts_btn_newlua.Size = new System.Drawing.Size(35, 22);
			this.ts_btn_newlua.Text = "New";
			this.ts_btn_newlua.Click += new System.EventHandler(this.Ts_btn_newluaClick);
			// 
			// ts_btn_openlua
			// 
			this.ts_btn_openlua.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.ts_btn_openlua.Image = ((System.Drawing.Image)(resources.GetObject("ts_btn_openlua.Image")));
			this.ts_btn_openlua.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ts_btn_openlua.Name = "ts_btn_openlua";
			this.ts_btn_openlua.Size = new System.Drawing.Size(40, 22);
			this.ts_btn_openlua.Text = "Open";
			this.ts_btn_openlua.Click += new System.EventHandler(this.Ts_btn_openluaClick);
			// 
			// ts_btn_savelua
			// 
			this.ts_btn_savelua.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.ts_btn_savelua.Image = ((System.Drawing.Image)(resources.GetObject("ts_btn_savelua.Image")));
			this.ts_btn_savelua.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ts_btn_savelua.Name = "ts_btn_savelua";
			this.ts_btn_savelua.Size = new System.Drawing.Size(35, 22);
			this.ts_btn_savelua.Text = "Save";
			this.ts_btn_savelua.Click += new System.EventHandler(this.Ts_btn_saveluaClick);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
			// 
			// ts_btn_runlua
			// 
			this.ts_btn_runlua.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.ts_btn_runlua.Image = ((System.Drawing.Image)(resources.GetObject("ts_btn_runlua.Image")));
			this.ts_btn_runlua.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ts_btn_runlua.Name = "ts_btn_runlua";
			this.ts_btn_runlua.Size = new System.Drawing.Size(65, 22);
			this.ts_btn_runlua.Text = "Run Script";
			this.ts_btn_runlua.Click += new System.EventHandler(this.Ts_btn_runluaClick);
			// 
			// txt_lua
			// 
			this.txt_lua.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.txt_lua.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_lua.Location = new System.Drawing.Point(5, 30);
			this.txt_lua.Name = "txt_lua";
			this.txt_lua.Size = new System.Drawing.Size(850, 297);
			this.txt_lua.TabIndex = 2;
			this.txt_lua.Text = resources.GetString("txt_lua.Text");
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "img_patterneditor.png");
			this.imageList1.Images.SetKeyName(1, "img_ledgroup.png");
			this.imageList1.Images.SetKeyName(2, "img_audiocap.png");
			this.imageList1.Images.SetKeyName(3, "img_luascript.png");
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.panel3);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.lstLNP);
			this.panel1.Controls.Add(this.btn_devconfig);
			this.panel1.Controls.Add(this.btn_color);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.tb_fadespeed);
			this.panel1.Controls.Add(this.btn_saveconfig);
			this.panel1.Controls.Add(this.btn_run);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(870, 45);
			this.panel1.TabIndex = 21;
			// 
			// panel3
			// 
			this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel3.Controls.Add(this.label4);
			this.panel3.Controls.Add(this.nm_refresh);
			this.panel3.Controls.Add(this.lbl_currentRate);
			this.panel3.Controls.Add(this.label18);
			this.panel3.Location = new System.Drawing.Point(505, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(125, 45);
			this.panel3.TabIndex = 16;
			// 
			// lbl_currentRate
			// 
			this.lbl_currentRate.Location = new System.Drawing.Point(75, 20);
			this.lbl_currentRate.Name = "lbl_currentRate";
			this.lbl_currentRate.Size = new System.Drawing.Size(40, 20);
			this.lbl_currentRate.TabIndex = 14;
			this.lbl_currentRate.Text = "Off";
			this.lbl_currentRate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.toolTip1.SetToolTip(this.lbl_currentRate, "Show duration milisecond time needs to complete update to LNP device");
			// 
			// label18
			// 
			this.label18.Location = new System.Drawing.Point(60, 20);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(15, 20);
			this.label18.TabIndex = 14;
			this.label18.Text = "/";
			this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btn_devconfig
			// 
			this.btn_devconfig.Location = new System.Drawing.Point(290, 20);
			this.btn_devconfig.Name = "btn_devconfig";
			this.btn_devconfig.Size = new System.Drawing.Size(110, 20);
			this.btn_devconfig.TabIndex = 1;
			this.btn_devconfig.Text = "Config LNP LED";
			this.btn_devconfig.UseVisualStyleBackColor = true;
			this.btn_devconfig.Click += new System.EventHandler(this.Btn_devconfigClick);
			// 
			// btn_saveconfig
			// 
			this.btn_saveconfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_saveconfig.Location = new System.Drawing.Point(798, 0);
			this.btn_saveconfig.Name = "btn_saveconfig";
			this.btn_saveconfig.Size = new System.Drawing.Size(70, 41);
			this.btn_saveconfig.TabIndex = 3;
			this.btn_saveconfig.Text = "Save Config";
			this.toolTip1.SetToolTip(this.btn_saveconfig, "Update config file.\r\nClosing the program normally will auto save config as well");
			this.btn_saveconfig.UseVisualStyleBackColor = true;
			this.btn_saveconfig.Click += new System.EventHandler(this.Btn_saveconfigClick);
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.label21);
			this.panel2.Controls.Add(this.label20);
			this.panel2.Controls.Add(this.label19);
			this.panel2.Controls.Add(this.label17);
			this.panel2.Controls.Add(this.tb_anim_delay);
			this.panel2.Controls.Add(this.tb_anim_pos);
			this.panel2.Controls.Add(this.chk_reverse);
			this.panel2.Controls.Add(this.btn_anim_add);
			this.panel2.Controls.Add(this.btn_anim_del);
			this.panel2.Controls.Add(this.txt_anim_pos);
			this.panel2.Controls.Add(this.btn_anim_paste);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Controls.Add(this.btn_anim_next);
			this.panel2.Controls.Add(this.btn_anim_prev);
			this.panel2.Controls.Add(this.btn_patlist);
			this.panel2.Controls.Add(this.btn_anim_play);
			this.panel2.Controls.Add(this.btn_anim_copy);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 45);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(870, 40);
			this.panel2.TabIndex = 22;
			// 
			// label21
			// 
			this.label21.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label21.Location = new System.Drawing.Point(575, 3);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(2, 32);
			this.label21.TabIndex = 21;
			// 
			// label20
			// 
			this.label20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label20.Location = new System.Drawing.Point(335, 3);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(2, 32);
			this.label20.TabIndex = 20;
			// 
			// label19
			// 
			this.label19.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label19.Location = new System.Drawing.Point(225, 3);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(2, 32);
			this.label19.TabIndex = 19;
			// 
			// label17
			// 
			this.label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label17.Location = new System.Drawing.Point(90, 4);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(2, 32);
			this.label17.TabIndex = 18;
			// 
			// tb_anim_delay
			// 
			this.tb_anim_delay.AutoSize = false;
			this.tb_anim_delay.Location = new System.Drawing.Point(230, 15);
			this.tb_anim_delay.Maximum = 1000;
			this.tb_anim_delay.Minimum = 16;
			this.tb_anim_delay.Name = "tb_anim_delay";
			this.tb_anim_delay.Size = new System.Drawing.Size(104, 20);
			this.tb_anim_delay.TabIndex = 17;
			this.tb_anim_delay.TickFrequency = 100;
			this.toolTip1.SetToolTip(this.tb_anim_delay, "Set animation delay per frame");
			this.tb_anim_delay.Value = 100;
			this.tb_anim_delay.ValueChanged += new System.EventHandler(this.Tb_anim_delayValueChanged);
			// 
			// tb_anim_pos
			// 
			this.tb_anim_pos.AutoSize = false;
			this.tb_anim_pos.Location = new System.Drawing.Point(380, 0);
			this.tb_anim_pos.Maximum = 0;
			this.tb_anim_pos.Name = "tb_anim_pos";
			this.tb_anim_pos.Size = new System.Drawing.Size(150, 20);
			this.tb_anim_pos.TabIndex = 0;
			this.tb_anim_pos.TickFrequency = 0;
			this.tb_anim_pos.Scroll += new System.EventHandler(this.Tb_anim_posScroll);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(230, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(105, 15);
			this.label2.TabIndex = 14;
			this.label2.Text = "Frame Delay";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btn_anim_next
			// 
			this.btn_anim_next.Location = new System.Drawing.Point(530, 0);
			this.btn_anim_next.Name = "btn_anim_next";
			this.btn_anim_next.Size = new System.Drawing.Size(40, 39);
			this.btn_anim_next.TabIndex = 9;
			this.btn_anim_next.Text = ">>";
			this.toolTip1.SetToolTip(this.btn_anim_next, "Next Animation Frame");
			this.btn_anim_next.UseVisualStyleBackColor = true;
			this.btn_anim_next.Click += new System.EventHandler(this.Btn_anim_nextClick);
			// 
			// btn_anim_prev
			// 
			this.btn_anim_prev.Location = new System.Drawing.Point(340, 0);
			this.btn_anim_prev.Name = "btn_anim_prev";
			this.btn_anim_prev.Size = new System.Drawing.Size(40, 39);
			this.btn_anim_prev.TabIndex = 9;
			this.btn_anim_prev.Text = "<<";
			this.toolTip1.SetToolTip(this.btn_anim_prev, "Previous animation frame");
			this.btn_anim_prev.UseVisualStyleBackColor = true;
			this.btn_anim_prev.Click += new System.EventHandler(this.Btn_anim_prevClick);
			// 
			// btn_patlist
			// 
			this.btn_patlist.Location = new System.Drawing.Point(0, 0);
			this.btn_patlist.Name = "btn_patlist";
			this.btn_patlist.Size = new System.Drawing.Size(88, 39);
			this.btn_patlist.TabIndex = 9;
			this.btn_patlist.Text = "Open Pattern List";
			this.btn_patlist.UseVisualStyleBackColor = true;
			this.btn_patlist.Click += new System.EventHandler(this.Btn_patlist_openClick);
			// 
			// notifyIcon
			// 
			this.notifyIcon.ContextMenuStrip = this.notifyIcon_menu;
			this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
			this.notifyIcon.Text = "SharpLNP";
			this.notifyIcon.Visible = true;
			this.notifyIcon.DoubleClick += new System.EventHandler(this.NotifyIconDoubleClick);
			// 
			// notifyIcon_menu
			// 
			this.notifyIcon_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.ts_showhide,
			this.ts_runLNP,
			this.ts_patternmenu,
			this.ts_audiocap,
			this.toolStripSeparator3,
			this.exitToolStripMenuItem});
			this.notifyIcon_menu.Name = "contextMenuStrip1";
			this.notifyIcon_menu.ShowCheckMargin = true;
			this.notifyIcon_menu.ShowImageMargin = false;
			this.notifyIcon_menu.Size = new System.Drawing.Size(152, 120);
			this.notifyIcon_menu.Opening += new System.ComponentModel.CancelEventHandler(this.NotifyIcon_menuOpening);
			// 
			// ts_showhide
			// 
			this.ts_showhide.Name = "ts_showhide";
			this.ts_showhide.Size = new System.Drawing.Size(151, 22);
			this.ts_showhide.Text = "Show/Hide";
			this.ts_showhide.Click += new System.EventHandler(this.Ts_showhideClick);
			// 
			// ts_runLNP
			// 
			this.ts_runLNP.Name = "ts_runLNP";
			this.ts_runLNP.Size = new System.Drawing.Size(151, 22);
			this.ts_runLNP.Text = "Run";
			this.ts_runLNP.Click += new System.EventHandler(this.Ts_runLNPClick);
			// 
			// ts_patternmenu
			// 
			this.ts_patternmenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.ts_pat_play,
			this.ts_pat_reverse});
			this.ts_patternmenu.Name = "ts_patternmenu";
			this.ts_patternmenu.Size = new System.Drawing.Size(151, 22);
			this.ts_patternmenu.Text = "Pattern List";
			// 
			// ts_pat_play
			// 
			this.ts_pat_play.Name = "ts_pat_play";
			this.ts_pat_play.Size = new System.Drawing.Size(114, 22);
			this.ts_pat_play.Text = "Play";
			this.ts_pat_play.Click += new System.EventHandler(this.Ts_pat_playClick);
			// 
			// ts_pat_reverse
			// 
			this.ts_pat_reverse.Name = "ts_pat_reverse";
			this.ts_pat_reverse.Size = new System.Drawing.Size(114, 22);
			this.ts_pat_reverse.Text = "Reverse";
			this.ts_pat_reverse.Click += new System.EventHandler(this.Ts_pat_reverseClick);
			// 
			// ts_audiocap
			// 
			this.ts_audiocap.Name = "ts_audiocap";
			this.ts_audiocap.Size = new System.Drawing.Size(151, 22);
			this.ts_audiocap.Text = "Audio Capture";
			this.ts_audiocap.Click += new System.EventHandler(this.Ts_audiocapClick);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(148, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(870, 461);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(878, 451);
			this.Name = "MainForm";
			this.Opacity = 0D;
			this.Text = "SharpLNP";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.SizeChanged += new System.EventHandler(this.MainFormSizeChanged);
			((System.ComponentModel.ISupportInitialize)(this.dgv_anim)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nm_refresh)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_fadespeed)).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.split.Panel1.ResumeLayout(false);
			this.split.Panel1.PerformLayout();
			this.split.Panel2.ResumeLayout(false);
			this.split.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.split)).EndInit();
			this.split.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgv_patlist)).EndInit();
			this.toolStrip2.ResumeLayout(false);
			this.toolStrip2.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.pnl_audio_ledstyle.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.tb_audio_vol)).EndInit();
			this.tabPage4.ResumeLayout(false);
			this.tabPage4.PerformLayout();
			this.toolStrip3.ResumeLayout(false);
			this.toolStrip3.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.tb_anim_delay)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tb_anim_pos)).EndInit();
			this.notifyIcon_menu.ResumeLayout(false);
			this.ResumeLayout(false);

		}
	}
}
