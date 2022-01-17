using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using z80.ViewModel.BaseClass;
using System.Collections.ObjectModel;

namespace z80.Model.Data
{
    class AddressArray
    {
        internal static string GenerateHex(int index)
        {
            string hex = "0x" + index.ToString("X").PadLeft(2, '0');
            return hex;
        }

        internal static byte[] GenerateAddressRegister(int size)
        {
            byte[] array = new byte[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = (byte)i;
            }
            Debug.WriteLine(array);
            return array;
        }
        internal static string[] GenerateAddressHex(int size)
        {
            string[] array = new string[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = GenerateHex(i);
            }
            Debug.WriteLine(array);
            return array;
        }
        internal static ObservableCollection<Memory> GenerateMemoryRegister(byte[] AddressRegister){
            ObservableCollection<Memory> Register = new ObservableCollection<Memory>();
            for(int i = 0; i < AddressRegister.Length; i++)
            {
                Register.Add(new Memory(GenerateHex(Int32.Parse(AddressRegister[i].ToString())), AddressRegister[i]));
            }
            return Register;
        }
        internal static ObservableCollection<Memory> GenerateMemoryArray(string[] AddressRegister, byte[] AddressValue)
        {
            ObservableCollection<Memory> Register = new ObservableCollection<Memory>();
            for (int i = 0; i < AddressRegister.Length; i++)
            {
                Register.Add(new Memory(AddressRegister[i], AddressValue[i]));
            }
            return Register;
        }
    }
}
