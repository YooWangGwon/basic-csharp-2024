// project : Delegator_review
// date : 240412
// desc : 대리자 복습

using System.Data;

namespace Delegator_review
{
    delegate int MyDelegate(int a, int b);
    delegate void MyDelegate2(int a);

    class Market
    {
        public event MyDelegate2 CustomerEvent;
        public void BuySomething(int CustomerNo)
        {
            if (CustomerNo == 30) 
            {
                CustomerEvent(CustomerNo);
            }
        }
    }
    internal class Program
    {   
        public static void EventHandler(int a)
        {
            Console.WriteLine($"축하합니다! {a}번째 고객 이벤트에 당첨되셨습니다.");
        }
        static void Main(string[] args)
        {
            MyDelegate Callback;

            Callback = delegate (int a, int b)
            {
                return a + b;
            };
            Console.WriteLine(Callback(3, 4));
            Callback = delegate (int a, int b)
            {
                return a - b;
            };
            Console.WriteLine(Callback(7,5));

            Market market = new Market();
            market.CustomerEvent += new MyDelegate2(EventHandler);  // += 연산자를 통한 대리자 체인 만들기

            for(int customerNo = 0; customerNo < 100; customerNo += 10) 
                market.BuySomething(customerNo);
        }
    }
}
