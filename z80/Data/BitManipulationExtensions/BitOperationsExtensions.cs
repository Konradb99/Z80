using static z80.Data.BitManipulationExtensions.FlagsHelper;

namespace z80.Data.BitManipulationExtensions
{
    public class BitOperationsExtensions
    {
        public Flags Q { get; set; } = 0x00;


        /// <summary>
        /// Operacja logiczna AND. 
        /// </summary>
        /// <param name="a">Rejestr podawany przez użytkownika</param>
        /// <param name="b">Akumulator podawany w kodzie</param>
        /// <returns>Wartość na podstawie podanej operacji logicznej</returns>
        public byte And(byte a, byte b)
        {
            var result = (byte)(a & b);

            SetFlag(Flags.N, false);
            SetFlag(Flags.C, false);
            SetFlag(Flags.S, (result & 0x80) > 0);
            SetFlag(Flags.Z, result == 0x00);
            SetFlag(Flags.P, Parity(result));
            SetFlag(Flags.H, true);

            // Undocumented Flags
            SetFlag(Flags.X, ((result & 0x08) > 0) ? true : false); //Copy of bit 3
            SetFlag(Flags.U, ((result & 0x20) > 0) ? true : false); //Copy of bit 5
            SetQ();

            return result;
        }
        /// <summary>
        /// Operacja logiczna OR. 
        /// </summary>
        /// <param name="a">Rejestr podawany przez użytkownika</param>
        /// <param name="b">Akumulator podawany w kodzie</param>
        /// <returns>Wartość na podstawie podanej operacji logicznej</returns>
        public byte Or(byte a, byte b)
        {
            var result = (byte)(a | b);

            SetFlag(Flags.N, false);
            SetFlag(Flags.C, false);
            SetFlag(Flags.S, (result & 0x80) > 0);
            SetFlag(Flags.Z, result == 0x00);
            SetFlag(Flags.P, Parity(result));
            SetFlag(Flags.H, false);

            // Undocumented Flags
            SetFlag(Flags.X, ((result & 0x08) > 0) ? true : false); //Copy of bit 3
            SetFlag(Flags.U, ((result & 0x20) > 0) ? true : false); //Copy of bit 5
            SetQ();

            return result;
        }
        /// <summary>
        /// Operacja logiczna XOR. 
        /// </summary>
        /// <param name="a">Rejestr podawany przez użytkownika</param>
        /// <param name="b">Akumulator podawany w kodzie</param>
        /// <returns>Wartość na podstawie podanej operacji logicznej</returns>
        public byte Xor(byte a, byte b)
        {
            var result = (byte)(a ^ b);

            SetFlag(Flags.N, false);
            SetFlag(Flags.C, false);
            SetFlag(Flags.S, (result & 0x80) > 0);
            SetFlag(Flags.Z, result == 0x00);
            SetFlag(Flags.P, Parity(result));
            SetFlag(Flags.H, false);

            // Undocumented Flags
            SetFlag(Flags.X, ((result & 0x08) > 0) ? true : false); //Copy of bit 3
            SetFlag(Flags.U, ((result & 0x20) > 0) ? true : false); //Copy of bit 5
            SetQ();

            return result;
        }


        /// <summary>
        /// Operacja sprawdzania parzystości
        /// </summary>
        /// <param name="res">Wartość zwrócona z operacji logicznej</param>
        /// <returns>Wartość logiczna 0 lub 1, zależna od podanej wartości argumentu</returns>
        private static bool Parity(ushort res)
        {
            var retVal = true;

            while (res > 0)
            {
                if ((res & 0x01) == 1)
                {
                    retVal = !retVal;
                }

                res = (byte)(res >> 1);
            }

            return retVal;
        }

        private void SetQ() => Q = F;
    }
}
