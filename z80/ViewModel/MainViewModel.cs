using System;
using System.Collections.Generic;
using System.Text;
using z80.ViewModel.BaseClass;

namespace z80.ViewModel
{
    class MainViewModel : ViewModelBase
    {
        public ConsoleViewModel ConsoleVM { get; set; }

        public MainViewModel()
        {
            ConsoleVM = new ConsoleViewModel();
        }
    }
}
