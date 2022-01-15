
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
    }
}
