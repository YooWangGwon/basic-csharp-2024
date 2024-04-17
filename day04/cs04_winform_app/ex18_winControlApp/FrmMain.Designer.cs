namespace ex18_winControlApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            GroupBox = new GroupBox();
            TxtSampleText = new TextBox();
            ChkItalic = new CheckBox();
            ChkBold = new CheckBox();
            CboFonts = new ComboBox();
            label1 = new Label();
            groupBox1 = new GroupBox();
            PrgDummy = new ProgressBar();
            TrbDummy = new TrackBar();
            groupBox2 = new GroupBox();
            BtnQuestion = new Button();
            BtnMsgBox = new Button();
            BtnModaless = new Button();
            BtnModal = new Button();
            groupBox3 = new GroupBox();
            TrvDummy = new TreeView();
            BtnAddChild = new Button();
            BtnAddRoot = new Button();
            LsvDummy = new ListView();
            groupBox4 = new GroupBox();
            BtnLoad = new Button();
            PicNormal = new PictureBox();
            DlgOpenImage = new OpenFileDialog();
            GrbEditor = new GroupBox();
            BtnFileSave = new Button();
            BtnFileLoad = new Button();
            RtxEditor = new RichTextBox();
            groupBox5 = new GroupBox();
            BtnNoThread = new Button();
            BtnThread = new Button();
            BtnStop = new Button();
            PrgProcess = new ProgressBar();
            TxtLog = new TextBox();
            BgwProgress = new System.ComponentModel.BackgroundWorker();
            GroupBox.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TrbDummy).BeginInit();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PicNormal).BeginInit();
            GrbEditor.SuspendLayout();
            groupBox5.SuspendLayout();
            SuspendLayout();
            // 
            // GroupBox
            // 
            GroupBox.Controls.Add(TxtSampleText);
            GroupBox.Controls.Add(ChkItalic);
            GroupBox.Controls.Add(ChkBold);
            GroupBox.Controls.Add(CboFonts);
            GroupBox.Controls.Add(label1);
            GroupBox.Font = new Font("나눔고딕", 8.999999F);
            GroupBox.Location = new Point(12, 11);
            GroupBox.Name = "GroupBox";
            GroupBox.Size = new Size(439, 106);
            GroupBox.TabIndex = 0;
            GroupBox.TabStop = false;
            GroupBox.Text = "콤보박스, 체크박스, 텍스트박스";
            // 
            // TxtSampleText
            // 
            TxtSampleText.Font = new Font("나눔고딕", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 129);
            TxtSampleText.Location = new Point(30, 71);
            TxtSampleText.Multiline = true;
            TxtSampleText.Name = "TxtSampleText";
            TxtSampleText.Size = new Size(378, 22);
            TxtSampleText.TabIndex = 4;
            TxtSampleText.Text = "Hello, C#!";
            // 
            // ChkItalic
            // 
            ChkItalic.AutoSize = true;
            ChkItalic.Font = new Font("나눔고딕", 8.999999F, FontStyle.Italic);
            ChkItalic.Location = new Point(346, 37);
            ChkItalic.Name = "ChkItalic";
            ChkItalic.Size = new Size(59, 18);
            ChkItalic.TabIndex = 3;
            ChkItalic.Text = "이탤릭";
            ChkItalic.UseVisualStyleBackColor = true;
            ChkItalic.CheckedChanged += ChkItalic_CheckedChanged;
            // 
            // ChkBold
            // 
            ChkBold.AutoSize = true;
            ChkBold.Font = new Font("나눔고딕", 8.999999F, FontStyle.Bold);
            ChkBold.Location = new Point(290, 37);
            ChkBold.Name = "ChkBold";
            ChkBold.Size = new Size(48, 18);
            ChkBold.TabIndex = 3;
            ChkBold.Text = "굵게";
            ChkBold.UseVisualStyleBackColor = true;
            ChkBold.CheckedChanged += ChkBold_CheckedChanged;
            // 
            // CboFonts
            // 
            CboFonts.Font = new Font("나눔고딕", 8.999999F);
            CboFonts.FormattingEnabled = true;
            CboFonts.Location = new Point(75, 35);
            CboFonts.Name = "CboFonts";
            CboFonts.Size = new Size(209, 22);
            CboFonts.TabIndex = 2;
            CboFonts.SelectedIndexChanged += CboFonts_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("나눔고딕", 8.999999F);
            label1.Location = new Point(30, 38);
            label1.Name = "label1";
            label1.Size = new Size(36, 14);
            label1.TabIndex = 1;
            label1.Text = "폰트 :";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(PrgDummy);
            groupBox1.Controls.Add(TrbDummy);
            groupBox1.Location = new Point(12, 136);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(439, 108);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "트랙바, 프로그래스바";
            // 
            // PrgDummy
            // 
            PrgDummy.Location = new Point(33, 71);
            PrgDummy.Maximum = 20;
            PrgDummy.Name = "PrgDummy";
            PrgDummy.Size = new Size(375, 23);
            PrgDummy.TabIndex = 1;
            // 
            // TrbDummy
            // 
            TrbDummy.Location = new Point(30, 20);
            TrbDummy.Maximum = 20;
            TrbDummy.Name = "TrbDummy";
            TrbDummy.Size = new Size(378, 45);
            TrbDummy.TabIndex = 0;
            TrbDummy.Scroll += TrbDummy_Scroll;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(BtnQuestion);
            groupBox2.Controls.Add(BtnMsgBox);
            groupBox2.Controls.Add(BtnModaless);
            groupBox2.Controls.Add(BtnModal);
            groupBox2.Location = new Point(12, 259);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(439, 63);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "모달창, 모달리스창";
            // 
            // BtnQuestion
            // 
            BtnQuestion.Location = new Point(368, 20);
            BtnQuestion.Name = "BtnQuestion";
            BtnQuestion.Size = new Size(51, 30);
            BtnQuestion.TabIndex = 1;
            BtnQuestion.Text = "...";
            BtnQuestion.UseVisualStyleBackColor = true;
            BtnQuestion.Click += BtnQuestion_Click;
            // 
            // BtnMsgBox
            // 
            BtnMsgBox.Location = new Point(233, 20);
            BtnMsgBox.Name = "BtnMsgBox";
            BtnMsgBox.Size = new Size(129, 30);
            BtnMsgBox.TabIndex = 0;
            BtnMsgBox.Text = "MessageBox";
            BtnMsgBox.UseVisualStyleBackColor = true;
            BtnMsgBox.Click += BtnMsgBox_Click;
            // 
            // BtnModaless
            // 
            BtnModaless.Location = new Point(124, 20);
            BtnModaless.Name = "BtnModaless";
            BtnModaless.Size = new Size(103, 30);
            BtnModaless.TabIndex = 0;
            BtnModaless.Text = "Modaless";
            BtnModaless.UseVisualStyleBackColor = true;
            BtnModaless.Click += BtnModaless_Click;
            // 
            // BtnModal
            // 
            BtnModal.Location = new Point(15, 20);
            BtnModal.Name = "BtnModal";
            BtnModal.Size = new Size(103, 30);
            BtnModal.TabIndex = 0;
            BtnModal.Text = "Modal";
            BtnModal.UseVisualStyleBackColor = true;
            BtnModal.Click += BtnModal_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(TrvDummy);
            groupBox3.Controls.Add(BtnAddChild);
            groupBox3.Controls.Add(BtnAddRoot);
            groupBox3.Controls.Add(LsvDummy);
            groupBox3.Location = new Point(12, 339);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(439, 234);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "트리뷰, 리스트뷰";
            // 
            // TrvDummy
            // 
            TrvDummy.Location = new Point(24, 27);
            TrvDummy.Name = "TrvDummy";
            TrvDummy.Size = new Size(190, 155);
            TrvDummy.TabIndex = 2;
            // 
            // BtnAddChild
            // 
            BtnAddChild.Location = new Point(120, 188);
            BtnAddChild.Name = "BtnAddChild";
            BtnAddChild.Size = new Size(94, 36);
            BtnAddChild.TabIndex = 1;
            BtnAddChild.Text = "자식추가";
            BtnAddChild.UseVisualStyleBackColor = true;
            BtnAddChild.Click += BtnAddChild_Click;
            // 
            // BtnAddRoot
            // 
            BtnAddRoot.Location = new Point(24, 188);
            BtnAddRoot.Name = "BtnAddRoot";
            BtnAddRoot.Size = new Size(94, 36);
            BtnAddRoot.TabIndex = 1;
            BtnAddRoot.Text = "루트추가";
            BtnAddRoot.UseVisualStyleBackColor = true;
            BtnAddRoot.Click += BtnAddRoot_Click;
            // 
            // LsvDummy
            // 
            LsvDummy.Location = new Point(229, 27);
            LsvDummy.Name = "LsvDummy";
            LsvDummy.Size = new Size(190, 155);
            LsvDummy.TabIndex = 0;
            LsvDummy.UseCompatibleStateImageBehavior = false;
            LsvDummy.View = View.Details;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(BtnLoad);
            groupBox4.Controls.Add(PicNormal);
            groupBox4.Location = new Point(469, 12);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(342, 304);
            groupBox4.TabIndex = 4;
            groupBox4.TabStop = false;
            groupBox4.Text = "픽쳐박스";
            // 
            // BtnLoad
            // 
            BtnLoad.Location = new Point(261, 274);
            BtnLoad.Name = "BtnLoad";
            BtnLoad.Size = new Size(75, 23);
            BtnLoad.TabIndex = 1;
            BtnLoad.Text = "로드";
            BtnLoad.UseVisualStyleBackColor = true;
            BtnLoad.Click += BtnLoad_Click;
            // 
            // PicNormal
            // 
            PicNormal.BackColor = SystemColors.ActiveBorder;
            PicNormal.Location = new Point(6, 18);
            PicNormal.Name = "PicNormal";
            PicNormal.Size = new Size(330, 249);
            PicNormal.TabIndex = 0;
            PicNormal.TabStop = false;
            PicNormal.Click += PicNormal_Click_1;
            // 
            // GrbEditor
            // 
            GrbEditor.Controls.Add(BtnFileSave);
            GrbEditor.Controls.Add(BtnFileLoad);
            GrbEditor.Controls.Add(RtxEditor);
            GrbEditor.Location = new Point(831, 12);
            GrbEditor.Name = "GrbEditor";
            GrbEditor.Size = new Size(350, 561);
            GrbEditor.TabIndex = 5;
            GrbEditor.TabStop = false;
            GrbEditor.Text = "텍스트에디터";
            // 
            // BtnFileSave
            // 
            BtnFileSave.Location = new Point(255, 515);
            BtnFileSave.Name = "BtnFileSave";
            BtnFileSave.Size = new Size(89, 36);
            BtnFileSave.TabIndex = 1;
            BtnFileSave.Text = "파일 세이브";
            BtnFileSave.UseVisualStyleBackColor = true;
            BtnFileSave.Click += BtnFileSave_Click;
            // 
            // BtnFileLoad
            // 
            BtnFileLoad.Location = new Point(174, 515);
            BtnFileLoad.Name = "BtnFileLoad";
            BtnFileLoad.Size = new Size(75, 36);
            BtnFileLoad.TabIndex = 1;
            BtnFileLoad.Text = "파일로드";
            BtnFileLoad.UseVisualStyleBackColor = true;
            BtnFileLoad.Click += BtnFileLoad_Click;
            // 
            // RtxEditor
            // 
            RtxEditor.Location = new Point(6, 20);
            RtxEditor.Name = "RtxEditor";
            RtxEditor.Size = new Size(338, 489);
            RtxEditor.TabIndex = 0;
            RtxEditor.Text = "";
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(BtnNoThread);
            groupBox5.Controls.Add(BtnThread);
            groupBox5.Controls.Add(BtnStop);
            groupBox5.Controls.Add(PrgProcess);
            groupBox5.Controls.Add(TxtLog);
            groupBox5.Location = new Point(469, 322);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(342, 251);
            groupBox5.TabIndex = 6;
            groupBox5.TabStop = false;
            groupBox5.Text = "스레드, 백그라운드워커";
            // 
            // BtnNoThread
            // 
            BtnNoThread.Location = new Point(55, 205);
            BtnNoThread.Name = "BtnNoThread";
            BtnNoThread.Size = new Size(97, 36);
            BtnNoThread.TabIndex = 3;
            BtnNoThread.Text = "노스레드";
            BtnNoThread.UseVisualStyleBackColor = true;
            BtnNoThread.Click += BtnNoThread_Click;
            // 
            // BtnThread
            // 
            BtnThread.Location = new Point(158, 205);
            BtnThread.Name = "BtnThread";
            BtnThread.Size = new Size(97, 36);
            BtnThread.TabIndex = 3;
            BtnThread.Text = "스레드";
            BtnThread.UseVisualStyleBackColor = true;
            BtnThread.Click += BtnThread_Click;
            // 
            // BtnStop
            // 
            BtnStop.Enabled = false;
            BtnStop.Location = new Point(261, 205);
            BtnStop.Name = "BtnStop";
            BtnStop.Size = new Size(75, 36);
            BtnStop.TabIndex = 3;
            BtnStop.Text = "중지";
            BtnStop.UseVisualStyleBackColor = true;
            BtnStop.Click += BtnStop_Click;
            // 
            // PrgProcess
            // 
            PrgProcess.Location = new Point(6, 176);
            PrgProcess.Name = "PrgProcess";
            PrgProcess.Size = new Size(330, 23);
            PrgProcess.TabIndex = 1;
            // 
            // TxtLog
            // 
            TxtLog.Location = new Point(6, 18);
            TxtLog.Multiline = true;
            TxtLog.Name = "TxtLog";
            TxtLog.Size = new Size(330, 152);
            TxtLog.TabIndex = 0;
            // 
            // BgwProgress
            // 
            BgwProgress.DoWork += BgwProgress_DoWork;
            BgwProgress.ProgressChanged += BgwProgress_ProgressChanged;
            BgwProgress.RunWorkerCompleted += BgwProgress_RunWorkerCompleted;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1193, 586);
            Controls.Add(groupBox5);
            Controls.Add(GrbEditor);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(GroupBox);
            Font = new Font("나눔고딕", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 129);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmMain";
            Text = "컨트롤 예제";
            FormClosing += FrmMain_FormClosing;
            Load += FrmMain_Load;
            GroupBox.ResumeLayout(false);
            GroupBox.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)TrbDummy).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PicNormal).EndInit();
            GrbEditor.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox GroupBox;
        private CheckBox ChkItalic;
        private CheckBox ChkBold;
        private ComboBox CboFonts;
        private Label label1;
        private TextBox TxtSampleText;
        private GroupBox groupBox1;
        private ProgressBar PrgDummy;
        private TrackBar TrbDummy;
        private GroupBox groupBox2;
        private Button BtnMsgBox;
        private Button BtnModaless;
        private Button BtnModal;
        private Button BtnQuestion;
        private GroupBox groupBox3;
        private ListView LsvDummy;
        private TreeView TrvDummy;
        private Button BtnAddChild;
        private Button BtnAddRoot;
        private GroupBox groupBox4;
        private Button BtnLoad;
        private PictureBox PicNormal;
        private OpenFileDialog DlgOpenImage;
        private GroupBox GrbEditor;
        private RichTextBox RtxEditor;
        private Button BtnFileSave;
        private Button BtnFileLoad;
        private GroupBox groupBox5;
        private Button BtnNoThread;
        private Button BtnThread;
        private Button BtnStop;
        private ProgressBar PrgProcess;
        private TextBox TxtLog;
        private System.ComponentModel.BackgroundWorker BgwProgress;
    }
}
