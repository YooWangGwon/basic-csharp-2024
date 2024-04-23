using schedule_app_2;
using System.Data;
using System.Data.SqlClient;
using System.Timers;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace schedule_app
{
    public partial class MainFrm : Form
    {
        private bool isNew = false;
        private string complete;
        private int todoIdx;
        public MainFrm()
        {
            InitializeComponent();
            Initializer1();
        }
        #region '메서드 영역'
        private void Initializer1() // 초기화용 메서드
        {
            DtpEnd.Enabled = DtpStart.Enabled = false;
            TxtTodo.Text = TxtPlace.Text = TxtDetail.Text = string.Empty;
            BtnNew.Enabled = BtnCorrection.Enabled = BtnDelete.Enabled = true;
            BtnCancel.Enabled = BtnConfirm.Enabled = false;
            TxtTodo.ReadOnly = TxtPlace.ReadOnly = TxtDetail.ReadOnly = true;
            ChbPrivate.Checked = ChbPublic.Checked = false;
        }

        private void RefreshData()
        {
            using (SqlConnection conn = new SqlConnection(schedule_app_2.Helper.Common.Connstring))
            {
                conn.Open();
                var query = @"SELECT  userIdx
                                  , TodoIdx
                                  , Todo
                                  , StartDate
                                  , EndDate
                                  , Place
                                  , Detail
                                  , Division
                                  , Complete
                              FROM todotbl";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                var temp = new Dictionary<string, string>();

                while(reader.Read())
                {
                    temp.Add(reader[1].ToString(), reader[2].ToString());
                }
                ClbTodo.DataSource = new BindingSource(temp, null);
                ClbTodo.
            }
        }
        #endregion

        #region '이벤트 핸들러 영역'

        private void MainFrm_Load(object sender, EventArgs e)
        {
            FrmLogin frm = new FrmLogin(this);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.TopMost = true; // 가장 윈도우화면 상단에
            frm.ShowDialog();
        }
        private void FrmMain_DateSelected(object sender, DateRangeEventArgs e)
        {
            //ClbTodo.Items.Add();
        }
        private void BtnNew_Click(object sender, EventArgs e)
        {
            isNew = true;
            TxtTodo.Text = TxtPlace.Text = TxtDetail.Text = string.Empty;
            TxtTodo.ReadOnly = TxtPlace.ReadOnly = TxtDetail.ReadOnly = false;
            BtnNew.Enabled = BtnCorrection.Enabled = BtnDelete.Enabled = false;
            BtnCancel.Enabled = BtnConfirm.Enabled = true;
        }
        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            if (isNew == true)
            {
                if (ChbPrivate.Checked)
                {
                    //TodoInfo todo = new TodoInfo(TxtTodo.Text, Dtp.Text, startTime, endTime, TxtPlace.Text, TxtTodo.Text, "Private");
                }
                else if (ChbPublic.Checked)
                {
                    //TodoInfo todo = new TodoInfo(TxtTodo.Text, Dtp.Text, startTime, endTime, TxtPlace.Text, TxtTodo.Text, "Public");
                }
                MessageBox.Show($"{TxtTodo.Text}, {DtpStart.Text}, {DtpEnd.Text}, {TxtPlace.Text}, {TxtDetail.Text}");
            }

            using (SqlConnection conn = new SqlConnection(schedule_app_2.Helper.Common.Connstring))
            {
                conn.Open();

                var query = "";
                if (isNew) // INSERT 이면
                {
                    query = @"	INSERT INTO todotbl(
				                       Todo 
			                         , StartDate 
			                         , EndDate 
			                         , Place 
			                         , Detail 
			                         , Division 
			                         , Complete )
		                        VALUES
			                         ( @Todo
			                         , @StartDate
			                         , @EndDate
			                         , @Place
			                         , @Detail
			                         , @Division
			                         , @Complete)";
                                    }
                else // UPDATE이면
                {
                    query = @"UPDATE todotbl
                               SET Todo = @Todo
                                  ,StartDate = @StartDate
                                  ,EndDate = @EndDate
                                  ,Place = @Place
                                  ,Detail = @Detail
                                  ,Division = @Division
                                  ,Complete = @Complete
                             WHERE TodoIdx = @TodoIdx";
                }

                SqlCommand cmd = new SqlCommand(query, conn);



                SqlParameter prmPrice = new SqlParameter("","");
                cmd.Parameters.Add("");

                if (isNew != true)  // UPDATE일 경우
                {
                    SqlParameter prmTodoIdx = new SqlParameter("@bookIdx", todoIdx);
                    cmd.Parameters.Add(prmTodoIdx);
                }

                var result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    // this : 메시지 박스의 부모창이 누구인가? -> FrmLoginUser
                    MessageBox.Show(this, "저장성공!", "저장", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //MessageBox.Show("저장 성공","저장", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("저장 실패!", "저장", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            Initializer1();
        }
        // 개인 업무 체크박스 클릭
        private void ChbPrivate_Click(object sender, EventArgs e)
        {
            ChbPublic.Checked = false;
            ChbPrivate.Checked = true;
        }

        // 공통 업무 체크박스 클릭
        private void ChbPublic_Click(object sender, EventArgs e)
        {
            ChbPublic.Checked = true;
            ChbPrivate.Checked = false;
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Initializer1();
            isNew = false;
    }
        #endregion



    }
}
