// project : ex09_exceptionhandlings
// date : 240412
// desc : 예외처리

using System.Diagnostics;   // Debug 클래스를 사용하기위해 추가

namespace ex09_exceptionhandlings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[3] { 1, 2, 3 };

            try    // 예외는 중복해서 사용하면 성능저하에 치명적이다.
            {
                for (int i = 0; i < 4; i++)
                {
                    // 0, 1, 2, 3
                    Console.WriteLine($"{array[i]}");
                }
            }
            catch (Exception ex) // 모든 예외 클래스의 조상이 Exception 이므로
            {                                   // 어떤 예외 클래스를 써야할지 모르면 무조건 Exception 클래스.
                Debug.WriteLine(ex.Message); // 디버깅 할 때만 나옴. 실행할 때는 안나옴
            }
            finally // 예외가 발생하던 안하던 실행되는 코드
            {
                Console.WriteLine("프로그램 종료!");
            }
        }
    }
}
