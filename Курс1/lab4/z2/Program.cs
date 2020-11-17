using System;
using System.Runtime.InteropServices;

namespace z2
{
    class Program
    {
        [DllImport("C:\\Intel\\Dinlib\\Debug\\Dinlib.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int Sum(int a, int b);

        [DllImport("C:\\Intel\\Dinlib\\Debug\\Dinlib.dll")]
        public static extern int Diff(int a, int b);

        [DllImport("C:\\Intel\\Dinlib\\Debug\\Dinlib.dll", CallingConvention = CallingConvention.Cdecl)]

        public static extern int stepen(int a, int b);

        static void Main(string[] args)
        {
            int sum = Sum(17, 41);
            int dif = Diff(5, 4);
            float pow = stepen(2, 5);
            Console.WriteLine($"17 + 41 = {sum.ToString()}");
            Console.WriteLine($"5 - 4 = {dif.ToString()}");
            Console.WriteLine($"2^5 = {pow.ToString()}");
        }
    }
}
