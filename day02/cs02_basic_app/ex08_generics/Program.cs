// project  : ex08_generics
// date : 240412
// desc : 일반화 프로그래밍

namespace ex08_generics
{
    internal class Program
    {
        // 배열 복사 기능 -> 일반화 프로그래밍
        // 메서드 뒤에 <T>, 매개변수의 타입 대신 T로 변경(T가 아닌 다른 문자를 사용하여 통일해도 됨)
        
        static void CopyArray<T>(T[] src, T[] dest)
        {
            for (int i = 0; i < src.Length; i++)
                dest[i] = src[i];
        }

        //static void CopyArray(float[] src, float[] dest) 
        //{
        //    for (int i = 0; i < src.Length; i++)
        //        dest[i] = src[i];
        //}

        static void Main(string[] args)
        {
            int[] arr1 = { 10, 20, 30, 50, 70 };
            int[] arr2 = new int[arr1.Length];

            CopyArray(arr1, arr2);

            Console.WriteLine(arr2[4]);

            float[] arr3 = { 3.4f, 2.2f, 7.7f };
            float[] arr4 = new float[arr3.Length];



            CopyArray(arr3, arr4);
            Console.WriteLine(arr4[0]);
            Array.Sort(arr4);
            Console.WriteLine(arr4[0]);
        }
    }
}
