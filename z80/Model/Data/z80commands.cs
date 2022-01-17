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
            //Check if input in hex
            try
            {
                var byteValue = Convert.ToInt32(value, 16);
                //Execute Add By Hex value

            }catch(FormatException e)
            {
                Console.WriteLine(e);
            }
            var currentRegister = _vm.MainRegister.FirstOrDefault(x => x.address == reg);
            Console.WriteLine(_vm.MainRegister.FirstOrDefault(x => x.address == reg));
            try
            {
                currentRegister.value = byte.Parse(value);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
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
