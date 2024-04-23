namespace schedule_app_2
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            pictureBox1 = new PictureBox();
            TxtUserId = new TextBox();
            TxtPassword = new TextBox();
            label1 = new Label();
            label2 = new Label();
            BtnLogin = new Button();
            BtnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.user;
            pictureBox1.Location = new Point(28, 26);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(190, 190);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // TxtUserId
            // 
            TxtUserId.Font = new Font("나눔고딕", 8.999999F);
            TxtUserId.Location = new Point(313, 77);
            TxtUserId.Name = "TxtUserId";
            TxtUserId.Size = new Size(130, 21);
            TxtUserId.TabIndex = 1;
            // 
            // TxtPassword
            // 
            TxtPassword.Font = new Font("나눔고딕", 8.999999F);
            TxtPassword.Location = new Point(313, 104);
            TxtPassword.Name = "TxtPassword";
            TxtPassword.PasswordChar = '●';
            TxtPassword.Size = new Size(130, 21);
            TxtPassword.TabIndex = 2;
            TxtPassword.Text = "1234";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("나눔고딕", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 129);
            label1.Location = new Point(267, 80);
            label1.Name = "label1";
            label1.Size = new Size(40, 14);
            label1.TabIndex = 3;
            label1.Text = "아이디";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("나눔고딕", 9.75F);
            label2.Location = new Point(252, 106);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 4;
            label2.Text = "패스워드";
            // 
            // BtnLogin
            // 
            BtnLogin.Font = new Font("나눔고딕", 9.75F);
            BtnLogin.Location = new Point(281, 143);
            BtnLogin.Name = "BtnLogin";
            BtnLogin.Size = new Size(78, 33);
            BtnLogin.TabIndex = 5;
            BtnLogin.Text = "로그인";
            BtnLogin.UseVisualStyleBackColor = true;
            BtnLogin.Click += BtnLogin_Click;
            // 
            // BtnCancel
            // 
            BtnCancel.Font = new Font("나눔고딕", 9.75F);
            BtnCancel.Location = new Point(365, 143);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(78, 33);
            BtnCancel.TabIndex = 6;
            BtnCancel.Text = "취소";
            BtnCancel.UseVisualStyleBackColor = true;
            BtnCancel.Click += button2_Click;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(479, 243);
            Controls.Add(BtnCancel);
            Controls.Add(BtnLogin);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(TxtPassword);
            Controls.Add(TxtUserId);
            Controls.Add(pictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmLogin";
            Text = "FrmLogin";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private TextBox TxtUserId;
        private TextBox TxtPassword;
        private Label label1;
        private Label label2;
        private Button BtnLogin;
        private Button BtnCancel;
    }
}