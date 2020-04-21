using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace z1
{
    class Program
    {

        [DllImport("User32.dll")]
        public static extern int GetAsyncKeyState(int i);
        static void Main(string[] args)
        {
            while (true)
            {
                Thread.Sleep(150);

                for (int i = 32; i <= 127; i++)
                {
                    int keystate = GetAsyncKeyState(i);
                    if (keystate != 0)
                    {
                        Console.Write((char)i + ", ");
                    }
                }
            }
        }
    }
}
