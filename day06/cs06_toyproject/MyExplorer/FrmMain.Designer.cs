namespace MyExplorer
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            panel1 = new Panel();
            BtnOpen = new Button();
            TxtPath = new TextBox();
            Label1 = new Label();
            splitContainer1 = new SplitContainer();
            TrvFolder = new TreeView();
            ImgSmallIcon = new ImageList(components);
            LsvFile = new ListView();
            ClhTitle = new ColumnHeader();
            ClhdModifiedDate = new ColumnHeader();
            ClhType = new ColumnHeader();
            ClhSize = new ColumnHeader();
            ImgLargeIcon = new ImageList(components);
            CmsFiles = new ContextMenuStrip(components);
            qToolStripMenuItem = new ToolStripMenuItem();
            큰아이콘ToolStripMenuItem = new ToolStripMenuItem();
            작은아이콘ToolStripMenuItem = new ToolStripMenuItem();
            목ToolStripMenuItem = new ToolStripMenuItem();
            자세히ToolStripMenuItem = new ToolStripMenuItem();
            타일ToolStripMenuItem = new ToolStripMenuItem();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            CmsFiles.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveBorder;
            panel1.Controls.Add(BtnOpen);
            panel1.Controls.Add(TxtPath);
            panel1.Controls.Add(Label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(898, 49);
            panel1.TabIndex = 0;
            // 
            // BtnOpen
            // 
            BtnOpen.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtnOpen.FlatStyle = FlatStyle.Flat;
            BtnOpen.Location = new Point(811, 12);
            BtnOpen.Name = "BtnOpen";
            BtnOpen.Size = new Size(75, 23);
            BtnOpen.TabIndex = 2;
            BtnOpen.Text = "열기";
            BtnOpen.UseVisualStyleBackColor = true;
            BtnOpen.Click += BtnOpen_Click;
            // 
            // TxtPath
            // 
            TxtPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TxtPath.Location = new Point(49, 13);
            TxtPath.Name = "TxtPath";
            TxtPath.ReadOnly = true;
            TxtPath.Size = new Size(748, 23);
            TxtPath.TabIndex = 1;
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Location = new Point(12, 16);
            Label1.Name = "Label1";
            Label1.Size = new Size(31, 15);
            Label1.TabIndex = 0;
            Label1.Text = "경로";
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 49);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(TrvFolder);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(LsvFile);
            splitContainer1.Size = new Size(898, 493);
            splitContainer1.SplitterDistance = 299;
            splitContainer1.TabIndex = 1;
            // 
            // TrvFolder
            // 
            TrvFolder.BorderStyle = BorderStyle.None;
            TrvFolder.Dock = DockStyle.Fill;
            TrvFolder.ImageIndex = 0;
            TrvFolder.ImageList = ImgSmallIcon;
            TrvFolder.Location = new Point(0, 0);
            TrvFolder.Name = "TrvFolder";
            TrvFolder.SelectedImageIndex = 0;
            TrvFolder.Size = new Size(299, 493);
            TrvFolder.TabIndex = 0;
            TrvFolder.BeforeExpand += TrvFolder_BeforeExpand;
            TrvFolder.AfterSelect += TrvFolder_AfterSelect;
            // 
            // ImgSmallIcon
            // 
            ImgSmallIcon.ColorDepth = ColorDepth.Depth32Bit;
            ImgSmallIcon.ImageStream = (ImageListStreamer)resources.GetObject("ImgSmallIcon.ImageStream");
            ImgSmallIcon.TransparentColor = Color.Transparent;
            ImgSmallIcon.Images.SetKeyName(0, "hard-drive.png");
            ImgSmallIcon.Images.SetKeyName(1, "folder-normal.png");
            ImgSmallIcon.Images.SetKeyName(2, "folder-open.png");
            ImgSmallIcon.Images.SetKeyName(3, "file-exe.png");
            ImgSmallIcon.Images.SetKeyName(4, "file-normal.png");
            ImgSmallIcon.Images.SetKeyName(5, "txt.png");
            // 
            // LsvFile
            // 
            LsvFile.Columns.AddRange(new ColumnHeader[] { ClhTitle, ClhdModifiedDate, ClhType, ClhSize });
            LsvFile.Dock = DockStyle.Fill;
            LsvFile.LargeImageList = ImgLargeIcon;
            LsvFile.Location = new Point(0, 0);
            LsvFile.Name = "LsvFile";
            LsvFile.Size = new Size(595, 493);
            LsvFile.SmallImageList = ImgSmallIcon;
            LsvFile.TabIndex = 0;
            LsvFile.UseCompatibleStateImageBehavior = false;
            LsvFile.View = View.Details;
            LsvFile.MouseDown += LsvFile_MouseDown;
            // 
            // ClhTitle
            // 
            ClhTitle.Text = "이름";
            ClhTitle.Width = 200;
            // 
            // ClhdModifiedDate
            // 
            ClhdModifiedDate.Text = "수정일자";
            ClhdModifiedDate.Width = 150;
            // 
            // ClhType
            // 
            ClhType.Text = "유형";
            ClhType.Width = 80;
            // 
            // ClhSize
            // 
            ClhSize.Text = "크기";
            ClhSize.TextAlign = HorizontalAlignment.Right;
            ClhSize.Width = 150;
            // 
            // ImgLargeIcon
            // 
            ImgLargeIcon.ColorDepth = ColorDepth.Depth32Bit;
            ImgLargeIcon.ImageStream = (ImageListStreamer)resources.GetObject("ImgLargeIcon.ImageStream");
            ImgLargeIcon.TransparentColor = Color.Transparent;
            ImgLargeIcon.Images.SetKeyName(0, "hard-drive.png");
            ImgLargeIcon.Images.SetKeyName(1, "folder-normal.png");
            ImgLargeIcon.Images.SetKeyName(2, "folder-open.png");
            ImgLargeIcon.Images.SetKeyName(3, "file-exe.png");
            ImgLargeIcon.Images.SetKeyName(4, "file-normal.png");
            ImgLargeIcon.Images.SetKeyName(5, "txt.png");
            // 
            // CmsFiles
            // 
            CmsFiles.Items.AddRange(new ToolStripItem[] { qToolStripMenuItem });
            CmsFiles.Name = "Cms";
            CmsFiles.Size = new Size(99, 26);
            // 
            // qToolStripMenuItem
            // 
            qToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 큰아이콘ToolStripMenuItem, 작은아이콘ToolStripMenuItem, 목ToolStripMenuItem, 자세히ToolStripMenuItem, 타일ToolStripMenuItem });
            qToolStripMenuItem.Name = "qToolStripMenuItem";
            qToolStripMenuItem.Size = new Size(98, 22);
            qToolStripMenuItem.Text = "보기";
            // 
            // 큰아이콘ToolStripMenuItem
            // 
            큰아이콘ToolStripMenuItem.Name = "큰아이콘ToolStripMenuItem";
            큰아이콘ToolStripMenuItem.Size = new Size(138, 22);
            큰아이콘ToolStripMenuItem.Text = "큰 아이콘";
            // 
            // 작은아이콘ToolStripMenuItem
            // 
            작은아이콘ToolStripMenuItem.Name = "작은아이콘ToolStripMenuItem";
            작은아이콘ToolStripMenuItem.Size = new Size(138, 22);
            작은아이콘ToolStripMenuItem.Text = "작은 아이콘";
            // 
            // 목ToolStripMenuItem
            // 
            목ToolStripMenuItem.Name = "목ToolStripMenuItem";
            목ToolStripMenuItem.Size = new Size(138, 22);
            목ToolStripMenuItem.Text = "목록";
            // 
            // 자세히ToolStripMenuItem
            // 
            자세히ToolStripMenuItem.Name = "자세히ToolStripMenuItem";
            자세히ToolStripMenuItem.Size = new Size(138, 22);
            자세히ToolStripMenuItem.Text = "자세히";
            // 
            // 타일ToolStripMenuItem
            // 
            타일ToolStripMenuItem.Name = "타일ToolStripMenuItem";
            타일ToolStripMenuItem.Size = new Size(138, 22);
            타일ToolStripMenuItem.Text = "타일";
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(898, 542);
            Controls.Add(splitContainer1);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "내 탐색기 v1.0";
            Load += FrmMain_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            CmsFiles.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button BtnOpen;
        private TextBox TxtPath;
        private Label Label1;
        private SplitContainer splitContainer1;
        private TreeView TrvFolder;
        private ListView LsvFile;
        private ColumnHeader ClhTitle;
        private ColumnHeader ClhSize;
        private ColumnHeader ClhType;
        private ColumnHeader ClhdModifiedDate;
        private ImageList ImgSmallIcon;
        private ImageList ImgLargeIcon;
        private ContextMenuStrip CmsFiles;
        private ToolStripMenuItem qToolStripMenuItem;
        private ToolStripMenuItem 큰아이콘ToolStripMenuItem;
        private ToolStripMenuItem 작은아이콘ToolStripMenuItem;
        private ToolStripMenuItem 목ToolStripMenuItem;
        private ToolStripMenuItem 자세히ToolStripMenuItem;
        private ToolStripMenuItem 타일ToolStripMenuItem;
    }
}
