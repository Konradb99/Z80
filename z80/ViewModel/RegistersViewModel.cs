using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Data;
using System.Windows.Threading;
using z80.Model.Data;

namespace z80.ViewModel
{
    public class RegistersViewModel : INotifyPropertyChanged
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
                OnPropertyChanged(nameof(_mainMemory));
            }
        }

        private ObservableCollection<Register> _mainRegister = new ObservableCollection<Register>();
        public ObservableCollection<Register> MainRegister
        {
            get
            {
                if(_mainRegister != null)
                {
                    CollectionViewSource.GetDefaultView(_mainRegister).Refresh();
                }
                return _mainRegister ?? (_mainRegister = new ObservableCollection<Register>());
            }
            set
            {
                if(_mainRegister == value)
                {
                    return;
                }
                _mainRegister = value;
                OnPropertyChanged(nameof(_mainRegister));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string PropertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(PropertyName));
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
