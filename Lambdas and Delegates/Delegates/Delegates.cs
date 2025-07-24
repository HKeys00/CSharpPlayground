using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public class Delegates
    {
        public delegate void Int32Printer(int x);
        public delegate void Int64Printer(long x);

        public static void PrintInt32(Int32Printer print)
        {
            int x = 5;
            print(x);
        }

        public static void PrintInt64(Int64Printer print)
        {
            long x = 5L;
            print(x);
        }
    }
}
