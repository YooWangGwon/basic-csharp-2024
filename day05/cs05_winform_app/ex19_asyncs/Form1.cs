namespace ex19_asyncs
{
    public partial class Form1 : Form
    {
        #region '������, �ʱ�ȭ ����'
        public Form1()
        {
            InitializeComponent();
        }
        #endregion

        #region '�̺�Ʈ �ڵ鷯 ����'
        // ���� ��� ���� ��ư �̺�Ʈ �ڵ鷯, ������ �������� ����
        private void BtnGetSource_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK )
            {
                TxtSource.Text = ofd.FileName;
                TxtSource.ReadOnly = true;  // ��ΰ� �ؽ�Ʈ�ڽ��� �ԷµǸ� ReadOnly�θ� ��밡���ϰ� ����
                                            // ��ư�� Enabled��, �ؽ�Ʈ�ڽ��� ReadOnly�� 
            }
        }

        // Ÿ�� ���� ��ư �̺�Ʈ �ڵ鷯, �ٿ��ֱ� �� Ÿ������ ����
        private void BtnSetTarget_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if(sfd.ShowDialog() == DialogResult.OK )
            {
                TxtTarget.Text = sfd.FileName;
            }
            if(PrgCopy.Value == 100)
            {
                MessageBox.Show("���� ���� �Ϸ�", "���� ����", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // ����ȭ ���� ��ư Ŭ�� �̺�Ʈ �ڵ鷯, ����ȭ ���� ����
        private void BtnSyncCopy_Click(object sender, EventArgs e)
        {
            long result = CopySync(TxtSource.Text, TxtTarget.Text);
        }

        // �񵿱�ȭ ���� ��ư Ŭ�� �̺�Ʈ �ڵ鷯, �񵿱�ȭ ���� ����
        private async void BtnAsyncCopy_Click(object sender, EventArgs e)
        {
            long result = await CopyAsync(TxtSource.Text, TxtTarget.Text);
        }

        // ���� ��� ��ư Ŭ�� �̺�Ʈ �ڵ鷯, ���� ��� ó��
        private void BtnCancel_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region '����� �޼��� ����'

        private long CopySync(string srcPath, string destPath)
        {
            // ��ư��� ��Ȱ��ȭ
            BtnSyncCopy.Enabled = BtnAsyncCopy.Enabled = false;
            long totalCopied = 0;
            long copied = 0;

            // File�� Open()�ϸ� �ݵ�� Close() �ؾ� ��. ������ using Ű���带 ���� Close()�� C#�� �˾Ƽ� ����
            // ���� �����
            using (FileStream fromStream = new FileStream(srcPath, FileMode.Open))
            {   // ���� �����ϴ� ���� ���� -> FileMode.Open
                using (FileStream toStream = new FileStream(destPath, FileMode.Create))
                {   // �������� �ʴ� ������ ����� -> FileMode.Create
                    // 1MByte ���۸� ����
                    byte[] buffer = new byte[1024 * 1024]; // 1024(byte) = 1kb, 1024*1024 = 1Mb
                                                           // �׽�Ʈ �� 10*10���� ����
                    // fromStream�� ���� ������ 1MB�� �޶� ���ۿ� ���� ����
                    // toStream�� 1MB�� �ٿ�����
                    int nRead = 0;
                    while((nRead = fromStream.Read(buffer, 0, buffer.Length)) != 0) // �������Ͽ��� �о���� byte���� 0�� �� ����
                    {
                        toStream.Write(buffer, 0, nRead);   // ��ǥ ������ ������ 1MB�� �ᰡ�鼭 ����
                        totalCopied += nRead; // ��ü ���� ����� ��� ����

                        // ���α׷��� �ٿ� ��������� ǥ��
                        PrgCopy.Value = (int)((double)(totalCopied / fromStream.Length)*100);
                    }
                }
            }

            BtnSyncCopy.Enabled = BtnAsyncCopy.Enabled = true;
            return totalCopied; // ������ ���� ����� ����
        }

        // �񵿱� ó���� async, await Ű���尡 ���� �߿�
        // async : �񵿱� �޼������� ����
        // await : �񵿱�޼��尡 ���������� ��ٸ� ���� ����
        // �񵿱⸦ ó���ϴ� �޼���� ...Async() �� ����
        // async�� �޼��� ���ϰ��� �ۼ�. ���ϰ��� Task<���ϰ�>���� �ۼ�
        // ReadAsync, WriteAsync�� ������ await�� ���� �ʴ´ٸ� �񵿱�� �۵����� ����
        async Task<long> CopyAsync(string srcPath, string destPath)
        {
            BtnSyncCopy.Enabled = BtnAsyncCopy.Enabled = false;
            long totalCopied = 0;
            long copied = 0;


            using (FileStream fromStream = new FileStream(srcPath, FileMode.Open))
            {   
                using (FileStream toStream = new FileStream(destPath, FileMode.Create))
                {   
                    byte[] buffer = new byte[1024 * 1024]; // �׽�Ʈ �� 10*10���� ����
                    int nRead = 0;
                    while ((nRead = await fromStream.ReadAsync(buffer, 0, buffer.Length)) != 0) // �������Ͽ��� �о���� byte���� 0�� �� ����
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
