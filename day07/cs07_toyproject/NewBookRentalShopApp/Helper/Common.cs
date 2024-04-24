using System.Security.Cryptography;
using System.Text;

namespace NewBookRentalShopApp.Helper   // NewBookRentalShopApp 프로젝트 안의 Helper 폴더
{
    public class Common
    {
        // 정적(static)으로 만드는 공통 문자 연결 -> 프로그램 시작부터 끝까지 할당되어 사용할 수 있음
        public static readonly string Connstring = "Data Source=localhost;" +
                                   "Initial Catalog=BookRentalShop2024;" +
                                   "Persist Security Info=True;" +
                                   "User ID=sa;Encrypt=False;Password=mssql_p@ss";
        // 로그인 아이디
        public static string LoginId { get; set; }

        // 회원 선택 팝업에서 대출 화면으로 넘길 데이터들을 정적변수로 만들기
        public static string SelMemberIdx { get; set; }
        public static string SelMemberName { get; set; }
        public static string SelBookIdx { get; set; }
        public static string SelBookName {  get; set; }


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
