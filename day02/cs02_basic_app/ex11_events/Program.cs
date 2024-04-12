// project : ex11_events
// date : 240412
// desc : 대리자와 이벤트

namespace ex11_events
{
    // delegate int MyDelegate(int a, int b);
    delegate void EventHandler(string message); // 이벤트 핸들러 대리자(어떠한 메서드를 대신 호출)
    class CustomNotifier    // 미리 만들어져 있다(고 생각)
    {
        // 이벤트 등록, event라는 키워드를 쓰면 기본적으로 EventHandler 이름을 기본적으로 사용
        public event EventHandler SomethingHappened;    // 대리자 선언 : SomethingHappened라는 이벤트를 등록, 구성된 로직이 없음

        public void DoSomething(int number)
        {
            int temp = number % 10;

            if (temp != 0 && temp % 3 == 0)
            {   // 3, 6, 9 등의 상태가 되면 짝! 하는 이벤트 발생시키겠다
                SomethingHappened($"{number} : 짝!");    // SomethingHappened가 처리할 로직이 포함되어 있지 않음
                // 이벤트 핸들러 발생, 자신의 메서드가 아닌 외부에서 만들어진 메서드를 대신 실행
            }
        }
    }   // 우리가 구현하는게 아니라, 원래부터 만들어져 있는 것
    internal class Program
    {
        public static void MyHandler(string message)    // 이벤트를 조작하는 함수
        {
            //Console.WriteLine($"다른 일을 처리합니다.{message}");
            //Console.ReadLine();
            //Console.Clear();
            Console.WriteLine($"[{DateTime.Now.ToShortTimeString()}] : {message}");
        }
        static void Main(string[] args)
        {
            CustomNotifier notifier = new CustomNotifier();
            notifier.SomethingHappened += new EventHandler(MyHandler);  // SomethingHappened를 사용한 것이 아닌 연결해 줬을 뿐임

            for (int i = 1;i<30;i++)
            {
                notifier.DoSomething(i);    // 내장된 클래스의 어떠한 매서드 호출
            }
           
            // notifier.SomethingHappene(30); // 이벤트 핸들러는 함수가 아니기 때문에 호출불가
            #region "익명 메서드"
            //MyDelegate calc;    
            //// 메서드 이름이 존재하지 않음. delegate는 메서드 이름이 아님 대리자 키워드일 뿐
            //// 익명 메서드(함수) : 한번 사용 이후 다시 호출할 필요가 없을 때 사용
            //calc = delegate (int a, int b)
            //{
            //    return a + b;
            //};

            //var result = calc(10, 4);
            #endregion
        }
    }
}
