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
        private int todoIdx = -1;
        private DateTime selection;

        public int UserIdx { get; set; }
        public string UserName { get; set; }
        public MainFrm()
        {
            InitializeComponent();
            Initializer1();
        }

        #region '이벤트 핸들러 영역'

        private void MainFrm_Load(object sender, EventArgs e)
        {
            FrmLogin frm = new FrmLogin(this);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.TopMost = true; // 가장 윈도우화면 상단에
            frm.ShowDialog();
            LblUserName.Text = UserName;
            TxtDate.Text = McrDate.TodayDate.ToString("yyyy년 MM월 dd일");
            RefreshData();
        }

        // 신규 버튼 클릭
        private void BtnNew_Click(object sender, EventArgs e)
        {
            isNew = true;
            TxtTodo.Text = TxtPlace.Text = TxtDetail.Text = string.Empty;
            Initializer2();
            TxtTodo.Focus();
        }

        // 수정 버튼 클릭
        private void BtnCorrection_Click(object sender, EventArgs e)
        {
            isNew = false;
            Initializer2();
            TxtTodo.Focus();
        }

        // 삭제 버튼 클릭
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (todoIdx == -1) // 사용자 아이디 순번이 없으면
            {
                MessageBox.Show(this, "삭제할 일정을 선택하세요", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var answer = MessageBox.Show(this, "정말 삭제하시겠습니까?", "삭제 여부", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.No) return;

            using (SqlConnection conn = new SqlConnection(schedule_app_2.Helper.Common.Connstring))
            {
                conn.Open();
                var query = "DELETE FROM todotbl WHERE TodoIdx = @TodoIdx";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlParameter prmTodoIdx = new SqlParameter("@TodoIdx", todoIdx);
                cmd.Parameters.Add(prmTodoIdx);

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
            todoIdx = -1;
            Initializer1();
            RefreshData();
        }

        // 취소 버튼 클릭 이벤트 핸들러
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Initializer1();
            isNew = false;
        }

        // 등록 버튼 클릭 이벤트 핸들러
        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(schedule_app_2.Helper.Common.Connstring))
            {
                conn.Open();

                var query = "";
                var division = "";
                if (TxtTodo.Text == string.Empty)
                {
                    MessageBox.Show("일정 내용이 비어있습니다.\n일정 내용을 입력해주세요.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (ChbPrivate.Checked) division = "Private";
                else if (ChbPublic.Checked) division = "Public";
                else
                {
                    MessageBox.Show("업무 구분을 체크해주세요.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (isNew) // INSERT 이면
                {
                    query = @"	INSERT INTO todotbl(
                                       userIdx
				                     , Todo 
			                         , StartDate 
			                         , EndDate 
			                         , Place 
			                         , Detail 
			                         , Division 
			                         , Complete )
		                        VALUES
			                         ( @userIdx
                                     , @Todo
			                         , @StartDate
			                         , @EndDate
			                         , @Place
			                         , @Detail
			                         , @Division
			                         , 'N')";
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
                             WHERE TodoIdx = @TodoIdx";
                }

                SqlCommand cmd = new SqlCommand(query, conn);

                SqlParameter prmTodo = new SqlParameter("@Todo", TxtTodo.Text);
                cmd.Parameters.Add(prmTodo);
                SqlParameter prmStartDate = new SqlParameter("@StartDate", DtpStart.Value);
                cmd.Parameters.Add(prmStartDate);
                SqlParameter prmEndDate = new SqlParameter("@EndDate", DtpEnd.Value);
                cmd.Parameters.Add(prmEndDate);
                SqlParameter prmPlace = new SqlParameter("@Place", TxtPlace.Text);
                cmd.Parameters.Add(prmPlace);
                SqlParameter prmDetail = new SqlParameter("@Detail", TxtDetail.Text);
                cmd.Parameters.Add(prmDetail);
                SqlParameter prmDivision = new SqlParameter("@Division", division);
                cmd.Parameters.Add(prmDivision);

                if (isNew == true)  // INSERT 일 경우
                {
                    SqlParameter prmUserIdx = new SqlParameter("@userIdx", UserIdx);
                    cmd.Parameters.Add(prmUserIdx);
                }
                else    // UPDATE
                {
                    SqlParameter prmTodoIdx = new SqlParameter("@TodoIdx", todoIdx);
                    cmd.Parameters.Add(prmTodoIdx);
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
            RefreshData();
            Initializer1();
            isNew = false;
        }

        // DgvTodo 행 클릭 이벤트 핸들러
        private void DgvTodo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)    // 아무것도 선택하지 않으면 -1
            {
                Initializer1();
                BtnComplete.Enabled = true;
                var selData = DgvTodo.Rows[e.RowIndex]; // 내가 선택한 인덱스 값
                todoIdx = (int)selData.Cells[0].Value;// 업무 번호
                // TxtMemberIdx.Text = selData.Cells[1].Value.ToString(); // 사용자 번호
                TxtTodo.Text = selData.Cells[2].Value.ToString();   // 업무 내용
                DtpStart.Value = DateTime.Parse(selData.Cells[3].Value.ToString());    // 시작일
                DtpEnd.Value = DateTime.Parse(selData.Cells[4].Value.ToString());    // 마감일
                TxtPlace.Text = selData.Cells[5].Value.ToString();    // 장소
                TxtDetail.Text = selData.Cells[6].Value.ToString();    // 상세 내용
                // 업무 구분
                if (selData.Cells[7].Value.ToString() == "Private")
                {
                    ChbPrivate.Checked = true;
                    ChbPublic.Checked = false;
                }
                else if (selData.Cells[7].Value.ToString() == "Public")
                {
                    ChbPrivate.Checked = false;
                    ChbPublic.Checked = true;
                }
                //TxtBookNames.Text = selData.Cells[7].Value.ToString();    // 완료 여부

                BtnDelete.Enabled = BtnCorrection.Enabled = true;
                ChbPrivate.Enabled = ChbPublic.Enabled = false;
                isNew = false; // UPDATE
            }
            else
            {
                return;
            }
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

        // 완료버튼 클릭
        private void BtnComplete_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(schedule_app_2.Helper.Common.Connstring))
            {
                conn.Open();
                var query = "UPDATE todotbl SET Complete = 'Y' WHERE todoIdx = @todoIdx";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlParameter prmUserIdx = new SqlParameter("@todoIdx", todoIdx);
                cmd.Parameters.Add(prmUserIdx);
                cmd.ExecuteNonQuery();
            }
            RefreshData();
            Initializer1();
        }
        private void MainFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var res = MessageBox.Show("종료하시겠습니까?", "종료여부", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                Environment.Exit(0);
            }
        }

        private void McrDate_DateChanged(object sender, DateRangeEventArgs e)
        {
            TxtDate.Text = McrDate.SelectionStart.ToString("yyyy년 MM월 dd일");
            DateTime selection = McrDate.SelectionStart;
            RefreshData();
        }

        private void MnuUsers_Click(object sender, EventArgs e)
        {
            FrmUsers frm = new FrmUsers();
            frm.ShowDialog();
        }
        #endregion


        #region '메서드 영역'

        private void Initializer1() // 초기화용 메서드
        {
            DtpEnd.Enabled = DtpStart.Enabled = false;
            TxtTodo.Text = TxtPlace.Text = TxtDetail.Text = string.Empty;
            BtnNew.Enabled = BtnCorrection.Enabled = true;
            BtnCancel.Enabled = BtnConfirm.Enabled = BtnComplete.Enabled = BtnDelete.Enabled = BtnCorrection.Enabled = false;
            TxtTodo.ReadOnly = TxtPlace.ReadOnly = TxtDetail.ReadOnly = true;
            ChbPrivate.Checked = ChbPublic.Checked = false;


        }
        private void RefreshData()
        {
            selection = McrDate.SelectionStart;

            using (SqlConnection conn = new SqlConnection(schedule_app_2.Helper.Common.Connstring))
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
                               WHERE StartDate <= @Date
                                 AND EndDate >= @Date
                                 AND userIdx = @userIdx
                                 AND Division = 'Private'
                               UNION 
                              SELECT TodoIdx
                                   , userIdx
                                   , Todo
                                   , StartDate
                                   , EndDate
                                   , Place
                                   , Detail
                                   , Division
                                   , Complete
                                FROM todotbl
                               WHERE StartDate <= @Date
                                 AND EndDate >= @Date
                                 AND Division = 'Public'";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlParameter prmDate = new SqlParameter("@Date", selection);
                cmd.Parameters.Add(prmDate);
                SqlParameter prmUserIdx = new SqlParameter("@userIdx", UserIdx);
                cmd.Parameters.Add(prmUserIdx);

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand = cmd;
                DataSet ds = new DataSet();
                adapter.Fill(ds, "todotbl");    // ds에 usertbl 이름으로 값을 집어넣어줘 
                DgvTodo.DataSource = ds.Tables[0];
                DgvTodo.ReadOnly = true;  // 수정 불가
                DgvTodo.Columns[0].HeaderText = "업무 번호";
                DgvTodo.Columns[1].HeaderText = "사용자 번호";
                DgvTodo.Columns[2].HeaderText = "내용";
                DgvTodo.Columns[3].HeaderText = "시작일";
                DgvTodo.Columns[4].HeaderText = "마감일";
                DgvTodo.Columns[5].HeaderText = "장소";
                DgvTodo.Columns[6].HeaderText = "상세내용";
                DgvTodo.Columns[7].HeaderText = "구분";
                DgvTodo.Columns[8].HeaderText = "완료여부";

                DgvTodo.Columns[0].Visible = false;
                DgvTodo.Columns[1].Visible = false;
                DgvTodo.Columns[2].Width = 80;
                DgvTodo.Columns[3].Visible = false;
                DgvTodo.Columns[4].Visible = false;
                DgvTodo.Columns[5].Visible = false;
                DgvTodo.Columns[6].Visible = false;
                DgvTodo.Columns[7].Width = 80;
                DgvTodo.Columns[8].Width = 80;
            }
        }   // DgvTodo 데이터 갱신용
        private void Initializer2() // 신규/수정용 초기화 함수 
        {
            TxtTodo.ReadOnly = TxtPlace.ReadOnly = TxtDetail.ReadOnly = false;
            BtnNew.Enabled = BtnCorrection.Enabled = BtnDelete.Enabled = BtnComplete.Enabled = false;
            DtpEnd.Enabled = DtpStart.Enabled = true;
            BtnCancel.Enabled = BtnConfirm.Enabled = true;
        }
        #endregion


        private void MnuDepartment_Click(object sender, EventArgs e)
        {
            FrmDepartment frm = new FrmDepartment();
            frm.ShowDialog();
        }
    }
}
