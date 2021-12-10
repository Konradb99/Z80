using System;
using z80.Data.BitManipulationExtensions;

namespace DataTests
{
    class Program
    {
        public static void Print(BitArray wrapper)
        {
            Print(wrapper.Sub(0));
        }

        public static void Print(BitArraySegment wrapper)
        {
            foreach (var val in wrapper)
            {
                Console.Write(val ? 1 : 0);
            }
            Console.WriteLine();
        }

        public static void Main(string[] args)
        {
            var data = new byte[10];
            var baw = new BitArray(data);
            baw.Sub(0).And(baw.Sub(1));
            Print(baw);
        }
    }
}
