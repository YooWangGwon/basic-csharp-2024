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
            FrmModal.ShowDialog();  // 모달창 띄우기

        }

        private void BtnModaless_Click(object sender, EventArgs e)
        {
            Form FrmModaless = new Form();
            FrmModaless.Text = "모달리스창";
            FrmModaless.Width = 300;
            FrmModaless.Height = 100;
            FrmModaless.BackColor = Color.Green;
            FrmModaless.Show();  // 모달리스창 띄우기
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

        private void PicNormal_Click_1(object sender, EventArgs e)
        {
            if (PicNormal.SizeMode == PictureBoxSizeMode.Normal)    // 불러온 이미지의 크기가 Picture Box보다 클 경우
                PicNormal.SizeMode = PictureBoxSizeMode.StretchImage;   // 이미지의 크기를 조절함
            else                                                    // 이미지의 크기가 Picture박스의 크기보다 크지 않을 경우
                PicNormal.SizeMode = PictureBoxSizeMode.Normal;     // 이미지를 좌측상단에 위치함
        }
    }
}
