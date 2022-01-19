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
    public class Register
    {
        public string address { get; set; }
        public byte value { get; set; }

        public Register(string HexAddress, byte value)
        {
            this.address = HexAddress;
            this.value = value;
        }
    }
}
