using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using z80.ViewModel;

namespace z80.Model.Data.Commands
{
    public static class LD
    {
        public static byte LDr(string reg, string value, RegistersViewModel _vm)
        {
            Register currentRegister;
            switch (reg)
            {
                //Accumulator
                case "A":
                    switch (value)
                    {
                        case "(BC)":
                            LDAbc(reg, value, _vm);
                            break;
                        case "(DE)":
                            LDAde(reg, value, _vm);
                            break;
                        default:
                            try
                            {
                                var byteValue = Convert.ToInt32(value, 16);
                                //Execute Add By Hex value
                                currentRegister = _vm.MainRegister.FirstOrDefault(x => x.address == "A");
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
                            catch (FormatException e)
                            {
                                Console.WriteLine(e);
                            }
                            currentRegister = _vm.MainRegister.FirstOrDefault(x => x.address == "A");
                            try
                            {
                                currentRegister.value = byte.Parse(value);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                            }
                            break;
                    }
                    return 0;
                default:
                    //Test second value
                    switch (value)
                    {
                        case "(HL)":
                            LDRhr(reg, value, _vm);
                            break;
                        default:
                            try
                            {
                                var byteValue = Convert.ToInt32(value, 16);
                                //Execute Add By Hex value
                                currentRegister = _vm.MainRegister.FirstOrDefault(x => x.address == reg);
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
                            catch (FormatException e)
                            {
                                Console.WriteLine(e);
                            }
                            currentRegister = _vm.MainRegister.FirstOrDefault(x => x.address == reg);
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
                    break;
            }
            return 0;
        }
        public static byte LDhr(string reg, string value, RegistersViewModel _vm)
        {
            Register hReg = _vm.MainRegister.FirstOrDefault(x => x.address == "H");
            Register lReg = _vm.MainRegister.FirstOrDefault(x => x.address == "L");
            string regAddress = "0x" + hReg.value.ToString() + lReg.value.ToString();
            Memory memCell = _vm.MainMemory.FirstOrDefault(x => x.address == regAddress);
            try
            {
                memCell.value = byte.Parse(value);
            }catch(Exception e)
            {
                Console.WriteLine(e);
            }
            return 0;
        }
        public static byte LDde(string reg, string value, RegistersViewModel _vm)
        {
            Register hReg = _vm.MainRegister.FirstOrDefault(x => x.address == "D");
            Register lReg = _vm.MainRegister.FirstOrDefault(x => x.address == "E");
            string regAddress = "0x" + hReg.value.ToString() + lReg.value.ToString();
            Memory memCell = _vm.MainMemory.FirstOrDefault(x => x.address == regAddress);
            try
            {
                memCell.value = byte.Parse(value);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return 0;
        }
        public static byte LDbc(string reg, string value, RegistersViewModel _vm)
        {
            Register hReg = _vm.MainRegister.FirstOrDefault(x => x.address == "B");
            Register lReg = _vm.MainRegister.FirstOrDefault(x => x.address == "C");
            string regAddress = "0x" + hReg.value.ToString() + lReg.value.ToString();
            Memory memCell = _vm.MainMemory.FirstOrDefault(x => x.address == regAddress);
            try
            {
                memCell.value = byte.Parse(value);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return 0;
        }
        public static byte LDRhr(string reg, string value, RegistersViewModel _vm)
        {
            Register currentReg = _vm.MainRegister.FirstOrDefault(x => x.address == reg);
            Register hReg = _vm.MainRegister.FirstOrDefault(x => x.address == "H");
            Register lReg = _vm.MainRegister.FirstOrDefault(x => x.address == "L");
            string regAddress = "0x" + hReg.value.ToString() + lReg.value.ToString();
            Memory memCell = _vm.MainMemory.FirstOrDefault(x => x.address == regAddress);
            try
            {
                currentReg.value = memCell.value;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return 0;
        }

        public static byte LDAde(string reg, string value, RegistersViewModel _vm)
        {
            Register currentReg = _vm.MainRegister.FirstOrDefault(x => x.address == "A");
            Register hReg = _vm.MainRegister.FirstOrDefault(x => x.address == "D");
            Register lReg = _vm.MainRegister.FirstOrDefault(x => x.address == "E");
            string regAddress = "0x" + hReg.value.ToString() + lReg.value.ToString();
            Memory memCell = _vm.MainMemory.FirstOrDefault(x => x.address == regAddress);
            try
            {
                currentReg.value = memCell.value;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return 0;
        }
        public static byte LDAbc(string reg, string value, RegistersViewModel _vm)
        {
            Register currentReg = _vm.MainRegister.FirstOrDefault(x => x.address == "A");
            Register hReg = _vm.MainRegister.FirstOrDefault(x => x.address == "B");
            Register lReg = _vm.MainRegister.FirstOrDefault(x => x.address == "C");
            string regAddress = "0x" + hReg.value.ToString() + lReg.value.ToString();
            Memory memCell = _vm.MainMemory.FirstOrDefault(x => x.address == regAddress);
            try
            {
                currentReg.value = memCell.value;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return 0;
        }
    }
}
