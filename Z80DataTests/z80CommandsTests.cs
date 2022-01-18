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

        public z80CommandsTests()
        {
            _bitOperationsExtensions = new BitOperationsExtensions();
            _vm = new RegistersViewModel();
            _cvm = new ConsoleViewModel(_vm);
            _z80Class = new z80.Data.z80(_bitOperationsExtensions, _vm, _cvm);
        }

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

        [Theory]
        [InlineData("ADD B", 5)]
        [InlineData("ADD B", 0x02)]
        public void AddRTests(string operation, byte currentRegValue)
        {
            _z80Class._vm.MainRegister.FirstOrDefault(x => x.address == "B").value = currentRegValue;
            _z80Class.ProcessInput(operation);
            Assert.Equal(currentRegValue, _z80Class._vm.MainRegister.FirstOrDefault(x => x.address == "A").value);
        }

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

        [Theory]
        [InlineData("ADD 10", 10)]
        public void AddNTests(string operation, byte expectedAccValue)
        {
            _z80Class.ProcessInput(operation);
            Assert.Equal(expectedAccValue, _z80Class._vm.MainRegister.FirstOrDefault(x => x.address == "A").value);
        }


        [Theory]
        [InlineData("LD C 7", 7)]
        public void LdTests(string operation, byte expectedRegValue)
        {
            _z80Class.ProcessInput(operation);
            Assert.Equal(expectedRegValue, _z80Class._vm.MainRegister.FirstOrDefault(x => x.address == "C").value);
        }

        [Theory]
        [InlineData("LD (HL) 10", 10)]
        public void LdHLTests(string operation, byte expectedRegValue)
        {
            string regAddress = "0x34";
            _z80Class._vm.MainRegister.FirstOrDefault(x => x.address == "H").value = 3;
            _z80Class._vm.MainRegister.FirstOrDefault(x => x.address == "L").value = 4;
            _z80Class.ProcessInput(operation);
            Assert.Equal(expectedRegValue, _z80Class._vm.MainMemory.FirstOrDefault(x => x.address == regAddress).value);
        }

        [Theory]
        [InlineData("LD (DE) 10", 10)]
        public void LdDETests(string operation, byte expectedRegValue)
        {
            string regAddress = "0x34";
            _z80Class._vm.MainRegister.FirstOrDefault(x => x.address == "D").value = 3;
            _z80Class._vm.MainRegister.FirstOrDefault(x => x.address == "E").value = 4;
            _z80Class.ProcessInput(operation);
            Assert.Equal(expectedRegValue, _z80Class._vm.MainMemory.FirstOrDefault(x => x.address == regAddress).value);
        }

        [Theory]
        [InlineData("LD (BC) 10", 10)]
        public void LdBCTests(string operation, byte expectedRegValue)
        {
            string regAddress = "0x34";
            _z80Class._vm.MainRegister.FirstOrDefault(x => x.address == "B").value = 3;
            _z80Class._vm.MainRegister.FirstOrDefault(x => x.address == "C").value = 4;
            _z80Class.ProcessInput(operation);
            Assert.Equal(expectedRegValue, _z80Class._vm.MainMemory.FirstOrDefault(x => x.address == regAddress).value);
        }
    }
}
