// project : ex10_delegators
// date : 240412
// desc : 대리자와 이벤트

using System.ComponentModel;
using System.Text.Json.Serialization.Metadata;

namespace ex10_delegators
{
    delegate int MyDelegate(int a, int b);  // 함수의 매개변수 값과 데이터 형식이 동일
    delegate int Compare(int a, int b);  // 두 값을 비교하는 대리자
    // 어떠한 일이 발생하는지 시스템이 알려주는 것 - 이벤트 
    delegate void Notify(string message);   // Notify 대리자

    class Notifier
    {
        public Notify EventOccured; // 이벤트 발생(이벤트 메서드 실행)
    }

    class EventListener // 이벤트가 발생하는지 듣고있는 객체
    {
        private string name;
        public EventListener(string name) // 생성자
        {
            this.name = name;
        }

        public void SomethingHappened(string message)
        {
            Console.WriteLine($"{name}.뭔일이 발생했다!!! {message}");
        }
    }

    class Caculator
    {
        public int Plus(int a, int b)
        {
            return a + b;
        }
        public int Minus(int a, int b)
        {
            return a - b;
        }
    }

    class Sorting
    {
        public int AscendingCompare(int a, int b) // 오름차순 비교
        {
            if (a > b)
                return 1;
            else if (a == b)
                return 0;
            else 
                return -1;
        }
        public int DecendingCompare(int a, int b) // 내림차순 비교 
        {
            if (a > b)
                return -1;
            else if (a == b)
                return 0;
            else
                return 1;
        }

        public void BubbleSort(int[] DataSet, Compare comparer)
        {
            int i = 0, j = 0, temp = 0;

            for (i = 0; i < DataSet.Length -1; i++) 
            {
                for (j = 0; j < DataSet.Length -1; j++ )
                {
                    if (comparer(DataSet[j], DataSet[j+1]) > 0)
                    {
                        temp = DataSet[j + 1];
                        DataSet[j+1] = DataSet[j];
                        DataSet[j] = temp;
                    }
                }
            }
        }
    }
 

    internal class Program
    {
        static void Main(string[] args)
        {
            Notifier notifier = new Notifier();
            EventListener listener1 = new EventListener("리스너 1");
            EventListener listener2 = new EventListener("리스너 2");
            EventListener listener3 = new EventListener("리스너 3");
            // 대리자 체인(+= 연산자)!! notifier의 EventOccured라는 대리자에 리스너 3개에 일어날 수 있는 메서드를 연결
            // 일반적인 함수 호출에서 한번에 여러개의 함수 실행이 불가능 -> 대리자를 이용한다면 가능
            notifier.EventOccured += listener1.SomethingHappened;
            notifier.EventOccured += listener2.SomethingHappened;
            notifier.EventOccured += listener3.SomethingHappened;
            notifier.EventOccured("메일을 받았어요!!");     // 1, 2, 3 실행 
            Console.WriteLine();

            notifier.EventOccured -= listener2.SomethingHappened;
            notifier.EventOccured("파일 다운로드 완료!!");  // 1, 3 실행

            notifier.EventOccured = new Notify(listener2.SomethingHappened) + new Notify(listener3.SomethingHappened);
            notifier.EventOccured("미사일 발사~!");         // 2, 3 실행
            Console.WriteLine();    // 윈폼(PyQt 등) 이벤트도 이와 유사한 형태로 동작

            #region "정렬 대리자 코드 영역"
            int[] array = { 3, 7, 10, 5, 4, 2, 1, 9 };
            Sorting sorting = new Sorting();

            Console.WriteLine("오름차순 정렬");
            sorting.BubbleSort(array, new Compare(sorting.AscendingCompare));

            for ( int i = 0; i < array.Length -1; i++ ) 
            {
                Console.Write($"{array[i]}, ");
            }
            Console.WriteLine();

            Console.WriteLine("내림차순 정렬");
            sorting.BubbleSort(array, new Compare(sorting.DecendingCompare));

            for (int i = 0; i < array.Length - 1; i++)
            {
                Console.Write($"{array[i]}, ");
            }
            Console.WriteLine();

            #endregion

            #region "계산기 대리자 코드 영역"

            Caculator calc = new Caculator();   // 객체 생성
            MyDelegate Callback;

            Callback = new MyDelegate(calc.Plus);
            var result = Callback(10, 4);   // Callback은 calc.Plus를 실행
            Console.WriteLine(result);  // 14

            Callback = new MyDelegate(calc.Minus);
            result = Callback(10, 4);   // Callback은 calc.Plus를 실행
            Console.WriteLine(result);  // 14 

            #endregion
        }
    }
}
