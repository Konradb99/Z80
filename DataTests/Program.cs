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

        public static void Print(BitArraySegment array)
        {
            foreach (var val in array)
            {
                Console.Write(val ? 1 : 0);
            }
            Console.WriteLine();
        }

        public static void Main(string[] args)
        {
            var data = new byte[10];
            var ba = new BitArray(data);
            ba.Sub(0).And(ba.Sub(1));
            Print(ba);
        }
    }
}
