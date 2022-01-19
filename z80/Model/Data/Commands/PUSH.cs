using System;
using System.Linq;
using z80.ViewModel;

namespace z80.Model.Data.Commands
{
    /// <summary>
    /// Klasa obsługująca rozkaz PUSH
    /// </summary>
    public static class PUSH
    {
        /// <summary>
        /// Rozkaz PUSH (BC)
        /// Wpisuje wartość z rejestrów B i C na górę stosu pamięci.
        /// </summary>
        /// <param name="reg">Rejestr podawany przez użytkownika</param>
        /// <param name="_vm">Instacja klasy ViewModel rejestrów</param>
        /// <returns>Zmienia odpowiednio rejestry</returns>
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
        /// <summary>
        /// Rozkaz PUSH (DE)
        /// Wpisuje wartość z rejestrów D i E na górę stosu pamięci.
        /// </summary>
        /// <param name="reg">Rejestr podawany przez użytkownika</param>
        /// <param name="_vm">Instacja klasy ViewModel rejestrów</param>
        /// <returns>Zmienia odpowiednio rejestry</returns>
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
        /// <summary>
        /// Rozkaz PUSH (HL)
        /// Wpisuje wartość z rejestrów H i L na górę stosu pamięci.
        /// </summary>
        /// <param name="reg">Rejestr podawany przez użytkownika</param>
        /// <param name="_vm">Instacja klasy ViewModel rejestrów</param>
        /// <returns>Zmienia odpowiednio rejestry</returns>
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
        /// <summary>
        /// Rozkaz PUSH (AF)
        /// Wpisuje wartość z rejestrów A i F na górę stosu pamięci.
        /// </summary>
        /// <param name="reg">Rejestr podawany przez użytkownika</param>
        /// <param name="_vm">Instacja klasy ViewModel rejestrów</param>
        /// <returns>Zmienia odpowiednio rejestry</returns>
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