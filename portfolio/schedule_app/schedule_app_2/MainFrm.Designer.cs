namespace schedule_app
{
    partial class MainFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
            ClbTodo = new CheckedListBox();
            FrmMain = new MonthCalendar();
            BtnDelete = new Button();
            BtnCorrection = new Button();
            BtnNew = new Button();
            panel1 = new Panel();
            ChbPublic = new CheckBox();
            ChbPrivate = new CheckBox();
            BtnCancel = new Button();
            BtnConfirm = new Button();
            TxtTodo = new TextBox();
            TxtPlace = new TextBox();
            TxtDetail = new TextBox();
            DtpEnd = new DateTimePicker();
            DtpStart = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            label4 = new Label();
            label3 = new Label();
            label10 = new Label();
            label5 = new Label();
            menuStrip1 = new MenuStrip();
            파일ToolStripMenuItem = new ToolStripMenuItem();
            사용자정보관리ToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            미완료업무확인ToolStripMenuItem = new ToolStripMenuItem();
            도움말ToolStripMenuItem = new ToolStripMenuItem();
            panel1.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // ClbTodo
            // 
            ClbTodo.CheckOnClick = true;
            ClbTodo.FormattingEnabled = true;
            ClbTodo.Location = new Point(14, 183);
            ClbTodo.Name = "ClbTodo";
            ClbTodo.Size = new Size(220, 184);
            ClbTodo.TabIndex = 2;
            // 
            // FrmMain
            // 
            FrmMain.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            FrmMain.Location = new Point(14, 9);
            FrmMain.Name = "FrmMain";
            FrmMain.TabIndex = 3;
            FrmMain.DateSelected += FrmMain_DateSelected;
            // 
            // BtnDelete
            // 
            BtnDelete.Font = new Font("나눔바른고딕", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 129);
            BtnDelete.Location = new Point(484, 296);
            BtnDelete.Name = "BtnDelete";
            BtnDelete.Size = new Size(70, 30);
            BtnDelete.TabIndex = 7;
            BtnDelete.Text = "삭제";
            BtnDelete.UseVisualStyleBackColor = true;
            // 
            // BtnCorrection
            // 
            BtnCorrection.Font = new Font("나눔바른고딕", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 129);
            BtnCorrection.Location = new Point(411, 296);
            BtnCorrection.Name = "BtnCorrection";
            BtnCorrection.Size = new Size(70, 30);
            BtnCorrection.TabIndex = 8;
            BtnCorrection.Text = "수정";
            BtnCorrection.UseVisualStyleBackColor = true;
            // 
            // BtnNew
            // 
            BtnNew.Font = new Font("나눔바른고딕", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 129);
            BtnNew.Location = new Point(336, 296);
            BtnNew.Name = "BtnNew";
            BtnNew.Size = new Size(70, 30);
            BtnNew.TabIndex = 9;
            BtnNew.Text = "신규";
            BtnNew.UseVisualStyleBackColor = true;
            BtnNew.Click += BtnNew_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(ChbPublic);
            panel1.Controls.Add(ChbPrivate);
            panel1.Controls.Add(BtnCancel);
            panel1.Controls.Add(BtnConfirm);
            panel1.Controls.Add(FrmMain);
            panel1.Controls.Add(ClbTodo);
            panel1.Controls.Add(TxtTodo);
            panel1.Controls.Add(BtnDelete);
            panel1.Controls.Add(BtnCorrection);
            panel1.Controls.Add(TxtPlace);
            panel1.Controls.Add(BtnNew);
            panel1.Controls.Add(TxtDetail);
            panel1.Controls.Add(DtpEnd);
            panel1.Controls.Add(DtpStart);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(label5);
            panel1.Location = new Point(12, 27);
            panel1.Name = "panel1";
            panel1.Size = new Size(568, 381);
            panel1.TabIndex = 10;
            // 
            // ChbPublic
            // 
            ChbPublic.AutoSize = true;
            ChbPublic.CheckAlign = ContentAlignment.MiddleRight;
            ChbPublic.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
            ChbPublic.Location = new Point(433, 271);
            ChbPublic.Name = "ChbPublic";
            ChbPublic.Size = new Size(78, 19);
            ChbPublic.TabIndex = 31;
            ChbPublic.Text = "공통 업무";
            ChbPublic.UseVisualStyleBackColor = true;
            ChbPublic.Click += ChbPublic_Click;
            // 
            // ChbPrivate
            // 
            ChbPrivate.AutoSize = true;
            ChbPrivate.CheckAlign = ContentAlignment.MiddleRight;
            ChbPrivate.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
            ChbPrivate.Location = new Point(323, 271);
            ChbPrivate.Name = "ChbPrivate";
            ChbPrivate.Size = new Size(78, 19);
            ChbPrivate.TabIndex = 31;
            ChbPrivate.Text = "개인 업무";
            ChbPrivate.UseVisualStyleBackColor = true;
            ChbPrivate.Click += ChbPrivate_Click;
            // 
            // BtnCancel
            // 
            BtnCancel.Location = new Point(484, 332);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(70, 30);
            BtnCancel.TabIndex = 30;
            BtnCancel.Text = "취소";
            BtnCancel.UseVisualStyleBackColor = true;
            BtnCancel.Click += BtnCancel_Click;
            // 
            // BtnConfirm
            // 
            BtnConfirm.Location = new Point(411, 332);
            BtnConfirm.Name = "BtnConfirm";
            BtnConfirm.Size = new Size(70, 30);
            BtnConfirm.TabIndex = 29;
            BtnConfirm.Text = "등록";
            BtnConfirm.UseVisualStyleBackColor = true;
            BtnConfirm.Click += BtnConfirm_Click;
            // 
            // TxtTodo
            // 
            TxtTodo.Location = new Point(317, 9);
            TxtTodo.Name = "TxtTodo";
            TxtTodo.Size = new Size(237, 23);
            TxtTodo.TabIndex = 10;
            // 
            // TxtPlace
            // 
            TxtPlace.Location = new Point(317, 101);
            TxtPlace.Name = "TxtPlace";
            TxtPlace.Size = new Size(237, 23);
            TxtPlace.TabIndex = 15;
            // 
            // TxtDetail
            // 
            TxtDetail.Location = new Point(317, 134);
            TxtDetail.Multiline = true;
            TxtDetail.Name = "TxtDetail";
            TxtDetail.Size = new Size(237, 125);
            TxtDetail.TabIndex = 16;
            // 
            // DtpEnd
            // 
            DtpEnd.Location = new Point(317, 72);
            DtpEnd.Name = "DtpEnd";
            DtpEnd.Size = new Size(237, 23);
            DtpEnd.TabIndex = 28;
            // 
            // DtpStart
            // 
            DtpStart.Location = new Point(317, 40);
            DtpStart.Name = "DtpStart";
            DtpStart.Size = new Size(237, 23);
            DtpStart.TabIndex = 28;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("나눔바른고딕", 11F, FontStyle.Bold);
            label1.Location = new Point(242, 11);
            label1.Name = "label1";
            label1.Size = new Size(66, 17);
            label1.TabIndex = 24;
            label1.Text = "해야 할 일";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("나눔바른고딕", 11F, FontStyle.Bold);
            label2.Location = new Point(245, 42);
            label2.Name = "label2";
            label2.Size = new Size(63, 17);
            label2.TabIndex = 23;
            label2.Text = "시작 날짜";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("나눔바른고딕", 11F, FontStyle.Bold);
            label4.Location = new Point(274, 103);
            label4.Name = "label4";
            label4.Size = new Size(34, 17);
            label4.TabIndex = 18;
            label4.Text = "장소";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("나눔바른고딕", 11F, FontStyle.Bold);
            label3.Location = new Point(245, 74);
            label3.Name = "label3";
            label3.Size = new Size(63, 17);
            label3.TabIndex = 22;
            label3.Text = "마감 날짜";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("나눔바른고딕", 11F, FontStyle.Bold);
            label10.Location = new Point(245, 271);
            label10.Name = "label10";
            label10.Size = new Size(63, 17);
            label10.TabIndex = 17;
            label10.Text = "업무 구분";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("나눔바른고딕", 11F, FontStyle.Bold);
            label5.Location = new Point(245, 136);
            label5.Name = "label5";
            label5.Size = new Size(63, 17);
            label5.TabIndex = 17;
            label5.Text = "상세 내용";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { 파일ToolStripMenuItem, 도움말ToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(592, 24);
            menuStrip1.TabIndex = 11;
            menuStrip1.Text = "menuStrip1";
            // 
            // 파일ToolStripMenuItem
            // 
            파일ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 사용자정보관리ToolStripMenuItem, toolStripSeparator1, 미완료업무확인ToolStripMenuItem });
            파일ToolStripMenuItem.Name = "파일ToolStripMenuItem";
            파일ToolStripMenuItem.Size = new Size(43, 20);
            파일ToolStripMenuItem.Text = "관리";
            // 
            // 사용자정보관리ToolStripMenuItem
            // 
            사용자정보관리ToolStripMenuItem.Name = "사용자정보관리ToolStripMenuItem";
            사용자정보관리ToolStripMenuItem.Size = new Size(166, 22);
            사용자정보관리ToolStripMenuItem.Text = "사용자 정보 관리";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(163, 6);
            // 
            // 미완료업무확인ToolStripMenuItem
            // 
            미완료업무확인ToolStripMenuItem.Name = "미완료업무확인ToolStripMenuItem";
            미완료업무확인ToolStripMenuItem.Size = new Size(166, 22);
            미완료업무확인ToolStripMenuItem.Text = "미완료 업무 확인";
            // 
            // 도움말ToolStripMenuItem
            // 
            도움말ToolStripMenuItem.Name = "도움말ToolStripMenuItem";
            도움말ToolStripMenuItem.Size = new Size(55, 20);
            도움말ToolStripMenuItem.Text = "도움말";
            // 
            // MainFrm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(592, 420);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "MainFrm";
            Text = "일정 관리 프로그램";
            Load += MainFrm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckedListBox ClbTodo;
        private MonthCalendar FrmMain;
        public Button BtnDelete;
        public Button BtnNew;
        public Button BtnCorrection;
        private Panel panel1;
        private TextBox TxtTodo;
        private TextBox TxtPlace;
        private TextBox TxtDetail;
        private DateTimePicker DtpStart;
        private Label label1;
        private Label label2;
        private Label label4;
        private Label label3;
        private Label label5;
        private Button BtnCancel;
        private Button BtnConfirm;
        private CheckBox ChbPublic;
        private CheckBox ChbPrivate;
        private Label label10;
        private DateTimePicker DtpEnd;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem 파일ToolStripMenuItem;
        private ToolStripMenuItem 도움말ToolStripMenuItem;
        private ToolStripMenuItem 미완료업무확인ToolStripMenuItem;
        private ToolStripMenuItem 사용자정보관리ToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
    }
}
