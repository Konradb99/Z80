using System;
using System.Linq;
using z80.ViewModel;

namespace z80.Model.Data.Commands
{
    /// <summary>
    /// Klasa odpowiadająca za rozkaz ADD
    /// </summary>
    public static class ADD
    {
        /// <summary>
        /// Rozkaz ADD r
        /// Pobiera wartość z podanego rejestru i dodaje do akumulatora
        /// </summary>
        /// <param name="reg">Rejestr podawany przez użytkownika</param>
        /// <param name="_vm">Instacja klasy ViewModel rejestrów</param>
        /// <returns>Zmienia odpowiednio rejestry</returns>
        public static byte ADDr(string reg, RegistersViewModel _vm)
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
        /// <summary>
        /// Rozkaz ADD n
        /// Dodaje do akumulatora wartość liczbową podaną przez użytkownika
        /// </summary>
        /// <param name="reg">Wartość liczbowa podawana przez użytkownika</param>
        /// <param name="_vm">Instacja klasy ViewModel rejestrów</param>
        /// <returns>Zmienia odpowiednio rejestry</returns>
        public static byte ADDn(string reg, RegistersViewModel _vm)
        {
            var acc = _vm.MainRegister.FirstOrDefault(x => x.address == "A");
            //Add numerical value
            try
            {
                var byteValue = Convert.ToInt32(reg, 16);
                //Execute Add By Hex value
                try
                {
                    acc.value = byte.Parse(reg);
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

            try
            {
                acc.value = (byte)(acc.value + (byte)Int32.Parse(reg));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return 0;
        }
        /// <summary>
        /// Rozkaz ADD (HL)
        /// Dodaje do akumulatora wartość liczbową pobraną z pamięci z adresu podanego w komórkach rejestru H i L
        /// </summary>
        /// <param name="reg">Rejestry H i L wprowadzane przez użytkownika</param>
        /// <param name="_vm">Instacja klasy ViewModel rejestrów</param>
        /// <returns>Zmienia odpowiednio rejestry</returns>
        public static byte ADDhl(string reg, RegistersViewModel _vm)
        {
            Register hReg = _vm.MainRegister.FirstOrDefault(x => x.address == "H");
            Register lReg = _vm.MainRegister.FirstOrDefault(x => x.address == "L");
            Register acc = _vm.MainRegister.FirstOrDefault(x => x.address == "A");
            string regAddress = "0x" + hReg.value.ToString() + lReg.value.ToString();
            Memory memCell = _vm.MainMemory.FirstOrDefault(x => x.address == regAddress);
            try
            {
                acc.value = (byte)(acc.value + memCell.value);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return 0;
        }
    }
}
