

using System;
using System.Runtime.InteropServices;

namespace CircularQueue
{
    partial class Client
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        public static void SetWindow(int w, int h)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            IntPtr ptr = GetConsoleWindow();
            MoveWindow(ptr, (1920 - w) / 2, (1080 - h) / 2, w, h, true);
        } //SetWindow

        public static void CLS(string header)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t" + header);
            Console.WriteLine("\t" + "".PadRight(header.Length, '='));
            Console.WriteLine();
        } //CLS

        public static void ReadKey()
        {
            Console.Write("\n\tPress any key to return to the menu ... ");
            Console.ReadKey();
        } //ReadKey

    } //class Client
}
