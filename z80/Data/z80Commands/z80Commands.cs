﻿namespace z80.Data.z80Commands
{
    public class z80Commands
    {
        // Instruction   : AND r
        // Operation     : A <- A & r
        // Flags Affected: All
        private byte ANDR(byte opCode)
        {
            return 0;
        }

        // Instruction   : AND n
        // Operation     : A <- A & n
        // Flags Affected: All
        private byte ANDN(byte opCode)
        {
            return 0;
        }

        // Instruction   : OR r
        // Operation     : A <- A | r
        // Flags Affected: All
        private byte ORR(byte opCode)
        {
            return 0;
        }

        // Instruction   : OR n
        // Operation     : A <- A | n
        // Flags Affected: All
        private byte ORN(byte opCode)
        {
            return 0;
        }
    }
}
