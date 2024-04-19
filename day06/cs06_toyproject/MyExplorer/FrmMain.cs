using System.Diagnostics;

namespace MyExplorer
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        // 열기 버튼 클릭 이벤트 핸들러 
        private void BtnOpen_Click(object sender, EventArgs e)
        {

        }

        // 가장 기본. 폼 로드 이벤트 핸들러(가장 먼저 실행됨)
        private void FrmMain_Load(object sender, EventArgs e)
        {
            TreeNode root = TrvFolder.Nodes.Add("내 컴퓨터");

            string[] drives = Directory.GetLogicalDrives(); // 내 컴퓨터 논리드라이브(C:\, D:\)
            foreach (var dirve in drives)
            {
                TreeNode node = root.Nodes.Add(dirve);
                node.Nodes.Add("..."); // 아직 미지정
            }
        }



        // 트리노드 선택 후 이벤트 핸들러
        private void TrvFolder_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // TrvFolder 에서 노드  선택하면 리스트뷰에 파일 표시
            TreeNode current = e.Node;
            if (e.Node == null) return;

            string path = current.FullPath.Replace("\\\\", "\\");
            TxtPath.Text = path.Substring(path.IndexOf("\\") + 1);  // '내 컴퓨터\' 를 제거

            try
            {
                LsvFile.Items.Clear();  // 다른 폴더에 있던 이전 파일 정보 삭제
                                        // 현재 폴더의 하위폴더 정보 디스플레이
                string[] diretories = Directory.GetDirectories(TxtPath.Text);
                foreach (var diretory in diretories)
                {
                    DirectoryInfo info = new DirectoryInfo(diretory);
                    // 리스틑뷰 컬럼 이름, 수정일자, 유형, 크기 순으로 리스트뷰 아이템 생성
                    // 문자열 빈값 : "", string.Empty
                    ListViewItem item = new ListViewItem(new string[] { info.Name, info.LastWriteTime.ToString(), "파일폴더", string.Empty });
                    item.ImageIndex = 1;
                    LsvFile.Items.Add(item);
                }

                string[] files = Directory.GetFiles(TxtPath.Text);
                foreach (var file in files)
                {
                    FileInfo info = new FileInfo(file);
                    ListViewItem item = new ListViewItem(new string[] { info.Name, info.LastWriteTime.ToString(), info.Extension, info.Length.ToString() });
                    item.ImageIndex = GetImageIndex(info.Extension);
                    LsvFile.Items.Add(item);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetImageIndex(string extension)
        {
            // 3: 실행파일, 4: 일반파일, 5: 텍스트파일
            var index = -1;
            switch (extension.ToLower())
            {
                case ".exe":
                    index = 3;
                    break;
                case ".txt":
                    index = 5;
                    break;
                default:
                    index = 4;
                    break;
            }
            return index;
        }

        // 트리 확장 축소 아이콘 클릭해서 확장되기 직전 이벤트 핸들러
        private void TrvFolder_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode current = e.Node;
            // 폼이 로드된 후 최초의 상태라면
            if (current.Nodes.Count == 1 && current.Nodes[0].Text.Equals("..."))
            {
                current.Nodes.Clear();  // ...을 삭제
                // FullPath인 '내 컴퓨터\C:\'에서 C만 남기고 다 지운다.
                String path = current.FullPath.Substring(current.FullPath.IndexOf("\\") + 1);

                try
                {
                    string[] directories = Directory.GetDirectories(path);
                    foreach (var directory in directories)
                    {
                        Debug.WriteLine(directory); // 디버그시만 출력
                        TreeNode newNode = current.Nodes.Add(directory.Substring(directory.LastIndexOf("\\") + 1));
                        newNode.ImageIndex = 1; // 미 선택시 폴더 이미지
                        newNode.SelectedImageIndex = 2; // 선택시 폴더 이미지
                        newNode.Nodes.Add("...");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LsvFile_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // 컨텍스트 메뉴
                CmsFiles.Show(LsvFile, e.Location);
            }
        }

        private void TsmLargeIcon_Click(object sender, EventArgs e)
        {
            LsvFile.View = View.LargeIcon;
        }

        private void TsmSmallIcon_Click(object sender, EventArgs e)
        {
            LsvFile.View = View.SmallIcon;
        }

        private void TsmList_Click(object sender, EventArgs e)
        {
            LsvFile.View = View.List;
        }

        private void TsmDetail_Click(object sender, EventArgs e)
        {
            LsvFile.View = View.Details;
        }

        private void TsmTile_Click(object sender, EventArgs e)
        {
            LsvFile.View = View.Tile;
        }

        private void LsvFile_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                var extension = LsvFile.SelectedItems[0].Text.Split(".")[1];
                if (extension == "exe")
                {   // 확장자명이 exe인 경우
                    // MessageBox.Show(LsvFile.SelectedItems[0].ToString());    // 디버깅용
                    // 실행파일 경로는 TxtPath
                    var fullPath = TxtPath.Text + "\\" + LsvFile.SelectedItems[0].Text;
                    Process.Start(fullPath);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
