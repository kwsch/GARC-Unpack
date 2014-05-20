GARC-Unpack
===========

Simple Nintendo 3DS .GARC container unpacker.

	Takes an input file (via File Browser or Drag&Drop)
	Creates a new folder for extracted contents
	Extracts all files inside
	LZSS decompresses any compressed files

	Attempts to detect file extensions (ie BCH, CGFX, CFNT)
	Also can force BIN extension for all files.

	Basis for extraction (via structs) is based off Tinke by pleonex
	The LZSS decompression code is from Tinke as well.
	https://github.com/pleonex
	https://code.google.com/p/tinke
