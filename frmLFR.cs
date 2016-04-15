/*
 * LfdFontReader.exe, Editor for TIE95 FONT resources in LFD files
 * Copyright (C) 2009-2016 Michael Gaisser (mjgaisser@gmail.com)
 * 
 * This software is free software; you can redistribute it and/or modify it
 * under the terms of the Mozilla Public License; either version 2.0 of the
 * License, or (at your option) any later version.
 *
 * This software is "as is" without warranty of any kind; including that the
 * software is free of defects, merchantable, fit for a particular purpose or
 * non-infringing. See the full license text for more details.
 *
 * If a copy of the MPL (License.txt) was not distributed with this file,
 * you can obtain one at http://mozilla.org/MPL/2.0/.
 * 
 * VERSION: 2.0
 */

/*
 * CHANGELOG
 * v2.0, 
 * [ADD] Added ability to import/export entire FONT resources
 * [UPD] Removed code replicating ConvertTo1bpp
 * [UPD] Removed extra Bitmap from opnBitmap.OK
 * [UPD] Importing glyphs/FONTs now ties back to the LFD directly. You can edit all FONTs before saving
 * [FIX] pctGlyph clears when switching LFDs
 * v1.0.3, 150127
 * - Published under MPL 2.0
 * v1.0.2, 090918
 * [UPD] Adjusted how some buttons enable/disable themselves
 * [UPD] image processing rewritten
 * v1.0.1, 090731
 * [FIX] Changed how Import handled the bitmaps to avoid keeping files open until exit
 * [UPD] changed form to fixed size
 * [DEL] removed Maxmimize button
 * v1.0, 090730
 * - Release
 */

using Idmr.LfdReader;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Idmr.LfdFontReader
{
    public partial class frmLFR : Form
	{
		private int _index=0;
		private LfdReader.Font _fnt;
		LfdFile _lfd;
		Bitmap _charMap = null;

		public frmLFR()
		{
			InitializeComponent();
			Height = 260;
		}

		private void cmdPrev_Click(object sender, EventArgs e)
		{
			if (_index==0) return;
			_index--;
			UpdateGlyph();
		}
		private void cmdNext_Click(object sender, EventArgs e)
		{
			if (_index==(_fnt.TotalChars-1)) return;
			_index++;
			UpdateGlyph();
		}

		private void PaintGlyphs()
		{
			Graphics g = Graphics.FromImage(_charMap);
			g.Clear(SystemColors.ControlDark);
			for (int index = 0, y = 0; ; y++)
			{
				for (int x = 0; x < _charMap.Width / (_fnt.BitsPerScanLine + 1); index++, x++)
				{
					if (index >= _fnt.TotalChars) break;
					g.DrawImageUnscaled(_fnt.Glyphs[index], x * (_fnt.BitsPerScanLine + 1), y * (_fnt.Height + 1) - vsbImages.Value);
				}
				if (index >= _fnt.TotalChars) break;
			}
			pnlImages.Invalidate();
			g.Dispose();
		}
		private void UpdateGlyph()
		{
			pctGlyph.BackgroundImage = _fnt.Glyphs[_index];
			lblGlyph.Text = "Glyph #" + _index.ToString();
			lblWidth.Text = "Width: " + _fnt.Glyphs[_index].Width;
			lblHeight.Text = "Height: " + _fnt.Glyphs[_index].Height;
			lblAscii.Text = "ASCII: " + (_fnt.StartingChar + _index).ToString();
			lblChar.Text = "Char: " + (char)(_fnt.StartingChar + _index);
			if ((_fnt.StartingChar + _index) == 38) lblChar.Text = "Char: &&";
		}

		private void frmLFR_Load(object sender, EventArgs e)
		{
			_charMap = new Bitmap(pnlImages.Width, pnlImages.Height);
		}

		private void cmdCopy_Click(object sender, EventArgs e)
		{
			_fnt.Glyphs[_index] = (Bitmap)pctImport.BackgroundImage;
			UpdateGlyph();
			if (!Text.Contains("*")) Text += "*";
		}
		private void cmdExit_Click(object sender, EventArgs e)
		{
			if (Text.Contains("*"))
			{
				DialogResult res = MessageBox.Show("Font is unsaved, do you wish to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (res == DialogResult.Yes) Application.Exit();
			}
			else Application.Exit();
		}
		private void cmdExport_Click(object sender, EventArgs e)
		{
			savFont.FileName = Common.StringFunctions.GetFileName(_fnt.FileName, false) + "-" + _fnt.Name;
			savFont.ShowDialog();
		}
		private void cmdImport_Click(object sender, EventArgs e)
		{
			opnBitmap.ShowDialog();
		}
		private void cmdLoad_Click(object sender, EventArgs e)
		{
			opnFont.ShowDialog();
		}
		private void cmdOpen_Click(object sender, EventArgs e)
		{
			opnLFD.ShowDialog();
		}
		private void cmdSave_Click(object sender, EventArgs e)
		{
			_lfd.Write();
			Text = "LFD Font Reader - " + _lfd.FileName + ":" + lstFONT.Items[lstFONT.SelectedIndex].ToString();
		}

		private void lstFONT_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lstFONT.SelectedIndex == -1) return;
			cmdImport.Enabled = true;
			cmdCopy.Enabled = false;
			pctImport.BackgroundImage = null;
			for (int i = 0; i < _lfd.Rmap.NumberOfHeaders; i++)
				if (_lfd.Rmap.SubHeaders[i].Name == lstFONT.Items[lstFONT.SelectedIndex].ToString())
				{
					_fnt = (LfdReader.Font)_lfd.Resources[i];
					Text = "LFD Font Reader - " + _lfd.FileName + ":" + _fnt.Name;
					cmdNext.Enabled = true;
					cmdPrev.Enabled = true;
					cmdExport.Enabled = true;
					cmdLoad.Enabled = true;
					_index = 0;
					UpdateGlyph();
					lblRules.Text = "Height must be same. Width must be " + _fnt.BitsPerScanLine + "px or less. Auto-converts to black and white.";
					int numRows = (int)Math.Ceiling((double)_fnt.TotalChars / pnlImages.Width * (_fnt.BitsPerScanLine + 1));  // rows of glyphs in pnlImages
					vsbImages.Enabled = (numRows * (_fnt.Height + 1) > pnlImages.Height);
					vsbImages.Value = 0;
					if (vsbImages.Enabled) vsbImages.Maximum = numRows * (_fnt.Height + 2) - pnlImages.Height;
					PaintGlyphs();
				}
		}

		private void opnBitmap_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
		{
			cmdCopy.Enabled = false;
			Bitmap bm = new Bitmap(opnBitmap.FileName);
			Bitmap glyph = new Bitmap(bm.Width, bm.Height, PixelFormat.Format1bppIndexed);
			lblImpHeight.Text = "Height: " + bm.Height.ToString();
			lblImpWidth.Text = "Width: " + bm.Width.ToString();
			if (bm.Height == _fnt.Height && bm.Width <= _fnt.BitsPerScanLine) cmdCopy.Enabled = true;
			pctImport.BackgroundImage = Common.GraphicsFunctions.ConvertTo1bpp(bm);
			bm.Dispose();   // prevents file from remaining open
		}
		private void opnFont_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
		{
			FileStream fs = null;
			try
			{
				fs = File.OpenRead(opnFont.FileName);
				LfdReader.Font newFont = new LfdReader.Font(fs, 0);
				if (newFont.Name != _fnt.Name) throw new InvalidDataException();
				_fnt.DecodeResource(newFont.RawData, false);
			}
			catch (InvalidDataException)
			{
				MessageBox.Show("FONT Resource names must match to ensure compatability and prevent accidental overwrites.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (Exception x)
			{
				MessageBox.Show(x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				fs.Close();
			}
		}
		private void opnLFD_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
		{
			lstFONT.Items.Clear();
			pctGlyph.BackgroundImage = null;
			cmdImport.Enabled = false;
			_lfd = new LfdFile(opnLFD.FileName);
			for (int i = 0; i < _lfd.Rmap.NumberOfHeaders; i++)
				if (_lfd.Rmap.SubHeaders[i].Type == Resource.ResourceType.Font) lstFONT.Items.Add(_lfd.Rmap.SubHeaders[i].Name);
			Text = "LFD Font Reader" + _lfd.FileName;
			cmdNext.Enabled = false;
			cmdPrev.Enabled = false;
            cmdExport.Enabled = false;
            cmdLoad.Enabled = false;
			lblFilename.Text = opnLFD.FileName;
		}

		private void pnlImages_MouseClick(object sender, MouseEventArgs e)
		{
			int x, y, glyphsPerRow, rows;
			glyphsPerRow = pnlImages.Width / (_fnt.BitsPerScanLine + 1);
			rows = (int)Math.Ceiling((double)_fnt.TotalChars / glyphsPerRow);
			x = e.X / (_fnt.BitsPerScanLine + 1);
			if ((x + 1) * (_fnt.BitsPerScanLine + 1) > pnlImages.Width) x--;
			y = (e.Y + vsbImages.Value) / (_fnt.Height + 1);
			if ((y + 1) * (_fnt.Height + 1) > rows * (_fnt.Height + 1)) y--;
			_index = glyphsPerRow * y + x;
			if (_index > _fnt.TotalChars) _index = _fnt.TotalChars - 1;
			UpdateGlyph();
		}
		private void pnlImages_Paint(object sender, PaintEventArgs e)
		{
			Graphics g;
			g = e.Graphics;
			g.DrawImage(_charMap, 0, 0, _charMap.Width, _charMap.Height);
		}

		private void savFont_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            FileStream fs = null;
            try
            {
                fs = File.OpenWrite(savFont.FileName);
                BinaryWriter bw = new BinaryWriter(fs);
                bw.Write("FONT".ToCharArray());
                bw.Write(_fnt.Name.ToCharArray());
                bw.Write((long)0);
                fs.Position = Resource.LengthOffset;
                bw.Write(_fnt.Length);
                bw.Write(_fnt.RawData);
                fs.SetLength(fs.Position);
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                fs.Close();
            }
        }

		private void vsbImages_ValueChanged(object sender, EventArgs e)
		{
			PaintGlyphs();
		}

	}
}
