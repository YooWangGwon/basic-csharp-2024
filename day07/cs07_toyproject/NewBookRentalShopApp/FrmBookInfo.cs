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
    public partial class FrmBookInfo : MetroForm
    {
        private bool isNew = false; // UPDATE(false), INSERT(true)

        public FrmBookInfo()
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
                using (SqlConnection conn = new SqlConnection(Helper.Common.Connstring))
                {
                    conn.Open();

                    var query = @"SELECT Division, Names FROM divtbl";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    // SqlDataReader = 개발자가 하나씩 처리할 때
                    // SqlDataAdapter, DataSet = 한번에 데이터 그리드 뷰 등에 뿌릴 때
                    SqlDataReader reader = cmd.ExecuteReader();
                    var temp = new Dictionary<string, string>();
                                             // key , value
                                             // B001, 공포/스릴러
                    while(reader.Read())    
                    {
                        // reader[0] = Division 컬럼, reader[1] = Names 컬럼
                        temp.Add(reader[0].ToString(), reader[1].ToString());
                    }
                    CboDivision.DataSource = new BindingSource(temp, null);
                    CboDivision.DisplayMember = "Value";    // 공포/스릴러
                    CboDivision.ValueMember = "Key";        // B001
                    CboDivision.SelectedIndex = -1;         // 콤보박스에 아무것도 선택 안된 상태
                    // CboDivision.PromptText = "--구분명 선택--";
                }
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
            TxtAuthor.Text = TxtBookIdx.Text = string.Empty;
            TxtBookIdx.ReadOnly = true;
            TxtAuthor.Focus();
        }

        // 저장버튼 클릭
        private void BtnSave_Click(object sender, EventArgs e)
        {
            // 입력 검증(Validation) -> 이름, 패스워드를 안넣으면 저장을 막음
            if (string.IsNullOrEmpty(TxtAuthor.Text))
            {
                MessageBox.Show("저자명을 입력하세요.");
                return;
            }
            // 콤보박스는 SelectedIndex가 -1이 되면 안됨
            if(CboDivision.SelectedIndex < 0)
            {
                MessageBox.Show("구분명을 선택하세요.");
                return;
            }
            if (string.IsNullOrEmpty(TxtNames.Text))
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
                        query = @"	INSERT INTO todotbl(
				                           TodoIdx 
			                             , Todo 
			                             , StartDate 
			                             , EndDate 
			                             , Place 
			                             , Detail 
			                             , Division 
			                             , Complete )
		                            VALUES
			                             ( @TodoIdx
			                             , @Todo
			                             , @StartDate
			                             , @EndDate
			                             , @Place
			                             , @Detail
			                             , @Division
			                             , @Complete)";
                    }
                    else // UPDATE이면
                    {
                        query = @"UPDATE bookstbl
                                     SET Author = @Author
                                       , Division = @Division
                                       , Names = @Names
                                       , ReleaseDate = @ReleaseDate
                                       , ISBN = @ISBN
                                       , Price = @Price
                                   WHERE bookIdx = @bookIdx";
                    }

                    SqlCommand cmd = new SqlCommand(query, conn);

                    SqlParameter prmAuthor = new SqlParameter("@Author", TxtAuthor.Text);
                    cmd.Parameters.Add(prmAuthor);
                    SqlParameter prmDivision = new SqlParameter("@Division", CboDivision.SelectedValue);
                    cmd.Parameters.Add(prmDivision);
                    SqlParameter prmNames = new SqlParameter("@Names", TxtNames.Text);
                    cmd.Parameters.Add(prmNames);
                    SqlParameter prmReleaseDate = new SqlParameter("@ReleaseDate", DtpReleaseDate.Value);
                    cmd.Parameters.Add(prmReleaseDate);
                    SqlParameter prmIsbn = new SqlParameter("@ISBN", TxtIsbn.Text);
                    cmd.Parameters.Add(prmIsbn);
                    SqlParameter prmPrice = new SqlParameter("@Price", NudPrice.Value);
                    cmd.Parameters.Add(prmPrice);

                    if (isNew != true)  // UPDATE일 경우
                    {
                        SqlParameter prmBookIdx = new SqlParameter("@bookIdx", TxtBookIdx.Text);
                        cmd.Parameters.Add(prmBookIdx);
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
            TxtAuthor.Text = TxtBookIdx.Text = string.Empty; // 입력, 수정, 삭제 이후에는 모든 입력값을 지워줘야 함
            CboDivision.SelectedIndex = -1;
            TxtNames.Text = TxtIsbn.Text = string.Empty;
            DtpReleaseDate.Value = DateTime.Now;
            NudPrice.Value = 0;
            RefreshData();
        }

        // 삭제 버튼 클릭
        private void BtnDel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtBookIdx.Text)) // 사용자 아이디 순번이 없으면
            {
                MetroMessageBox.Show(this, "삭제할 책를 선택하세요", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var answer = MetroMessageBox.Show(this, "정말 삭제하시겠습니까?", "삭제 여부", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.No) return;

            using (SqlConnection conn = new SqlConnection(Helper.Common.Connstring))
            {
                conn.Open();
                var query = @"DELETE FROM bookstbl
                           WHERE bookIdx = @bookIdx";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlParameter prmBookIdx = new SqlParameter("@bookIdx", TxtBookIdx.Text);
                cmd.Parameters.Add(prmBookIdx);

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
            TxtAuthor.Text = TxtBookIdx.Text = string.Empty;
            CboDivision.SelectedIndex = -1;
            TxtNames.Text = TxtIsbn.Text = string.Empty;
            DtpReleaseDate.Value = DateTime.Now;
            NudPrice.Value = 0;
            RefreshData(); // 데이터 그리드 재조회
        }
        private void TxtIsbn_KeyPress(object sender, KeyPressEventArgs e) // ISBN에 숫자만 입력되도록 처리
        {   // 숫자 이외에는 전부 막아버림
            if (char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // 데이터 그리드 뷰에 데이터를 새로 부르기
        private void RefreshData()
        {
            using (SqlConnection conn = new SqlConnection(Helper.Common.Connstring))
            {
                conn.Open();
                var query = @"SELECT bookIdx
                                   , Author
                                   , b.[Division]
                                   , d.Names AS DivNames
                                   , b.Names
                                   , b.ReleaseDate
                                   , b.ISBN
                                   , b.Price
                                FROM bookstbl AS b
                                   , divtbl AS d
                               WHERE d.Division = b.Division";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "bookstbl");    // ds에 usertbl 이름으로 값을 집어넣어줘 
                DgvResult.DataSource = ds.Tables[0];
                DgvResult.ReadOnly = true;  // 수정 불가
                DgvResult.Columns[0].HeaderText = "책순번";
                DgvResult.Columns[1].HeaderText = "저자명";
                DgvResult.Columns[2].HeaderText = "구분코드";
                DgvResult.Columns[3].HeaderText = "구분명";
                DgvResult.Columns[4].HeaderText = "책제목";
                DgvResult.Columns[5].HeaderText = "출판일";
                DgvResult.Columns[6].HeaderText = "ISBN";
                DgvResult.Columns[7].HeaderText = "책가격";
                // 너비 설정
                DgvResult.Columns[0].Width = 68; // 책 순번
                DgvResult.Columns[1].Width = 145;// 저자명
                DgvResult.Columns[2].Visible = false;   // 구분코드 숨기기
                DgvResult.Columns[4].Width = 195;// 책제목
                DgvResult.Columns[5].Width = 73; // 출판일
                DgvResult.Columns[7].Width = 68; // 책가격
            }
        }

        private void DgvResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)    // 아무것도 선택하지 않으면 -1
            {
                var selData = DgvResult.Rows[e.RowIndex]; // 내가 선택한 인덱스 값
                TxtBookIdx.Text = selData.Cells[0].Value.ToString();// 책 순번
                TxtAuthor.Text = selData.Cells[1].Value.ToString(); // 저자명
                TxtNames.Text = selData.Cells[4].Value.ToString();  // 책 제목

                // "2019-03-09" 문자열을 DateTime.Parse() DateTime형으로 변경
                DtpReleaseDate.Value = DateTime.Parse(selData.Cells[5].Value.ToString());
                TxtIsbn.Text = selData.Cells[6].Value.ToString();   // ISBN
                // "20000" 가격을 숫자형으로 형변환해주는 메서드
                // 거의 모든 타입에 .Parse(string) 메서드가 존재
                NudPrice.Value = Decimal.Parse(selData.Cells[7].Value.ToString());
                TxtBookIdx.ReadOnly = true; // UPDATE 시에는 구분번호를 '읽기 전용'

                // 콤보박스는 맨 마지막에
                CboDivision.SelectedValue = selData.Cells[2].Value; // 구분 코드로 선택

                isNew = false; // UPDATE
            }
        }

    }
}
