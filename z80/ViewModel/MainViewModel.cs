using System;
using System.Collections.Generic;
using System.Text;
using z80.Model.Data;
using z80.ViewModel.BaseClass;

namespace z80.ViewModel
{
    /// <summary>
    /// Podstawowy ViewModel aplikacji
    /// </summary>
    class MainViewModel : ViewModelBase
    {
        public ConsoleViewModel ConsoleVM { get; set; }
        public RegistersViewModel RegistersVM { get; set; }

        public MainViewModel()
        {
            RegistersVM = new RegistersViewModel();
            ConsoleVM = new ConsoleViewModel(RegistersVM);
        }
    }
}
