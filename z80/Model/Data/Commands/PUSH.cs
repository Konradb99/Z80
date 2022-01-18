using System;
using System.Linq;
using z80.ViewModel;

namespace z80.Model.Data.Commands
{
    public static class PUSH
    {
        public static byte PUSHbc(string reg, RegistersViewModel _vm)
        {
            Register hReg = _vm.MainRegister.FirstOrDefault(x => x.address == "B");
            Register lReg = _vm.MainRegister.FirstOrDefault(x => x.address == "C");
            try
            {
                var str1 = "0x" + hReg.value.ToString("X").PadLeft(2, '0');
                var str2 = "0x" + lReg.value.ToString("X").PadLeft(2, '0');
                _vm.MainMemory.Add(new Memory(str1, hReg.value));
                _vm.MainMemory.Add(new Memory(str2, lReg.value));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return 0;
        }

        public static byte PUSHde(string reg, RegistersViewModel _vm)
        {
            Register hReg = _vm.MainRegister.FirstOrDefault(x => x.address == "D");
            Register lReg = _vm.MainRegister.FirstOrDefault(x => x.address == "E");
            try
            {
                var str1 = "0x" + hReg.value.ToString("X").PadLeft(2, '0');
                var str2 = "0x" + lReg.value.ToString("X").PadLeft(2, '0');
                _vm.MainMemory.Add(new Memory(str1, hReg.value));
                _vm.MainMemory.Add(new Memory(str2, lReg.value));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return 0;
        }

        public static byte PUSHhl(string reg, RegistersViewModel _vm)
        {
            Register hReg = _vm.MainRegister.FirstOrDefault(x => x.address == "H");
            Register lReg = _vm.MainRegister.FirstOrDefault(x => x.address == "L");
            try
            {
                var str1 = "0x" + hReg.value.ToString("X").PadLeft(2, '0');
                var str2 = "0x" + lReg.value.ToString("X").PadLeft(2, '0');
                _vm.MainMemory.Add(new Memory(str1, hReg.value));
                _vm.MainMemory.Add(new Memory(str2, lReg.value));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return 0;
        }

        public static byte PUSHaf(string reg, RegistersViewModel _vm)
        {
            Register hReg = _vm.MainRegister.FirstOrDefault(x => x.address == "A");
            Register lReg = _vm.MainRegister.FirstOrDefault(x => x.address == "F");
            try
            {
                var str1 = "0x" + hReg.value.ToString("X").PadLeft(2, '0');
                var str2 = "0x" + lReg.value.ToString("X").PadLeft(2, '0');
                _vm.MainMemory.Add(new Memory(str1, hReg.value));
                _vm.MainMemory.Add(new Memory(str2, lReg.value));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return 0;
        }
    }
}