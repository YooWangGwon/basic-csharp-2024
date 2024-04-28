namespace schedule_app_2
{
    partial class FrmUsers
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUsers));
            BtnSave = new Button();
            BtnNew = new Button();
            label1 = new Label();
            label2 = new Label();
            TxtUserIdx = new TextBox();
            TxtNames = new TextBox();
            label3 = new Label();
            label4 = new Label();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            BtnCancel = new Button();
            label5 = new Label();
            splitContainer1 = new SplitContainer();
            DgvUsers = new DataGridView();
            CboDepartment = new ComboBox();
            BtnDelete = new Button();
            BtnUpdate = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvUsers).BeginInit();
            SuspendLayout();
            // 
            // BtnSave
            // 
            BtnSave.Location = new Point(101, 250);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(71, 30);
            BtnSave.TabIndex = 2;
            BtnSave.Text = "등록";
            BtnSave.UseVisualStyleBackColor = true;
            // 
            // BtnNew
            // 
            BtnNew.Location = new Point(24, 214);
            BtnNew.Name = "BtnNew";
            BtnNew.Size = new Size(71, 30);
            BtnNew.TabIndex = 2;
            BtnNew.Text = "신규";
            BtnNew.UseVisualStyleBackColor = true;
            BtnNew.Click += BtnNew_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("나눔바른고딕", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 129);
            label1.Location = new Point(19, 63);
            label1.Name = "label1";
            label1.Size = new Size(76, 17);
            label1.TabIndex = 3;
            label1.Text = "사용자 번호";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("나눔바른고딕", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 129);
            label2.Location = new Point(61, 92);
            label2.Name = "label2";
            label2.Size = new Size(34, 17);
            label2.TabIndex = 3;
            label2.Text = "이름";
            // 
            // TxtUserIdx
            // 
            TxtUserIdx.BackColor = SystemColors.ControlLightLight;
            TxtUserIdx.Location = new Point(101, 61);
            TxtUserIdx.Name = "TxtUserIdx";
            TxtUserIdx.ReadOnly = true;
            TxtUserIdx.Size = new Size(148, 23);
            TxtUserIdx.TabIndex = 4;
            // 
            // TxtNames
            // 
            TxtNames.Location = new Point(101, 90);
            TxtNames.Name = "TxtNames";
            TxtNames.Size = new Size(148, 23);
            TxtNames.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("나눔바른고딕", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 129);
            label3.Location = new Point(48, 150);
            label3.Name = "label3";
            label3.Size = new Size(47, 17);
            label3.TabIndex = 3;
            label3.Text = "아이디";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("나눔바른고딕", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 129);
            label4.Location = new Point(35, 181);
            label4.Name = "label4";
            label4.Size = new Size(60, 17);
            label4.TabIndex = 3;
            label4.Text = "패스워드";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(101, 148);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(148, 23);
            textBox3.TabIndex = 4;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(101, 179);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(148, 23);
            textBox4.TabIndex = 4;
            // 
            // BtnCancel
            // 
            BtnCancel.Location = new Point(178, 250);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(71, 30);
            BtnCancel.TabIndex = 2;
            BtnCancel.Text = "취소";
            BtnCancel.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("나눔바른고딕", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 129);
            label5.Location = new Point(61, 121);
            label5.Name = "label5";
            label5.Size = new Size(34, 17);
            label5.TabIndex = 3;
            label5.Text = "부서";
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(DgvUsers);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(CboDepartment);
            splitContainer1.Panel2.Controls.Add(textBox4);
            splitContainer1.Panel2.Controls.Add(BtnDelete);
            splitContainer1.Panel2.Controls.Add(BtnUpdate);
            splitContainer1.Panel2.Controls.Add(BtnSave);
            splitContainer1.Panel2.Controls.Add(textBox3);
            splitContainer1.Panel2.Controls.Add(BtnCancel);
            splitContainer1.Panel2.Controls.Add(TxtNames);
            splitContainer1.Panel2.Controls.Add(BtnNew);
            splitContainer1.Panel2.Controls.Add(label4);
            splitContainer1.Panel2.Controls.Add(label1);
            splitContainer1.Panel2.Controls.Add(label5);
            splitContainer1.Panel2.Controls.Add(label2);
            splitContainer1.Panel2.Controls.Add(TxtUserIdx);
            splitContainer1.Panel2.Controls.Add(label3);
            splitContainer1.Size = new Size(751, 307);
            splitContainer1.SplitterDistance = 467;
            splitContainer1.TabIndex = 5;
            splitContainer1.TabStop = false;
            // 
            // DgvUsers
            // 
            DgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvUsers.Dock = DockStyle.Fill;
            DgvUsers.Location = new Point(0, 0);
            DgvUsers.Name = "DgvUsers";
            DgvUsers.Size = new Size(467, 307);
            DgvUsers.TabIndex = 0;
            // 
            // CboDepartment
            // 
            CboDepartment.FormattingEnabled = true;
            CboDepartment.Location = new Point(101, 119);
            CboDepartment.Name = "CboDepartment";
            CboDepartment.Size = new Size(148, 23);
            CboDepartment.TabIndex = 5;
            CboDepartment.Text = "--부서 선택--";
            // 
            // BtnDelete
            // 
            BtnDelete.Location = new Point(178, 214);
            BtnDelete.Name = "BtnDelete";
            BtnDelete.Size = new Size(71, 30);
            BtnDelete.TabIndex = 2;
            BtnDelete.Text = "삭제";
            BtnDelete.UseVisualStyleBackColor = true;
            // 
            // BtnUpdate
            // 
            BtnUpdate.Location = new Point(101, 214);
            BtnUpdate.Name = "BtnUpdate";
            BtnUpdate.Size = new Size(71, 30);
            BtnUpdate.TabIndex = 2;
            BtnUpdate.Text = "수정";
            BtnUpdate.UseVisualStyleBackColor = true;
            // 
            // FrmUsers
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(751, 307);
            Controls.Add(splitContainer1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmUsers";
            Text = "사용자 관리";
            Load += FrmUsers_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DgvUsers).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button BtnSave;
        private Button BtnNew;
        private Label label1;
        private Label label2;
        private TextBox TxtUserIdx;
        private TextBox TxtNames;
        private Label label3;
        private Label label4;
        private TextBox textBox3;
        private TextBox textBox4;
        private Button BtnCancel;
        private Label label5;
        private SplitContainer splitContainer1;
        private DataGridView DgvUsers;
        private Button BtnDelete;
        private Button BtnUpdate;
        private ComboBox CboDepartment;
    }
}