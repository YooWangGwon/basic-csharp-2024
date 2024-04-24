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
    public partial class FrmBookRental : MetroForm
    {
        private bool isNew = false; // UPDATE(false), INSERT(true)

        public FrmBookRental()
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
            // TODO 지금은 필요없음
        }

        // 신규버튼 클릭
        private void BtnNew_Click(object sender, EventArgs e)
        {
            isNew = true;
            TxtMemNames.Text = TxtRentalIdx.Text = string.Empty;
            TxtRentalIdx.ReadOnly = true;
            TxtMemNames.Focus();    // 순번은 자동증가하기 때문에 입력불가
            DtpRentalDate.Value = DtpReturnDate.Value = DateTime.Now;
        }

        // 저장버튼 클릭
        private void BtnSave_Click(object sender, EventArgs e)
        {
            // 입력 검증(Validation) -> 이름, 패스워드를 안넣으면 저장을 막음
            if (string.IsNullOrEmpty(TxtMemNames.Text))
            {
                MessageBox.Show("회원명을 선택하세요.");
                return;
            }
            if (string.IsNullOrEmpty(TxtBookNames.Text))
            {
                MessageBox.Show("대출할 책을 선택하세요.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(Helper.Common.Connstring))
                {
                    conn.Open();

                    var query = "";
                    if (isNew) // INSERT 이면
                    {
                        query = @"INSERT INTO [rentaltbl]
                                        ([memberIdx]
                                        ,[bookIdx]
                                        ,[rentalDate]
                                        ,[returnDate])
                                    VALUES
                                        ( @memberIdx 
                                        , @bookIdx 
                                        , @rentalDate 
                                        , @returnDate )";
                    }
                    else // UPDATE이면
                    {
                        query = @"UPDATE [rentaltbl]
                                   SET [memberIdx] = @memberIdx
                                      ,[bookIdx] = @bookIdx
                                      ,[rentalDate] = @rentalDate
                                      ,[returnDate] = @returnDate
                                 WHERE rentalIdx = @rentalIdx";
                    }

                    SqlCommand cmd = new SqlCommand(query, conn);

                    SqlParameter prmMemberIdx = new SqlParameter("@memberIdx", TxtMemberIdx.Text);
                    cmd.Parameters.Add(prmMemberIdx);
                    SqlParameter prmBookIdx = new SqlParameter("@bookIdx", TxtBookIdx.Text);
                    cmd.Parameters.Add(prmBookIdx);
                    SqlParameter prmRentalDate = new SqlParameter("@rentalDate", DtpRentalDate.Value);
                    cmd.Parameters.Add(prmRentalDate);
                    var returnDate = "";    // 반납 날짜 때문에 추가 처리

                    if (DtpReturnDate.Value < DtpRentalDate.Value)  // 대출일보다 반납일이 더 뒤의 날짜가 되어야함
                    {
                        returnDate = "";
                    }
                    else
                    {
                        returnDate = DtpReturnDate.Value.ToString("yyyy-MM-dd");
                    }
                    SqlParameter prmRenturnDate = new SqlParameter("@returnDate", returnDate);
                    cmd.Parameters.Add(prmRenturnDate);

                    if (isNew != true)  // UPDATE일 경우
                    {
                        SqlParameter prmRentalIdx = new SqlParameter("@RentalIdx", TxtRentalIdx.Text);
                        cmd.Parameters.Add(prmRentalIdx);
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
            TxtMemNames.Text = TxtRentalIdx.Text = string.Empty; // 입력, 수정, 삭제 이후에는 모든 입력값을 지워줘야 함
            DtpReturnDate.Value = DateTime.Now;
            RefreshData();
        }
        private void DgvResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)    // 아무것도 선택하지 않으면 -1
            {
                var selData = DgvResult.Rows[e.RowIndex]; // 내가 선택한 인덱스 값
                TxtRentalIdx.Text = selData.Cells[0].Value.ToString();// 책 순번
                TxtMemberIdx.Text = selData.Cells[1].Value.ToString(); // 저자명
                TxtMemNames.Text = selData.Cells[2].Value.ToString();
                TxtBookIdx.Text = selData.Cells[3].Value.ToString();
                TxtBookNames.Text = selData.Cells[4].Value.ToString();
                DtpRentalDate.Value = DateTime.Parse(selData.Cells[5].Value.ToString());
                DtpReturnDate.Value = !string.IsNullOrEmpty(selData.Cells[6].Value.ToString()) ?
                    DateTime.Parse(selData.Cells[6].Value.ToString()) :
                    DateTime.Parse("1800-01-01");   // 1800-01-01은 반납 안한 날짜
                TxtRentalIdx.ReadOnly = true; // UPDATE 시에는 구분번호를 '읽기 전용'
                isNew = false; // UPDATE
            }
        }

        private void BtnSearchMemeber_Click(object sender, EventArgs e)
        {
            PopMember popup = new PopMember();
            popup.StartPosition = FormStartPosition.CenterParent;
            if (popup.ShowDialog() == DialogResult.Yes)
            {
                TxtMemberIdx.Text = Helper.Common.SelMemberIdx;
                TxtMemNames.Text = Helper.Common.SelMemberName;
            }
        }

        private void BtnSearchBook_Click(object sender, EventArgs e)
        {
            PopBook popup = new PopBook();
            popup.StartPosition = FormStartPosition.CenterParent;
            if (popup.ShowDialog() == DialogResult.Yes)
            {
                TxtBookIdx.Text = Helper.Common.SelBookIdx;
                TxtBookNames.Text = Helper.Common.SelBookName;
            }
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
                var query = @"SELECT r.rentalIdx
                                   , r.memberIdx
	                               , m.Names AS memNames
                                   , r.bookIdx
	                               , b.Names AS bookNames
                                   , r.rentalDate
                                   , r.returnDate
                                FROM rentaltbl AS r
                                JOIN membertbl AS m
                                  ON r.memberIdx = m.memberIdx
                                JOIN bookstbl AS b
	                              ON r.bookIdx = b.bookIdx;";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "rentaltbl");    // 대표테이블 이름 작성 
                DgvResult.DataSource = ds.Tables[0];
                DgvResult.ReadOnly = true;  // 수정 불가
                DgvResult.Columns[0].HeaderText = "대출번호";
                DgvResult.Columns[1].HeaderText = "회원번호";
                DgvResult.Columns[2].HeaderText = "회원명";
                DgvResult.Columns[3].HeaderText = "책번호";
                DgvResult.Columns[4].HeaderText = "책제목";
                DgvResult.Columns[5].HeaderText = "대출일";
                DgvResult.Columns[6].HeaderText = "반납일";
                // 너비 설정
                //DgvResult.Columns[0].Width = 68; // 책 순번
                //DgvResult.Columns[1].Width = 145;// 저자명
                //DgvResult.Columns[2].Visible = false;   // 구분코드 숨기기
                //DgvResult.Columns[4].Width = 195;// 책제목
                //DgvResult.Columns[5].Width = 73; // 출판일
            }
        }
    }
}
