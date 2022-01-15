using System.Linq;
using System.Text;
using z80.Data.BitManipulationExtensions;
using z80.ViewModel;

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

        public void ProcessInput(string input)
        {
            var inputArray = input.Split(' ');
            if (inputArray.Any())
            {
                switch (inputArray[0])
                {
                    case "XORR":
                        XORR(inputArray[1]);
                        break;
                    case "ORR":
                        ORR(inputArray[1]);
                        break;
                    case "ANDR":
                        ANDR(inputArray[1]);
                        break;
                    default:
                        break;
                }
            }
        }

        // Instruction   : AND r
        // Operation     : A <- A & r
        // Flags Affected: All
        public byte ANDR(string reg)
        {
            var currentRegister = _vm.MainRegister.FirstOrDefault(x => x.address == reg);
            var acc = _vm.MainRegister.FirstOrDefault(x => x.address == "A");        
            acc.value = _bitOperationsExtensions.And(acc.value, currentRegister.value);
            return 0;
        }

        // Instruction   : OR r
        // Operation     : A <- A | r
        // Flags Affected: All
        public byte ORR(string reg)
        {
            var currentRegister = _vm.MainRegister.FirstOrDefault(x => x.address == reg);
            var acc = _vm.MainRegister.FirstOrDefault(x => x.address == "A");
            acc.value = _bitOperationsExtensions.Or(acc.value, currentRegister.value);
            return 0;
        }

        // Instruction   : XOR r
        // Operation     : A <- A ^ r
        // Flags Affected: All
        public byte XORR(string reg)
        {
            var currentRegister = _vm.MainRegister.FirstOrDefault(x => x.address == reg);
            var acc = _vm.MainRegister.FirstOrDefault(x => x.address == "A");
            acc.value = _bitOperationsExtensions.Xor(acc.value, currentRegister.value);
            return 0;
        }
    }
}
