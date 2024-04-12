// project : ex01_hellocsharp
// date : 240411
// desc : C# 시작 2

namespace hello_world // 프로그램  소스의 가장 큰 단위 : namespace -> 파이썬의 모듈, 라이브러리 역할
{
    internal class Program  // 접근제한자 class 파일명/internal은 class 구조체의 private과 유사함/파일명과 클래스명이 달라도 됨
    {
        static void Main(string[] args) // 메인함수는 프로그램이 실행될 때 처음부터 끝까지 실행되야하기 때문에 static(정적변수) 선언, 리턴값이 void라 없는것과 마찬가지
        {                               // c#에서는 모든 method(함수)를 쓸 때 대문자로 시작해야함
            // System 네임스페이스 >> console 클래스에 잇는 정적메서드 writeline()
            //Console.WriteLine("hello, world!"); // c++의 cout
            if(args.Length == 0) 
            {
                Console.WriteLine("사용법 : hello_world.exe <이름>");
                return;
            } else
            {
                Console.WriteLine($"Hello, {args[0]}!");
            }
        }
    }
}