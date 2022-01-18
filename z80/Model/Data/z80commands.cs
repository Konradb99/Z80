using System;
using System.Collections;
using System.Linq;
using z80.Data.BitManipulationExtensions;
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
            string[] registers = new string[] { "A", "B", "C", "D", "E", "H", "L" };
            Register currentRegister;
            Register acc;
            switch (reg)
            {
                case "(HL)":
                    Commands.ADD.ADDhl(reg, _vm);
                    break;
                default:
                    if (registers.Contains(reg))
                    {
                        //Add from register
                        Commands.ADD.ADDr(reg, _vm);
                    }
                    else
                    {
                        //Add numerical value
                        Commands.ADD.ADDn(reg, _vm);                        
                    }
                    break;
            }
            return 0;
        }

        public static byte NEG(RegistersViewModel _vm)
        {
            var acc = _vm.MainRegister.FirstOrDefault(x => x.address == "A");
            byte[] tab = BitConverter.GetBytes(acc.value);
            BitArray tab2 = new BitArray(tab);
            BitArray finaltab = new BitArray(8);
            for (int i = 0; i < tab2.Length/2; i++)
            {
                if (tab2[i])
                    finaltab[i] = false;
                else
                   finaltab[i] = true;
            }
            byte final = finaltab.ToByte();
            acc.value = final;
            return 0;
        }

        public static byte ANDR(string reg,
            RegistersViewModel _vm,
            BitOperationsExtensions _bitOperationsExtensions)
        {
            var currentRegister = _vm.MainRegister.FirstOrDefault(x => x.address == reg);
            var acc = _vm.MainRegister.FirstOrDefault(x => x.address == "A");
            acc.value = _bitOperationsExtensions.And(acc.value, currentRegister.value);
            return 0;
        }

        public static byte ORR(string reg,
            RegistersViewModel _vm,
            BitOperationsExtensions _bitOperationsExtensions)
        {
            var currentRegister = _vm.MainRegister.FirstOrDefault(x => x.address == reg);
            var acc = _vm.MainRegister.FirstOrDefault(x => x.address == "A");
            acc.value = _bitOperationsExtensions.Or(acc.value, currentRegister.value);
            return 0;
        }

        public static byte XORR(string reg,
            RegistersViewModel _vm,
            BitOperationsExtensions _bitOperationsExtensions)
        {
            var currentRegister = _vm.MainRegister.FirstOrDefault(x => x.address == reg);
            var acc = _vm.MainRegister.FirstOrDefault(x => x.address == "A");
            acc.value = _bitOperationsExtensions.Xor(acc.value, currentRegister.value);
            return 0;
        }


        public static byte ToByte(this BitArray bits)
        {
            if (bits.Count != 8)
            {
                throw new ArgumentException("bits");
            }
            byte[] bytes = new byte[1];
            bits.CopyTo(bytes, 0);
            return bytes[0];
        }

    }

}
