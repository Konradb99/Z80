using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using z80.ViewModel;

namespace z80.Model.Data.Commands
{
    public class POP
    {
        public static byte POPbc(string reg, RegistersViewModel _vm)
        {
            Register hReg = _vm.MainRegister.FirstOrDefault(x => x.address == "B");
            Register lReg = _vm.MainRegister.FirstOrDefault(x => x.address == "C");
            try
            {
                var tmpb = _vm.MainMemory[_vm.MainMemory.Count() - 1];
                var tmpc = _vm.MainMemory[_vm.MainMemory.Count() - 2];

                _vm.MainMemory.Remove(tmpb);
                _vm.MainMemory.Remove(tmpc);

                hReg.value = tmpb.value;
                lReg.value = tmpc.value;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return 0;
        }
        public static byte POPde(string reg, RegistersViewModel _vm)
        {
            Register hReg = _vm.MainRegister.FirstOrDefault(x => x.address == "D");
            Register lReg = _vm.MainRegister.FirstOrDefault(x => x.address == "E");
            try
            {
                var tmpb = _vm.MainMemory[_vm.MainMemory.Count() - 1];
                var tmpc = _vm.MainMemory[_vm.MainMemory.Count() - 2];

                _vm.MainMemory.Remove(tmpb);
                _vm.MainMemory.Remove(tmpc);

                hReg.value = tmpb.value;
                lReg.value = tmpc.value;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return 0;
        }
        public static byte POPhl(string reg, RegistersViewModel _vm)
        {
            Register hReg = _vm.MainRegister.FirstOrDefault(x => x.address == "H");
            Register lReg = _vm.MainRegister.FirstOrDefault(x => x.address == "L");
            try
            {
                var tmpb = _vm.MainMemory[_vm.MainMemory.Count() - 1];
                var tmpc = _vm.MainMemory[_vm.MainMemory.Count() - 2];

                _vm.MainMemory.Remove(tmpb);
                _vm.MainMemory.Remove(tmpc);

                hReg.value = tmpb.value;
                lReg.value = tmpc.value;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return 0;
        }
        public static byte POPaf(string reg, RegistersViewModel _vm)
        {
            Register hReg = _vm.MainRegister.FirstOrDefault(x => x.address == "A");
            Register lReg = _vm.MainRegister.FirstOrDefault(x => x.address == "F");
            try
            {
                var tmpb = _vm.MainMemory[_vm.MainMemory.Count() - 1];
                var tmpc = _vm.MainMemory[_vm.MainMemory.Count() - 2];

                _vm.MainMemory.Remove(tmpb);
                _vm.MainMemory.Remove(tmpc);

                hReg.value = tmpb.value;
                lReg.value = tmpc.value;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return 0;
        }
    }
}
