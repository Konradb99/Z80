using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            //LD types
            switch (reg)
            {
                //BC register pair
                case "(BC)":
                    Commands.LD.LDbc(reg, value, _vm);
                    break;
                //DE register pair
                case "(DE)":
                    Commands.LD.LDde(reg, value, _vm);
                    break;
                //HL register pair
                case "(HL)":
                    Commands.LD.LDhr(reg, value, _vm);
                    break;
                //Default register -> Simple one added
                default:
                    Commands.LD.LDr(reg, value, _vm);
                    break;
            }
            return 0;
        }
        public static byte ADD(string reg, RegistersViewModel _vm)
        {
            var currentRegister = _vm.MainRegister.FirstOrDefault(x => x.address == reg);
            var acc = _vm.MainRegister.FirstOrDefault(x => x.address == "A");
            try
            {
                acc.value = (byte)(acc.value + currentRegister.value);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return 0;
        }
    }
}
