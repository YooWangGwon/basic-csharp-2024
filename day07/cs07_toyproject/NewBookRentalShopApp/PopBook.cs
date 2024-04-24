using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace NewBookRentalShopApp
{
    public partial class PopBook : MetroForm
    {
        public PopBook()
        {
            InitializeComponent();
        }

        private void PopMember_Load(object sender, EventArgs e)
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

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            if (DgvResult.SelectedRows == null)
            {
                MessageBox.Show("회원을 선택하세요");
                return;
            }
            var selData = DgvResult.SelectedRows[0];
            Helper.Common.SelBookIdx = selData.Cells[0].Value.ToString();
            Helper.Common.SelBookName = selData.Cells[4].Value.ToString();

            this.DialogResult = DialogResult.Yes;   // DialogResult를 발생시키고 다이얼로그의 Yes 버튼을 누른 것 같은 기능 제공 
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();   // 선택안하고 그냥 닫기
        }

        private void DgvResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
    }
}
