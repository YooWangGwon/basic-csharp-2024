using System.ComponentModel;
using System.Threading; // ������ ���
namespace ex18_winControlApp
{
    public partial class FrmMain : Form
    {
        Random rand = new Random(); // Ʈ���� ����̸����� ����� ������
        public FrmMain()
        {
            InitializeComponent();  // �����̳ʿ��� ������ ȭ�鱸�� �ʱ�ȭ

            LsvDummy.Columns.Add("�̸�");
            LsvDummy.Columns.Add("����");

            GrbEditor.Text = "�ؽ�Ʈ������";  // �ڵ� �����ε� ������ ����
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            var Fonts = FontFamily.Families; // ���� OS ���� ��ġ�� Font�� �� ������
            foreach (var font in Fonts)
            {
                CboFonts.Items.Add(font.Name);
            }
        }
        // ����ü, ����, ���Ÿ����� �����ϴ� �޼���
        void ChangeFont()
        {
            if (CboFonts.SelectedIndex < 0) // Font ��Ͽ��� �ƹ��͵� ���� ������ ���(���� -1�̴�)
                return;

            FontStyle style = FontStyle.Regular;    // �Ϲ� ����(����X, ���Ÿ�X)

            if (ChkBold.Checked)    // '����'��� üũ�ڽ��� üũ�� ���
                style |= FontStyle.Bold;    // |:�������� �Ӽ����� ������ �� ���

            if (ChkItalic.Checked)  // ���Ÿ� üũ�ڽ��� üũ�ϸ�
                style |= FontStyle.Italic;

            TxtSampleText.Font = new Font((string)CboFonts.SelectedItem, 12, style);
        }

        void TreeToList()
        {
            LsvDummy.Items.Clear();
            foreach (TreeNode node in TrvDummy.Nodes)
            {
                TreeToList(node);   // �����ε�
            }
        }

        private void TreeToList(TreeNode node)
        {
            //throw new NotImplementedException();
            LsvDummy.Items.Add( // ����Ʈ�信 ������ �߰�
                new ListViewItem(
                    new string[] { node.Text, node.FullPath.Count(f => f == '\\').ToString() }
                    )
                );
            foreach (TreeNode subNode in node.Nodes)
            {
                TreeToList(subNode);
            }
        }

        private void CboFonts_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeFont();
        }

        private void ChkBold_CheckedChanged(object sender, EventArgs e)
        {
            ChangeFont();
        }

        private void ChkItalic_CheckedChanged(object sender, EventArgs e)
        {
            ChangeFont();
        }
        // Ʈ���� ��ũ�� �̺�Ʈ �ڵ鷯
        private void TrbDummy_Scroll(object sender, EventArgs e)
        {
            PrgDummy.Value = TrbDummy.Value;    // Ʈ���� �����͸� �ű�� ���α׷����� ���� ���� ����
        }

        private void BtnModal_Click(object sender, EventArgs e)
        {
            Form FrmModal = new Form();
            FrmModal.Text = "���â";
            FrmModal.Width = 300;
            FrmModal.Height = 100;
            FrmModal.BackColor = Color.Red;
            // ���â�� ������� ��ġ�� �θ�â�� �߾����� ����
            FrmModal.StartPosition = FormStartPosition.CenterParent;
            FrmModal.ShowDialog();  // ���â ����

        }

        private void BtnModaless_Click(object sender, EventArgs e)
        {
            Form FrmModaless = new Form();
            FrmModaless.Text = "��޸���â";
            FrmModaless.Width = 300;
            FrmModaless.Height = 100;
            FrmModaless.BackColor = Color.Green;
            // ��޸���â�� �θ� �� �߾ӿ� ��ġ�� ���� �Ʒ��� ���� �۾��ؾ� ��.
            FrmModaless.StartPosition = FormStartPosition.Manual;
            FrmModaless.Location = new Point(this.Location.X + (this.Width - FrmModaless.Width) / 2, // ���� ��ġ���� 
                                           this.Location.Y + (this.Height - FrmModaless.Height) / 2);
            FrmModaless.Show(this);  // ��޸���â ����
        }

        private void BtnMsgBox_Click(object sender, EventArgs e)
        {
            MessageBox.Show(TxtSampleText.Text, "�޽��� �ڽ�", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void BtnQuestion_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("���ƿ�?", "����", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                MessageBox.Show("�� ���ƿ�!");
            }
            else if (res == DialogResult.No)
            {
                MessageBox.Show("�ƴϿ� ���� �Ⱦ��!!");
            }
        }
        // ������ ���� ��ư�� Ŭ������ �� �߻��ϴ� �̺�Ʈ �ڵ鷯
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            var res = MessageBox.Show("���� �����Ͻðڽ��ϱ�?", "���Ῡ��", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No) e.Cancel = true;    // ���� ���
        }

        private void BtnAddRoot_Click(object sender, EventArgs e)
        {
            TrvDummy.Nodes.Add(rand.Next().ToString());
            TreeToList();
        }

        private void BtnAddChild_Click(object sender, EventArgs e)
        {
            if (TrvDummy.SelectedNode == null)
            {    // �θ��带 �������� ������
                MessageBox.Show("������ ��尡 ����", "�θ��� �̼���", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // ���̻� ������� �޼��� ����
            }
            TrvDummy.SelectedNode.Nodes.Add(rand.Next().ToString());
            TrvDummy.SelectedNode.Expand();
            TreeToList();   // ����Ʈ�並 �ٽ� �׷��ش�
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            DlgOpenImage.Title = "�̹��� ����";
            // Ȯ���ڸ� �̹����θ� �����ϱ� ����
            DlgOpenImage.Filter = "Image Files(*.bmp; *.jpg; *.png)|*.bmp; *.jpg; *.png";
            // | �տ��Ŵ� Ž���⿡���� ����, | �ڴ� ���������� ���͸��� Ȯ���ڸ�
            var res = DlgOpenImage.ShowDialog(this);
            if (res == DialogResult.OK)
            {
                // MessageBox.Show(DlgOpenImage.FileName.ToString());
                PicNormal.Image = Bitmap.FromFile(DlgOpenImage.FileName);
            }
        }
        // �̹��� Ŭ�� �� �߻��ϴ� �̺�Ʈ �ڵ鷯 
        private void PicNormal_Click_1(object sender, EventArgs e)
        {
            if (PicNormal.SizeMode == PictureBoxSizeMode.Normal)    // �ҷ��� �̹����� ũ�Ⱑ Picture Box���� Ŭ ���
                PicNormal.SizeMode = PictureBoxSizeMode.StretchImage;   // �̹����� ũ�⸦ ������
            else                                                    // �̹����� ũ�Ⱑ Picture�ڽ��� ũ�⺸�� ũ�� ���� ���
                PicNormal.SizeMode = PictureBoxSizeMode.Normal;     // �̹����� ������ܿ� ��ġ��
        }

        // �ؽ�Ʈ ���� �ε� �̺�Ʈ �ڵ鷯
        private void BtnFileLoad_Click(object sender, EventArgs e)
        {
            // OpenFielDialog ��Ʈ���� �����ο��� �������� �ʰ� �����ϴ� ���
            // �ؽ�Ʈ ���� �ε� ��ȭ���� ����
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false; // 2�� �̻��� ���� ������ ����, �⺻������ Dialog�� Multiselect�� false�̴�.
            dialog.Filter = "Text Files(*.txt; *.cs; *.py)|*.txt; *.cs; *.py";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // UTF-8���� �ѱ��� ����. EUC-KR(Window 949), UTF-8(BOM) �� �ѱ��� ���� ����
                // ������ ���Ͽ��� RichTextBox�� ���� �ε�
                RtxEditor.LoadFile(dialog.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        // �ؽ�Ʈ ���� ���� ��ư Ŭ�� �� �߻��ϴ� �̺�Ʈ �ڵ鷯
        private void BtnFileSave_Click(object sender, EventArgs e)
        {
            // �ؽ�Ʈ ���� ���� ��ȭ���� ����
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "RichText Files(*.rtf)|*.rtf";
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                // RichTextBox ������ ������ ���Ϸ� ����
                RtxEditor.SaveFile(dialog.FileName, RichTextBoxStreamType.RichNoOleObjs);
            }
        }

        private void BtnNoThread_Click(object sender, EventArgs e)
        {
            var maxValue = 100;
            var currValue = 0;
            PrgProcess.Minimum = 0;
            PrgProcess.Maximum = maxValue;
            PrgProcess.Value = 0;   // ���α׷��� �� ��ġ�� 0���� �ʱ�ȭ

            BtnThread.Enabled = false;      // ������ ��ư�� ����� ����
            BtnNoThread.Enabled = false;    // �뽺���� ��ư�� ����� ����
            BtnStop.Enabled = true;         // ��ž��ư�� ��� �����ϰ� ��(�⺻���� false)
            // �ݺ�����
            for (var i = 0; i <= maxValue; i++)
            {
                // ���������� �����ϰ� �ð��� ���� ���ϴ� �۾�
                currValue = i;
                TxtLog.AppendText($"�������� : {currValue}\r\n"); // ������� \r\n, ������, Mac \n, ��Ų��� \r
                PrgProcess.Value = currValue;
                Thread.Sleep(500);  // 1000ms = 1��, 500ms = 0.5�� 
            }
            // �۾��� �Ϸ�� ����
            BtnThread.Enabled = true;
            BtnNoThread.Enabled = true;
            BtnStop.Enabled = false;
        }

        private void BtnThread_Click(object sender, EventArgs e)
        {
            var maxValue = 100;
            PrgProcess.Minimum = 0;
            PrgProcess.Maximum = maxValue;
            PrgProcess.Value = 0;   // ���α׷��� �� ��ġ�� 0���� �ʱ�ȭ

            BtnThread.Enabled = BtnNoThread.Enabled = false;
            BtnStop.Enabled = true;


            BgwProgress.WorkerReportsProgress = true;       // ���� ���� ����Ʈ Ȱ��ȭ
            BgwProgress.WorkerSupportsCancellation = true;  // ��׶����Ŀ ��� Ȱ��ȭ
            BgwProgress.RunWorkerAsync(null);   // ��׶��� ��Ŀ ����
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            BgwProgress.CancelAsync();  // �񵿱�� ��� ����!
        }

        #region '��׶����Ŀ �̺�Ʈ �ڵ鷯'
        private void DoRealWork(BackgroundWorker worker, DoWorkEventArgs e)
        {
            var maxValue = 100;
            double currValue = 0;   // �Ǽ������� ����
            for (var i = 0; i <= maxValue; i++)
            {
                if (worker.CancellationPending) // �߰��� ����Ұ��� ����� ��
                {
                    e.Cancel = true;
                    break;
                }
                else {
                    currValue = i;
                    // �����ð��� �ɸ��� ��ó��
                    Thread.Sleep(500);  // 1000ms = 1��, 500ms = 0.5�� 

                    // �Ʒ��� �����ϸ�,BgwProgress_ProgressChanged �̺�Ʈ �ڵ鷯��
                    // ProgressChangedEventArgs���� ProgressPercantage �Ӽ��� ���� ��
                    worker.ReportProgress((int)((currValue / maxValue) * 100));
                }
            }
        }


        // ���� ����
        private void BgwProgress_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            DoRealWork((BackgroundWorker)sender, e); // �ڽ̵� ��ü�� ��ڽ�
            e.Result = null;
        }
        // ������� �ٲ�� �� ǥ��
        private void BgwProgress_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            PrgProcess.Value = e.ProgressPercentage;    // DoRealWork���� ���޹��� ������ PrgProcess�� Value�� �������
            TxtLog.AppendText($"����� : {PrgProcess.Value}%\r\n");
        }
        // ������ �Ϸ�Ǹ� �� ������ ó��
        private void BgwProgress_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if(e.Cancelled)
            {
                TxtLog.AppendText("�۾��� ��ҵǾ����ϴ�.\r\n");
            }
            else
            {
                TxtLog.AppendText("�۾��� �Ϸ�Ǿ����ϴ�.\r\n");
            }
            BtnNoThread.Enabled = BtnThread.Enabled = true;
            BtnStop.Enabled = false;
        }
        #endregion
    }
}
