namespace schedule_app_2
{
    partial class FrmIncomplete
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
            DgvIncomplete = new DataGridView();
            BtnDelete = new Button();
            BtnComplete = new Button();
            ((System.ComponentModel.ISupportInitialize)DgvIncomplete).BeginInit();
            SuspendLayout();
            // 
            // DgvIncomplete
            // 
            DgvIncomplete.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvIncomplete.EditMode = DataGridViewEditMode.EditOnKeystroke;
            DgvIncomplete.Location = new Point(12, 12);
            DgvIncomplete.Name = "DgvIncomplete";
            DgvIncomplete.Size = new Size(660, 382);
            DgvIncomplete.TabIndex = 0;
            DgvIncomplete.CellClick += DgvIncomplete_CellClick;
            DgvIncomplete.CellValueChanged += DgvIncomplete_CellValueChanged;
            // 
            // BtnDelete
            // 
            BtnDelete.Location = new Point(582, 400);
            BtnDelete.Name = "BtnDelete";
            BtnDelete.Size = new Size(90, 38);
            BtnDelete.TabIndex = 2;
            BtnDelete.Text = "전원 삭제";
            BtnDelete.UseVisualStyleBackColor = true;
            // 
            // BtnComplete
            // 
            BtnComplete.Location = new Point(466, 400);
            BtnComplete.Name = "BtnComplete";
            BtnComplete.Size = new Size(110, 38);
            BtnComplete.TabIndex = 3;
            BtnComplete.Text = "전원 완료 처리";
            BtnComplete.UseVisualStyleBackColor = true;
            BtnComplete.Click += BtnComplete_Click;
            // 
            // FrmIncomplete
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(684, 450);
            Controls.Add(BtnComplete);
            Controls.Add(BtnDelete);
            Controls.Add(DgvIncomplete);
            Name = "FrmIncomplete";
            Text = "전체 미완료 일정";
            Load += FrmIncomplete_Load;
            ((System.ComponentModel.ISupportInitialize)DgvIncomplete).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView DgvIncomplete;
        private Button BtnDelete;
        private Button BtnComplete;
    }
}