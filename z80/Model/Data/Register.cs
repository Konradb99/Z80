using System;
using System.Collections.Generic;
using System.Text;

namespace z80.Model.Data
{
    public class Register
    {
        public string address { get; set; }
        public string value { get; set; }

        public Register(string HexAddress, string HexValue)
        {
            this.address = HexAddress;
            this.value = HexValue;
        }
    }
}
