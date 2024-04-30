using schedule_app;
using schedule_app_2.Helper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace schedule_app_2
{
    public partial class FrmIncomplete : Form
    {
        MainFrm frm;

        public FrmIncomplete()
        {
            InitializeComponent();
        }

        public FrmIncomplete(MainFrm mainFrm)
        {
            InitializeComponent();
            frm = mainFrm;
        }

        private void FrmIncomplete_Load(object sender, EventArgs e)
        {
            //DataGridViewCheckBoxColumn dgvCmb = new DataGridViewCheckBoxColumn();
            ////dgvCmb.ValueType = typeof(bool);
            //dgvCmb.Name = "Chk";
            //dgvCmb.HeaderText = "선택";
            //DgvIncomplete.Columns.Add(dgvCmb);
            RefreshData();
        }

        private void RefreshData()
        {
            using (SqlConnection conn = new SqlConnection(Common.Connstring))
            {
                conn.Open();
                var query = @"SELECT TodoIdx
                                   , userIdx
                                   , Todo
                                   , StartDate
                                   , EndDate
                                   , Place
                                   , Detail
                                   , Division
                                   , Complete
                                FROM todotbl
                               WHERE userIdx = @userIdx
                                 AND Complete = 'N'";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlParameter prmUserIdx = new SqlParameter("@userIdx", frm.UserIdx);
                cmd.Parameters.Add(prmUserIdx);

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand = cmd;
                DataSet ds = new DataSet();
                adapter.Fill(ds, "todotbl");    // ds에 usertbl 이름으로 값을 집어넣어줘 
                DgvIncomplete.DataSource = ds.Tables[0];
                DgvIncomplete.ReadOnly = true;  // 수정 불가
                DgvIncomplete.Columns[0].HeaderText = "업무 번호";
                DgvIncomplete.Columns[1].HeaderText = "사용자 번호";
                DgvIncomplete.Columns[2].HeaderText = "내용";
                DgvIncomplete.Columns[3].HeaderText = "시작일";
                DgvIncomplete.Columns[4].HeaderText = "마감일";
                DgvIncomplete.Columns[5].HeaderText = "장소";
                DgvIncomplete.Columns[6].HeaderText = "상세내용";
                DgvIncomplete.Columns[7].HeaderText = "구분";
                DgvIncomplete.Columns[8].HeaderText = "완료여부";

                DgvIncomplete.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                DgvIncomplete.Columns[0].Visible = false;
                DgvIncomplete.Columns[1].Visible = false;
                //DgvIncomplete.Columns[2].Visible = false;
                //DgvIncomplete.Columns[3].Visible = false;
                //DgvIncomplete.Columns[4].Width = 200;
                DgvIncomplete.Columns[5].Visible = false;
                DgvIncomplete.Columns[6].Visible = false;
                DgvIncomplete.Columns[7].Width = 80;
                DgvIncomplete.Columns[8].Width = 80;
            }
        }

        private void DgvIncomplete_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex > -1)    // 아무것도 선택하지 않으면 -1
            //{
            //    var selData = DgvIncomplete.Rows[e.RowIndex]; // 내가 선택한 행 인덱스 값
            //    BtnDelete.Enabled = BtnComplete.Enabled = true;
            //    //MessageBox.Show(selData.Cells[0].Value.ToString());
            //}
            //else
            //{
            //    return;
            //}
        }

        private void BtnComplete_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(Common.Connstring))
            {
                conn.Open();
                var query = @"UPDATE todotbl
                                 SET Complete = 'Y'
                               WHERE userIdx = @userIdx";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlParameter prmUserIdx = new SqlParameter("@userIdx", frm.UserIdx);
                cmd.Parameters.Add(prmUserIdx);

                var result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show(this, "전원 완료 처리 성공!", "저장", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("전원 완료 처리 실패!", "저장", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            RefreshData();
        }

        private void DgvIncomplete_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == 0 && e.RowIndex >= 0) // 체크박스 열의 인덱스를 확인하고, 유효한 행 인덱스인지 확인
            //{
            //    // 체크박스 상태 업데이트
            //    DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)DgvIncomplete.Rows[e.RowIndex].Cells[0];
            //    if (cell.Value != null)
            //    {
            //        cell.Value = !(bool)cell.Value; // 현재 값의 반대값으로 업데이트
            //        DgvIncomplete.RefreshEdit();
            //    }
            //}
        }
    }
}
