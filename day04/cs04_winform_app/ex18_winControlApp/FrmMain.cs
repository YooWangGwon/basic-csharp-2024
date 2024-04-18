using System.ComponentModel;
using System.Threading; // 스레드 사용
namespace ex18_winControlApp
{
    public partial class FrmMain : Form
    {
        Random rand = new Random(); // 트리뷰 노드이름으로 사용할 랜덤값
        public FrmMain()
        {
            InitializeComponent();  // 디자이너에서 정의한 화면구성 초기화

            LsvDummy.Columns.Add("이름");
            LsvDummy.Columns.Add("깊이");

            GrbEditor.Text = "텍스트에디터";  // 코드 비하인드 디자인 세팅
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            var Fonts = FontFamily.Families; // 현재 OS 내에 설치된 Font를 다 가져와
            foreach (var font in Fonts)
            {
                CboFonts.Items.Add(font.Name);
            }
        }
        // 글자체, 볼드, 이탤릭으로 변경하는 메서드
        void ChangeFont()
        {
            if (CboFonts.SelectedIndex < 0) // Font 목록에서 아무것도 선택 안했을 경우(보통 -1이다)
                return;

            FontStyle style = FontStyle.Regular;    // 일반 글자(볼드X, 이탤릭X)

            if (ChkBold.Checked)    // '굵게'라는 체크박스를 체크할 경우
                style |= FontStyle.Bold;    // |:여러가지 속성들을 접목할 때 사용

            if (ChkItalic.Checked)  // 이탤릭 체크박스를 체크하면
                style |= FontStyle.Italic;

            TxtSampleText.Font = new Font((string)CboFonts.SelectedItem, 12, style);
        }

        void TreeToList()
        {
            LsvDummy.Items.Clear();
            foreach (TreeNode node in TrvDummy.Nodes)
            {
                TreeToList(node);   // 오버로딩
            }
        }

        private void TreeToList(TreeNode node)
        {
            //throw new NotImplementedException();
            LsvDummy.Items.Add( // 리스트뷰에 아이템 추가
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
        // 트랙바 스크롤 이벤트 핸들러
        private void TrbDummy_Scroll(object sender, EventArgs e)
        {
            PrgDummy.Value = TrbDummy.Value;    // 트랙바 포인터를 옮기면 프로그레스바 값도 같이 변경
        }

        private void BtnModal_Click(object sender, EventArgs e)
        {
            Form FrmModal = new Form();
            FrmModal.Text = "모달창";
            FrmModal.Width = 300;
            FrmModal.Height = 100;
            FrmModal.BackColor = Color.Red;
            // 모달창이 띄어지는 위치를 부모창의 중앙으로 설정
            FrmModal.StartPosition = FormStartPosition.CenterParent;
            FrmModal.ShowDialog();  // 모달창 띄우기

        }

        private void BtnModaless_Click(object sender, EventArgs e)
        {
            Form FrmModaless = new Form();
            FrmModaless.Text = "모달리스창";
            FrmModaless.Width = 300;
            FrmModaless.Height = 100;
            FrmModaless.BackColor = Color.Green;
            // 모달리스창을 부모 정 중앙에 위치할 때는 아래와 같이 작업해야 함.
            FrmModaless.StartPosition = FormStartPosition.Manual;
            FrmModaless.Location = new Point(this.Location.X + (this.Width - FrmModaless.Width) / 2, // 나의 위치값에 
                                           this.Location.Y + (this.Height - FrmModaless.Height) / 2);
            FrmModaless.Show(this);  // 모달리스창 띄우기
        }

        private void BtnMsgBox_Click(object sender, EventArgs e)
        {
            MessageBox.Show(TxtSampleText.Text, "메시지 박스", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void BtnQuestion_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("좋아요?", "질문", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                MessageBox.Show("네 좋아요!");
            }
            else if (res == DialogResult.No)
            {
                MessageBox.Show("아니요 정말 싫어요!!");
            }
        }
        // 윈도우 종료 버튼을 클릭했을 때 발생하는 이벤트 핸들러
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            var res = MessageBox.Show("정말 종료하시겠습니까?", "종료여부", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No) e.Cancel = true;    // 종료 취소
        }

        private void BtnAddRoot_Click(object sender, EventArgs e)
        {
            TrvDummy.Nodes.Add(rand.Next().ToString());
            TreeToList();
        }

        private void BtnAddChild_Click(object sender, EventArgs e)
        {
            if (TrvDummy.SelectedNode == null)
            {    // 부모노드를 선택하지 않으면
                MessageBox.Show("선택한 노드가 없음", "부모노드 미선택", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // 더이상 진행없이 메서드 종료
            }
            TrvDummy.SelectedNode.Nodes.Add(rand.Next().ToString());
            TrvDummy.SelectedNode.Expand();
            TreeToList();   // 리스트뷰를 다시 그려준다
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            DlgOpenImage.Title = "이미지 열기";
            // 확장자를 이미지로만 제한하기 위함
            DlgOpenImage.Filter = "Image Files(*.bmp; *.jpg; *.png)|*.bmp; *.jpg; *.png";
            // | 앞에거는 탐색기에서의 설명, | 뒤는 실질적으로 필터링할 확장자명
            var res = DlgOpenImage.ShowDialog(this);
            if (res == DialogResult.OK)
            {
                // MessageBox.Show(DlgOpenImage.FileName.ToString());
                PicNormal.Image = Bitmap.FromFile(DlgOpenImage.FileName);
            }
        }
        // 이미지 클릭 시 발생하는 이벤트 핸들러 
        private void PicNormal_Click_1(object sender, EventArgs e)
        {
            if (PicNormal.SizeMode == PictureBoxSizeMode.Normal)    // 불러온 이미지의 크기가 Picture Box보다 클 경우
                PicNormal.SizeMode = PictureBoxSizeMode.StretchImage;   // 이미지의 크기를 조절함
            else                                                    // 이미지의 크기가 Picture박스의 크기보다 크지 않을 경우
                PicNormal.SizeMode = PictureBoxSizeMode.Normal;     // 이미지를 좌측상단에 위치함
        }

        // 텍스트 파일 로드 이벤트 핸들러
        private void BtnFileLoad_Click(object sender, EventArgs e)
        {
            // OpenFielDialog 컨트롤을 디자인에서 구성하지 않고 생성하는 방법
            // 텍스트 파일 로드 대화상자 열기
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false; // 2개 이상의 파일 선택을 금지, 기본적으로 Dialog의 Multiselect는 false이다.
            dialog.Filter = "Text Files(*.txt; *.cs; *.py)|*.txt; *.cs; *.py";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // UTF-8에서 한글이 깨짐. EUC-KR(Window 949), UTF-8(BOM) 은 한글이 문제 없음
                // 선택한 파일에서 RichTextBox에 내용 로드
                RtxEditor.LoadFile(dialog.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        // 텍스트 파일 저장 버튼 클릭 시 발생하는 이벤트 핸들러
        private void BtnFileSave_Click(object sender, EventArgs e)
        {
            // 텍스트 파일 저장 대화상자 열기
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "RichText Files(*.rtf)|*.rtf";
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                // RichTextBox 내용을 선택한 파일로 저장
                RtxEditor.SaveFile(dialog.FileName, RichTextBoxStreamType.RichNoOleObjs);
            }
        }

        private void BtnNoThread_Click(object sender, EventArgs e)
        {
            var maxValue = 100;
            var currValue = 0;
            PrgProcess.Minimum = 0;
            PrgProcess.Maximum = maxValue;
            PrgProcess.Value = 0;   // 프로그레스 바 수치를 0으로 초기화

            BtnThread.Enabled = false;      // 스레드 버튼의 사용을 차단
            BtnNoThread.Enabled = false;    // 노스레드 버튼의 사용을 차단
            BtnStop.Enabled = true;         // 스탑버튼을 사용 가능하게 함(기본값은 false)
            // 반복시작
            for (var i = 0; i <= maxValue; i++)
            {
                // 내부적으로 복잡하고 시간이 많이 요하는 작업
                currValue = i;
                TxtLog.AppendText($"현재진행 : {currValue}\r\n"); // 윈도우는 \r\n, 리눅스, Mac \n, 매킨토시 \r
                PrgProcess.Value = currValue;
                Thread.Sleep(500);  // 1000ms = 1초, 500ms = 0.5초 
            }
            // 작업이 완료된 이후
            BtnThread.Enabled = true;
            BtnNoThread.Enabled = true;
            BtnStop.Enabled = false;
        }

        private void BtnThread_Click(object sender, EventArgs e)
        {
            var maxValue = 100;
            PrgProcess.Minimum = 0;
            PrgProcess.Maximum = maxValue;
            PrgProcess.Value = 0;   // 프로그레스 바 수치를 0으로 초기화

            BtnThread.Enabled = BtnNoThread.Enabled = false;
            BtnStop.Enabled = true;


            BgwProgress.WorkerReportsProgress = true;       // 진행 사항 리포트 활성화
            BgwProgress.WorkerSupportsCancellation = true;  // 백그라운드워커 취소 활성화
            BgwProgress.RunWorkerAsync(null);   // 백그라운드 워커 실행
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            BgwProgress.CancelAsync();  // 비동기로 취소 실행!
        }

        #region '백그라운드워커 이벤트 핸들러'
        private void DoRealWork(BackgroundWorker worker, DoWorkEventArgs e)
        {
            var maxValue = 100;
            double currValue = 0;   // 실수형으로 설정
            for (var i = 0; i <= maxValue; i++)
            {
                if (worker.CancellationPending) // 중간에 취소할건지 물어보는 것
                {
                    e.Cancel = true;
                    break;
                }
                else {
                    currValue = i;
                    // 오랜시간이 걸리는 일처리
                    Thread.Sleep(500);  // 1000ms = 1초, 500ms = 0.5초 

                    // 아래를 실행하면,BgwProgress_ProgressChanged 이벤트 핸들러의
                    // ProgressChangedEventArgs내의 ProgressPercantage 속성에 값이 들어감
                    worker.ReportProgress((int)((currValue / maxValue) * 100));
                }
            }
        }


        // 일을 진행
        private void BgwProgress_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            DoRealWork((BackgroundWorker)sender, e); // 박싱된 객체를 언박싱
            e.Result = null;
        }
        // 진행상태 바뀌는 것 표시
        private void BgwProgress_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            PrgProcess.Value = e.ProgressPercentage;    // DoRealWork에서 전달받은 내용을 PrgProcess의 Value에 집어넣음
            TxtLog.AppendText($"진행률 : {PrgProcess.Value}%\r\n");
        }
        // 진행이 완료되면 그 이후의 처리
        private void BgwProgress_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if(e.Cancelled)
            {
                TxtLog.AppendText("작업이 취소되었습니다.\r\n");
            }
            else
            {
                TxtLog.AppendText("작업이 완료되었습니다.\r\n");
            }
            BtnNoThread.Enabled = BtnThread.Enabled = true;
            BtnStop.Enabled = false;
        }
        #endregion
    }
}
