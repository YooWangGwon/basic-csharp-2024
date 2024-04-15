// project : ex14_attributes
// date : 240415
// desc : 애트리뷰트

using System.Reflection;

namespace ex14_attributes
{
    internal class Program
    {

        
        class MyClass
        {
            [Obsolete("이 메서드는 다음 버전에서 폐기됩니다. NewMethod()를 사용하세요.", true)]   // 경고 문구 다음에 , true를 붙이면 오류로 취급하게 하여 사용을 못하게 함
            /// <summary>
            /// 올드메써드. 이렇게 쓰셈
            /// </summary> 
            public void OldMethod() // 최초에 제작한 메서드
            {
                Console.WriteLine("Old Method");
            }

            /// <summary>
            ///  뉴메써드, 제발 이걸 쓰셈!!
            /// </summary>
            public void NewMethod() // 개선한 메서드
            {
                Console.WriteLine("New Method");
            }
        }
        static void Main(string[] args)
        {
            #region '리플렉션'
            // 리플렉션
            Console.WriteLine("리플렉션");  // GetType() 만 알고있으면 됨

            List<string> list = new List<string>();
            list.GetType();

            int a = int.MaxValue;
            Type type = a.GetType();
            Console.WriteLine(a.GetType()); // System.Int32

            float f = float.MaxValue;
            Console.WriteLine(f.GetType()); // System.Single

            double d = double.MaxValue;
            Console.WriteLine(d.GetType()); // System.Double

            FieldInfo[] fields = type.GetFields();  // 타입 객체에서 어떤 필드가 있는지 모두 확인
            foreach (var item in fields)
            {
                Console.WriteLine($"Type : {item.FieldType}, Name:{item.Name}");
            }

            MethodInfo[] methods = type.GetMethods();  // 타입 객체에서 어떤 메서드가 있는지 모두 확인
            foreach (var item in methods)
            {
                Console.WriteLine($"Type : {item.DeclaringType}, Name:{item.Name}");
            }
            #endregion
            // 애트리뷰트
            Console.WriteLine("애트리뷰트!");
            MyClass myClass = new MyClass();
            myClass.OldMethod();
            myClass.NewMethod();
        }
    }
}
