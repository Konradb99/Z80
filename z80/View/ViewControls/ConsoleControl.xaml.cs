using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using z80.Model.Data;

namespace z80.View.ViewControls
{
    /// <summary>
    /// Logika interakcji dla klasy ConsoleControl.xaml
    /// </summary>
    public partial class ConsoleControl : UserControl
    {
        string _Result = null;
        public ConsoleControl()
        {
            InitializeComponent();
            input.Focus();
        }

        #region DependencyProperty
        public string ConsoleResult
        {
            get { return (string)GetValue(_ConsoleResultProperty); }
            set { SetValue(_ConsoleResultProperty, value);  }
        }

        public static readonly DependencyProperty _ConsoleResultProperty = DependencyProperty.Register(
            nameof(ConsoleResult),
            typeof(string),
            typeof(ConsoleControl)
            );

        public string ConsoleInput
        {
            get { return (string)GetValue(_ConsoleInputProperty); }
            set { SetValue(_ConsoleInputProperty, value); }
        }

        public static readonly DependencyProperty _ConsoleInputProperty = DependencyProperty.Register(
            nameof(ConsoleInput),
            typeof(string),
            typeof(ConsoleControl)
            );

        #endregion


        public string Open(string displayMessage)
        {
            display.Text = displayMessage;
            return _Result;
        }

        private void input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                _Result = input.Text;
                ConsoleResult = input.Text;
                _Result += "\n";
                input.Text = null;
                display.Text += _Result;
                _Result = null;
            }
        }
    }
}
