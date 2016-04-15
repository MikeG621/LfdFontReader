namespace Idmr.LfdFontReader
{
	partial class frmLFR
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLFR));
			this.pctGlyph = new System.Windows.Forms.PictureBox();
			this.cmdPrev = new System.Windows.Forms.Button();
			this.cmdNext = new System.Windows.Forms.Button();
			this.lblGlyph = new System.Windows.Forms.Label();
			this.lblWidth = new System.Windows.Forms.Label();
			this.lblHeight = new System.Windows.Forms.Label();
			this.lblAscii = new System.Windows.Forms.Label();
			this.lblChar = new System.Windows.Forms.Label();
			this.cmdExit = new System.Windows.Forms.Button();
			this.opnLFD = new System.Windows.Forms.OpenFileDialog();
			this.cmdOpen = new System.Windows.Forms.Button();
			this.lblFilename = new System.Windows.Forms.Label();
			this.lstFONT = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.pctImport = new System.Windows.Forms.PictureBox();
			this.label3 = new System.Windows.Forms.Label();
			this.cmdSave = new System.Windows.Forms.Button();
			this.cmdCopy = new System.Windows.Forms.Button();
			this.lblImpWidth = new System.Windows.Forms.Label();
			this.lblImpHeight = new System.Windows.Forms.Label();
			this.cmdImport = new System.Windows.Forms.Button();
			this.lblRules = new System.Windows.Forms.Label();
			this.opnBitmap = new System.Windows.Forms.OpenFileDialog();
			this.pnlImages = new System.Windows.Forms.Panel();
			this.vsbImages = new System.Windows.Forms.VScrollBar();
			this.cmdLoad = new System.Windows.Forms.Button();
			this.cmdExport = new System.Windows.Forms.Button();
			this.savFont = new System.Windows.Forms.SaveFileDialog();
			this.opnFont = new System.Windows.Forms.OpenFileDialog();
			((System.ComponentModel.ISupportInitialize)(this.pctGlyph)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pctImport)).BeginInit();
			this.SuspendLayout();
			// 
			// pctGlyph
			// 
			this.pctGlyph.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pctGlyph.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pctGlyph.Location = new System.Drawing.Point(150, 35);
			this.pctGlyph.Name = "pctGlyph";
			this.pctGlyph.Size = new System.Drawing.Size(71, 81);
			this.pctGlyph.TabIndex = 0;
			this.pctGlyph.TabStop = false;
			// 
			// cmdPrev
			// 
			this.cmdPrev.Enabled = false;
			this.cmdPrev.Location = new System.Drawing.Point(150, 122);
			this.cmdPrev.Name = "cmdPrev";
			this.cmdPrev.Size = new System.Drawing.Size(30, 23);
			this.cmdPrev.TabIndex = 1;
			this.cmdPrev.Text = "<";
			this.cmdPrev.UseVisualStyleBackColor = true;
			this.cmdPrev.Click += new System.EventHandler(this.cmdPrev_Click);
			// 
			// cmdNext
			// 
			this.cmdNext.Enabled = false;
			this.cmdNext.Location = new System.Drawing.Point(191, 122);
			this.cmdNext.Name = "cmdNext";
			this.cmdNext.Size = new System.Drawing.Size(30, 23);
			this.cmdNext.TabIndex = 1;
			this.cmdNext.Text = ">";
			this.cmdNext.UseVisualStyleBackColor = true;
			this.cmdNext.Click += new System.EventHandler(this.cmdNext_Click);
			// 
			// lblGlyph
			// 
			this.lblGlyph.AutoSize = true;
			this.lblGlyph.Location = new System.Drawing.Point(227, 35);
			this.lblGlyph.Name = "lblGlyph";
			this.lblGlyph.Size = new System.Drawing.Size(44, 13);
			this.lblGlyph.TabIndex = 2;
			this.lblGlyph.Text = "Glyph #";
			// 
			// lblWidth
			// 
			this.lblWidth.AutoSize = true;
			this.lblWidth.Location = new System.Drawing.Point(227, 48);
			this.lblWidth.Name = "lblWidth";
			this.lblWidth.Size = new System.Drawing.Size(38, 13);
			this.lblWidth.TabIndex = 2;
			this.lblWidth.Text = "Width:";
			// 
			// lblHeight
			// 
			this.lblHeight.AutoSize = true;
			this.lblHeight.Location = new System.Drawing.Point(227, 61);
			this.lblHeight.Name = "lblHeight";
			this.lblHeight.Size = new System.Drawing.Size(41, 13);
			this.lblHeight.TabIndex = 2;
			this.lblHeight.Text = "Height:";
			// 
			// lblAscii
			// 
			this.lblAscii.AutoSize = true;
			this.lblAscii.Location = new System.Drawing.Point(227, 74);
			this.lblAscii.Name = "lblAscii";
			this.lblAscii.Size = new System.Drawing.Size(37, 13);
			this.lblAscii.TabIndex = 2;
			this.lblAscii.Text = "ASCII:";
			// 
			// lblChar
			// 
			this.lblChar.AutoSize = true;
			this.lblChar.Location = new System.Drawing.Point(227, 87);
			this.lblChar.Name = "lblChar";
			this.lblChar.Size = new System.Drawing.Size(32, 13);
			this.lblChar.TabIndex = 2;
			this.lblChar.Text = "Char:";
			// 
			// cmdExit
			// 
			this.cmdExit.Location = new System.Drawing.Point(800, 189);
			this.cmdExit.Name = "cmdExit";
			this.cmdExit.Size = new System.Drawing.Size(75, 23);
			this.cmdExit.TabIndex = 3;
			this.cmdExit.Text = "E&xit";
			this.cmdExit.UseVisualStyleBackColor = true;
			this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
			// 
			// opnLFD
			// 
			this.opnLFD.DefaultExt = "lfd";
			this.opnLFD.Filter = "LFD Files|*.lfd";
			this.opnLFD.FileOk += new System.ComponentModel.CancelEventHandler(this.opnLFD_FileOk);
			// 
			// cmdOpen
			// 
			this.cmdOpen.Location = new System.Drawing.Point(12, 149);
			this.cmdOpen.Name = "cmdOpen";
			this.cmdOpen.Size = new System.Drawing.Size(44, 23);
			this.cmdOpen.TabIndex = 4;
			this.cmdOpen.Text = "&Open";
			this.cmdOpen.UseVisualStyleBackColor = true;
			this.cmdOpen.Click += new System.EventHandler(this.cmdOpen_Click);
			// 
			// lblFilename
			// 
			this.lblFilename.Location = new System.Drawing.Point(62, 154);
			this.lblFilename.Name = "lblFilename";
			this.lblFilename.Size = new System.Drawing.Size(293, 18);
			this.lblFilename.TabIndex = 5;
			this.lblFilename.Text = "Click to Open a LFD file";
			// 
			// lstFONT
			// 
			this.lstFONT.FormattingEnabled = true;
			this.lstFONT.Location = new System.Drawing.Point(12, 35);
			this.lstFONT.Name = "lstFONT";
			this.lstFONT.Size = new System.Drawing.Size(86, 108);
			this.lstFONT.TabIndex = 6;
			this.lstFONT.SelectedIndexChanged += new System.EventHandler(this.lstFONT_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(85, 13);
			this.label1.TabIndex = 7;
			this.label1.Text = "FONT resources";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(9, 181);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(246, 31);
			this.label2.TabIndex = 8;
			this.label2.Text = "TIE95 FONTs are located in EMPIRE.LFD, INSTALL.LFD and TITLE.LFD";
			// 
			// pctImport
			// 
			this.pctImport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pctImport.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pctImport.Location = new System.Drawing.Point(384, 35);
			this.pctImport.Name = "pctImport";
			this.pctImport.Size = new System.Drawing.Size(71, 81);
			this.pctImport.TabIndex = 0;
			this.pctImport.TabStop = false;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(381, 19);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(77, 13);
			this.label3.TabIndex = 9;
			this.label3.Text = "Import Preview";
			// 
			// cmdSave
			// 
			this.cmdSave.Location = new System.Drawing.Point(230, 181);
			this.cmdSave.Name = "cmdSave";
			this.cmdSave.Size = new System.Drawing.Size(75, 23);
			this.cmdSave.TabIndex = 10;
			this.cmdSave.Text = "&Save LFD";
			this.cmdSave.UseVisualStyleBackColor = true;
			this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
			// 
			// cmdCopy
			// 
			this.cmdCopy.Enabled = false;
			this.cmdCopy.Location = new System.Drawing.Point(296, 35);
			this.cmdCopy.Name = "cmdCopy";
			this.cmdCopy.Size = new System.Drawing.Size(75, 23);
			this.cmdCopy.TabIndex = 11;
			this.cmdCopy.Text = "<- &Copy";
			this.cmdCopy.UseVisualStyleBackColor = true;
			this.cmdCopy.Click += new System.EventHandler(this.cmdCopy_Click);
			// 
			// lblImpWidth
			// 
			this.lblImpWidth.AutoSize = true;
			this.lblImpWidth.Location = new System.Drawing.Point(461, 48);
			this.lblImpWidth.Name = "lblImpWidth";
			this.lblImpWidth.Size = new System.Drawing.Size(38, 13);
			this.lblImpWidth.TabIndex = 2;
			this.lblImpWidth.Text = "Width:";
			// 
			// lblImpHeight
			// 
			this.lblImpHeight.AutoSize = true;
			this.lblImpHeight.Location = new System.Drawing.Point(461, 61);
			this.lblImpHeight.Name = "lblImpHeight";
			this.lblImpHeight.Size = new System.Drawing.Size(41, 13);
			this.lblImpHeight.TabIndex = 2;
			this.lblImpHeight.Text = "Height:";
			// 
			// cmdImport
			// 
			this.cmdImport.Enabled = false;
			this.cmdImport.Location = new System.Drawing.Point(384, 122);
			this.cmdImport.Name = "cmdImport";
			this.cmdImport.Size = new System.Drawing.Size(75, 23);
			this.cmdImport.TabIndex = 12;
			this.cmdImport.Text = "&Import";
			this.cmdImport.UseVisualStyleBackColor = true;
			this.cmdImport.Click += new System.EventHandler(this.cmdImport_Click);
			// 
			// lblRules
			// 
			this.lblRules.Location = new System.Drawing.Point(293, 61);
			this.lblRules.Name = "lblRules";
			this.lblRules.Size = new System.Drawing.Size(80, 93);
			this.lblRules.TabIndex = 13;
			this.lblRules.Text = "Height must be same. Width must be #px or less. Auto-converts to black and white." +
    "";
			// 
			// opnBitmap
			// 
			this.opnBitmap.DefaultExt = "bmp";
			this.opnBitmap.Filter = "Bitmaps|*.bmp";
			this.opnBitmap.FileOk += new System.ComponentModel.CancelEventHandler(this.opnBitmap_FileOk);
			// 
			// pnlImages
			// 
			this.pnlImages.BackColor = System.Drawing.SystemColors.ControlDark;
			this.pnlImages.Location = new System.Drawing.Point(534, 12);
			this.pnlImages.Name = "pnlImages";
			this.pnlImages.Size = new System.Drawing.Size(320, 169);
			this.pnlImages.TabIndex = 14;
			this.pnlImages.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlImages_Paint);
			this.pnlImages.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnlImages_MouseClick);
			// 
			// vsbImages
			// 
			this.vsbImages.Enabled = false;
			this.vsbImages.Location = new System.Drawing.Point(857, 12);
			this.vsbImages.Name = "vsbImages";
			this.vsbImages.Size = new System.Drawing.Size(21, 169);
			this.vsbImages.TabIndex = 15;
			this.vsbImages.ValueChanged += new System.EventHandler(this.vsbImages_ValueChanged);
			// 
			// cmdLoad
			// 
			this.cmdLoad.Enabled = false;
			this.cmdLoad.Location = new System.Drawing.Point(534, 189);
			this.cmdLoad.Name = "cmdLoad";
			this.cmdLoad.Size = new System.Drawing.Size(75, 23);
			this.cmdLoad.TabIndex = 16;
			this.cmdLoad.Text = "&Load FONT";
			this.cmdLoad.UseVisualStyleBackColor = true;
			this.cmdLoad.Click += new System.EventHandler(this.cmdLoad_Click);
			// 
			// cmdExport
			// 
			this.cmdExport.Enabled = false;
			this.cmdExport.Location = new System.Drawing.Point(615, 189);
			this.cmdExport.Name = "cmdExport";
			this.cmdExport.Size = new System.Drawing.Size(89, 23);
			this.cmdExport.TabIndex = 17;
			this.cmdExport.Text = "Export FONT";
			this.cmdExport.UseVisualStyleBackColor = true;
			this.cmdExport.Click += new System.EventHandler(this.cmdExport_Click);
			// 
			// savFont
			// 
			this.savFont.DefaultExt = "FONT";
			this.savFont.Filter = "LFD FONT Files|*.FONT";
			this.savFont.FileOk += new System.ComponentModel.CancelEventHandler(this.savFont_FileOk);
			// 
			// opnFont
			// 
			this.opnFont.DefaultExt = "FONT";
			this.opnFont.FileName = "openFileDialog1";
			this.opnFont.Filter = "LFD FONT Files|*.FONT";
			this.opnFont.FileOk += new System.ComponentModel.CancelEventHandler(this.opnFont_FileOk);
			// 
			// frmLFR
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(887, 228);
			this.Controls.Add(this.cmdExport);
			this.Controls.Add(this.cmdLoad);
			this.Controls.Add(this.vsbImages);
			this.Controls.Add(this.pnlImages);
			this.Controls.Add(this.lblRules);
			this.Controls.Add(this.cmdImport);
			this.Controls.Add(this.cmdCopy);
			this.Controls.Add(this.cmdSave);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lstFONT);
			this.Controls.Add(this.lblFilename);
			this.Controls.Add(this.cmdOpen);
			this.Controls.Add(this.cmdExit);
			this.Controls.Add(this.lblChar);
			this.Controls.Add(this.lblAscii);
			this.Controls.Add(this.lblImpHeight);
			this.Controls.Add(this.lblHeight);
			this.Controls.Add(this.lblImpWidth);
			this.Controls.Add(this.lblWidth);
			this.Controls.Add(this.lblGlyph);
			this.Controls.Add(this.cmdNext);
			this.Controls.Add(this.cmdPrev);
			this.Controls.Add(this.pctImport);
			this.Controls.Add(this.pctGlyph);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "frmLFR";
			this.Text = "LFD Font Reader";
			this.Load += new System.EventHandler(this.frmLFR_Load);
			((System.ComponentModel.ISupportInitialize)(this.pctGlyph)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pctImport)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pctGlyph;
		private System.Windows.Forms.Button cmdPrev;
		private System.Windows.Forms.Button cmdNext;
		private System.Windows.Forms.Label lblGlyph;
		private System.Windows.Forms.Label lblWidth;
		private System.Windows.Forms.Label lblHeight;
		private System.Windows.Forms.Label lblAscii;
		private System.Windows.Forms.Label lblChar;
		private System.Windows.Forms.Button cmdExit;
		private System.Windows.Forms.OpenFileDialog opnLFD;
		private System.Windows.Forms.Button cmdOpen;
		private System.Windows.Forms.Label lblFilename;
		private System.Windows.Forms.ListBox lstFONT;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.PictureBox pctImport;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button cmdSave;
		private System.Windows.Forms.Button cmdCopy;
		private System.Windows.Forms.Label lblImpWidth;
		private System.Windows.Forms.Label lblImpHeight;
		private System.Windows.Forms.Button cmdImport;
		private System.Windows.Forms.Label lblRules;
		private System.Windows.Forms.OpenFileDialog opnBitmap;
        private System.Windows.Forms.Panel pnlImages;
        private System.Windows.Forms.VScrollBar vsbImages;
        private System.Windows.Forms.Button cmdLoad;
        private System.Windows.Forms.Button cmdExport;
        private System.Windows.Forms.SaveFileDialog savFont;
        private System.Windows.Forms.OpenFileDialog opnFont;
    }
}

