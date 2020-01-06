namespace Kybinextracter
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
            this.fileselectbtn = new System.Windows.Forms.Button();
            this.filepathtxt = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.analyzebtn = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.extractallbtn = new System.Windows.Forms.Button();
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.path = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.offset = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.size = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
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
            this.filepathtxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filepathtxt.Location = new System.Drawing.Point(94, 12);
            this.filepathtxt.Name = "filepathtxt";
            this.filepathtxt.Size = new System.Drawing.Size(624, 21);
            this.filepathtxt.TabIndex = 1;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // analyzebtn
            // 
            this.analyzebtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.analyzebtn.Location = new System.Drawing.Point(12, 41);
            this.analyzebtn.Name = "analyzebtn";
            this.analyzebtn.Size = new System.Drawing.Size(706, 23);
            this.analyzebtn.TabIndex = 2;
            this.analyzebtn.Text = "Analyze!";
            this.analyzebtn.UseVisualStyleBackColor = true;
            this.analyzebtn.Click += new System.EventHandler(this.analyzebtn_Click);
            // 
            // listView1
            // 
            this.listView1.AllowDrop = true;
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.path,
            this.size,
            this.offset});
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 100);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(706, 372);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // extractallbtn
            // 
            this.extractallbtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.extractallbtn.Enabled = false;
            this.extractallbtn.Location = new System.Drawing.Point(12, 71);
            this.extractallbtn.Name = "extractallbtn";
            this.extractallbtn.Size = new System.Drawing.Size(706, 23);
            this.extractallbtn.TabIndex = 4;
            this.extractallbtn.Text = "Extract all";
            this.extractallbtn.UseVisualStyleBackColor = true;
            this.extractallbtn.Click += new System.EventHandler(this.extractallbtn_Click);
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
            // offset
            // 
            this.offset.Text = "Offset";
            this.offset.Width = 97;
            // 
            // size
            // 
            this.size.Text = "Size";
            this.size.Width = 110;
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 485);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(730, 22);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 507);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.extractallbtn);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.analyzebtn);
            this.Controls.Add(this.filepathtxt);
            this.Controls.Add(this.fileselectbtn);
            this.Name = "Form1";
            this.Text = "KybinExtracter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
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
    }
}

