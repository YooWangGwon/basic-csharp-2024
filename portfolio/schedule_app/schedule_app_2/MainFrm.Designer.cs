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
            BtnShowUndo = new Button();
            panel1 = new Panel();
            ChbPublic = new CheckBox();
            ChbPrivate = new CheckBox();
            BtnCancel = new Button();
            BtnConfirm = new Button();
            CboEndMin = new ComboBox();
            CboEndHour = new ComboBox();
            TxtTodo = new TextBox();
            CboStartMin = new ComboBox();
            TxtPlace = new TextBox();
            CboStartHour = new ComboBox();
            TxtDetail = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            Dtp = new DateTimePicker();
            label1 = new Label();
            label9 = new Label();
            label2 = new Label();
            label4 = new Label();
            label8 = new Label();
            label3 = new Label();
            label10 = new Label();
            label5 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // ClbTodo
            // 
            ClbTodo.CheckOnClick = true;
            ClbTodo.FormattingEnabled = true;
            ClbTodo.Location = new Point(9, 183);
            ClbTodo.Name = "ClbTodo";
            ClbTodo.Size = new Size(220, 202);
            ClbTodo.TabIndex = 2;
            // 
            // FrmMain
            // 
            FrmMain.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            FrmMain.Location = new Point(9, 9);
            FrmMain.Name = "FrmMain";
            FrmMain.TabIndex = 3;
            FrmMain.DateSelected += FrmMain_DateSelected;
            // 
            // BtnDelete
            // 
            BtnDelete.Font = new Font("나눔바른고딕", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 129);
            BtnDelete.Location = new Point(467, 321);
            BtnDelete.Name = "BtnDelete";
            BtnDelete.Size = new Size(70, 30);
            BtnDelete.TabIndex = 7;
            BtnDelete.Text = "삭제";
            BtnDelete.UseVisualStyleBackColor = true;
            // 
            // BtnCorrection
            // 
            BtnCorrection.Font = new Font("나눔바른고딕", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 129);
            BtnCorrection.Location = new Point(394, 321);
            BtnCorrection.Name = "BtnCorrection";
            BtnCorrection.Size = new Size(70, 30);
            BtnCorrection.TabIndex = 8;
            BtnCorrection.Text = "수정";
            BtnCorrection.UseVisualStyleBackColor = true;
            // 
            // BtnNew
            // 
            BtnNew.Font = new Font("나눔바른고딕", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 129);
            BtnNew.Location = new Point(319, 321);
            BtnNew.Name = "BtnNew";
            BtnNew.Size = new Size(70, 30);
            BtnNew.TabIndex = 9;
            BtnNew.Text = "신규";
            BtnNew.UseVisualStyleBackColor = true;
            BtnNew.Click += BtnNew_Click;
            // 
            // BtnShowUndo
            // 
            BtnShowUndo.Font = new Font("나눔바른고딕", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 129);
            BtnShowUndo.Location = new Point(539, 321);
            BtnShowUndo.Name = "BtnShowUndo";
            BtnShowUndo.Size = new Size(111, 30);
            BtnShowUndo.TabIndex = 9;
            BtnShowUndo.Text = "미완료 업무";
            BtnShowUndo.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(ChbPublic);
            panel1.Controls.Add(ChbPrivate);
            panel1.Controls.Add(BtnCancel);
            panel1.Controls.Add(BtnConfirm);
            panel1.Controls.Add(CboEndMin);
            panel1.Controls.Add(FrmMain);
            panel1.Controls.Add(CboEndHour);
            panel1.Controls.Add(ClbTodo);
            panel1.Controls.Add(TxtTodo);
            panel1.Controls.Add(BtnDelete);
            panel1.Controls.Add(CboStartMin);
            panel1.Controls.Add(BtnCorrection);
            panel1.Controls.Add(TxtPlace);
            panel1.Controls.Add(BtnShowUndo);
            panel1.Controls.Add(CboStartHour);
            panel1.Controls.Add(BtnNew);
            panel1.Controls.Add(TxtDetail);
            panel1.Controls.Add(dateTimePicker1);
            panel1.Controls.Add(Dtp);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(label5);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(660, 396);
            panel1.TabIndex = 10;
            // 
            // ChbPublic
            // 
            ChbPublic.AutoSize = true;
            ChbPublic.CheckAlign = ContentAlignment.MiddleRight;
            ChbPublic.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
            ChbPublic.Location = new Point(433, 297);
            ChbPublic.Name = "ChbPublic";
            ChbPublic.Size = new Size(78, 19);
            ChbPublic.TabIndex = 31;
            ChbPublic.Text = "공통 업무";
            ChbPublic.UseVisualStyleBackColor = true;
            // 
            // ChbPrivate
            // 
            ChbPrivate.AutoSize = true;
            ChbPrivate.CheckAlign = ContentAlignment.MiddleRight;
            ChbPrivate.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
            ChbPrivate.Location = new Point(323, 297);
            ChbPrivate.Name = "ChbPrivate";
            ChbPrivate.Size = new Size(78, 19);
            ChbPrivate.TabIndex = 31;
            ChbPrivate.Text = "개인 업무";
            ChbPrivate.UseVisualStyleBackColor = true;
            // 
            // BtnCancel
            // 
            BtnCancel.Location = new Point(580, 357);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(70, 30);
            BtnCancel.TabIndex = 30;
            BtnCancel.Text = "취소";
            BtnCancel.UseVisualStyleBackColor = true;
            // 
            // BtnConfirm
            // 
            BtnConfirm.Location = new Point(504, 357);
            BtnConfirm.Name = "BtnConfirm";
            BtnConfirm.Size = new Size(70, 30);
            BtnConfirm.TabIndex = 29;
            BtnConfirm.Text = "등록";
            BtnConfirm.UseVisualStyleBackColor = true;
            // 
            // CboEndMin
            // 
            CboEndMin.FormattingEnabled = true;
            CboEndMin.Items.AddRange(new object[] { "00", "05", "10", "15", "20", "25", "30", "35", "40", "45", "50", "55" });
            CboEndMin.Location = new Point(608, 72);
            CboEndMin.Name = "CboEndMin";
            CboEndMin.Size = new Size(42, 23);
            CboEndMin.TabIndex = 12;
            // 
            // CboEndHour
            // 
            CboEndHour.FormattingEnabled = true;
            CboEndHour.Items.AddRange(new object[] { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23" });
            CboEndHour.Location = new Point(560, 72);
            CboEndHour.Name = "CboEndHour";
            CboEndHour.Size = new Size(42, 23);
            CboEndHour.TabIndex = 13;
            // 
            // TxtTodo
            // 
            TxtTodo.Location = new Point(317, 9);
            TxtTodo.Name = "TxtTodo";
            TxtTodo.Size = new Size(333, 23);
            TxtTodo.TabIndex = 10;
            // 
            // CboStartMin
            // 
            CboStartMin.FormattingEnabled = true;
            CboStartMin.Items.AddRange(new object[] { "00", "05", "10", "15", "20", "25", "30", "35", "40", "45", "50", "55" });
            CboStartMin.Location = new Point(608, 40);
            CboStartMin.Name = "CboStartMin";
            CboStartMin.Size = new Size(42, 23);
            CboStartMin.TabIndex = 14;
            // 
            // TxtPlace
            // 
            TxtPlace.Location = new Point(317, 101);
            TxtPlace.Name = "TxtPlace";
            TxtPlace.Size = new Size(333, 23);
            TxtPlace.TabIndex = 15;
            // 
            // CboStartHour
            // 
            CboStartHour.FormattingEnabled = true;
            CboStartHour.Items.AddRange(new object[] { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23" });
            CboStartHour.Location = new Point(560, 40);
            CboStartHour.Name = "CboStartHour";
            CboStartHour.Size = new Size(42, 23);
            CboStartHour.TabIndex = 11;
            // 
            // TxtDetail
            // 
            TxtDetail.Location = new Point(317, 134);
            TxtDetail.Multiline = true;
            TxtDetail.Name = "TxtDetail";
            TxtDetail.Size = new Size(333, 151);
            TxtDetail.TabIndex = 16;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(317, 72);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(237, 23);
            dateTimePicker1.TabIndex = 28;
            // 
            // Dtp
            // 
            Dtp.Location = new Point(317, 40);
            Dtp.Name = "Dtp";
            Dtp.Size = new Size(237, 23);
            Dtp.TabIndex = 28;
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
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("나눔바른고딕", 11F, FontStyle.Bold);
            label9.Location = new Point(600, 75);
            label9.Name = "label9";
            label9.Size = new Size(12, 17);
            label9.TabIndex = 20;
            label9.Text = ":";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("나눔바른고딕", 11F, FontStyle.Bold);
            label2.Location = new Point(242, 45);
            label2.Name = "label2";
            label2.Size = new Size(34, 17);
            label2.TabIndex = 23;
            label2.Text = "날짜";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("나눔바른고딕", 11F, FontStyle.Bold);
            label4.Location = new Point(242, 103);
            label4.Name = "label4";
            label4.Size = new Size(34, 17);
            label4.TabIndex = 18;
            label4.Text = "장소";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("나눔바른고딕", 11F, FontStyle.Bold);
            label8.Location = new Point(600, 43);
            label8.Name = "label8";
            label8.Size = new Size(12, 17);
            label8.TabIndex = 21;
            label8.Text = ":";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("나눔바른고딕", 11F, FontStyle.Bold);
            label3.Location = new Point(242, 75);
            label3.Name = "label3";
            label3.Size = new Size(34, 17);
            label3.TabIndex = 22;
            label3.Text = "시간";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("나눔바른고딕", 11F, FontStyle.Bold);
            label10.Location = new Point(242, 297);
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
            label5.Location = new Point(242, 136);
            label5.Name = "label5";
            label5.Size = new Size(63, 17);
            label5.TabIndex = 17;
            label5.Text = "상세 내용";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MainFrm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(684, 420);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainFrm";
            Text = "일정 관리 프로그램";
            Load += MainFrm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private CheckedListBox ClbTodo;
        private MonthCalendar FrmMain;
        public Button BtnDelete;
        public Button BtnNew;
        public Button BtnShowUndo;
        public Button BtnCorrection;
        private Panel panel1;
        private ComboBox CboEndMin;
        private ComboBox CboEndHour;
        private TextBox TxtTodo;
        private ComboBox CboStartMin;
        private TextBox TxtPlace;
        private ComboBox CboStartHour;
        private TextBox TxtDetail;
        private DateTimePicker Dtp;
        private Label label1;
        private Label label9;
        private Label label2;
        private Label label4;
        private Label label8;
        private Label label3;
        private Label label5;
        private Button BtnCancel;
        private Button BtnConfirm;
        private CheckBox ChbPublic;
        private CheckBox ChbPrivate;
        private Label label10;
        private DateTimePicker dateTimePicker1;
    }
}
