using System.Data;
using System.Timers;
using System.Windows.Forms;

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

        private void FrmMain_DateSelected(object sender, DateRangeEventArgs e)
        {
            //ClbTodo.Items.Add();
        }
        private void BtnNew_Click(object sender, EventArgs e)
        {
            string startTime = CboStartHour.Text + CboStartMin.Text;
            string endTime = CboEndHour.Text + CboEndMin.Text;
            if (ChbPrivate.Checked)
            {
                TodoInfo todo = new TodoInfo(TxtTodo.Text, Dtp.Text, startTime, endTime, TxtPlace.Text, TxtTodo.Text, "Private");
            }
            else if (ChbPublic.Checked) 
            {
                TodoInfo todo = new TodoInfo(TxtTodo.Text, Dtp.Text, startTime, endTime, TxtPlace.Text, TxtTodo.Text, "Public");
            }

            MessageBox.Show($"{TxtTodo.Text}, {Dtp.Text}, {startTime}, {endTime}, {TxtPlace.Text}, {TxtDetail.Text}");
            BtnNew.Enabled = BtnCorrection.Enabled = BtnDelete.Enabled = BtnShowUndo.Enabled = true;
        }
        private void MainFrm_Load(object sender, EventArgs e)
        {
            
            CboStartHour.SelectedIndex = CboStartMin.SelectedIndex = CboEndHour.SelectedIndex = CboEndMin.SelectedIndex = 0;
            BtnConfirm.Enabled = BtnCancel.Enabled = false;
            
        }

        #endregion

    }
    public class TodoInfo
    {
        public TodoInfo(string todo, string date, string endTime, string startTime, string place, string detail, string classification)
        {
            Todo = todo;
            Date = date;
            EndTime = endTime;
            StartTime = startTime;
            Place = place;
            Detail = detail;
            Classification = classification;
        }

        public string Todo { get; set; }
        public string Date { get; set; }
        public string EndTime { get; set; }
        public string StartTime { get; set; }
        public string? Place { get; set; }
        public string? Detail { get; set; }
        public string Classification { get; set;}
    }
}
