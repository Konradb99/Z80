using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Data;
using z80.Model.Data;

namespace z80.ViewModel
{
    public class RegistersViewModel : INotifyPropertyChanged
    {

        private string _currentInstruction = "";
        public string CurrentInstruction
        {
            get
            {
                return _currentInstruction;
            }
            set
            {
                _currentInstruction = value;
                OnPropertyChanged(nameof(_currentInstruction));
            }
        }

        private string _lastInstruction = "";
        public string LastInstruction
        {
            get
            {
                return _lastInstruction;
            }
            set
            {
                _lastInstruction = value;
                OnPropertyChanged(nameof(_lastInstruction));
            }
        }

        private ObservableCollection<Memory> _mainMemory = new ObservableCollection<Memory>();
        public ObservableCollection<Memory> MainMemory
        {
            get
            {
                if (_mainMemory != null)
                {
                    CollectionViewSource.GetDefaultView(_mainMemory).Refresh();
                }
                return _mainMemory ?? (_mainMemory = new ObservableCollection<Memory>());
            }
            set
            {
                if (_mainMemory == value)
                {
                    return;
                }
                _mainMemory = value;
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
            byte[] MainMemoryValues = AddressArray.GenerateAddressRegister(256);
            string[] MainMemoryAddress = AddressArray.GenerateAddressHex(256);
            _mainMemory = AddressArray.GenerateMemoryArray(MainMemoryAddress, MainMemoryValues);
            //Prepare flags of registers
            _mainRegister = new ObservableCollection<Register>{
                new Register("A", 0x00 ),
                new Register("F", 0x00 ),
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
