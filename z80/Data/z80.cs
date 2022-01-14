using System.Collections.Generic;
using System.Linq;
using z80.Data.BitManipulationExtensions;
using z80.Data.z80Commands;
using z80.ViewModel;
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

        private byte _currentOpCode = 0x00;

        private byte ReadFromBus(ushort addr) => _bus.Read(addr, false);
        private BitOperationsExtensions _bitOperationsExtensions;
        public RegistersViewModel _vm;

        public z80(BitOperationsExtensions bitOperationsExtensions, RegistersViewModel vm)
        {
            _bitOperationsExtensions = bitOperationsExtensions;
            _vm = vm;

        }

        // Instruction   : AND r
        // Operation     : A <- A & r
        // Flags Affected: All
        public byte ANDR(string reg)
        {
            var test = _vm.MainRegister.FirstOrDefault(x => x.address == reg);
            var acc = _vm.MainRegister.FirstOrDefault(x => x.address == "A");
            acc.value = _bitOperationsExtensions.And(A, test?.value);
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
        public byte ORR(string reg)
        {
            var test = _vm.MainRegister.FirstOrDefault(x => x.address == reg);
            var acc = _vm.MainRegister.FirstOrDefault(x => x.address == "A");
            acc.value = _bitOperationsExtensions.And(A, test?.value);
            return 0;
        }

        // Instruction   : OR n
        // Operation     : A <- A | n
        // Flags Affected: All
        public byte ORN(byte opCode)
        {
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
    }
}
