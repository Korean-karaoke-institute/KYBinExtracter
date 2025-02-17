﻿namespace Kybinextracter
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.fileselectbtn = new System.Windows.Forms.Button();
            this.filepathtxt = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.analyzebtn = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.path = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.size = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.offset = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.extractThisFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractallbtn = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.auto_openopt = new System.Windows.Forms.CheckBox();
            this.subfolderopt = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listView2 = new System.Windows.Forms.ListView();
            this.property = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.value = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileselectbtn
            // 
            this.fileselectbtn.Location = new System.Drawing.Point(12, 11);
            this.fileselectbtn.Name = "fileselectbtn";
            this.fileselectbtn.Size = new System.Drawing.Size(75, 23);
            this.fileselectbtn.TabIndex = 0;
            this.fileselectbtn.Text = "Select File";
            this.fileselectbtn.UseVisualStyleBackColor = true;
            this.fileselectbtn.Click += new System.EventHandler(this.fileselectbtn_Click);
            // 
            // filepathtxt
            // 
            this.filepathtxt.AllowDrop = true;
            this.filepathtxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filepathtxt.Location = new System.Drawing.Point(94, 12);
            this.filepathtxt.Name = "filepathtxt";
            this.filepathtxt.Size = new System.Drawing.Size(689, 21);
            this.filepathtxt.TabIndex = 1;
            this.filepathtxt.DragDrop += new System.Windows.Forms.DragEventHandler(this.filepathtxt_DragDrop);
            this.filepathtxt.DragEnter += new System.Windows.Forms.DragEventHandler(this.filepathtxt_DragEnter);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "*.bin";
            this.openFileDialog1.Filter = "Keumyoung Bin Package file|*.bin|All Files|*.*";
            // 
            // analyzebtn
            // 
            this.analyzebtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.analyzebtn.Location = new System.Drawing.Point(12, 41);
            this.analyzebtn.Name = "analyzebtn";
            this.analyzebtn.Size = new System.Drawing.Size(771, 23);
            this.analyzebtn.TabIndex = 2;
            this.analyzebtn.Text = "Analyze!";
            this.analyzebtn.UseVisualStyleBackColor = true;
            this.analyzebtn.Click += new System.EventHandler(this.analyzebtn_Click);
            // 
            // listView1
            // 
            this.listView1.AllowDrop = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.path,
            this.size,
            this.offset});
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(504, 380);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            // 
            // name
            // 
            this.name.Text = "File Name";
            this.name.Width = 100;
            // 
            // path
            // 
            this.path.Text = "Original Path";
            this.path.Width = 161;
            // 
            // size
            // 
            this.size.Text = "Size";
            this.size.Width = 110;
            // 
            // offset
            // 
            this.offset.Text = "Offset";
            this.offset.Width = 97;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.extractThisFileToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(154, 26);
            this.contextMenuStrip1.Text = "xcvxcv";
            // 
            // extractThisFileToolStripMenuItem
            // 
            this.extractThisFileToolStripMenuItem.Name = "extractThisFileToolStripMenuItem";
            this.extractThisFileToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.extractThisFileToolStripMenuItem.Text = "Extract this file";
            this.extractThisFileToolStripMenuItem.Click += new System.EventHandler(this.extractThisFileToolStripMenuItem_Click);
            // 
            // extractallbtn
            // 
            this.extractallbtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.extractallbtn.Enabled = false;
            this.extractallbtn.Location = new System.Drawing.Point(288, 77);
            this.extractallbtn.Name = "extractallbtn";
            this.extractallbtn.Size = new System.Drawing.Size(495, 23);
            this.extractallbtn.TabIndex = 4;
            this.extractallbtn.Text = "Extract all";
            this.extractallbtn.UseVisualStyleBackColor = true;
            this.extractallbtn.Click += new System.EventHandler(this.extractallbtn_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 530);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(795, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel1.Text = "Ready";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.auto_openopt);
            this.groupBox1.Controls.Add(this.subfolderopt);
            this.groupBox1.Location = new System.Drawing.Point(13, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(269, 70);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Extract Options";
            // 
            // auto_openopt
            // 
            this.auto_openopt.AutoSize = true;
            this.auto_openopt.Checked = true;
            this.auto_openopt.CheckState = System.Windows.Forms.CheckState.Checked;
            this.auto_openopt.Location = new System.Drawing.Point(15, 43);
            this.auto_openopt.Name = "auto_openopt";
            this.auto_openopt.Size = new System.Drawing.Size(191, 16);
            this.auto_openopt.TabIndex = 1;
            this.auto_openopt.Text = "Open Folder when completed";
            this.auto_openopt.UseVisualStyleBackColor = true;
            this.auto_openopt.CheckedChanged += new System.EventHandler(this.auto_openopt_CheckedChanged);
            // 
            // subfolderopt
            // 
            this.subfolderopt.AutoSize = true;
            this.subfolderopt.Checked = true;
            this.subfolderopt.CheckState = System.Windows.Forms.CheckState.Checked;
            this.subfolderopt.Location = new System.Drawing.Point(15, 20);
            this.subfolderopt.Name = "subfolderopt";
            this.subfolderopt.Size = new System.Drawing.Size(126, 16);
            this.subfolderopt.TabIndex = 0;
            this.subfolderopt.Text = "Create Sub Folder";
            this.subfolderopt.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(289, 119);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(493, 20);
            this.progressBar1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(288, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(494, 13);
            this.label1.TabIndex = 9;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 147);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listView2);
            this.splitContainer1.Size = new System.Drawing.Size(769, 380);
            this.splitContainer1.SplitterDistance = 504;
            this.splitContainer1.TabIndex = 10;
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.property,
            this.value});
            this.listView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(0, 0);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(261, 380);
            this.listView2.TabIndex = 0;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // property
            // 
            this.property.Text = "Property";
            this.property.Width = 104;
            // 
            // value
            // 
            this.value.Text = "Value";
            this.value.Width = 152;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 552);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.extractallbtn);
            this.Controls.Add(this.analyzebtn);
            this.Controls.Add(this.filepathtxt);
            this.Controls.Add(this.fileselectbtn);
            this.Name = "Form1";
            this.Text = "KybinExtracter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button fileselectbtn;
        private System.Windows.Forms.TextBox filepathtxt;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button analyzebtn;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button extractallbtn;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader path;
        private System.Windows.Forms.ColumnHeader offset;
        private System.Windows.Forms.ColumnHeader size;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox auto_openopt;
        private System.Windows.Forms.CheckBox subfolderopt;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem extractThisFileToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView listView2;
        internal System.Windows.Forms.ColumnHeader property;
        private System.Windows.Forms.ColumnHeader value;
    }
}

