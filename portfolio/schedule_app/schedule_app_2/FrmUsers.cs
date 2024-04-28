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
        public FrmUsers()
        {
            InitializeComponent();
        }
        private void FrmUsers_Load(object sender, EventArgs e)
        {
            RefreshData();
            InitInputData();
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

        private void BtnNew_Click(object sender, EventArgs e)
        {
            TxtNames.Text = string.Empty;
        }

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
    }
}
