using System;
using System.Collections.Generic;
using System.Text;

namespace z80.Data.z80Commands
{
    public interface IBus
    {
        bool Interrupt { get; set; }
        bool NonMaskableInterrupt { get; set; }
        IList<byte> Data { get; set; }
        IReadOnlyCollection<byte> RAM { get; }
        byte Read(ushort addr, bool ro = false);
        void Write(ushort addr, byte data);
        byte ReadPeripheral(ushort port);
        void WritePeripheral(ushort port, byte data);
    }
}
