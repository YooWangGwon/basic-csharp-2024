using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;
using Microsoft.Win32.SafeHandles;

namespace NewBookRentalShopApp
{
    public partial class FrmLoginUser : MetroForm
    {
        private bool isNew = false; // UPDATE(false), INSERT(true)

        public FrmLoginUser()
        {
            InitializeComponent();
        }

        private void FrmLoginUser_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            isNew = true;
            TxtUserId.Text = TxtUserIdx.Text = TxtPassword.Text = string.Empty;
            // TxtUserIdx.Focus(); // 순번은 자동으로 증가하기 때문에 입력 불가
            TxtUserIdx.ReadOnly = false;
            TxtUserIdx.ReadOnly = true;
        }

        // 저장버튼 클릭
        private void BtnSave_Click(object sender, EventArgs e)
        {
            var md5Hash = MD5.Create(); // MD5 암호화용 객체 생성
            var valid = true;
            var errMsg = "";

            // 입력 검증(Validation) -> 이름, 패스워드를 안넣으면 저장을 막음
            if (string.IsNullOrEmpty(TxtUserId.Text))
            {
                errMsg += "사용자아이디를 입력하세요.\n";
                valid = false;
            }
            if (string.IsNullOrEmpty(TxtPassword.Text))
            {
                errMsg += "패스워드를 입력하세요.\n";
                valid = false;
            }
            if(valid == false)
            {
                MetroMessageBox.Show(this.Parent.Parent, errMsg, "입력오류",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            try
            {
                using (SqlConnection conn = new SqlConnection(Helper.Common.Connstring))
                {
                    conn.Open();

                    var query = "";
                    if (isNew) // INSERT 이면
                    {
                        query = @"INSERT INTO usertbl
                                   ( userid
                                   , [password]
		                           )
                              VALUES
                                   ( @userid
                                   , @password
		                           )";
                    }
                    else // UPDATE이면
                    {
                        query = @"UPDATE usertbl
                                 SET userid = @userId
                                   , [password] = @password
                               WHERE useridx = @userIdx";
                    }

                    SqlCommand cmd = new SqlCommand(query, conn);
                    if (isNew == false) // UPDATE 시에는 @useridx가 필요함
                    {
                        SqlParameter prmUserIdx = new SqlParameter("@userIdx", TxtUserIdx.Text);
                        cmd.Parameters.Add(prmUserIdx);
                    }
                    SqlParameter prmUserId = new SqlParameter("@userId", TxtUserId.Text);
                    SqlParameter prmPassword = new SqlParameter("@password", Helper.Common.GetMd5Hash(md5Hash, TxtPassword.Text));
                    // Command에 Parameter를 연결해줘야 함
                    cmd.Parameters.Add(prmUserId);
                    cmd.Parameters.Add(prmPassword);

                    var result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        // this : 메시지 박스의 부모창이 누구인가? -> FrmLoginUser
                        MetroMessageBox.Show(this.Parent.Parent, "저장성공!", "저장", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }
                    else
                    {
                        MetroMessageBox.Show(this.Parent.Parent,"저장 실패!", "저장", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this.Parent.Parent, $"오류 : {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            TxtUserId.Text = TxtUserIdx.Text = TxtPassword.Text = string.Empty; // 입력, 수정, 삭제 이후에는 모든 입력값을 지워줘야 함
            RefreshData();
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtUserIdx.Text)) // 사용자 아이디 순번이 없으면
            {
                MetroMessageBox.Show(this.Parent.Parent, "삭제할 사용자를 선택하세요", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var answer = MetroMessageBox.Show(this.Parent.Parent, "정말 삭제하시겠습니까?", "삭제 여부", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.No) return;

            using (SqlConnection conn = new SqlConnection(Helper.Common.Connstring))
            {
                conn.Open();
                var query = @"DELETE FROM usertbl
                           WHERE userIdx = @userIdx";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlParameter prmUserIdx = new SqlParameter("@userIdx", TxtUserIdx.Text);
                cmd.Parameters.Add(prmUserIdx);

                var result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MetroMessageBox.Show(this.Parent.Parent, "삭제 성공", "삭제", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MetroMessageBox.Show(this.Parent.Parent, "삭제 실패!", "삭제", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            TxtUserId.Text = TxtUserIdx.Text = TxtPassword.Text = string.Empty;
            RefreshData(); // 데이터 그리드 재조회
        }

        // 데이터 그리드 뷰에 데이터를 새로 부르기
        private void RefreshData()
        {
            using (SqlConnection conn = new SqlConnection(Helper.Common.Connstring))
            {
                conn.Open();
                var query = @"SELECT useridx
                                   , userid
                                   , [password]
                                   , lastLoginDateTime
                                FROM usertbl";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "usertbl");    // ds에 usertbl 이름으로 값을 집어넣어줘 
                DgvResult.DataSource = ds.Tables[0];
                DgvResult.ReadOnly = true;  // 수정 불가
                DgvResult.Columns[0].HeaderText = "사용자 순번";
                DgvResult.Columns[1].HeaderText = "사용자 아이디";
                DgvResult.Columns[2].HeaderText = "패스워드";
                DgvResult.Columns[3].HeaderText = "마지막 로그인 날짜";
            }
        }

        private void DgvResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)    // 아무것도 선택하지 않으면 -1
            {
                var selData = DgvResult.Rows[e.RowIndex]; // 내가 선택한 인덱스 값
                TxtUserIdx.Text = selData.Cells[0].Value.ToString();
                TxtUserIdx.ReadOnly = true;
                TxtUserId.Text = selData.Cells[1].Value.ToString();
                TxtPassword.Text = selData.Cells[2].Value.ToString();

                isNew = false; // UPDATE
            }
        }
    }
}
