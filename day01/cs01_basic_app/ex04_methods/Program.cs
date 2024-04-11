namespace ex04_methods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x = 3; int y = 4;
            BasicSwap(x, y);
            Console.WriteLine($"BasicSwap -> x = {x}, y = {y}");

            RefSwap(ref x, ref y);  // 참조로  매개변수를 사용할 땐 ref를 써줘야함
            Console.WriteLine($"RefSwap -> x = {x}, y = {y}");

            int a = 10; int b = 3;
            int 값 = 0; int 나머지 = 0;
            Divide(a, b, out 값, out 나머지);
            Console.WriteLine($"{a} / {b} = {값}, {나머지}");

            x = 3; y = 4;
            int res = Plus(x, y);
            float x1 = 3.4f; float y1 = 4.5f;
            float res1 = Plus(x1, y1);
            Console.WriteLine($"x + y = {res} / x + y = {res1}");

            Console.WriteLine(Sum(1, 2, 3, 4, 5, 6, 7, 8, 9));
            Console.WriteLine(Sum(1,2, 3, 4, 5, 6,7, 8, 9, 10));
            Console.WriteLine(Sum(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11));

            PrintProfile(phone: "010-9999-8888", name: "홍길동");
            PrintProfile("홍길동","010-9999-8888");

            DefaultMethod(10, 8);
            DefaultMethod(6);
            DefaultMethod();
        }
        public static void DefaultMethod(int a = 1, int b = 0)
        {
            Console.WriteLine($"Default Value = {a}, {b}");
        }
        public static void PrintProfile(string name, string phone)
        {
            Console.WriteLine($"이름 = {name}, 모바일 = {phone}");
        }
        public static int Sum(params int[] argv)
        {
            int sum = 0;
            foreach(var item in argv)
            {
                sum += item;
            }
            return sum;
        }

        public static void BasicSwap(int a, int b) 
        {
            int temp = b;
            b = a;
            a = temp;
        }
        public static void RefSwap(ref int a, ref int b)
        {
            int temp = b;
            b = a;
            a = temp;
        }

        // quotient는 나누기 값, remainder는 나머지
        public static void Divide(int a, int b, out int quotient, out int remainder)   // 값을 두개 이상 리턴하고 싶을 때 out 사용
        {
            quotient = a / b;
            remainder = a % b;
            // 예전엔 튜플 리턴이 없어서 한번에 하나만 값을 리턴할 수 있었음
        }

        public static int Plus(int a, int b)
        {
            return a + b;
        }

        public static float Plus(float a, float b)
        {
            return a + b;
        }
    }
}
