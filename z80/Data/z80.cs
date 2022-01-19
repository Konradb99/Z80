using System;
using System.Linq;
using z80.Data.BitManipulationExtensions;
using z80.Model.Data;
using z80.ViewModel;

namespace z80.Data
{
    public class z80
    {
        private BitOperationsExtensions _bitOperationsExtensions;
        public RegistersViewModel _vm;
        public ConsoleViewModel _cvm;

        public z80(BitOperationsExtensions bitOperationsExtensions, RegistersViewModel vm, ConsoleViewModel cvm)
        {
            _bitOperationsExtensions = bitOperationsExtensions;
            _vm = vm;
            _cvm = cvm;
        }

        public void ProcessInput(string input)
        {

            string[] inputArray;
            try
            {
                inputArray = input.Split(' ');
                Console.WriteLine(inputArray);
                if (inputArray.Any())
                {
                    switch (inputArray[0])
                    {
                        case "XORR":
                            z80commands.XORR(inputArray[1], _vm, _bitOperationsExtensions);
                            break;
                        case "ORR":
                            z80commands.ORR(inputArray[1], _vm, _bitOperationsExtensions);
                            break;
                        case "ANDR":
                            z80commands.ANDR(inputArray[1], _vm, _bitOperationsExtensions);
                            break;
                        case "NEG":
                            z80commands.NEG(_vm);
                            break;
                        default:
                            z80commands.defaultCommand(inputArray, _vm, _cvm);
                            break;
                    }
                }
            }catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
