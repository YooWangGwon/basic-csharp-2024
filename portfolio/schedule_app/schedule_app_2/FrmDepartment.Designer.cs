namespace schedule_app_2
{
    partial class FrmDepartment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDepartment));
            BtnSave = new Button();
            BtnNew = new Button();
            label1 = new Label();
            label2 = new Label();
            TxtDepIdx = new TextBox();
            TxtNames = new TextBox();
            BtnCancel = new Button();
            splitContainer1 = new SplitContainer();
            DgvDepartment = new DataGridView();
            BtnDelete = new Button();
            BtnUpdate = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvDepartment).BeginInit();
            SuspendLayout();
            // 
            // BtnSave
            // 
            BtnSave.Location = new Point(87, 202);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(71, 30);
            BtnSave.TabIndex = 8;
            BtnSave.Text = "등록";
            BtnSave.UseVisualStyleBackColor = true;
            BtnSave.Click += BtnSave_Click;
            // 
            // BtnNew
            // 
            BtnNew.Location = new Point(10, 166);
            BtnNew.Name = "BtnNew";
            BtnNew.Size = new Size(71, 30);
            BtnNew.TabIndex = 5;
            BtnNew.Text = "신규";
            BtnNew.UseVisualStyleBackColor = true;
            BtnNew.Click += BtnNew_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("나눔바른고딕", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 129);
            label1.Location = new Point(18, 94);
            label1.Name = "label1";
            label1.Size = new Size(63, 17);
            label1.TabIndex = 3;
            label1.Text = "부서 번호";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("나눔바른고딕", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 129);
            label2.Location = new Point(34, 123);
            label2.Name = "label2";
            label2.Size = new Size(47, 17);
            label2.TabIndex = 3;
            label2.Text = "부서명";
            // 
            // TxtDepIdx
            // 
            TxtDepIdx.BackColor = Color.White;
            TxtDepIdx.Location = new Point(87, 92);
            TxtDepIdx.Name = "TxtDepIdx";
            TxtDepIdx.ReadOnly = true;
            TxtDepIdx.Size = new Size(148, 23);
            TxtDepIdx.TabIndex = 0;
            // 
            // TxtNames
            // 
            TxtNames.BackColor = Color.White;
            TxtNames.Location = new Point(87, 121);
            TxtNames.Name = "TxtNames";
            TxtNames.Size = new Size(148, 23);
            TxtNames.TabIndex = 1;
            // 
            // BtnCancel
            // 
            BtnCancel.Location = new Point(164, 202);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(71, 30);
            BtnCancel.TabIndex = 9;
            BtnCancel.Text = "취소";
            BtnCancel.UseVisualStyleBackColor = true;
            BtnCancel.Click += BtnCancel_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(DgvDepartment);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(BtnDelete);
            splitContainer1.Panel2.Controls.Add(BtnUpdate);
            splitContainer1.Panel2.Controls.Add(BtnSave);
            splitContainer1.Panel2.Controls.Add(BtnCancel);
            splitContainer1.Panel2.Controls.Add(TxtNames);
            splitContainer1.Panel2.Controls.Add(BtnNew);
            splitContainer1.Panel2.Controls.Add(label1);
            splitContainer1.Panel2.Controls.Add(label2);
            splitContainer1.Panel2.Controls.Add(TxtDepIdx);
            splitContainer1.Size = new Size(488, 307);
            splitContainer1.SplitterDistance = 229;
            splitContainer1.TabIndex = 5;
            splitContainer1.TabStop = false;
            // 
            // DgvDepartment
            // 
            DgvDepartment.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvDepartment.Location = new Point(12, 12);
            DgvDepartment.Name = "DgvDepartment";
            DgvDepartment.Size = new Size(214, 283);
            DgvDepartment.TabIndex = 0;
            DgvDepartment.CellClick += DgvUsers_CellClick;
            // 
            // BtnDelete
            // 
            BtnDelete.Location = new Point(164, 166);
            BtnDelete.Name = "BtnDelete";
            BtnDelete.Size = new Size(71, 30);
            BtnDelete.TabIndex = 7;
            BtnDelete.Text = "삭제";
            BtnDelete.UseVisualStyleBackColor = true;
            BtnDelete.Click += BtnDelete_Click;
            // 
            // BtnUpdate
            // 
            BtnUpdate.Location = new Point(87, 166);
            BtnUpdate.Name = "BtnUpdate";
            BtnUpdate.Size = new Size(71, 30);
            BtnUpdate.TabIndex = 26;
            BtnUpdate.Text = "수정";
            BtnUpdate.UseVisualStyleBackColor = true;
            BtnUpdate.Click += BtnUpdate_Click;
            // 
            // FrmDepartment
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(488, 307);
            Controls.Add(splitContainer1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmDepartment";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "부서 관리";
            Load += FrmUsers_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DgvDepartment).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button BtnSave;
        private Button BtnNew;
        private Label label1;
        private Label label2;
        private TextBox TxtDepIdx;
        private TextBox TxtNames;
        private Button BtnCancel;
        private SplitContainer splitContainer1;
        private DataGridView DgvDepartment;
        private Button BtnDelete;
        private Button BtnUpdate;
    }
}