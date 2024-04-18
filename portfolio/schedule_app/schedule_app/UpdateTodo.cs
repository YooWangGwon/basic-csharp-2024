using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace schedule_app
{
    public partial class UpdateTodo : Form
    {
        MainFrm frm1;
        public UpdateTodo()
        {
            InitializeComponent();
        }
        public UpdateTodo(MainFrm mainFrm)
        {
            InitializeComponent();
            frm1 = mainFrm;
            CboStartHour.SelectedIndex = CboStartMin.SelectedIndex = CboEndHour.SelectedIndex = CboEndMin.SelectedIndex = 0;
        }
        // 확인 버튼 클릭 이벤트 핸들러
        private void BtnConfirm_Click(object sender, EventArgs e)
        {

            frm1.BtnNew.Enabled = frm1.BtnCorrection.Enabled = frm1.BtnDelete.Enabled = frm1.BtnShowUndo.Enabled = true;
            Close();
        }

        // 등록 버튼 클릭 이벤트 핸들러
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            frm1.BtnNew.Enabled = frm1.BtnCorrection.Enabled = frm1.BtnDelete.Enabled = frm1.BtnShowUndo.Enabled = true;
            Close();
        }
    }
}
