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
            listView1 = new ListView();
            BtnCorrection = new Button();
            BtnNew = new Button();
            BtnShowUndo = new Button();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // ClbTodo
            // 
            ClbTodo.CheckOnClick = true;
            ClbTodo.FormattingEnabled = true;
            ClbTodo.Location = new Point(9, 183);
            ClbTodo.Name = "ClbTodo";
            ClbTodo.Size = new Size(220, 112);
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
            BtnDelete.Location = new Point(413, 183);
            BtnDelete.Name = "BtnDelete";
            BtnDelete.Size = new Size(80, 30);
            BtnDelete.TabIndex = 7;
            BtnDelete.Text = "삭제";
            BtnDelete.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            listView1.Location = new Point(241, 9);
            listView1.Name = "listView1";
            listView1.Size = new Size(284, 162);
            listView1.TabIndex = 6;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // BtnCorrection
            // 
            BtnCorrection.Font = new Font("나눔바른고딕", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 129);
            BtnCorrection.Location = new Point(327, 183);
            BtnCorrection.Name = "BtnCorrection";
            BtnCorrection.Size = new Size(80, 30);
            BtnCorrection.TabIndex = 8;
            BtnCorrection.Text = "수정";
            BtnCorrection.UseVisualStyleBackColor = true;
            BtnCorrection.Click += BtnCorrection_Click;
            // 
            // BtnNew
            // 
            BtnNew.Font = new Font("나눔바른고딕", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 129);
            BtnNew.Location = new Point(241, 183);
            BtnNew.Name = "BtnNew";
            BtnNew.Size = new Size(80, 30);
            BtnNew.TabIndex = 9;
            BtnNew.Text = "신규";
            BtnNew.UseVisualStyleBackColor = true;
            BtnNew.Click += BtnNew_Click;
            // 
            // BtnShowUndo
            // 
            BtnShowUndo.Font = new Font("나눔바른고딕", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 129);
            BtnShowUndo.Location = new Point(241, 219);
            BtnShowUndo.Name = "BtnShowUndo";
            BtnShowUndo.Size = new Size(120, 30);
            BtnShowUndo.TabIndex = 9;
            BtnShowUndo.Text = "미완료 업무 확인";
            BtnShowUndo.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            panel1.Controls.Add(FrmMain);
            panel1.Controls.Add(ClbTodo);
            panel1.Controls.Add(BtnDelete);
            panel1.Controls.Add(listView1);
            panel1.Controls.Add(BtnCorrection);
            panel1.Controls.Add(BtnShowUndo);
            panel1.Controls.Add(BtnNew);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(536, 309);
            panel1.TabIndex = 10;
            // 
            // MainFrm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 333);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainFrm";
            Text = "일정 관리 프로그램";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private CheckedListBox ClbTodo;
        private MonthCalendar FrmMain;
        private ListView listView1;
        public Button BtnDelete;
        public Button BtnNew;
        public Button BtnShowUndo;
        public Button BtnCorrection;
        private Panel panel1;
    }
}
