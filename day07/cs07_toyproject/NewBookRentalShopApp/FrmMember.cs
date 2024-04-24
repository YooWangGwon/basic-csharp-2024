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
    public partial class FrmMember : MetroForm
    {
        private bool isNew = false; // UPDATE(false), INSERT(true)

        public FrmMember()
        {
            InitializeComponent();
        }

        private void FrmLoginUser_Load(object sender, EventArgs e)
        {
            RefreshData();  // bookstabl에서 데이터를 가져오는 부분
            // 콤보박스에 들어가는 데이터를 초기화
            InitInputData(); // 콤보박스, 날짜, NumericUpDown 컨트롤 데이터, 초기화
        }

        private void InitInputData()
        {
            try
            {
                var temp = new Dictionary<string, string>();
                temp.Add("A","A");
                temp.Add("B","B");
                temp.Add("C","C");
                temp.Add("D","D");

                CboLevels.DataSource = new BindingSource(temp, null);
                CboLevels.DisplayMember = "Value";
                CboLevels.ValueMember = "Key";
                CboLevels.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // 신규버튼 클릭
        private void BtnNew_Click(object sender, EventArgs e)
        {
            isNew = true;
            TxtNames.Text = TxtMemberIdx.Text = string.Empty;
            TxtMemberIdx.ReadOnly = true;
            TxtNames.Focus();
        }

        // 저장버튼 클릭
        private void BtnSave_Click(object sender, EventArgs e)
        {
            // 입력 검증(Validation) -> 이름, 패스워드를 안넣으면 저장을 막음
            if (string.IsNullOrEmpty(TxtNames.Text))
            {
                MessageBox.Show("저자명을 입력하세요.");
                return;
            }
            // 콤보박스는 SelectedIndex가 -1이 되면 안됨
            if(CboLevels.SelectedIndex < 0)
            {
                MessageBox.Show("구분명을 선택하세요.");
                return;
            }
            if (string.IsNullOrEmpty(TxtAddr.Text))
            {
                MessageBox.Show("책제목을 입력하세요.");
                return;
            }

            // 출판일은 기본으로 오늘 날짜가 들어감
            // ISBN은 NULL이 들어가도 상관없음
            // 책가격은 기본값이 0원

            try
            {
                using (SqlConnection conn = new SqlConnection(Helper.Common.Connstring))
                {
                    conn.Open();

                    var query = "";
                    if (isNew) // INSERT 이면
                    {
                        query = @"INSERT INTO [membertbl]
                                               ([Names]
                                               ,[Levels]
                                               ,[Addr]
                                               ,[Mobile]
                                               ,[Email])
                                         VALUES
                                               (@Names
                                               ,@Levels
                                               ,@Addr
                                               ,@Mobile
                                               ,@Email)";
                    }
                    else // UPDATE이면
                    {
                        query = @"UPDATE [membertbl]
                                     SET [Names] = @Names
                                        ,[Levels] = @Levels
                                        ,[Addr] = @Addr
                                        ,[Mobile] = @Mobile
                                        ,[Email] = @Email
                                   WHERE memberIdx = @memberIdx";
                    }

                    SqlCommand cmd = new SqlCommand(query, conn);

                    // 복사 붙여넣기 후 쿼리가 변경되면 늘 파라미터를 변경!!
                    SqlParameter prmNames = new SqlParameter("@Names", TxtNames.Text);
                    cmd.Parameters.Add(prmNames);
                    SqlParameter prmLevels = new SqlParameter("@Levels", CboLevels.SelectedValue);
                    cmd.Parameters.Add(prmLevels);
                    SqlParameter prmAddr = new SqlParameter("@Addr", TxtAddr.Text);
                    cmd.Parameters.Add(prmAddr);
                    SqlParameter prmMobile = new SqlParameter("@Mobile", TxtMobile.Text);
                    cmd.Parameters.Add(prmMobile);
                    SqlParameter prmEmail = new SqlParameter("@Email", TxtEmail.Text);
                    cmd.Parameters.Add(prmEmail);


                    if (isNew != true)  // UPDATE일 경우
                    {
                        SqlParameter prmMemberIdx = new SqlParameter("@memberIdx", TxtMemberIdx.Text);
                        cmd.Parameters.Add(prmMemberIdx);
                    }

                    var result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        // this : 메시지 박스의 부모창이 누구인가? -> FrmLoginUser
                        MetroMessageBox.Show(this, "저장성공!", "저장", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //MessageBox.Show("저장 성공","저장", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("저장 실패!", "저장", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, $"오류 : {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            TxtNames.Text = TxtMemberIdx.Text = string.Empty; // 입력, 수정, 삭제 이후에는 모든 입력값을 지워줘야 함
            TxtAddr.Text = TxtEmail.Text = string.Empty;
            RefreshData();
        }

        // 삭제 버튼 클릭
        private void BtnDel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtMemberIdx.Text)) // 사용자 아이디 순번이 없으면
            {
                MetroMessageBox.Show(this, "삭제할 책를 선택하세요", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var answer = MetroMessageBox.Show(this, "정말 삭제하시겠습니까?", "삭제 여부", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.No) return;

            using (SqlConnection conn = new SqlConnection(Helper.Common.Connstring))
            {
                conn.Open();
                var query = @"DELETE FROM membertbl
                           WHERE memberIdx = @memberIdx";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlParameter prmMemberIdx = new SqlParameter("@memberIdx", TxtMemberIdx.Text);
                cmd.Parameters.Add(prmMemberIdx);

                var result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MetroMessageBox.Show(this, "삭제 성공", "삭제", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MetroMessageBox.Show(this, "삭제 실패!", "삭제", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            TxtNames.Text = TxtMemberIdx.Text = string.Empty;
            TxtAddr.Text = TxtEmail.Text = string.Empty;
            RefreshData(); // 데이터 그리드 재조회
        }
        private void TxtIsbn_KeyPress(object sender, KeyPressEventArgs e) // ISBN에 숫자만 입력되도록 처리
        {
        }

        // 데이터 그리드 뷰에 데이터를 새로 부르기
        private void RefreshData()
        {
            using (SqlConnection conn = new SqlConnection(Helper.Common.Connstring))
            {
                conn.Open();
                var query = @"SELECT [memberIdx]
                                   , [Names]
                                   , [Levels]
                                   , [Addr]
                                   , [Mobile]
                                   , [Email]
                                FROM [membertbl]";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "membertbl");    // ds에 usertbl 이름으로 값을 집어넣어줘 
                DgvResult.DataSource = ds.Tables[0];
                DgvResult.ReadOnly = true;  // 수정 불가
                DgvResult.Columns[0].HeaderText = "회원번호";
                DgvResult.Columns[1].HeaderText = "회원명";
                DgvResult.Columns[2].HeaderText = "등급";
                DgvResult.Columns[3].HeaderText = "주소";
                DgvResult.Columns[4].HeaderText = "전화번호";
                DgvResult.Columns[5].HeaderText = "이메일";

                DgvResult.Columns[0].Width = 80;// 회원번호
                DgvResult.Columns[1].Width = 68;// 회원명
                DgvResult.Columns[2].Width = 60;// 등급
            }
        }

        private void DgvResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)    // 아무것도 선택하지 않으면 -1
            {
                var selData = DgvResult.Rows[e.RowIndex]; // 내가 선택한 인덱스 값
                TxtMemberIdx.Text = selData.Cells[0].Value.ToString();// 회원번호
                TxtNames.Text = selData.Cells[1].Value.ToString(); // 회원명
                CboLevels.SelectedValue = selData.Cells[2].Value;
                TxtAddr.Text = selData.Cells[3].Value.ToString();  // 주소
                TxtMobile.Text = selData.Cells[4].Value.ToString(); // 전화번호
                TxtEmail.Text = selData.Cells[5].Value.ToString();   // 이메일
                TxtMemberIdx.ReadOnly = true; // UPDATE 시에는 구분번호를 '읽기 전용'
                isNew = false; // UPDATE
            }
        }

    }
}
