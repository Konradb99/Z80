using System.ComponentModel;
using System.Windows.Data;
using z80.Data.BitManipulationExtensions;
using z80.ViewModel.BaseClass;

namespace z80.ViewModel
{
    /// <summary>
    /// ViewModel odpowiedzialny za widok konsoli
    /// </summary>
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
        /// <summary>
        /// Parametr klasy odpowiedzialny za przetwarzanie tekstu podanego przez użytkownika w konsoli
        /// </summary>
        public string ConsoleResult
        {
            get
            {
                return _consoleResult;
            }
            set
            {
                _consoleResult = value;
                z80Class.ProcessInput(_consoleResult);
                onPropertyChanged(nameof(ConsoleResult));
            }
        }
        /// <summary>
        /// Parametr klasy odpowiedzialny za przetwarzanie tekstu podanego przez użytkownika w konsoli
        /// </summary>
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
