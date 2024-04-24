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
    public partial class PopMember : MetroForm
    {
        public PopMember()
        {
            InitializeComponent();
        }

        private void PopMember_Load(object sender, EventArgs e)
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

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            if (DgvResult.SelectedRows == null)
            {
                MessageBox.Show("회원을 선택하세요");
                return;
            }
            var selData = DgvResult.SelectedRows[0];
            //MessageBox.Show(selData.Cells[0].Value.ToString() + selData.Cells[1].Value.ToString());
            Helper.Common.SelMemberIdx = selData.Cells[0].Value.ToString();
            Helper.Common.SelMemberName = selData.Cells[1].Value.ToString();

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
