/*
 * LfdFontReader.exe, Editor for TIE95 FONT resources in LFD files
 * Copyright (C) 2009 Michael Gaisser (mjgaisser@gmail.com)
 * Licensed under the MPL v2.0 or later
 * 
 * VERSION: 1.0.3
 */

using System;
using System.Windows.Forms;

namespace Idmr.LfdFontReader
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new frmLFR());
		}
	}
}
