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
            string hex = "0x" + index.ToString("X").PadLeft(4, '0');
            return hex;
        }

        internal static string[] GenerateAddressRegister(int size)
        {
            string[] array = new string[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = GenerateHex(i);
            }
            Debug.WriteLine(array);
            return array;
        }
        internal static ObservableCollection<Register> GenerateMemoryRegister(string[] AddressRegister){
            ObservableCollection<Register> Register = new ObservableCollection<Register>();
            for(int i = 0; i < AddressRegister.Length; i++)
            {
                Register.Add(new Register(AddressRegister[i], AddressRegister[i]));
            }
            return Register;
        }
    }
}
