using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Runtime.InteropServices;

namespace UiBot
{
    public static class ConsoleWindow
    {
        private static bool isConsoleAllocated = false;

        [DllImport("kernel32.dll")]
        private static extern bool AllocConsole();

        [DllImport("kernel32.dll")]
        private static extern bool FreeConsole();

        public static void Create()
        {
            if (!isConsoleAllocated)
            {
                AllocConsole();
                isConsoleAllocated = true;
            }
        }

        public static void Close()
        {
            if (isConsoleAllocated)
            {
                FreeConsole();
                isConsoleAllocated = false;
            }
        }
    }
}
