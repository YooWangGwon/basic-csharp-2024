// project : ex12_lambdas
// date : 240415
// desc : 람다식

namespace cs03_basic_app
{
    // 대리자의 정수값 두개 받아서 정수값을 리턴해주는 함수들은 내가 대신 실행시켜줄게
    delegate int Calculate(int a, int b);
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("익명 메서드");
            Calculate calc;
            calc = delegate (int a, int b) {  // 13장에서 본, 대리자로 만든 무명 메서드            
                return a + b;
            };
            Console.WriteLine($"calc 계산 결과 : {calc(10, 4)}\n");
            
            Console.WriteLine("람다식 익명 메서드");

            // 람다식을 쓰면 훨씬 짧게 코딩 가능
            // calc와 동일한 기능
            Calculate calc2 = (a, b) => a + b; //(int a, int b) => a + b;  //{ return a + b; };
            Console.WriteLine($"람다식 calc2 계산 결과 : {calc2(10, 5)}");

            // 문장형식의 람다식 : {} 중괄호 안에서는 return을 생략해선 안됨
            Calculate calc3 = (a, b) =>
            {
                Console.WriteLine("이런식으로 뺄셈이 됩니다.");
                var sum = a - b;
                return sum;
            };
            Console.WriteLine($"람다식 calc3 계산 결과 : {calc3(11, 4)}");

            // Func, Action 빌트인 대리자 사용
            // Func는 return 값이 있기 때문에 <int> 는 리턴값이 int 라는 뜻
            Func<int> func1 = () => 10;
            Console.WriteLine($"func1의 값 = {func1()}");  // 10
            // <int, int>는 매개변수 하나, 리턴 하나 라는 뜻

            Func<int, int> func2 = (a) => a * 5;
            Console.WriteLine($"func2의 값 = {func2(5)}");    // 25

            Func<int, int, double> func3 = (a, b) => (double) a / b;
            Console.WriteLine($"func3 = {func3(22, 7)}");

            // Action은 리턴값이 없음
            int result = 0;
            Action<int> act1 = (a) => result = a * a;
            act1(3);
            Console.WriteLine($"act1 = {result}");

            Action<double, double> act2 = (x, y) =>
            {
                double res = x / y;
                Console.WriteLine(res);
            };
            act2(21.1, 7.0);

        }
    }

    class Test
    {
        private int name;
        private double point;

        public int Name     // 기본의 프로퍼티
        {
            get { return name; }
            set { name = value; }
        }

        public double Point// 람다식을 사용한 프로퍼티, 코딩이 간단해짐
        {
            get => point;
            set => point = value;
        }

    }
}
