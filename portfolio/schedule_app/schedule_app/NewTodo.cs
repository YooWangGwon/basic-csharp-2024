using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace schedule_app
{
    public partial class NewTodo : Form
    {
        MainFrm frm;
        public NewTodo()
        {
            InitializeComponent();
        }
        public NewTodo(MainFrm mainFrm)
        {
            InitializeComponent();
            frm = mainFrm;
            CboStartHour.SelectedIndex = CboStartMin.SelectedIndex = CboEndHour.SelectedIndex = CboEndMin.SelectedIndex = 0;
        }
        // 확인 버튼 클릭 이벤트 핸들러
        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            string startTime = CboStartHour.Text + CboStartMin.Text;
            string endTime = CboEndHour.Text + CboEndMin.Text;

            MessageBox.Show($"{TxtTodo.Text}, {Dtp.Text}, {startTime}, {endTime}, {TxtPlace.Text}, {TxtDetail.Text}");

            //TodoInfo newTodo = new TodoInfo(TxtTodo.Text, Dtp.Text, startTime, endTime, TxtPlace.Text, TxtDetail.Text);

            frm.BtnNew.Enabled = frm.BtnCorrection.Enabled = frm.BtnDelete.Enabled = frm.BtnShowUndo.Enabled = true;
            Close();
        }

        // 등록 버튼 클릭 이벤트 핸들러
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            frm.BtnNew.Enabled = frm.BtnCorrection.Enabled = frm.BtnDelete.Enabled = frm.BtnShowUndo.Enabled = true;
            Close();
        }
    }
}
