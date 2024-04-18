using System.Data;
using System.Timers;

namespace schedule_app
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
        }
        #region '메서드 영역'
        #endregion

        #region '이벤트 핸들러 영역'

        private void BtnNew_Click(object sender, EventArgs e)
        {
            NewTodo sub1 = new NewTodo(this);
            sub1.Show();
            BtnNew.Enabled = BtnCorrection.Enabled = BtnDelete.Enabled = BtnShowUndo.Enabled = false;

        }

        private void BtnCorrection_Click(object sender, EventArgs e)
        {
            UpdateTodo sub1 = new UpdateTodo(this);
            sub1.Show();
            BtnNew.Enabled = BtnCorrection.Enabled = BtnDelete.Enabled = BtnShowUndo.Enabled = false;
        }

        private void FrmMain_DateSelected(object sender, DateRangeEventArgs e)
        {
            //ClbTodo.Items.Add();
        }

        #endregion
    }
    public class TodoInfo
    {
        public TodoInfo(string todo, string date, string endTime, string startTime, string place, string detail)
        {
            Todo = todo;
            Date = date;
            EndTime = endTime;
            StartTime = startTime;
            Place = place;
            Detail = detail;
        }

        public string Todo { get; set; }
        public string Date { get; set; }
        public string EndTime { get; set; }
        public string StartTime { get; set; }
        public string? Place { get; set; }
        public string? Detail { get; set; }
    }
}
