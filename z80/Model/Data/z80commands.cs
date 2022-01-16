using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using z80.ViewModel;

namespace z80.Model.Data
{
    public static class z80commands
    {
        public static byte defaultCommand(string[] inputArray, RegistersViewModel _vm)
        {
            switch (inputArray[0])
            {
                case "LD":
                    try
                    {
                        LD(inputArray[1], inputArray[2], _vm);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                    break;
                case "ADD":
                    try
                    {
                        ADD(inputArray[1], _vm);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                    break;
            }
            return 0;
        }

        public static byte LD(string reg, string value, RegistersViewModel _vm)
        {
            var currentRegister = _vm.MainRegister.FirstOrDefault(x => x.address == reg);
            Console.WriteLine(_vm.MainRegister.FirstOrDefault(x => x.address == reg));
            try
            {
                currentRegister.value = byte.Parse(value);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            return currentRegister.value;
        }
        public static byte ADD(string reg, RegistersViewModel _vm)
        {
            var register = _vm.MainRegister;
            var currentRegister = register.FirstOrDefault(x => x.address == reg);
            var acc = register.FirstOrDefault(x => x.address == "A");
            try
            {
                acc.value = (byte)(acc.value + currentRegister.value);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return currentRegister.value;
        }
    }
}
