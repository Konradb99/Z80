using System;
using System.Collections.Generic;
using System.Text;

namespace z80.Model.Data
{
    /// <summary>
    /// Klasa pojedyńczej komórki pamięci
    /// Elementy składowe:
    /// address -> Wartość HEX adresu komórki pamięci
    /// value -> Wartość bitowa przetrzymywana w danej komórce
    /// </summary>
    public class Memory
    {
        public string address { get; set; }
        public byte value { get; set; }

        public Memory(string HexAddress, byte HexValue)
        {
            this.address = HexAddress;
            this.value = HexValue;
        }
    }
}
