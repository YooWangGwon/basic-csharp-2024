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
            McrDate = new MonthCalendar();
            BtnDelete = new Button();
            BtnCorrection = new Button();
            BtnNew = new Button();
            DgvTodo = new DataGridView();
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
            splitContainer1 = new SplitContainer();
            TxtDate = new TextBox();
            label6 = new Label();
            BtnComplete = new Button();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            LblUserName = new ToolStripStatusLabel();
            menuStrip1 = new MenuStrip();
            관리ToolStripMenuItem = new ToolStripMenuItem();
            MnuUsers = new ToolStripMenuItem();
            MnuDepartment = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)DgvTodo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            statusStrip1.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // McrDate
            // 
            McrDate.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            McrDate.Location = new Point(43, 33);
            McrDate.Name = "McrDate";
            McrDate.ShowTodayCircle = false;
            McrDate.TabIndex = 3;
            McrDate.DateChanged += McrDate_DateChanged;
            // 
            // BtnDelete
            // 
            BtnDelete.Font = new Font("나눔바른고딕", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 129);
            BtnDelete.Location = new Point(245, 355);
            BtnDelete.Name = "BtnDelete";
            BtnDelete.Size = new Size(70, 30);
            BtnDelete.TabIndex = 10;
            BtnDelete.Text = "삭제";
            BtnDelete.UseVisualStyleBackColor = true;
            BtnDelete.Click += BtnDelete_Click;
            // 
            // BtnCorrection
            // 
            BtnCorrection.Font = new Font("나눔바른고딕", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 129);
            BtnCorrection.Location = new Point(169, 355);
            BtnCorrection.Name = "BtnCorrection";
            BtnCorrection.Size = new Size(70, 30);
            BtnCorrection.TabIndex = 9;
            BtnCorrection.Text = "수정";
            BtnCorrection.UseVisualStyleBackColor = true;
            BtnCorrection.Click += BtnCorrection_Click;
            // 
            // BtnNew
            // 
            BtnNew.Font = new Font("나눔바른고딕", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 129);
            BtnNew.Location = new Point(93, 355);
            BtnNew.Name = "BtnNew";
            BtnNew.Size = new Size(70, 30);
            BtnNew.TabIndex = 8;
            BtnNew.Text = "신규";
            BtnNew.UseVisualStyleBackColor = true;
            BtnNew.Click += BtnNew_Click;
            // 
            // DgvTodo
            // 
            DgvTodo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvTodo.Location = new Point(11, 242);
            DgvTodo.MultiSelect = false;
            DgvTodo.Name = "DgvTodo";
            DgvTodo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvTodo.Size = new Size(283, 179);
            DgvTodo.TabIndex = 32;
            DgvTodo.CellClick += DgvTodo_CellClick;
            // 
            // ChbPublic
            // 
            ChbPublic.AutoSize = true;
            ChbPublic.CheckAlign = ContentAlignment.MiddleRight;
            ChbPublic.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
            ChbPublic.Location = new Point(194, 330);
            ChbPublic.Name = "ChbPublic";
            ChbPublic.Size = new Size(78, 19);
            ChbPublic.TabIndex = 7;
            ChbPublic.Text = "공통 업무";
            ChbPublic.UseVisualStyleBackColor = true;
            ChbPublic.Click += ChbPublic_Click;
            // 
            // ChbPrivate
            // 
            ChbPrivate.AutoSize = true;
            ChbPrivate.CheckAlign = ContentAlignment.MiddleRight;
            ChbPrivate.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
            ChbPrivate.Location = new Point(84, 330);
            ChbPrivate.Name = "ChbPrivate";
            ChbPrivate.Size = new Size(78, 19);
            ChbPrivate.TabIndex = 6;
            ChbPrivate.Text = "개인 업무";
            ChbPrivate.UseVisualStyleBackColor = true;
            ChbPrivate.Click += ChbPrivate_Click;
            // 
            // BtnCancel
            // 
            BtnCancel.Location = new Point(245, 391);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(70, 30);
            BtnCancel.TabIndex = 13;
            BtnCancel.Text = "취소";
            BtnCancel.UseVisualStyleBackColor = true;
            BtnCancel.Click += BtnCancel_Click;
            // 
            // BtnConfirm
            // 
            BtnConfirm.Location = new Point(169, 391);
            BtnConfirm.Name = "BtnConfirm";
            BtnConfirm.Size = new Size(70, 30);
            BtnConfirm.TabIndex = 12;
            BtnConfirm.Text = "등록";
            BtnConfirm.UseVisualStyleBackColor = true;
            BtnConfirm.Click += BtnConfirm_Click;
            // 
            // TxtTodo
            // 
            TxtTodo.BackColor = Color.White;
            TxtTodo.Location = new Point(78, 68);
            TxtTodo.Name = "TxtTodo";
            TxtTodo.Size = new Size(237, 23);
            TxtTodo.TabIndex = 1;
            // 
            // TxtPlace
            // 
            TxtPlace.BackColor = Color.White;
            TxtPlace.Location = new Point(78, 160);
            TxtPlace.Name = "TxtPlace";
            TxtPlace.Size = new Size(237, 23);
            TxtPlace.TabIndex = 4;
            // 
            // TxtDetail
            // 
            TxtDetail.BackColor = Color.White;
            TxtDetail.Location = new Point(78, 193);
            TxtDetail.Multiline = true;
            TxtDetail.Name = "TxtDetail";
            TxtDetail.Size = new Size(237, 125);
            TxtDetail.TabIndex = 5;
            // 
            // DtpEnd
            // 
            DtpEnd.Location = new Point(78, 131);
            DtpEnd.Name = "DtpEnd";
            DtpEnd.Size = new Size(237, 23);
            DtpEnd.TabIndex = 3;
            // 
            // DtpStart
            // 
            DtpStart.Location = new Point(78, 99);
            DtpStart.Name = "DtpStart";
            DtpStart.Size = new Size(237, 23);
            DtpStart.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("나눔바른고딕", 11F, FontStyle.Bold);
            label1.Location = new Point(3, 70);
            label1.Name = "label1";
            label1.Size = new Size(66, 17);
            label1.TabIndex = 24;
            label1.Text = "해야 할 일";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("나눔바른고딕", 11F, FontStyle.Bold);
            label2.Location = new Point(6, 101);
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
            label4.Location = new Point(35, 162);
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
            label3.Location = new Point(6, 133);
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
            label10.Location = new Point(6, 330);
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
            label5.Location = new Point(6, 195);
            label5.Name = "label5";
            label5.Size = new Size(63, 17);
            label5.TabIndex = 17;
            label5.Text = "상세 내용";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(TxtDate);
            splitContainer1.Panel1.Controls.Add(DgvTodo);
            splitContainer1.Panel1.Controls.Add(McrDate);
            splitContainer1.Panel1.Controls.Add(label6);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(ChbPublic);
            splitContainer1.Panel2.Controls.Add(TxtDetail);
            splitContainer1.Panel2.Controls.Add(DtpEnd);
            splitContainer1.Panel2.Controls.Add(ChbPrivate);
            splitContainer1.Panel2.Controls.Add(DtpStart);
            splitContainer1.Panel2.Controls.Add(label1);
            splitContainer1.Panel2.Controls.Add(BtnCancel);
            splitContainer1.Panel2.Controls.Add(BtnNew);
            splitContainer1.Panel2.Controls.Add(label2);
            splitContainer1.Panel2.Controls.Add(BtnConfirm);
            splitContainer1.Panel2.Controls.Add(TxtPlace);
            splitContainer1.Panel2.Controls.Add(label5);
            splitContainer1.Panel2.Controls.Add(label4);
            splitContainer1.Panel2.Controls.Add(TxtTodo);
            splitContainer1.Panel2.Controls.Add(BtnCorrection);
            splitContainer1.Panel2.Controls.Add(label10);
            splitContainer1.Panel2.Controls.Add(label3);
            splitContainer1.Panel2.Controls.Add(BtnComplete);
            splitContainer1.Panel2.Controls.Add(BtnDelete);
            splitContainer1.Size = new Size(626, 446);
            splitContainer1.SplitterDistance = 297;
            splitContainer1.TabIndex = 12;
            // 
            // TxtDate
            // 
            TxtDate.BackColor = Color.White;
            TxtDate.Location = new Point(81, 207);
            TxtDate.Name = "TxtDate";
            TxtDate.ReadOnly = true;
            TxtDate.Size = new Size(213, 23);
            TxtDate.TabIndex = 33;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("나눔바른고딕", 11F, FontStyle.Bold);
            label6.Location = new Point(12, 209);
            label6.Name = "label6";
            label6.Size = new Size(63, 17);
            label6.TabIndex = 17;
            label6.Text = "선택 날짜";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BtnComplete
            // 
            BtnComplete.Font = new Font("나눔바른고딕", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 129);
            BtnComplete.Location = new Point(92, 392);
            BtnComplete.Name = "BtnComplete";
            BtnComplete.Size = new Size(70, 30);
            BtnComplete.TabIndex = 11;
            BtnComplete.Text = "완료";
            BtnComplete.UseVisualStyleBackColor = true;
            BtnComplete.Click += BtnComplete_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, LblUserName });
            statusStrip1.Location = new Point(0, 424);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(626, 22);
            statusStrip1.SizingGrip = false;
            statusStrip1.TabIndex = 13;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(54, 17);
            toolStripStatusLabel1.Text = "사용자 : ";
            // 
            // LblUserName
            // 
            LblUserName.Name = "LblUserName";
            LblUserName.Size = new Size(0, 17);
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { 관리ToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(626, 24);
            menuStrip1.TabIndex = 14;
            menuStrip1.Text = "menuStrip1";
            // 
            // 관리ToolStripMenuItem
            // 
            관리ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { MnuUsers, MnuDepartment });
            관리ToolStripMenuItem.Name = "관리ToolStripMenuItem";
            관리ToolStripMenuItem.Size = new Size(43, 20);
            관리ToolStripMenuItem.Text = "관리";
            // 
            // MnuUsers
            // 
            MnuUsers.Image = schedule_app_2.Properties.Resources.profile;
            MnuUsers.Name = "MnuUsers";
            MnuUsers.Size = new Size(180, 22);
            MnuUsers.Text = "사용자 관리";
            MnuUsers.Click += MnuUsers_Click;
            // 
            // MnuDepartment
            // 
            MnuDepartment.Image = schedule_app_2.Properties.Resources.department;
            MnuDepartment.Name = "MnuDepartment";
            MnuDepartment.Size = new Size(180, 22);
            MnuDepartment.Text = "부서 관리";
            MnuDepartment.Click += MnuDepartment_Click;
            // 
            // MainFrm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(626, 446);
            Controls.Add(menuStrip1);
            Controls.Add(statusStrip1);
            Controls.Add(splitContainer1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MinimizeBox = false;
            Name = "MainFrm";
            Text = "일정 관리 프로그램";
            FormClosing += MainFrm_FormClosing;
            Load += MainFrm_Load;
            ((System.ComponentModel.ISupportInitialize)DgvTodo).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MonthCalendar McrDate;
        public Button BtnDelete;
        public Button BtnNew;
        public Button BtnCorrection;
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
        private DataGridView DgvTodo;
        private SplitContainer splitContainer1;
        public Button BtnComplete;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel LblUserName;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem 관리ToolStripMenuItem;
        private ToolStripMenuItem MnuUsers;
        private TextBox TxtDate;
        private Label label6;
        private ToolStripMenuItem MnuDepartment;
    }
}
