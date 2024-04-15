// project: ex15_pythons
// date : 240415
// desc : 파이썬 실행하기

// 파이썬용 라이브러리 사용등록
using IronPython.Hosting;
//using static System.Net.Mime.MediaTypeNames;
//using System;

namespace ex15_pythons
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("파이썬 실행예제");
            
            var engine = Python.CreateEngine();
            var scope = engine.CreateScope();
            var paths = engine.GetSearchPaths();

            // Python 경로 설정 // @ : 리소스 키워드
            paths.Add(@"C:\DEV\Langs\Python311");
            paths.Add(@"C:\DEV\Langs\Python311\DLLs");
            paths.Add(@"C:\DEV\Langs\Python311\Lib");
            paths.Add(@"C:\DEV\Langs\Python311\Lib\site-packages");

            // 필요없나?
            //paths.Add(@"C:\Users\user\AppData\Roaming\Python\Python311\site-packages");
            //paths.Add(@"C:\Users\user\AppData\Roaming\Python\Python311\site-packages\win32");
            //paths.Add(@"C:C:\Users\user\AppData\Roaming\Python\Python311\site-packages\win32\lib");

            // 실행시킬 파이썬 파일의 경로를 wlwjd
            var filePath = @"C:\Sources\basic-csharp-2024\day03\cs03_basic_app\ConsoleApp1\test.py";
            var source = engine.CreateScriptSourceFromFile(filePath);

            // Python 실행
            source.Execute(scope);

            var PythonFunc = scope.GetVariable<Func<int, int, int>>("sum");
            var result = PythonFunc(10, 7);
            Console.WriteLine($"sum 함수 실행  결과 = {result}");

            var PythonGreeting = scope.GetVariable<Func<string>>("SayGreeting");
            var greeting = PythonGreeting();
            Console.WriteLine($"결과 = {greeting}");

            var PythonFunc2 = scope.GetVariable<Func<int, int, int, int>>("Calc");
            var result2 = PythonFunc2(5, 6, 7);
            Console.WriteLine($"Calc 함수 실행  결과 = {result2}");


        }
    }
}
