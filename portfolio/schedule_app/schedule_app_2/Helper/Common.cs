using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace schedule_app_2.Helper
{
    public class Common
    {
        // 정적(static)으로 만드는 공통 문자 연결 -> 프로그램 시작부터 끝까지 할당되어 사용할 수 있음
        public static readonly string Connstring = "Data Source=localhost;" +
                                   "Initial Catalog=TodoManagement;" +
                                   "Persist Security Info=True;" +
                                   "User ID=sa;Encrypt=False;Password=mssql_p@ss";

        // MD5 해시 알고리즘 암호화
        // 1234
        public static string GetMd5Hash(MD5 md5Hash, string input)
        {
            // 입력 문자열을 byte배열로 변환한 뒤 MD5 해시 처리
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder builder = new StringBuilder(); // 문자열을 쉽게 만들어주는 wrapping 된 클래스
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2")); // 16진수 문자로 각 글자를 전부 변환
            }
            return builder.ToString();
        }
    }
}
