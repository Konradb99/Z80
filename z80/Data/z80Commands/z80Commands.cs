using z80.Data.BitManipulationExtensions;
using static z80.Data.BitManipulationExtensions.FlagsHelper;

namespace z80.Data.z80Commands
{
    public class z80Commands
    {
        // CPU Registers
        // ========================================
        // General Purpose Registers
        // ========================================
        public byte A { get; set; } = 0x00;
        public Flags F { get; set; } = 0x00; //Shows CPU state in the form of bit flags
        public byte B { get; set; } = 0x00;
        public byte C { get; set; } = 0x00;
        public byte D { get; set; } = 0x00;
        public byte E { get; set; } = 0x00;
        public byte H { get; set; } = 0x00;
        public byte L { get; set; } = 0x00;

        // Instruction   : AND r
        // Operation     : A <- A & r
        // Flags Affected: All
        private byte ANDR(byte opCode)
        {
            return 0;
        }

        // Instruction   : AND n
        // Operation     : A <- A & n
        // Flags Affected: All
        private byte ANDN(byte opCode)
        {
            return 0;
        }

        // Instruction   : OR r
        // Operation     : A <- A | r
        // Flags Affected: All
        private byte ORR(byte opCode)
        {
            var bitOperationsExtensions = new BitOperationsExtensions();
            var src = opCode & 0b00000111;
            var n = ReadFromRegister(src);
            A = bitOperationsExtensions.Or(A, n);
            return 0;
        }

        // Instruction   : OR n
        // Operation     : A <- A | n
        // Flags Affected: All
        private byte ORN(byte opCode)
        {
            return 0;
        }


        // Instruction   : XOR r
        // Operation     : A <- A ^ r
        // Flags Affected: All
        private byte XORR(byte opCode)
        {
            return 0;
        }

        // Instruction   : XOR n
        // Operation     : A <- A ^ n
        // Flags Affected: All
        private byte XORN(byte opCode)
        {
            return 0;
        }


        // Instruction   : NEG
        // Operation     : A <- Twos Complement of A (negation)
        // Flags Affected: All
        private byte NEG(byte opCode)
        {
            return 0;
        }

        private byte ReadFromRegister(int src)
        {
            switch (src)
            {
                case 0: return B;
                case 1: return C;
                case 2: return D;
                case 3: return E;
                case 4: return H;
                case 5: return L;
                case 6: return (byte)F;
                case 7: return A;
                default: return 0x00;
            };
        }
    }
}
