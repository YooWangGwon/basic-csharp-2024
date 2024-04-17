namespace ex19_asyncs
{
    public partial class Form1 : Form
    {
        #region '생성자, 초기화 영역'
        public Form1()
        {
            InitializeComponent();
        }
        #endregion

        #region '이벤트 핸들러 영역'
        // 복사 대상 지정 버튼 이벤트 핸들러, 복사할 원본파일 선택
        private void BtnGetSource_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK )
            {
                TxtSource.Text = ofd.FileName;
                TxtSource.ReadOnly = true;  // 경로가 텍스트박스에 입력되면 ReadOnly로만 사용가능하게 변경
                                            // 버튼은 Enabled로, 텍스트박스는 ReadOnly로 
            }
        }

        // 타겟 지정 버튼 이벤트 핸들러, 붙여넣기 할 타겟파일 지정
        private void BtnSetTarget_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if(sfd.ShowDialog() == DialogResult.OK )
            {
                TxtTarget.Text = sfd.FileName;
            }
            if(PrgCopy.Value == 100)
            {
                MessageBox.Show("파일 복사 완료", "파일 복사", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // 동기화 복사 버튼 클릭 이벤트 핸들러, 동기화 복사 진행
        private void BtnSyncCopy_Click(object sender, EventArgs e)
        {
            long result = CopySync(TxtSource.Text, TxtTarget.Text);
        }

        // 비동기화 복사 버튼 클릭 이벤트 핸들러, 비동기화 복사 진행
        private async void BtnAsyncCopy_Click(object sender, EventArgs e)
        {
            long result = await CopyAsync(TxtSource.Text, TxtTarget.Text);
        }

        // 복사 취소 버튼 클릭 이벤트 핸들러, 복사 취소 처리
        private void BtnCancel_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region '사용자 메서드 영역'

        private long CopySync(string srcPath, string destPath)
        {
            // 버튼사용 비활성화
            BtnSyncCopy.Enabled = BtnAsyncCopy.Enabled = false;
            long totalCopied = 0;
            long copied = 0;

            // File은 Open()하면 반드시 Close() 해야 함. 하지만 using 키워드를 쓰면 Close()를 C#이 알아서 해줌
            // 파일 입출력
            using (FileStream fromStream = new FileStream(srcPath, FileMode.Open))
            {   // 원래 존재하는 파일 열기 -> FileMode.Open
                using (FileStream toStream = new FileStream(destPath, FileMode.Create))
                {   // 존재하지 않는 파일을 만들기 -> FileMode.Create
                    // 1MByte 버퍼를 생성
                    byte[] buffer = new byte[1024 * 1024]; // 1024(byte) = 1kb, 1024*1024 = 1Mb
                                                           // 테스트 시 10*10으로 변경
                    // fromStream에 들어온 파일을 1MB씩 달라서 버퍼에 담은 다음
                    // toStream에 1MB씩 붙여넣음
                    int nRead = 0;
                    while((nRead = fromStream.Read(buffer, 0, buffer.Length)) != 0) // 원본파일에서 읽어오는 byte값이 0일 때 까지
                    {
                        toStream.Write(buffer, 0, nRead);   // 목표 지점에 파일을 1MB씩 써가면서 적기
                        totalCopied += nRead; // 전체 복사 사이즈를 계속 증가

                        // 프로그레스 바에 진행사항을 표시
                        PrgCopy.Value = (int)((double)(totalCopied / fromStream.Length)*100);
                    }
                }
            }

            BtnSyncCopy.Enabled = BtnAsyncCopy.Enabled = true;
            return totalCopied; // 복사한 파일 사이즈를 리턴
        }

        // 비동기 처리시 async, await 키워드가 가장 중요
        // async : 비동기 메서드임을 정의
        // await : 비동기메서드가 끝날때까지 기다릴 것을 정의
        // 비동기를 처리하는 메서드명 ...Async() 로 끝남
        // async는 메서드 리턴값에 작성. 리턴값은 Task<리턴값>으로 작성
        // ReadAsync, WriteAsync를 쓰더라도 await를 쓰지 않는다면 비동기로 작동하지 않음
        async Task<long> CopyAsync(string srcPath, string destPath)
        {
            BtnSyncCopy.Enabled = BtnAsyncCopy.Enabled = false;
            long totalCopied = 0;
            long copied = 0;


            using (FileStream fromStream = new FileStream(srcPath, FileMode.Open))
            {   
                using (FileStream toStream = new FileStream(destPath, FileMode.Create))
                {   
                    byte[] buffer = new byte[1024 * 1024]; // 테스트 시 10*10으로 변경
                    int nRead = 0;
                    while ((nRead = await fromStream.ReadAsync(buffer, 0, buffer.Length)) != 0) // 원본파일에서 읽어오는 byte값이 0일 때 까지
                    {
                        await toStream.WriteAsync(buffer, 0, nRead);
                        totalCopied += nRead;

                        PrgCopy.Value = (int)((double)(totalCopied / fromStream.Length) * 100);
                    }
                }
            }

            BtnSyncCopy.Enabled = BtnAsyncCopy.Enabled = true;
            return totalCopied;
        }
        #endregion
    }
}
