using System;
using System.Collections.Generic;
using System.Text;
using z80.ViewModel.BaseClass;

namespace z80.ViewModel
{
    class ConsoleViewModel : ViewModelBase
    {
        private string _consoleResult = null;
        public string ConsoleResult
        {
            get
            {
                return _consoleResult;
            }
            set
            {
                _consoleResult = value;
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
