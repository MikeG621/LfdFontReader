/*
 * LfdFontReader.exe, Editor for TIE95 FONT resources in LFD files
 * Copyright (C) 2009 Michael Gaisser (mjgaisser@gmail.com)
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
 * VERSION: 1.0.3
 */

/*
 * CHANGELOG
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

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Idmr.LfdReader;

namespace Idmr.LfdFontReader
{
	public partial class frmLFR : Form
	{
		private int _index=0;
		private Idmr.LfdReader.Font _fnt;
		LfdFile _lfd;

		public frmLFR()
		{
			InitializeComponent();
			Height = 248;
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

		private void cmdExit_Click(object sender, EventArgs e)
		{
			if (Text.Contains("*"))
			{
				DialogResult res = MessageBox.Show("Font is unsaved, do you wish to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (res == DialogResult.Yes) Application.Exit();
			}
			else Application.Exit();
		}
		private void cmdOpen_Click(object sender, EventArgs e)
		{
			opnLFD.ShowDialog();
		}
		private void opnLFD_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
		{
			lstFONT.Items.Clear();
			cmdImport.Enabled = false;
			_lfd = new LfdFile(opnLFD.FileName);
			for (int i = 0; i < _lfd.Rmap.NumberOfHeaders; i++)
				if (_lfd.Rmap.SubHeaders[i].Type == Resource.ResourceType.Font) lstFONT.Items.Add(_lfd.Rmap.SubHeaders[i].Name);
			Text = "LFD Font Reader";
			cmdNext.Enabled = false;
			cmdPrev.Enabled = false;
			lblFilename.Text = opnLFD.FileName;
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
					_fnt = new Idmr.LfdReader.Font(_lfd.Rmap.FileName, _lfd.Rmap.SubHeaders[i].Offset);
					Text = "LFD Font Reader - " + _lfd.FileName + ":" + _lfd.Rmap.SubHeaders[i].Name;
					cmdNext.Enabled = true;
					cmdPrev.Enabled = true;
					_index = 0;
					UpdateGlyph();
					lblRules.Text = "Height must be same. Width must be " + _fnt.BitsPerScanLine.ToString() + "px or less. Auto-converts to black and white.";
				}
		}
		private void cmdImport_Click(object sender, EventArgs e)
		{
			opnBitmap.ShowDialog();
		}
		private void opnBitmap_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
		{
			cmdCopy.Enabled = false;
			Bitmap bm = new Bitmap(opnBitmap.FileName);
			Bitmap image = new Bitmap(bm);	// force to Format32bppRGB
			Bitmap glyph = new Bitmap(image.Width, image.Height, PixelFormat.Format1bppIndexed);
			bm.Dispose();	// prevents file from remaining open
			lblImpHeight.Text = "Height: " + image.Height.ToString();
			lblImpWidth.Text = "Width: " + image.Width.ToString();
			if (image.Height == _fnt.Height && image.Width <= _fnt.BitsPerScanLine) cmdCopy.Enabled = true;
			// convert to Format1bppIndexed
			BitmapData bd32 = image.LockBits(new Rectangle(new Point(), image.Size), ImageLockMode.ReadWrite, image.PixelFormat);
			byte[] pix32 = new byte[bd32.Stride*bd32.Height];
			System.Runtime.InteropServices.Marshal.Copy(bd32.Scan0, pix32, 0, pix32.Length);	// image to byte[]
			// setup glyph
			BitmapData bd1 = glyph.LockBits(new Rectangle(new Point(), glyph.Size), ImageLockMode.ReadWrite, glyph.PixelFormat);
			byte[] pix1 = new byte[bd1.Stride*bd1.Height];
			for (int y=0;y<image.Height;y++)
				for (int x=0, pos32=y*bd32.Stride, pos1=y*bd1.Stride;x<image.Width;x++)
					if (pix32[pos32+x*4] != 0 || pix32[pos32+x*4+1] != 0 || pix32[pos32+x*4+2] != 0) pix1[pos1+x/8] |= (byte)(0x80 >> (x&7));
			System.Runtime.InteropServices.Marshal.Copy(pix1, 0, bd1.Scan0, pix1.Length);	// byte[] to image
			image.UnlockBits(bd32);
			glyph.UnlockBits(bd1);
			pctImport.BackgroundImage = glyph;
		}
		private void cmdCopy_Click(object sender, EventArgs e)
		{
			_fnt.Glyphs[_index] = (Bitmap)pctImport.BackgroundImage;
			UpdateGlyph();
			if (!Text.Contains("*")) Text += "*";
		}
		private void cmdSave_Click(object sender, EventArgs e)
		{
			_lfd.Write();
			Text = "LFD Font Reader - " + lstFONT.Items[lstFONT.SelectedIndex].ToString();
		}
	}
}
