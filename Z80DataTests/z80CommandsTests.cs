using System.Linq;
using Xunit;
using z80.Data.BitManipulationExtensions;
using z80.ViewModel;

namespace Z80DataTests
{
    public class z80CommandsTests
    {
        private readonly BitOperationsExtensions _bitOperationsExtensions;
        private readonly RegistersViewModel _vm;
        private readonly ConsoleViewModel _cvm;
        private readonly z80.Data.z80 _z80Class;

        /// <summary>
        /// Konstruktor klasy z80CommandsTests
        /// </summary>
        public z80CommandsTests()
        {
            _bitOperationsExtensions = new BitOperationsExtensions();
            _vm = new RegistersViewModel();
            _cvm = new ConsoleViewModel(_vm);
            _z80Class = new z80.Data.z80(_bitOperationsExtensions, _vm, _cvm);
        }


        /// <summary>
        /// Test jednostkowy rozkazu ANDR 
        /// </summary>
        /// <param name="registerValue">Wartość danego rejestru</param>
        /// <param name="currentAccValue">Aktualna wartość w akumulatorze</param>
        /// <param name="expectedAccValue">Oczekiwania wartość w akumulatorze</param>
        /// <returns>Funkcja nic nie zwraca, wykonuje daną asercje</returns>
        [Theory]
        [InlineData(0, 1, 0)]
        [InlineData(1, 0, 0)]
        [InlineData(0, 0, 0)]
        [InlineData(1, 1, 1)]
        public void AndRTests(byte registerValue, byte currentAccValue, byte expectedAccValue)
        {
            _z80Class._vm.MainRegister.FirstOrDefault(x => x.address == "A").value = currentAccValue;
            _z80Class._vm.MainRegister.FirstOrDefault(x => x.address == "B").value = registerValue;
            _z80Class.ProcessInput("ANDR B");
            Assert.Equal(expectedAccValue, _z80Class._vm.MainRegister.FirstOrDefault(x => x.address == "A").value);
        }

        /// <summary>
        /// Test jednostkowy rozkazu ORR
        /// </summary>
        /// <param name="registerValue">Wartość danego rejestru</param>
        /// <param name="currentAccValue">Aktualna wartość w akumulatorze</param>
        /// <param name="expectedAccValue">Oczekiwania wartość w akumulatorze</param>
        /// <returns>Funkcja nic nie zwraca, wykonuje daną asercje</returns>
        [Theory]
        [InlineData(0, 1, 1)]
        [InlineData(1, 0, 1)]
        [InlineData(0, 0, 0)]
        [InlineData(1, 1, 1)]
        public void OrRTests(byte registerValue, byte currentAccValue, byte expectedAccValue)
        {
            _z80Class._vm.MainRegister.FirstOrDefault(x => x.address == "A").value = currentAccValue;
            _z80Class._vm.MainRegister.FirstOrDefault(x => x.address == "B").value = registerValue;
            _z80Class.ProcessInput("ORR B");
            Assert.Equal(expectedAccValue, _z80Class._vm.MainRegister.FirstOrDefault(x => x.address == "A").value);
        }


        /// <summary>
        /// Test jednostkowy rozkazu XORR 
        /// </summary>
        /// <param name="registerValue">Wartość danego rejestru</param>
        /// <param name="currentAccValue">Aktualna wartość w akumulatorze</param>
        /// <param name="expectedAccValue">Oczekiwania wartość w akumulatorze</param>
        /// <returns>Funkcja nic nie zwraca, wykonuje daną asercje</returns>
        [Theory]
        [InlineData(0, 1, 1)]
        [InlineData(1, 0, 1)]
        [InlineData(0, 0, 0)]
        [InlineData(1, 1, 0)]
        public void XorRTests(byte registerValue, byte currentAccValue, byte expectedAccValue)
        {
            _z80Class._vm.MainRegister.FirstOrDefault(x => x.address == "A").value = currentAccValue;
            _z80Class._vm.MainRegister.FirstOrDefault(x => x.address == "B").value = registerValue;
            _z80Class.ProcessInput("XORR B");
            Assert.Equal(expectedAccValue, _z80Class._vm.MainRegister.FirstOrDefault(x => x.address == "A").value);
        }

        /// <summary>
        /// Test jednostkowy rozkazu ADDR 
        /// </summary>
        /// <param name="operation">Operacja</param>
        /// <param name="currentRegValue">Aktualna wartość danego rejestru</param>
        /// <returns>Funkcja nic nie zwraca, wykonuje daną asercje</returns>
        [Theory]
        [InlineData("ADD B", 5)]
        [InlineData("ADD B", 0x02)]
        public void AddRTests(string operation, byte currentRegValue)
        {
            _z80Class._vm.MainRegister.FirstOrDefault(x => x.address == "B").value = currentRegValue;
            _z80Class.ProcessInput(operation);
            Assert.Equal(currentRegValue, _z80Class._vm.MainRegister.FirstOrDefault(x => x.address == "A").value);
        }


        /// <summary>
        /// Test jednostkowy rozkazu ADD (HL)
        /// </summary>
        /// <param name="operation">Operacja</param>
        /// <param name="expectedAccValue">Oczekiwania wartość w akumulatorze</param>
        /// <returns>Funkcja nic nie zwraca, wykonuje daną asercje</returns>
        [Theory]
        [InlineData("ADD (HL)", 10)]
        public void AddHLTests(string operation, byte expectedAccValue)
        {
            _z80Class._vm.MainRegister.FirstOrDefault(x => x.address == "H").value = 3;
            _z80Class._vm.MainRegister.FirstOrDefault(x => x.address == "L").value = 4;
            _z80Class.ProcessInput("LD (HL) 10");
            _z80Class.ProcessInput(operation);
            Assert.Equal(expectedAccValue, _z80Class._vm.MainRegister.FirstOrDefault(x => x.address == "A").value);
        }

        /// <summary>
        /// Test jednostkowy rozkazu ADD
        /// </summary>
        /// <param name="operation">Operacja</param>
        /// <param name="expectedAccValue">Oczekiwania wartość w akumulatorze</param>
        /// <returns>Funkcja nic nie zwraca, wykonuje daną asercje</returns>
        [Theory]
        [InlineData("ADD 10", 10)]
        public void AddNTests(string operation, byte expectedAccValue)
        {
            _z80Class.ProcessInput(operation);
            Assert.Equal(expectedAccValue, _z80Class._vm.MainRegister.FirstOrDefault(x => x.address == "A").value);
        }

        /// <summary>
        /// Test jednostkowy rozkazu LD
        /// </summary>
        /// <param name="operation">Operacja</param>
        /// <param name="expectedRegValue">Oczekiwania wartość w danym rejestrze</param>
        /// <returns>Funkcja nic nie zwraca, wykonuje daną asercje</returns>
        [Theory]
        [InlineData("LD C 7", 7)]
        public void LdTests(string operation, byte expectedRegValue)
        {
            _z80Class.ProcessInput(operation);
            Assert.Equal(expectedRegValue, _z80Class._vm.MainRegister.FirstOrDefault(x => x.address == "C").value);
        }

        /// <summary>
        /// Test jednostkowy rozkazu LD (X1X2)
        /// </summary>
        /// <param name="operation">Operacja</param>
        /// <param name="reg1">rejestr X1</param>
        /// <param name="reg2">rejestr X2</param>
        /// <returns>Funkcja nic nie zwraca, wykonuje daną asercje</returns>
        [Theory]
        [InlineData("LD (HL) 10", "H", "L")]
        [InlineData("LD (DE) 10", "D", "E")]
        [InlineData("LD (BC) 10", "B", "C")]
        public void LdHLTests(string operation, string reg1, string reg2)
        {
            string regAddress = "0x34";
            _z80Class._vm.MainRegister.FirstOrDefault(x => x.address == reg1).value = 3;
            _z80Class._vm.MainRegister.FirstOrDefault(x => x.address == reg2).value = 4;
            _z80Class.ProcessInput(operation);
            Assert.Equal(10, _z80Class._vm.MainMemory.FirstOrDefault(x => x.address == regAddress).value);
        }


        /// <summary>
        /// Test jednostkowy rozkazu NEG
        /// </summary>
        /// <param name="operation">Operacja</param>
        /// <param name="actualAccValue">Aktualna wartość w akumulatorze</param>
        /// <param name="expectedAccValue">Oczekiwania wartość w akumulatorze</param>
        /// <returns>Funkcja nic nie zwraca, wykonuje daną asercje</returns>
        [Theory]
        [InlineData("NEG", 0, 255)]
        [InlineData("NEG", 255, 0)]
        public void NEGTests(string operation, byte actualAccValue, byte expectedAccValue)
        {
            _z80Class._vm.MainRegister.FirstOrDefault(x => x.address == "A").value = actualAccValue;
            _z80Class.ProcessInput(operation);
            Assert.Equal(expectedAccValue, _z80Class._vm.MainRegister.FirstOrDefault(x => x.address == "A").value);
        }

        /// <summary>
        /// Test jednostkowy rozkazu PUSH (X1X2)
        /// </summary>
        /// <param name="operation">Operacja</param>
        /// <param name="reg1">rejestr X1</param>
        /// <param name="reg2">rejestr X2</param>
        /// <returns>Funkcja nic nie zwraca, wykonuje daną asercje</returns>
        [Theory]
        [InlineData("PUSH (BC)", "B", "C")]
        [InlineData("PUSH (DE)", "D", "E")]
        [InlineData("PUSH (HL)", "H", "L")]
        [InlineData("PUSH (AF)", "A", "F")]
        public void PUSHTests(string operation, string reg1, string reg2)
        {
            _z80Class._vm.MainRegister.FirstOrDefault(x => x.address == reg1).value = 4;
            _z80Class._vm.MainRegister.FirstOrDefault(x => x.address == reg2).value = 5;
            _z80Class.ProcessInput(operation);
            Assert.Equal(0x05, _z80Class._vm.MainMemory.Last().value);
            Assert.Equal(0x04, _z80Class._vm.MainMemory[_vm.MainMemory.Count - 2].value);
        }

        /// <summary>
        /// Test jednostkowy rozkazu POP (X1X2)
        /// </summary>
        /// <param name="operation">Operacja</param>
        /// <param name="reg1">rejestr X1</param>
        /// <param name="reg2">rejestr X2</param>
        /// <returns>Funkcja nic nie zwraca, wykonuje daną asercje</returns>
        [Theory]
        [InlineData("POP (BC)", "B", "C")]
        [InlineData("POP (DE)", "D", "E")]
        [InlineData("POP (HL)", "H", "L")]
        [InlineData("POP (AF)", "A", "F")]
        public void POPTests(string operation, string reg1, string reg2)
        {
            _z80Class._vm.MainRegister.FirstOrDefault(x => x.address == reg1).value = 4;
            _z80Class._vm.MainRegister.FirstOrDefault(x => x.address == reg2).value = 5;
            _z80Class.ProcessInput(operation);
            Assert.Equal(0xFE, _z80Class._vm.MainRegister.FirstOrDefault(x => x.address == reg2).value);
            Assert.Equal(0xFF, _z80Class._vm.MainRegister.FirstOrDefault(x => x.address == reg1).value);
        }
    }
}
