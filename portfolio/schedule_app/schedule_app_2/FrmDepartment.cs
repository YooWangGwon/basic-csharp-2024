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

namespace schedule_app_2
{
    public partial class FrmDepartment : Form
    {
        private bool isNew = false;

        public FrmDepartment()
        {
            InitializeComponent();
        }
        private void FrmUsers_Load(object sender, EventArgs e)
        {
            RefreshData();
            BtnInitializer();
            TxtInitializer();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            isNew = true;
            Activator();
            ContentInitial();

            BtnSave.Enabled = BtnCancel.Enabled = true;
        }
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            Activator();
            BtnSave.Enabled = BtnCancel.Enabled = true;
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (TxtNames.Text == string.Empty)
            {
                MessageBox.Show("부서명이 비어있습니다.\n부서명을 입력해주세요.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {

                using (SqlConnection conn = new SqlConnection(Helper.Common.Connstring))
                {
                    var query = "";
                    conn.Open();

                    if (isNew == true)
                    {
                        query = @"INSERT INTO departmenttbl
                                         (depNames)
                                  VALUES
                                         (@depNames)";
                    }
                    else
                    {
                        query = @"UPDATE departmenttbl
                               SET [depNames] = @depNames
                             WHERE depIdx = @depIdx";
                    }

                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlParameter prmname = new SqlParameter("@depNames", TxtNames.Text);
                    cmd.Parameters.Add(prmname);
                    

                    if (isNew != true)  // UPDATE일 경우
                    {
                        SqlParameter prmDepIdx = new SqlParameter("@depIdx", TxtDepIdx.Text);
                        cmd.Parameters.Add(prmDepIdx);
                    }

                    var result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show(this, "저장성공!", "저장", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("저장 실패!", "저장", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            RefreshData();
            TxtInitializer();
            BtnInitializer();
            ContentInitial();
            isNew = false;
        }
        private void DgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)    // 아무것도 선택하지 않으면 -1
            {
                var selData = DgvDepartment.Rows[e.RowIndex]; // 내가 선택한 행 인덱스 값
                TxtDepIdx.Text = selData.Cells[0].Value.ToString();// 업무 번호
                TxtNames.Text = selData.Cells[1].Value.ToString();
                BtnNew.Enabled = BtnUpdate.Enabled = BtnDelete.Enabled = true;
            }
            else
            {
                return;
            }
        }



        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtDepIdx.Text == string.Empty) // 사용자 아이디 순번이 없으면
                {
                    MessageBox.Show(this, "삭제할 일정을 선택하세요", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var answer = MessageBox.Show(this, "정말 삭제하시겠습니까?", "삭제 여부", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (answer == DialogResult.No) return;

                using (SqlConnection conn = new SqlConnection(Helper.Common.Connstring))
                {
                    conn.Open();
                    var query = "DELETE FROM departmenttbl WHERE depIdx = @depIdx";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlParameter prmDepIdx = new SqlParameter("@depIdx", TxtDepIdx.Text);
                    cmd.Parameters.Add(prmDepIdx);

                    var result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show(this, "삭제 성공", "삭제", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(this, "삭제 실패!", "삭제", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                BtnInitializer();
                ContentInitial();
                TxtInitializer();
                RefreshData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            RefreshData();
            BtnInitializer();
            TxtInitializer();
            isNew = false;
        }

        private void Activator()
        {
            TxtNames.ReadOnly = false;
            BtnNew.Enabled = BtnUpdate.Enabled = BtnDelete.Enabled = false;
        }
        private void RefreshData()
        {
            using (SqlConnection conn = new SqlConnection(schedule_app_2.Helper.Common.Connstring))
            {
                conn.Open();
                var query = @"SELECT [depIdx]
                                   , [depNames]
                                FROM [departmenttbl]";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "departmenttbl");    // ds에 usertbl 이름으로 값을 집어넣어줘 
                DgvDepartment.DataSource = ds.Tables[0];
                DgvDepartment.ReadOnly = true;  // 수정 불가
                DgvDepartment.Columns[0].HeaderText = "부서번호";
                DgvDepartment.Columns[1].HeaderText = "부서명";

                DgvDepartment.Columns[0].Width = 80;
                DgvDepartment.Columns[1].Width = 90;
            }
        }   // DgvUsers 데이터 갱신용
       
        private void BtnInitializer()
        {
            BtnUpdate.Enabled = BtnDelete.Enabled = BtnSave.Enabled = BtnCancel.Enabled = false;
            BtnNew.Enabled = true;
        }
        private void ContentInitial()
        {
            TxtNames.Text = TxtDepIdx.Text = string.Empty;
        }
        private void TxtInitializer()
        {
            TxtNames.ReadOnly = true;
        }
    }
}
