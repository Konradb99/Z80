using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using z80.Model.Data;
using z80.ViewModel.BaseClass;

namespace z80.ViewModel
{
    public class RegistersViewModel : ViewModelBase
    {

        private ObservableCollection<Register> _mainRegister = new ObservableCollection<Register>();
        public ObservableCollection<Register> MainRegister
        {
            get
            {
                return _mainRegister;
            }
            set
            {
                onPropertyChanged(nameof(MainRegister));
            }
        }

        private ObservableCollection<Register> _alternativeRegister = new ObservableCollection<Register>();
        public ObservableCollection<Register> AlternativeRegister
        {
            get
            {
                return _alternativeRegister;
            }
            set
            {
                onPropertyChanged(nameof(AlternativeRegister));
            }
        }

        public RegistersViewModel()
        {
            //Generate array of main register addressess -> 1 address = 1 bit
            //Initial size 1Kb
            string[] MainRegisterAddress = AddressArray.GenerateAddressRegister(1024);
            _mainRegister = AddressArray.GenerateMemoryRegister(MainRegisterAddress);

            //Generate array of alternative register addressess -> 1 address = 1 bit
            string[] AlternativeRegisterAddress = AddressArray.GenerateAddressRegister(1024);
            _alternativeRegister = AddressArray.GenerateMemoryRegister(AlternativeRegisterAddress);
            Debug.WriteLine(_mainRegister);
        }
    }
}
