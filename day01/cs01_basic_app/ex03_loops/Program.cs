// project: ex03_loops
// date : 240411
// desc : foreach

namespace ex03_loops
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4, 5};
            foreach (var item in arr) // C++
            {
                Console.WriteLine($"현재 수 : {item}");
            }
        }
    }
}
