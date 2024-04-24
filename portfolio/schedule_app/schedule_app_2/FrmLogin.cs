using schedule_app;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace schedule_app_2
{
    public partial class FrmLogin : Form
    {
        MainFrm frm = null;

        private bool isLogin = false;
        public bool IsLogin
        {
            get { return isLogin; }
            set { isLogin = value; }
        }
        public FrmLogin()
        {
            InitializeComponent();

            TxtUserId.Text = string.Empty;
            TxtPassword.Text = string.Empty;
        }
        public FrmLogin(MainFrm mainFrm)
        {
            InitializeComponent();
            frm = mainFrm;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            bool isFail = false;
            string errMsg = string.Empty;
            // DB 연계
            if (string.IsNullOrEmpty(TxtUserId.Text))
            {
                isFail = true;
                errMsg += "아이디를 입력하세요.\n";
            }
            if (string.IsNullOrEmpty(TxtPassword.Text))
            {
                isFail = true;
                errMsg += "패스워드를 입력하세요.\n";
            }
            if (isFail == true)
            {
                MessageBox.Show(errMsg, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            IsLogin = LoginProcess();
            if (IsLogin)
            { 
                this.Close();
            }
        }
        private bool LoginProcess()
        {
            var md5Hash = MD5.Create();

            string userId = TxtUserId.Text;   // 현재 DB로 넘기는 값
            string password = TxtPassword.Text;
            string chkUserId = string.Empty;    // DB에서 넘어온 값
            string chkPassword = string.Empty;

            using (SqlConnection conn = new SqlConnection(Helper.Common.Connstring))
            {
                conn.Open();

                string query = @"SELECT userIdx
                                      , name
                                      , userID
	                                  , [password]
                                   FROM usertbl
                                  WHERE userId = @userId
                                    AND [password] = @password";
                SqlCommand cmd = new SqlCommand(query, conn);
                // @userid, @password 파라미터 할당
                SqlParameter paramUserId = new SqlParameter("@userId", userId);
                SqlParameter paramPassword = new SqlParameter("@password", password);
                cmd.Parameters.Add(paramUserId);
                cmd.Parameters.Add(paramPassword);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    chkUserId = reader["userId"] != null ? reader["userId"].ToString() : "-"; // 유저 아이디가 null 일때 -로 변경
                    chkPassword = reader["password"] != null ? reader["password"].ToString() : "-"; // 패스워드가 null 이면 -로 변경
                    frm.UserIdx = (int)reader["userIdx"];
                    frm.UserName = reader["name"].ToString();
                    return true;
                }
                else
                {
                    MessageBox.Show("로그인 정보가 없습니다", "DB 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            }   // using을 사용하면 conn.Close()가 필요없음
        }

        private void TxtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) // Keychar : 키보드의 입력값에 대한 속성, Keychar 13은 엔터키
            {
                BtnLogin_Click(sender, e);
            }
        }
    }
}
