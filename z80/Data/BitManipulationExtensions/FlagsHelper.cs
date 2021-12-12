using System;

namespace z80.Data.BitManipulationExtensions
{
    public static class FlagsHelper
    {
        [Flags]
        public enum Flags
        {
            C = 1 << 0,
            // Add/Subtract flag - used by the DAA instruction; set for Subtractions, cleared for Additions.
            N = 1 << 1,
            // Parity/Overflow flag - for arithmetic operations, this flag is set when overflow occurs.
            // Also usd in logical operations to indicate that the resulting parity is even
            P = 1 << 2,
            // Undocumented - holds a copy of bit 3 of the result
            X = 1 << 3,
            // Half Carry flag - set or cleared depending upon the carry/borrow status between bits 3
            // and 4 of an 8-bit arithmetic operation. Need for Binary Coded Decimal correction.
            H = 1 << 4,
            // Undocumented - holds a copy of bit 5 of the result
            U = 1 << 5,
            // Zero flag - set if the result of an arithmetic operation is zero.
            Z = 1 << 6,
            // Sign flag - stores the state of the MSB of the Accumulator (register A).
            S = 1 << 7,
        }
        public static Flags F { get; set; } = 0x00;

        public static void SetFlag(Flags flag, bool value)
        {
            if (value)
            {
                F |= flag;
            }
            else
            {
                F &= ~flag;
            }
        }
    }
}
