using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Pack
{

    public partial class Form1 : Form
    {
        private void Form_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }
        private void Form_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            string path = files[0]; // open first D&D
            textBox1.Text = path;

            if (CHK_AutoExtract.Checked)
            {
                B_Go_Click(sender, (EventArgs)e);
            }

        }
        public Form1()
        {
            InitializeComponent();

            this.DragEnter += new DragEventHandler(Form_DragEnter);
            this.DragDrop += new DragEventHandler(Form_DragDrop);
            RTB.Clear();
        }

        private void B_Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = ofd.FileName;
            }
        }
        private void B_Go_Click(object sender, EventArgs e)
        {
            // Continue only if a string path is loaded.
            if (textBox1.Text.Length < 1) return;

            // Fetch file extension (first 4 bytes) to check if it is a GARC
            BinaryReader brz = new BinaryReader(System.IO.File.OpenRead(textBox1.Text));
            try { 
                string s = new string(Reverse(brz.ReadChars(4)));
                if (s != "GARC")
                {
                    RTB.Text += "Input file is not a .GARC";
                    return;
                }
                RTB.Text = s;
            }
            catch (EncoderFallbackException)
            {
                RTB.Text += "Invalid File.";
                return;
            }
            brz.Close();

            // Unpack the GARC
            GARC garc = ARC.Unpack(textBox1.Text);
            RTB.Text += "\r\nCount: " + garc.otaf.nFiles;
            ProgressInit(garc.otaf.nFiles);
            if (garc.otaf.nFiles > 50)
            {
                CHK_NoPrint.Checked = true;
            }

            // Get file path infos for exporting
            FileInfo fileInfo = new FileInfo(textBox1.Text);
            string path = fileInfo.DirectoryName;
            string parentName = fileInfo.Name;
            string basepath = path + "\\" + parentName + "_"; 
            BinaryReader br = new BinaryReader(System.IO.File.OpenRead(textBox1.Text));

            // Create Extraction folder if it does not exist.
            if (!Directory.Exists(basepath))
            {
                DirectoryInfo di = Directory.CreateDirectory(basepath);
            }
            
            // Pull out all the files
            for (int i = 0; i < garc.otaf.nFiles; i++)
            {
                string ext = "bin";
                bool compressed = false;

                string newext;
                br.BaseStream.Position = garc.btaf.entries[i].start_offset + garc.data_offset;
                try
                {
                    newext = TrimFromZero(new string(br.ReadChars(4)));
                    if ((System.Text.RegularExpressions.Regex.IsMatch(newext, @"^[a-zA-Z0-9]+$")) && (!CHK_ForceBIN.Checked))
                        ext = newext;
                    else
                    {
                        compressed = true;
                    }
                }
                catch { newext = null; }
                
                // Set File Name
                string filename = i.ToString("D" + Math.Ceiling(Math.Log10(garc.otaf.nFiles)));
                string fileout = basepath + "\\" + filename + "." + ext;
                BinaryWriter bw = new BinaryWriter(File.OpenWrite(fileout));
                
                // Write out the data for the file
                br.BaseStream.Position = garc.btaf.entries[i].start_offset + garc.data_offset;
                for (int x = 0; x < garc.btaf.entries[i].length; x++)
                {
                    bw.Write(br.ReadByte());
                }
                bw.Flush(); bw.Close();
                printout("\r\nWrote to " + fileout);

                // See if decompression should be attempted.
                if (compressed && !CHK_SkipDecompress.Checked)
                {
                    string decout = path + "\\" + parentName + "_\\" + "dec_" + filename;
                    string result = LZSS.Decompress11LZS(fileout, decout);

                    if (result != null)
                    {
                        printout("\r\n" + result);
                        if (CHK_delAfterD.Checked)
                        {
                            try { File.Delete(fileout); }
                            catch { }
                        }
                    }
                }
                pBar1.PerformStep();
            }
            br.Close();

            RTB.Text += "\r\nDone!";
            RTB.Select(RTB.Text.Length - 1, 0);
            RTB.ScrollToCaret();
        }
        private void printout(string str)
        {
            if (CHK_NoPrint.Checked) 
                return;
            RTB.Text += str;
            RTB.Select(RTB.Text.Length - 1, 0);
            RTB.ScrollToCaret();
        }
        public string TrimFromZero(string input)
        {
            int index = input.IndexOf('\0');
            if (index != input.Length - 1)
                return input;

            return input.Substring(0, index);
        }
        public static uint Reverse(uint x)
        {
            uint y = 0;
            for (int i = 0; i < 32; ++i)
            {
                y <<= 1;
                y |= (x & 1);
                x >>= 1;
            }
            return y;
        }
        public static char[] Reverse(char[] charArray)
        {
            Array.Reverse(charArray);
            return charArray;
        }
        private void clearTextbox(object sender, EventArgs e)
        {
            RTB.Clear();
        }
        private void ProgressInit(int count)
        {
            // Display the ProgressBar control.
            pBar1.Visible = true;
            pBar1.Minimum = 1;
            pBar1.Maximum = count;
            pBar1.Step = 1;
            pBar1.Value = 1;
        }
    }
    // Class code based off of
    // https://code.google.com/p/tinke/source/browse/trunk/Plugins/Pack/Pack/NARC.cs
    // by pleonex / benito356
    #region GARC Destructuring
    public class ARC
    {
        public static uint Reverse(uint x)
        {
            uint y = 0;
            for (int i = 0; i < 32; ++i)
            {
                y <<= 1;
                y |= (x & 1);
                x >>= 1;
            }
            return y;
        }
        public static char[] Reverse(char[] charArray)
        {
            Array.Reverse(charArray);
            return charArray;
        }
        public static GARC Unpack(string path)
        {
            GARC garc = new GARC();
            BinaryReader br = new BinaryReader(System.IO.File.OpenRead(path));

            // GARC Header
            garc.id = br.ReadChars(4);
            garc.header_size = br.ReadUInt32();
            garc.id_endian = br.ReadUInt16();
            if (garc.id_endian == 0xFEFF)
                Reverse(garc.id);
            garc.constant = br.ReadUInt16();
            garc.file_size = br.ReadUInt32();

            garc.data_offset = br.ReadUInt32();
            garc.file_length = br.ReadUInt32();
            garc.lastsize = br.ReadUInt32();

            // OTAF 
            garc.otaf.id = br.ReadChars(4);
            garc.otaf.section_size = br.ReadUInt32();
            garc.otaf.nFiles = br.ReadUInt16();
            garc.otaf.padding = br.ReadUInt16();

            garc.otaf.entries = new OTAF_Entry[garc.otaf.nFiles];
            // not really needed; plus it's wrong
            for (int i = 0; i < garc.otaf.nFiles; i++)
            {
                uint val = br.ReadUInt32();
                if (garc.otaf.padding == 0xffff)
                {
                    val = Reverse(val);
                }
                garc.otaf.entries[i].name = val.ToString();
            }

            // BTAF (File Allocation TaBle)
            garc.btaf.id = br.ReadChars(4);
            garc.btaf.section_size = br.ReadUInt32();
            garc.btaf.nFiles = br.ReadUInt32();

            garc.btaf.entries = new BTAF_Entry[garc.btaf.nFiles];
            for (int i = 0; i < garc.btaf.nFiles; i++)
            {
                garc.btaf.entries[i].bits = br.ReadUInt32();
                garc.btaf.entries[i].start_offset = br.ReadUInt32();
                garc.btaf.entries[i].end_offset = br.ReadUInt32();
                garc.btaf.entries[i].length = br.ReadUInt32();
            }

            // BMIF
            garc.gmif.id = br.ReadChars(4);
            garc.gmif.section_size = br.ReadUInt32();
            garc.gmif.data_size = br.ReadUInt32();

            // Files data

            br.Close();
            return garc;
        }
    }
    #region structs
    public struct GARC
    {
        public char[] id;           // Always GARC = 0x4E415243
        public UInt32 header_size;  // Always 0x001C
        public UInt16 id_endian;    // 0xFFFE
        public UInt16 constant;     // Always 0x0400 chunk count
        public UInt32 file_size;

        public UInt32 data_offset;
        public UInt32 file_length;
        public UInt32 lastsize;

        public OTAF otaf;
        public BTAF btaf;
        public GMIF gmif;
    }
    public struct OTAF
    {
        public char[] id;
        public UInt32 section_size;
        public UInt16 nFiles;
        public UInt16 padding;

        public OTAF_Entry[] entries;
    }
    public struct OTAF_Entry
    {
        public string name;
    }
    public struct BTAF
    {
        public char[] id;
        public UInt32 section_size;
        public UInt32 nFiles;
        public BTAF_Entry[] entries;
    }
    public struct BTAF_Entry
    {
        public UInt32 bits;
        public UInt32 start_offset;
        public UInt32 end_offset;
        public UInt32 length;
    }
    public struct GMIF
    {
        public char[] id;
        public UInt32 section_size;
        public UInt32 data_size;
    }
    #endregion
    #endregion

    // Tinke LZSS Code (now slightly altered)
    // https://code.google.com/p/tinke/source/browse/trunk/Plugins/Compresiones/Compresiones/LZSS.cs
    // by pleonex / benito356
    public static class LZSS
    {
        static int MAX_OUTSIZE = 0x200000;
        const int N = 4096, F = 18;
        const byte THRESHOLD = 2;
        const int NIL = N;
        static bool showAlways = true;

        const int LZ77_TAG = 0x10, LZSS_TAG = 0x11, RLE_TAG = 0x30, HUFF_TAG = 0x20, NONE_TAG = 0x00;

        // tag 0x11 LZSS
        public static string Decompress11LZS(string filein, string fileout)
        {
            /*  Data header (32bit)
                  Bit 0-3   Reserved
                  Bit 4-7   Compressed type (must be 1 for LZ77)
                  Bit 8-31  Size of decompressed data. if 0, the next 4 bytes are decompressed length
                Repeat below. Each Flag Byte followed by eight Blocks.
                Flag data (8bit)
                  Bit 0-7   Type Flags for next 8 Blocks, MSB first
                Block Type 0 - Uncompressed - Copy 1 Byte from Source to Dest
                  Bit 0-7   One data byte to be copied to dest
                Block Type 1 - Compressed - Copy LEN Bytes from Dest-Disp-1 to Dest
                    If Reserved is 0: - Default
                      Bit 0-3   Disp MSBs
                      Bit 4-7   LEN - 3
                      Bit 8-15  Disp LSBs
                    If Reserved is 1: - Higher compression rates for files with (lots of) long repetitions
                      Bit 4-7   Indicator
                        If Indicator > 1:
                            Bit 0-3    Disp MSBs
                            Bit 4-7    LEN - 1 (same bits as Indicator)
                            Bit 8-15   Disp LSBs
                        If Indicator is 1:
                            Bit 0-3 and 8-19   LEN - 0x111
                            Bit 20-31          Disp
                        If Indicator is 0:
                            Bit 0-3 and 8-11   LEN - 0x11
                            Bit 12-23          Disp
                      
             */
            string errstring = "";
            FileStream fstr = new FileStream(filein, FileMode.Open);
            if (fstr.Length > int.MaxValue)
            {
                errstring = "Filer larger than 2GB cannot be LZSS-compressed files.";
                fstr.Dispose();
                return errstring;
            }
            BinaryReader br = new BinaryReader(fstr);

            int decomp_size = 0, curr_size = 0;
            int i, j, disp, len;
            bool flag;
            byte b1, bt, b2, b3, flags;
            int cdest;

            int threshold = 1;

            if (br.ReadByte() != LZSS_TAG)
            {
                br.BaseStream.Seek(0x4, SeekOrigin.Begin);
                if (br.ReadByte() != LZSS_TAG)
                {
                    errstring = null; goto error;
                    // String.Format("File {0:s} is not a valid LZSS-11 file", filein);
                }
            }
            for (i = 0; i < 3; i++)
                decomp_size += br.ReadByte() << (i * 8);
            if (decomp_size > MAX_OUTSIZE)
            {
                errstring = String.Format("{0:s} will be larger than 0x{1:x} (0x{2:x}) and will not be decompressed.", filein, MAX_OUTSIZE, decomp_size); goto error;
            }
            else if (decomp_size == 0)
                for (i = 0; i < 4; i++)
                    decomp_size += br.ReadByte() << (i * 8);
            if (decomp_size > MAX_OUTSIZE << 8)
            {
                errstring = String.Format("{0:s} will be larger than 0x{1:x} (0x{2:x}) and will not be decompressed.", filein, MAX_OUTSIZE, decomp_size); goto error;
            }

            if (showAlways)
                Console.WriteLine("Decompressing {0:s}. (outsize: 0x{1:x})", filein, decomp_size);

            byte[] outdata = new byte[decomp_size];

            while (curr_size < decomp_size)
            {
                try { flags = br.ReadByte(); }
                catch (EndOfStreamException) { break; }

                for (i = 0; i < 8 && curr_size < decomp_size; i++)
                {
                    flag = (flags & (0x80 >> i)) > 0;
                    if (flag)
                    {
                        try { b1 = br.ReadByte(); }
                        catch (EndOfStreamException) { errstring = "Incomplete data 1"; goto error; }

                        switch (b1 >> 4)
                        {
                            #region case 0
                            case 0:
                                // ab cd ef
                                // =>
                                // len = abc + 0x11 = bc + 0x11
                                // disp = def

                                len = b1 << 4;
                                try { bt = br.ReadByte(); }
                                catch (EndOfStreamException) { errstring = "Incomplete data 2"; goto error; }
                                len |= bt >> 4;
                                len += 0x11;

                                disp = (bt & 0x0F) << 8;
                                try { b2 = br.ReadByte(); }
                                catch (EndOfStreamException) { errstring = "Incomplete data 3"; goto error; }
                                disp |= b2;
                                break;
                            #endregion

                            #region case 1
                            case 1:
                                // ab cd ef gh
                                // => 
                                // len = bcde + 0x111
                                // disp = fgh
                                // 10 04 92 3F => disp = 0x23F, len = 0x149 + 0x11 = 0x15A

                                try { bt = br.ReadByte(); b2 = br.ReadByte(); b3 = br.ReadByte(); }
                                catch (EndOfStreamException) { errstring = "Incomplete data 4"; goto error; }

                                len = (b1 & 0xF) << 12; // len = b000
                                len |= bt << 4; // len = bcd0
                                len |= (b2 >> 4); // len = bcde
                                len += 0x111; // len = bcde + 0x111
                                disp = (b2 & 0x0F) << 8; // disp = f
                                disp |= b3; // disp = fgh
                                break;
                            #endregion

                            #region other
                            default:
                                // ab cd
                                // =>
                                // len = a + threshold = a + 1
                                // disp = bcd

                                len = (b1 >> 4) + threshold;

                                disp = (b1 & 0x0F) << 8;
                                try { b2 = br.ReadByte(); }
                                catch (EndOfStreamException) { errstring = "Incomplete data 5"; goto error; }
                                disp |= b2;
                                break;
                            #endregion
                        }

                        if (disp > curr_size) { errstring = "Cannot go back more than already written"; goto error; }

                        cdest = curr_size;

                        for (j = 0; j < len && curr_size < decomp_size; j++)
                            outdata[curr_size++] = outdata[cdest - disp - 1 + j];

                        if (curr_size > decomp_size)
                        {
                            errstring = String.Format("File {0:s} is not a valid LZ77 file; actual output size > output size in header", filein); goto error;
                            //Console.WriteLine(String.Format("File {0:s} is not a valid LZ77 file; actual output size > output size in header; {1:x} > {2:x}.", filein, curr_size, decomp_size));
                            // break;
                        }
                    }
                    else
                    {
                        try { outdata[curr_size++] = br.ReadByte(); }
                        catch (EndOfStreamException) { break; }// throw new Exception("Incomplete data"); }

                        if (curr_size > decomp_size)
                        {
                            br.Close(); 
                            errstring = String.Format("File {0:s} is not a valid LZ77 file; actual output size > output size in header", filein);
                            goto error;
                            //Console.WriteLine(String.Format("File {0:s} is not a valid LZ77 file; actual output size > output size in header; {1:x} > {2:x}", filein, curr_size, decomp_size));
                            // break;
                        }
                    }
                }

            }

            try
            {
                while (br.ReadByte() == 0) { } // if we read a non-zero, print that there is still some data
                Console.WriteLine("Too much data in file; current INPOS = {0:x}", br.BaseStream.Position - 1);
            }
            catch (EndOfStreamException) { }
            string newext = "bin";
            if (outdata.Length > 4)
            {
                newext = "";
                for (int c = 0; c < 4; c++)
                {
                    newext += (char)outdata[c];
                }
                newext = TrimFromZero(newext);
                if (!(System.Text.RegularExpressions.Regex.IsMatch(newext, @"^[a-zA-Z0-9]+$")))
                    newext = "bin";
            }
            else { newext = "bin"; }
            string fn;
            try
            {
                fn = fileout + "." + newext;
                BinaryWriter bw = new BinaryWriter(new FileStream(fn, FileMode.Create));
                bw.Write(outdata);
                bw.Flush();
                bw.Dispose();
            }
            catch
            {
                fn = fileout + ".bin";
                BinaryWriter bw = new BinaryWriter(new FileStream(fn, FileMode.Create));
                bw.Write(outdata);
                bw.Flush();
                bw.Dispose();
            }

            br.Dispose();
            fstr.Dispose();
            Console.WriteLine("LZSS-11 Decompressed " + filein);
            return String.Format("Decompressed to {0:s}", fn);

        error:
            {
                br.Dispose();
                fstr.Dispose();
                return errstring;
            }
        }
        public static string TrimFromZero(string input)
        {
            int index = input.IndexOf('\0');
            if (index != input.Length - 1)
                return input;

            return input.Substring(0, index);
        }
    }
}
