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
        /// <summary>
        /// Parametr klasy za przetrzymywanie i wyświetlanie aktualnie wykonanego rozkazu
        /// </summary>
        public string CurrentInstruction
        {
            get
            {
                return _currentInstruction;
            }
            set
            {
                if (value == _currentInstruction) return;
                _currentInstruction = value;
                OnPropertyChanged(nameof(CurrentInstruction));
            }
        }

        private string _lastInstruction = "";
        /// <summary>
        /// Parametr klasy odpowiedzialny za przetrzymywanie i wyświetlanie poprzedniego wykonanego rozkazu
        /// </summary>
        public string LastInstruction
        {
            get
            {
                return _lastInstruction;
            }
            set
            {
                _lastInstruction = value;
                OnPropertyChanged(nameof(LastInstruction));
            }
        }

        private int _instructionCounter = 0;
        /// <summary>
        /// Parametr klasy odpowiedzialny za przetrzymywanie i wyświetlanie licznika rozkazów
        /// </summary>
        public int InstructionCounter
        {
            get
            {
                return _instructionCounter;
            }
            set
            {
                _instructionCounter = value;
                OnPropertyChanged(nameof(InstructionCounter));
            }
        }

        private ObservableCollection<Memory> _mainMemory = new ObservableCollection<Memory>();
        /// <summary>
        /// Kolekcja przetrzymująca tablicę pamięci
        /// </summary>
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
        /// <summary>
        /// Kolekcja przetrzymująca rejestry procesora
        /// </summary>
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

        /// <summary>
        /// Metoda odpowiedzialna za aktualizowanie GUI po zmianie któregoś z parametrów klasy
        /// </summary>
        /// <param name="PropertyName">Nazwa zmienianego parametry</param>
        protected virtual void OnPropertyChanged(string PropertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler.Invoke(this, new PropertyChangedEventArgs(PropertyName));
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
