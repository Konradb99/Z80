using System;
using System.Collections.Generic;
using System.Text;
using z80.Model.Data;
using z80.ViewModel.BaseClass;

namespace z80.ViewModel
{
    class MainViewModel : ViewModelBase
    {
        public ConsoleViewModel ConsoleVM { get; set; }

        public MainViewModel()
        {
            //Generate array of main register addressess -> 1address = 1bit
            //Initial size 1Kb
            string[] MainRegisterAddress = AddressArray.GenerateAddressRegister(1024);
            AddressArray.GenerateMemoryRegister(MainRegisterAddress);
            ConsoleVM = new ConsoleViewModel();
        }
    }
}
