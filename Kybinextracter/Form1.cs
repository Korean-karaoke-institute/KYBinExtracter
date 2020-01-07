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
            if(filepathtxt.Text.Length <= 0)
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
                        string filesig =Encoding.ASCII.GetString(kybinreader.ReadBytes(4));
                        byte filetype = kybinreader.ReadByte();
                        if (filesig != "HANA" || filetype != 5)
                        {
                            if(MessageBox.Show("This file may not be handled by this program. Continue anyway? Please do not report any errors that result from processing this file.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
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
                catch(Exception ex)
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
            if(folderBrowserDialog1.ShowDialog() == DialogResult.OK)
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
                Directory.CreateDirectory(folderBrowserDialog1.SelectedPath+"\\"+Path.GetFileNameWithoutExtension(filepathtxt.Text));
                extpath = extpath +"\\"+ Path.GetFileNameWithoutExtension(filepathtxt.Text);
            }
            int val = 0;
            foreach (string fl in filelist)
            {
                val++;
                toolStripStatusLabel1.Text = val+"/" + filelist.Count.ToString();
                toolStripProgressBar1.Value = val;
                progressBar1.Value = val;
                string binfilename = fl.Split('?')[0];
                string binpath = fl.Split('?')[1];
                binpath = binpath.Substring(3, binpath.Length - 3);
                if(binpath != "")
                {
                    Directory.CreateDirectory(extpath + "\\" + binpath);
                }
                int fileoffset = int.Parse(fl.Split('?')[2]);
                int filesize = int.Parse(fl.Split('?')[3]);
                BinaryReader kybinreader = new BinaryReader(File.Open(filepathtxt.Text, FileMode.Open));
                BinaryWriter ext = new BinaryWriter(File.Create(extpath + "\\" +binpath+"\\"+ binfilename));
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
    }
}
