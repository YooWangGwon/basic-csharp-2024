using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace NewBookRentalShopApp
{
    public partial class FrmLogin : MetroForm
    {
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

        // 로그인 버튼 클릭 이벤트 핸들러
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            // Application.Exit(); // 종료시 종료를 물어보는 다이얼로그가 나타남
            Environment.Exit(0);    // 무조건 종료
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
            if(isFail == true)
            {
                MessageBox.Show(errMsg, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            IsLogin = LoginProcess();
            if (IsLogin) this.Close();
        }


        private bool LoginProcess()
        {
            var md5Hash = MD5.Create();

            string userId = TxtUserId.Text;   // 현재 DB로 넘기는 값
            string password = TxtPassword.Text;
            string chkUserId = string.Empty;    // DB에서 넘어온 값
            string chkPassword = string.Empty;
            /*
             * 1. Connection 생성
             * 2. 쿼리 문자열 작성
             * 3. SqlCommand 명령 객체 생성
             * 4. SqlParameter 객체 생성
             * 5. Select SqlDataReader 또는 SqlDataSet 객체 사용
             * 6. CUD 작업 SqlCommand.ExecuteQuery()
             * 7. Connection 닫기
             */

            // 연결문자열(ConnectionString)
            // Data Source=localhost;Initial Catalog=BookRentalShop2024;Persist Security Info=True;User ID=sa;Encrypt=False;Password=mssql_p@ss
            // @userID, @password 쿼리문 외부에서 변수값을 안전하게 주입함
            using (SqlConnection conn = new SqlConnection(Helper.Common.Connstring))
            {
                conn.Open();

                string query = @"SELECT userID
	                                  , [password]
                                   FROM usertbl
                                  WHERE userid = @userId
                                    AND [password] = @password";
                SqlCommand cmd = new SqlCommand(query, conn);
                // @userid, @password 파라미터 할당
                SqlParameter paramUserId = new SqlParameter("@userId", userId);
                SqlParameter paramPassword = new SqlParameter("@password", Helper.Common.GetMd5Hash(md5Hash, password));
                cmd.Parameters.Add(paramUserId);
                cmd.Parameters.Add(paramPassword);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    chkUserId = reader["userId"] != null ? reader["userId"].ToString() : "-"; // 유저 아이디가 null 일때 -로 변경
                    chkPassword = reader["password"] != null ? reader["password"].ToString() : "-"; // 패스워드가 null 이면 -로 변경
                    Helper.Common.LoginId = chkUserId; // 로그인된 아이디
                    return true;
                }
                else
                {
                    MessageBox.Show("로그인 정보가 없습니다","DB 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
