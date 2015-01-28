LFD FONT Reader
===============================================================================
Author: Michael Gaisser (mjgaisser@gmail.com)
Version 1.0.3
Date: 2015.01.27
===============================================================================

This editor reads and writes the FONT resource types found in TIE95 LFD files.

At this time there is no ability to export images, this wasn't seen as a
necessity given the small size and simplicity of the character glyphs.  Future
versions may include the abilty to import/export bitmap image lists instead of
single characters.

===================
VERSION HISTORY

v1.0.3 - 27 Jan 2015
 - Published under MPL 2.0

v1.0.2 - 19 Sep 2009
 - Adjusted how some buttons enable/disable themselves
 - image processing rewritten 
 
v1.0.1 - 31 Jul 2009
 - Changed how Import handled the bitmaps to avoid keeping files open until exit
 - Changed form to fixed size
 - Removed Maxmimize button

v1.0 - 29 Jul 2009
 - Release

===================
IMAGE GUIDELINES

Given the different encodings, the maximum width of the character is dependant
on a variable within the FONT resource, which this program does not edit.  Max
width will be a multiple of 8.
Height of a given character for the FONT resource is required to be the same
throughout, and this program will not attempt to adjust off-size images, exact
height is required.

Images should have a black background, interpreted by the game as transparent.
Any non-black color will be converted to white as solid.

===================
INSTRUCTIONS

- Open the LFD you wish to search using the 'Open' button. The full path will be
displayed next to it.  The only FONT resources in TIE95 can be found in
EMPIRE.LFD, INSTALL.LFD and TITLE.LFD.
- Select the FONT you wish to view in the list on the left.
- Use the '<' and '>' buttons to browse the glyphs.
- The 'Import' button will let you choose the bitmap you wish to use to
overwrite, sizing restrictions are enforced here.
- The '<- Copy' button does just that, copies the imported image to the left.
- Changes are not permanent until the 'Save' button is clicked. This only has
to be done once per FONT resource, not per character.

As always, backup your original files first.

===============================================================================
Copyright © 2009 Michael Gaisser
This program and related files are licensed under the Mozilla Public License.
See License.txt for the full text. If for some reason the license was not
distributed with this program, you can obtain the full text of the license at
http://mozilla.org/MPL/2.0/.

"Star Wars" and related items are trademarks of LucasFilm Ltd and
LucasArts Entertainment Co.

This software is provided "as is" without warranty of any kind; including that
the software is free of defects, merchantable, fit for a particular purpose or
non-infringing. See the full license text for more details.