using System.Resources;

namespace schedule_app
{
    partial class UpdateTodo
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
            TxtTodo = new TextBox();
            CboStartHour = new ComboBox();
            TxtPlace = new TextBox();
            TxtDetail = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            BtnCancel = new Button();
            BtnConfirm = new Button();
            CboDate = new DateTimePicker();
            CboStartMin = new ComboBox();
            CboEndHour = new ComboBox();
            CboEndMin = new ComboBox();
            label8 = new Label();
            label9 = new Label();
            SuspendLayout();
            // 
            // TxtTodo
            // 
            TxtTodo.Location = new Point(87, 10);
            TxtTodo.Name = "TxtTodo";
            TxtTodo.Size = new Size(256, 23);
            TxtTodo.TabIndex = 1;
            // 
            // CboStartHour
            // 
            CboStartHour.FormattingEnabled = true;
            CboStartHour.Items.AddRange(new object[] { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23" });
            CboStartHour.Location = new Point(87, 73);
            CboStartHour.Name = "CboStartHour";
            CboStartHour.Size = new Size(42, 23);
            CboStartHour.TabIndex = 2;
            // 
            // TxtPlace
            // 
            TxtPlace.Location = new Point(87, 102);
            TxtPlace.Name = "TxtPlace";
            TxtPlace.Size = new Size(256, 23);
            TxtPlace.TabIndex = 3;
            // 
            // TxtDetail
            // 
            TxtDetail.Location = new Point(87, 131);
            TxtDetail.Multiline = true;
            TxtDetail.Name = "TxtDetail";
            TxtDetail.Size = new Size(256, 99);
            TxtDetail.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("나눔바른고딕", 11F, FontStyle.Bold);
            label1.Location = new Point(12, 12);
            label1.Name = "label1";
            label1.Size = new Size(66, 17);
            label1.TabIndex = 5;
            label1.Text = "해야 할 일";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("나눔바른고딕", 11F, FontStyle.Bold);
            label2.Location = new Point(12, 46);
            label2.Name = "label2";
            label2.Size = new Size(34, 17);
            label2.TabIndex = 5;
            label2.Text = "날짜";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("나눔바른고딕", 11F, FontStyle.Bold);
            label3.Location = new Point(12, 75);
            label3.Name = "label3";
            label3.Size = new Size(34, 17);
            label3.TabIndex = 5;
            label3.Text = "시간";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("나눔바른고딕", 11F, FontStyle.Bold);
            label4.Location = new Point(12, 104);
            label4.Name = "label4";
            label4.Size = new Size(34, 17);
            label4.TabIndex = 5;
            label4.Text = "장소";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("나눔바른고딕", 11F, FontStyle.Bold);
            label5.Location = new Point(12, 133);
            label5.Name = "label5";
            label5.Size = new Size(63, 17);
            label5.TabIndex = 5;
            label5.Text = "상세 내용";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("나눔바른고딕", 9.75F, FontStyle.Bold);
            label6.Location = new Point(179, 77);
            label6.Name = "label6";
            label6.Size = new Size(31, 15);
            label6.TabIndex = 5;
            label6.Text = "부터";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("나눔바른고딕", 9.75F, FontStyle.Bold);
            label7.Location = new Point(308, 77);
            label7.Name = "label7";
            label7.Size = new Size(31, 15);
            label7.TabIndex = 5;
            label7.Text = "까지";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BtnCancel
            // 
            BtnCancel.Font = new Font("나눔바른고딕", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 129);
            BtnCancel.Location = new Point(263, 236);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(80, 30);
            BtnCancel.TabIndex = 6;
            BtnCancel.Text = "취소";
            BtnCancel.UseVisualStyleBackColor = true;
            // 
            // BtnConfirm
            // 
            BtnConfirm.Font = new Font("나눔바른고딕", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 129);
            BtnConfirm.Location = new Point(177, 236);
            BtnConfirm.Name = "BtnConfirm";
            BtnConfirm.Size = new Size(80, 30);
            BtnConfirm.TabIndex = 6;
            BtnConfirm.Text = "등록";
            BtnConfirm.UseVisualStyleBackColor = true;
            // 
            // CboDate
            // 
            CboDate.Location = new Point(87, 41);
            CboDate.Name = "CboDate";
            CboDate.Size = new Size(254, 23);
            CboDate.TabIndex = 7;
            // 
            // CboStartMin
            // 
            CboStartMin.FormattingEnabled = true;
            CboStartMin.Items.AddRange(new object[] { "00", "05", "10", "15", "20", "25", "30", "35", "40", "45", "50", "55" });
            CboStartMin.Location = new Point(135, 73);
            CboStartMin.Name = "CboStartMin";
            CboStartMin.Size = new Size(42, 23);
            CboStartMin.TabIndex = 2;
            // 
            // CboEndHour
            // 
            CboEndHour.FormattingEnabled = true;
            CboEndHour.Items.AddRange(new object[] { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23" });
            CboEndHour.Location = new Point(215, 73);
            CboEndHour.Name = "CboEndHour";
            CboEndHour.Size = new Size(42, 23);
            CboEndHour.TabIndex = 2;
            // 
            // CboEndMin
            // 
            CboEndMin.FormattingEnabled = true;
            CboEndMin.Items.AddRange(new object[] { "00", "05", "10", "15", "20", "25", "30", "35", "40", "45", "50", "55" });
            CboEndMin.Location = new Point(263, 73);
            CboEndMin.Name = "CboEndMin";
            CboEndMin.Size = new Size(42, 23);
            CboEndMin.TabIndex = 2;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("나눔바른고딕", 11F, FontStyle.Bold);
            label8.Location = new Point(127, 76);
            label8.Name = "label8";
            label8.Size = new Size(12, 17);
            label8.TabIndex = 5;
            label8.Text = ":";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("나눔바른고딕", 11F, FontStyle.Bold);
            label9.Location = new Point(255, 76);
            label9.Name = "label9";
            label9.Size = new Size(12, 17);
            label9.TabIndex = 5;
            label9.Text = ":";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UpdateTodo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(353, 274);
            Controls.Add(CboEndMin);
            Controls.Add(CboEndHour);
            Controls.Add(CboStartMin);
            Controls.Add(CboStartHour);
            Controls.Add(CboDate);
            Controls.Add(BtnConfirm);
            Controls.Add(BtnCancel);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(TxtDetail);
            Controls.Add(TxtPlace);
            Controls.Add(TxtTodo);
            Name = "UpdateTodo";
            Text = "일정 수정";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox TxtTodo;
        private ComboBox CboStartHour;
        private TextBox TxtPlace;
        private TextBox TxtDetail;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Button BtnCancel;
        private Button BtnConfirm;
        private DateTimePicker CboDate;
        private ComboBox CboStartMin;
        private ComboBox CboEndHour;
        private ComboBox CboEndMin;
        private Label label8;
        private Label label9;
    }
}