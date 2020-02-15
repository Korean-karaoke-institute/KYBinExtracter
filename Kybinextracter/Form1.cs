using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kybinextracter
{
    public partial class Form1 : Form
    {
        List<string> filelist = new List<string>();

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        public Form1(string a)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            filepathtxt.Text = a;
            analyzebtn_Click(null, null);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void fileselectbtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filepathtxt.Text = openFileDialog1.FileName;
                analyzebtn_Click(null, null);
            }
        }

        private void analyzebtn_Click(object sender, EventArgs e)
        {
            if (filepathtxt.Text.Length <= 0)
            {
                MessageBox.Show("Please Select a file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    using (BinaryReader kybinreader = new BinaryReader(File.Open(filepathtxt.Text, FileMode.Open)))
                    {
                        filelist.Clear();
                        listView1.Items.Clear();
                        listView2.Items.Clear();
                        string filesig = Encoding.ASCII.GetString(kybinreader.ReadBytes(4));
                        byte filetype = kybinreader.ReadByte();
                        if (filesig != "HANA" || (filetype != 5 && filetype != 1))
                        {
                            if (MessageBox.Show("This file may not be handled by this program. Continue anyway? Please do not report any errors that result from processing this file.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                            {
                                return;
                            }
                        }
                        kybinreader.BaseStream.Seek(0x0B, SeekOrigin.Current);
                        while (true)
                        {
                            string filenamebin = Encoding.ASCII.GetString(kybinreader.ReadBytes(0x0E)).Split('\0')[0];
                            if (filenamebin == "") { break; }
                            string filepathbin = Encoding.ASCII.GetString(kybinreader.ReadBytes(0x16)).Split('\0')[0];
                            int filesize = kybinreader.ReadInt32();
                            //kybinreader.BaseStream.Seek(0x04, SeekOrigin.Current);
                            int fileoffset = kybinreader.ReadInt32();
                            kybinreader.BaseStream.Seek(0x04, SeekOrigin.Current);
                            listView1.Items.Add(new ListViewItem(new string[] { filenamebin, filepathbin, (Math.Ceiling(filesize / 1024.0)).ToString() + " KB", "0x" + fileoffset.ToString("X2") }));
                            filelist.Add(string.Format("{0}?{1}?{2}?{3}", filenamebin, filepathbin, fileoffset.ToString(), filesize.ToString()));
                        }
                        extractallbtn.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void extractallbtn_Click(object sender, EventArgs e)
        {
            extractallbtn.Enabled = false;
            try
            {
                folderBrowserDialog1.SelectedPath = Path.GetDirectoryName(filepathtxt.Text);
            }
            catch
            {

            }
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                extractallbtn.Enabled = true;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            extractallbtn.Text = "Processing...";
            toolStripProgressBar1.Maximum = filelist.Count;
            progressBar1.Maximum = filelist.Count;
            toolStripStatusLabel1.Text = "0/" + filelist.Count.ToString();
            toolStripProgressBar1.Value = 0;
            progressBar1.Value = 0;
            string extpath = folderBrowserDialog1.SelectedPath;
            if (subfolderopt.Checked)
            {
                Directory.CreateDirectory(folderBrowserDialog1.SelectedPath + "\\" + Path.GetFileNameWithoutExtension(filepathtxt.Text));
                extpath = extpath + "\\" + Path.GetFileNameWithoutExtension(filepathtxt.Text);
            }
            int val = 0;
            foreach (string fl in filelist)
            {
                val++;
                toolStripStatusLabel1.Text = val + "/" + filelist.Count.ToString();
                toolStripProgressBar1.Value = val;
                progressBar1.Value = val;
                string binfilename = fl.Split('?')[0];
                string binpath = fl.Split('?')[1];
                binpath = binpath.Substring(3, binpath.Length - 3);
                if (binpath != "")
                {
                    Directory.CreateDirectory(extpath + "\\" + binpath);
                }
                int fileoffset = int.Parse(fl.Split('?')[2]);
                int filesize = int.Parse(fl.Split('?')[3]);
                BinaryReader kybinreader = new BinaryReader(File.Open(filepathtxt.Text, FileMode.Open));
                BinaryWriter ext = new BinaryWriter(File.Create(extpath + "\\" + binpath + "\\" + binfilename));
                kybinreader.BaseStream.Seek(fileoffset, SeekOrigin.Begin);
                label1.Text = binfilename;
                ext.Write(kybinreader.ReadBytes(filesize));
                kybinreader.Close();
                ext.Close();
            }
            extractallbtn.Enabled = true;
            toolStripStatusLabel1.Text = "Completed!";
            extractallbtn.Text = "Extract all";
            if (auto_openopt.Checked)
            {
                Process.Start(extpath);
            }
        }

        private void auto_openopt_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void filepathtxt_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            filepathtxt.Text = files[0];
            analyzebtn_Click(null, null);
        }

        private void filepathtxt_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }


        private void extractThisFileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listView1.SelectedItems.Count == 1)
                {
                    listView1.ContextMenuStrip.Show(Cursor.Position);
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                loadPreview(filelist[listView1.FocusedItem.Index]);
            }
        }
        public void loadPreview(string flist)
        {
            //"{0}?{1}?{2}?{3}", filenamebin, filepathbin, fileoffset.ToString(), filesize.ToString()
            string[] gzMethod = { "store", "compress", "pack", "lzh", "-", "-", "-", "-", "deflate" };
            string[] gzOSType = { "FAT filesystem (MS-DOS, OS/2, NT/Win32)", "Amiga", "VMS (or OpenVMS)","Unix",
            "VM/CMS","Atari TOS","HPFS filesystem (OS/2, NT)","Macintosh","Z-System","CP/M","TOPS-20","NTFS filesystem (NT)",
            "QDOS","Acorn RISCOS"};
            string filename = flist.Split('?')[0];
            string filepath = flist.Split('?')[1];
            int fileoffset = int.Parse(flist.Split('?')[2]);
            uint filesize = uint.Parse(flist.Split('?')[3]);
            string fileext = Path.GetExtension(filename);
            listView2.Items.Clear();
            using (BinaryReader binreader = new BinaryReader(File.Open(filepathtxt.Text, FileMode.Open)))
            {
                listView2.Items.Add(new ListViewItem(new string[] { "Extention", fileext }));
                listView2.Items.Add(new ListViewItem(new string[] { "Name", filename }));
                listView2.Items.Add(new ListViewItem(new string[] { "Size(byte)", string.Format("{0:n0}", filesize) }));
                if (fileext.ToLower() == ".tgz" || fileext.ToLower() == ".kms")
                {
                    listView2.Items.Add(new ListViewItem(new string[] { "Format", "Gzip Compressed Package" }));
                    binreader.BaseStream.Seek(fileoffset + 2, SeekOrigin.Begin);
                    listView2.Items.Add(new ListViewItem(new string[] { "Comp. method", gzMethod[binreader.ReadByte()] }));
                    binreader.BaseStream.Seek(1, SeekOrigin.Current);
                    listView2.Items.Add(new ListViewItem(new string[] { "Last edited date", UnixTimeStampToDateTime(binreader.ReadInt32()).ToString() }));
                    binreader.BaseStream.Seek(1, SeekOrigin.Current);
                    try
                    {
                        listView2.Items.Add(new ListViewItem(new string[] { "Created OS Type", gzOSType[binreader.ReadByte()] }));
                    }
                    catch (IndexOutOfRangeException)
                    {
                        listView2.Items.Add(new ListViewItem(new string[] { "Created OS Type", "Unknown" }));
                    }
                }
                else if (fileext.ToLower() == ".kbn")
                {
                    binreader.BaseStream.Seek(fileoffset + 0x10, SeekOrigin.Begin);
                    listView2.Items.Add(new ListViewItem(new string[] { "Format", "h264 Encoded Video" }));
                    listView2.Items.Add(new ListViewItem(new string[] { "Inner Filename", Encoding.ASCII.GetString(binreader.ReadBytes(0x80)).Split('\0')[0] }));
                }
                else if (fileext.ToLower() == ".de2" || fileext.ToLower() == ".lst" || fileext.ToLower() == ".30" || fileext.ToLower() == ".del")
                {
                    binreader.BaseStream.Seek(fileoffset, SeekOrigin.Begin);
                    listView2.Items.Add(new ListViewItem(new string[] { "Format", "Text" }));
                    listView2.Items.Add(new ListViewItem(new string[] { "Text Preview", Encoding.GetEncoding(51949).GetString(binreader.ReadBytes(256)).Replace("\r\n", "  ") + "..." }));
                }
                else if (fileext.ToLower() == ".kyc" || fileext.ToLower() == ".ky2" || fileext.ToLower() == ".ky3")
                {
                    binreader.BaseStream.Seek(fileoffset, SeekOrigin.Begin);
                    listView2.Items.Add(new ListViewItem(new string[] { "Format", "KY Karaoke Song file" }));
                    bool encrypted = false;
                    string songno = "-";
                    string encoding = "-";
                    string lang = "-";
                    string title = "-";
                    string artist = "-";
                    string utaidashi = "-";
                    if (fileext.ToLower() == ".ky2" || fileext.ToLower() == ".ky3")
                    {
                        binreader.BaseStream.Seek(0x1b, SeekOrigin.Current);
                        byte enctype = binreader.ReadByte();
                        binreader.BaseStream.Seek(0x08, SeekOrigin.Current);
                        encoding = Encoding.ASCII.GetString(binreader.ReadBytes(0x08)).Split('\0')[0];
                        lang = Encoding.ASCII.GetString(binreader.ReadBytes(0x04)).Split('\0')[0];
                        title = Encoding.UTF8.GetString(binreader.ReadBytes(256)).Split('\0')[0];
                        binreader.BaseStream.Seek(256, SeekOrigin.Current);
                        artist = Encoding.UTF8.GetString(binreader.ReadBytes(256)).Split('\0')[0];
                        if (enctype == 0x01)
                            binreader.BaseStream.Seek(fileoffset + 0x4e4, SeekOrigin.Begin);
                        else
                        {
                            binreader.BaseStream.Seek(fileoffset + 0x51c, SeekOrigin.Begin);
                        }
                        int codepage = 51949;
                        if (encoding.ToUpper().Contains("EUC-JP"))
                        {
                            codepage = 51932;
                        }
                        else if (encoding.ToUpper().Contains("EUC-CN"))
                        {
                            codepage = 51936;
                        }

                        if (Encoding.ASCII.GetString(binreader.ReadBytes(4)) != "HANA")
                            encrypted = true;
                        binreader.BaseStream.Seek(0x04, SeekOrigin.Current);
                        songno = BitConverter.ToUInt32(binreader.ReadBytes(4), 0).ToString();
                        binreader.BaseStream.Seek(0x98, SeekOrigin.Current);
                        utaidashi = Encoding.GetEncoding(codepage).GetString(binreader.ReadBytes(0x1c)).Split('\0')[0];
                    }
                    else
                    {
                        //binreader.BaseStream.Seek(fileoffset, SeekOrigin.Begin);

                        if (Encoding.ASCII.GetString(binreader.ReadBytes(4)) != "HANA")
                        {
                            encrypted = true;
                        }

                        binreader.BaseStream.Seek(0x04, SeekOrigin.Current);
                        uint sn = BitConverter.ToUInt32(binreader.ReadBytes(4), 0);
                        songno = sn.ToString();
                        binreader.BaseStream.Seek(0xc, SeekOrigin.Current);
                        int codepage = 51949;
                        if (sn < 45000 && sn > 39999)
                        {
                            codepage = 51932;
                        }
                        else if (sn < 20000 && sn > 10000)
                        {
                            codepage = 51936;
                        }
                        else if (sn < 35000 && sn > 29999)
                        {
                            codepage = 51936;
                        }
                        title = Encoding.GetEncoding(codepage).GetString(binreader.ReadBytes(0x38)).Split('\0')[0];
                        binreader.BaseStream.Seek(0x1c, SeekOrigin.Current);
                        artist = Encoding.GetEncoding(codepage).GetString(binreader.ReadBytes(0x38)).Split('\0')[0];
                        utaidashi = Encoding.GetEncoding(codepage).GetString(binreader.ReadBytes(0x1c)).Split('\0')[0];
                    }
                    songno = songno.PadLeft(5, '0');                    
                    listView2.Items.Add(new ListViewItem(new string[] { "Song No", songno}));
                    listView2.Items.Add(new ListViewItem(new string[] { "Song Title", title }));
                    listView2.Items.Add(new ListViewItem(new string[] { "Song Artist", artist }));
                    listView2.Items.Add(new ListViewItem(new string[] { "Encrypted", encrypted.ToString() }));
                    listView2.Items.Add(new ListViewItem(new string[] { "Language", lang }));
                    listView2.Items.Add(new ListViewItem(new string[] { "Lyric Encoding",encoding}));
                    listView2.Items.Add(new ListViewItem(new string[] { "Start Lyric", utaidashi }));
                }
                else if (fileext.ToLower() == ".kyd")
                {
                    binreader.BaseStream.Seek(fileoffset, SeekOrigin.Begin);
                    listView2.Items.Add(new ListViewItem(new string[] { "Format", "KY Karaoke Song file" }));
                }
                else
                {
                    listView2.Items.Add(new ListViewItem(new string[] { "", "Preview Unsupported" }));
                }
            }
        }
        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }
    }
}
