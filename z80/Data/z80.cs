using System.Linq;
using z80.Data.BitManipulationExtensions;
using z80.ViewModel;
using static z80.Data.BitManipulationExtensions.FlagsHelper;

namespace z80.Data
{
    public class z80
    {
        private BitOperationsExtensions _bitOperationsExtensions;
        public RegistersViewModel _vm;
        public ConsoleViewModel _cvm;

        public z80(BitOperationsExtensions bitOperationsExtensions, RegistersViewModel vm, ConsoleViewModel cvm)
        {
            _bitOperationsExtensions = bitOperationsExtensions;
            _vm = vm;
            _cvm = cvm;
        }

        // Instruction   : AND r
        // Operation     : A <- A & r
        // Flags Affected: All
        public byte ANDR(string reg)
        {
            var test = _vm.MainRegister.FirstOrDefault(x => x.address == reg);
            var acc = _vm.MainRegister.FirstOrDefault(x => x.address == "A");        
            acc.value = _bitOperationsExtensions.And(acc.value, test.value);
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
            acc.value = _bitOperationsExtensions.Or(acc.value, test.value);
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
        public byte XORR(string reg)
        {
            var test = _vm.MainRegister.FirstOrDefault(x => x.address == reg);
            var acc = _vm.MainRegister.FirstOrDefault(x => x.address == "A");
            acc.value = _bitOperationsExtensions.Xor(acc.value, test.value);
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
