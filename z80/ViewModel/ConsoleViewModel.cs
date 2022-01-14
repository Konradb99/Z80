using z80.Data.BitManipulationExtensions;
using z80.ViewModel.BaseClass;

namespace z80.ViewModel
{
    public class ConsoleViewModel : ViewModelBase
    {
        private string _consoleResult = null;
        public RegistersViewModel _registersViewModel;
        public Data.z80 z80Class;
        public BitOperationsExtensions bitOperationsExtensions = new BitOperationsExtensions();
        public ConsoleViewModel(RegistersViewModel registersViewModel)
        {
            _registersViewModel = registersViewModel;

            z80Class = new Data.z80(bitOperationsExtensions, _registersViewModel, this);
        }
        public string ConsoleResult
        {
            get
            {
                return _consoleResult;
            }
            set
            {
                _consoleResult = value;
                z80Class.XORR(_consoleResult);
                onPropertyChanged(nameof(_consoleResult));
            }
        }

        private string _consoleInput = null;
        public string ConsoleInput
        {
            get
            {
                return _consoleInput;
            }
            set
            {
                _consoleInput = value;
                onPropertyChanged(nameof(_consoleInput));
            }
        }
    }
}
