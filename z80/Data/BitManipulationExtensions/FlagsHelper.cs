using System;

namespace z80.Data.BitManipulationExtensions
{
    public static class FlagsHelper
    {
        /// <summary>
        /// Spis flag w rejestrach
        /// </summary>
        [Flags]
        public enum Flags
        {
            C = 1 << 0,
            N = 1 << 1,
            P = 1 << 2,
            X = 1 << 3,
            H = 1 << 4,
            U = 1 << 5,
            Z = 1 << 6,
            S = 1 << 7,
        }
        /// <summary>
        /// Definicja instacji obiektu Flags odpowiedniego rejestru
        /// </summary>
        public static Flags F { get; set; } = 0x00;

        /// <summary>
        /// Funkcja ustawiająca odpowiednią wartość dla danej flagi
        /// </summary>
        /// <param name="flag">Flaga, której ustawiamy wartość</param>
        /// <param name="value">Ustawiana wartość</param>
        /// <returns>Metoda nic nie zwraca</returns>
        public static void SetFlag(Flags flag, bool value)
        {
            if (value)
            {
                F |= flag;
            }
            else
            {
                F &= ~flag;
            }
        }
    }
}
