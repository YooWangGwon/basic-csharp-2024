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
    public partial class FrmUsers : Form
    {
        private bool isNew = false;

        public FrmUsers()
        {
            InitializeComponent();
        }
        private void FrmUsers_Load(object sender, EventArgs e)
        {
            RefreshData();
            InitInputData();
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
                MessageBox.Show("이름이 비어있습니다.\n일정 이름을 입력해주세요.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (TxtId.Text == string.Empty)
            {
                MessageBox.Show("아이디가 비어있습니다.\n아이디를 입력해주세요.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CboDepartment.SelectedIndex == -1)
            {
                MessageBox.Show("부서가 선택되어 있지 않습니다.\n부서를 선택해주세요.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (TxtPassword.Text == string.Empty)
            {
                MessageBox.Show("패스워드가 비어있습니다.\n패스워드를 입력해주세요.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        query = @"INSERT INTO [usertbl]
                               ([name]
                               ,[department]
                               ,[userId]
                               ,[password])
                               VALUES
                                    ( @name
                                    , @department
                                    , @userId
                                    , @password)";
                    }
                    else
                    {
                        query = @"UPDATE [usertbl]
                               SET [name] = @name
                                  ,[department] = @department
                                  ,[userId] = @userId
                                  ,[password] = @password
                             WHERE userIdx = @userIdx";
                    }

                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlParameter prmname = new SqlParameter("@name", TxtNames.Text);
                    cmd.Parameters.Add(prmname);
                    SqlParameter prmdepartment = new SqlParameter("@department", CboDepartment.SelectedValue);
                    cmd.Parameters.Add(prmdepartment);
                    SqlParameter prmId = new SqlParameter("@userId", TxtPassword.Text);
                    cmd.Parameters.Add(prmId);
                    SqlParameter prmPassword = new SqlParameter("@password", TxtPassword.Text);
                    cmd.Parameters.Add(prmPassword);

                    if (isNew != true)  // UPDATE일 경우
                    {
                        SqlParameter prmUserIdx = new SqlParameter("@userIdx", TxtUserIdx.Text);
                        cmd.Parameters.Add(prmUserIdx);
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
                var selData = DgvUsers.Rows[e.RowIndex]; // 내가 선택한 행 인덱스 값
                TxtUserIdx.Text = selData.Cells[0].Value.ToString();// 업무 번호
                TxtNames.Text = selData.Cells[1].Value.ToString();
                CboDepartment.SelectedValue = selData.Cells[2].Value.ToString();
                TxtId.Text = selData.Cells[3].Value.ToString();
                TxtPassword.Text = selData.Cells[4].Value.ToString();

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
                if (TxtUserIdx.Text == string.Empty) // 사용자 아이디 순번이 없으면
                {
                    MessageBox.Show(this, "삭제할 일정을 선택하세요", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var answer = MessageBox.Show(this, "정말 삭제하시겠습니까?", "삭제 여부", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (answer == DialogResult.No) return;

                using (SqlConnection conn = new SqlConnection(Helper.Common.Connstring))
                {
                    conn.Open();
                    var query = "DELETE FROM usertbl WHERE userIdx = @userIdx";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlParameter prmUserIdx = new SqlParameter("@userIdx", TxtUserIdx.Text);
                    cmd.Parameters.Add(prmUserIdx);

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
            InitInputData();
            BtnInitializer();
            TxtInitializer();
            isNew = false;
        }

        private void Activator()
        {
            TxtNames.ReadOnly = TxtId.ReadOnly = TxtPassword.ReadOnly = false;
            BtnNew.Enabled = BtnUpdate.Enabled = BtnDelete.Enabled = false;
            CboDepartment.Enabled = true;
        }
        private void RefreshData()
        {
            using (SqlConnection conn = new SqlConnection(schedule_app_2.Helper.Common.Connstring))
            {
                conn.Open();
                var query = @"SELECT [userIdx]
                                    ,[name]
                                    ,[department]
	                                ,d.depNames
                                    ,[userId]
                                    ,[password]
                                    ,[lastLoginDateTime]
                                FROM usertbl AS u
	                               , departmenttbl AS d
                               WHERE u.department = d.depIdx;";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "usertbl");    // ds에 usertbl 이름으로 값을 집어넣어줘 
                DgvUsers.DataSource = ds.Tables[0];
                DgvUsers.ReadOnly = true;  // 수정 불가
                DgvUsers.Columns[0].HeaderText = "번호";
                DgvUsers.Columns[1].HeaderText = "이름";
                DgvUsers.Columns[2].HeaderText = "부서번호";
                DgvUsers.Columns[3].HeaderText = "부서";
                DgvUsers.Columns[4].HeaderText = "아이디";
                DgvUsers.Columns[5].HeaderText = "패스워드";

                DgvUsers.Columns[2].Visible = false;
            }
        }   // DgvUsers 데이터 갱신용
        private void InitInputData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Helper.Common.Connstring))
                {
                    conn.Open();

                    var query = @"SELECT depIdx, depNames FROM departmenttbl";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    var temp = new Dictionary<string, string>();

                    while (reader.Read())
                    {
                        // reader[0] = depIdx 컬럼, reader[1] = depNames 컬럼
                        temp.Add(reader[0].ToString(), reader[1].ToString());
                    }
                    CboDepartment.DataSource = new BindingSource(temp, null);
                    CboDepartment.DisplayMember = "Value";    // 공포/스릴러
                    CboDepartment.ValueMember = "Key";        // B001
                    CboDepartment.SelectedIndex = -1;         // 콤보박스에 아무것도 선택 안된 상태
                    // CboDepartment.PromptText = "--구분명 선택--";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void BtnInitializer()
        {
            CboDepartment.SelectedIndex = -1;
            BtnUpdate.Enabled = BtnDelete.Enabled = BtnSave.Enabled = BtnCancel.Enabled = false;
            BtnNew.Enabled = true;
        }
        private void ContentInitial()
        {
            TxtNames.Text = TxtUserIdx.Text = TxtId.Text = TxtPassword.Text = string.Empty;
            CboDepartment.SelectedValue = -1;
        }
        private void TxtInitializer()
        {
            TxtNames.ReadOnly = TxtId.ReadOnly = TxtPassword.ReadOnly = true;
            CboDepartment.Enabled = false;
        }
    }
}
