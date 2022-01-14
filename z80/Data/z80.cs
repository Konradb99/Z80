using System.Collections.Generic;
using z80.Data.BitManipulationExtensions;
using z80.Data.z80Commands;
using static z80.Data.BitManipulationExtensions.FlagsHelper;

namespace z80.Data
{
    public class z80
    {
        public byte A { get; set; } = 0x00;
        public Flags F { get; set; } = 0x00;
        public byte B { get; set; } = 0x00;
        public byte C { get; set; } = 0x00;
        public byte D { get; set; } = 0x00;
        public byte E { get; set; } = 0x00;
        public byte H { get; set; } = 0x00;
        public byte L { get; set; } = 0x00;

        private IBus _bus = null;
        private byte _currentOpCode = 0x00;
        private byte IMP() => 0;
        private byte IMM() => 0;
        private byte REG() => 0;

        private ushort _absoluteAddress = 0x0000;
        public Dictionary<byte, Instruction> RootInstructions { get; } = new Dictionary<byte, Instruction>();
        public ushort PC { get; set; } = 0x0000;
        private byte ReadFromBus(ushort addr) => _bus.Read(addr, false);
        private BitOperationsExtensions __bitOperationsExtensions;

        public z80(BitOperationsExtensions _bitOperationsExtensions)
        {
            __bitOperationsExtensions = _bitOperationsExtensions;

            RootInstructions = new Dictionary<byte, Instruction>
            {
                { 0xF6, new Instruction("OR n", IMM, IMP, ORN, new List<int>{ 4, 3 }) },
                { 0xB0, new Instruction("OR B", IMP, IMP, ORR, new List<int>{ 4 }) },
                { 0xB1, new Instruction("OR C", IMP, IMP, ORR, new List<int>{ 4 }) },
                { 0xB2, new Instruction("OR D", IMP, IMP, ORR, new List<int>{ 4 }) },
                { 0xB3, new Instruction("OR E", IMP, IMP, ORR, new List<int>{ 4 }) },
                { 0xB4, new Instruction("OR H", IMP, IMP, ORR, new List<int>{ 4 }) },
                { 0xB5, new Instruction("OR L", IMP, IMP, ORR, new List<int>{ 4 }) },
                { 0xB7, new Instruction("OR A", IMP, IMP, ORR, new List<int>{ 4 }) },
                { 0xE6, new Instruction("AND n", IMM, IMP, ANDN, new List<int>{ 4, 3 }) },
                { 0xA0, new Instruction("AND B", IMP, IMP, ANDR, new List<int>{ 4 }) },
                { 0xA1, new Instruction("AND C", IMP, IMP, ANDR, new List<int>{ 4 }) },
                { 0xA2, new Instruction("AND D", IMP, IMP, ANDR, new List<int>{ 4 }) },
                { 0xA3, new Instruction("AND E", IMP, IMP, ANDR, new List<int>{ 4 }) },
                { 0xA4, new Instruction("AND H", IMP, IMP, ANDR, new List<int>{ 4 }) },
                { 0xA5, new Instruction("AND L", IMP, IMP, ANDR, new List<int>{ 4 }) },
                { 0xA7, new Instruction("AND A", IMP, IMP, ANDR, new List<int>{ 4 }) },
            };
        }

        public byte Fetch()
        {
            if ((RootInstructions[_currentOpCode].AddressingMode1 != IMP) &&
                (RootInstructions[_currentOpCode].AddressingMode1 != REG))
            {
                RootInstructions[_currentOpCode].AddressingMode1();
                return ReadFromBus(_absoluteAddress);
            }

            return 0x00;
        }
        // Instruction   : AND r
        // Operation     : A <- A & r
        // Flags Affected: All
        public byte ANDR(byte opCode)
        {
            return 0;
        }

        // Instruction   : AND n
        // Operation     : A <- A & n
        // Flags Affected: All
        public byte ANDN(byte opCode)
        {
            return 0;
        }

        // Instruction   : OR r
        // Operation     : A <- A | r
        // Flags Affected: All
        public byte ORR(byte opCode)
        {
            var src = opCode & 0b00000111;
            var n = ReadFromRegister(src);
            A = __bitOperationsExtensions.Or(A, n);
            return 0;
        }

        // Instruction   : OR n
        // Operation     : A <- A | n
        // Flags Affected: All
        public byte ORN(byte opCode)
        {
            var n = Fetch();
            A = __bitOperationsExtensions.Or(A, n);

            return 0;
        }


        // Instruction   : XOR r
        // Operation     : A <- A ^ r
        // Flags Affected: All
        public byte XORR(byte opCode)
        {
            return 0;
        }

        // Instruction   : XOR n
        // Operation     : A <- A ^ n
        // Flags Affected: All
        public byte XORN(byte opCode)
        {
            return 0;
        }


        // Instruction   : NEG
        // Operation     : A <- Twos Complement of A (negation)
        // Flags Affected: All
        public byte NEG(byte opCode)
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
