using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using z80.Model.Data;
using z80.ViewModel.BaseClass;

namespace z80.ViewModel
{
    class RegistersViewModel : ViewModelBase
    {

        private ObservableCollection<Memory> _mainMemory = new ObservableCollection<Memory>();
        public ObservableCollection<Memory> MainMemory
        {
            get
            {
                return _mainMemory;
            }
            set
            {
                onPropertyChanged(nameof(_mainMemory));
            }
        }

        private ObservableCollection<Register> _mainRegister = new ObservableCollection<Register>();
        public ObservableCollection<Register> MainRegister
        {
            get
            {
                return _mainRegister;
            }
            set
            {
                onPropertyChanged(nameof(_mainRegister));
            }
        }

        public RegistersViewModel()
        {
            //Generate array of main register addressess -> 1 address = 1 bit
            //Initial size 1Kb
            byte[] MainMemory = AddressArray.GenerateAddressRegister(1024);
            _mainMemory = AddressArray.GenerateMemoryRegister(MainMemory);
            //Prepare flags of registers
            _mainRegister = new ObservableCollection<Register>{
                new Register("A", 0x00 ),
                new Register("B", 0x00 ),
                new Register("C", 0x00 ),
                new Register("D", 0x00 ),
                new Register("E", 0x00 ),
                new Register("H", 0x00 ),
                new Register("L", 0x00 )
            };
            Debug.WriteLine(_mainMemory);
        }
    }
}
