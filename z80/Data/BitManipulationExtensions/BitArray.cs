using System;
using System.Collections;
using System.Collections.Generic;

namespace z80.Data.BitManipulationExtensions
{
    public class BitArray : IEnumerable<bool>
    {
        private static readonly int Size = sizeof(byte) * 8;
        public byte[] Data { get; }
        public int Length => Data.Length * Size;
        public BitArray(byte[] data)
        {
            Data = data;
        }

        public bool this[int index]
        {
            get => Get(index);
            set => Set(index, value);
        }

        public bool Get(int index)
        {
            int i = index / Size;
            int b = index % Size;
            return (Data[i] & (1 << b)) > 0;
        }

        public void Set(int index, bool value)
        {
            int i = index / Size;
            int b = index % Size;
            Data[i] = value ? (byte)(Data[i] | (1 << b)) : (byte)(Data[i] & (~(1 << b)));
        }

        public void SetAll(bool value)
        {
            byte val = value ? (byte)0xFF : (byte)0;
            int l = Length;
            for (int i = 0; i < l; i++)
            {
                Data[i] = val;
            }
        }

        public void And(BitArray ba)
        {
            int l = Math.Min(Data.Length, ba.Data.Length);
            for (int i = 0; i < l; i++)
            {
                Data[i] &= ba.Data[i];
            }
        }

        public BitArraySegment Sub(int offset)
        {
            return new BitArraySegment(this, offset);
        }

        public IEnumerator<bool> GetEnumerator()
        {
            for (int i = 0; i < Data.Length; i++)
            {
                byte d = Data[i];
                for (int j = 0; j < Size; j++)
                {
                    yield return (d & 1) == 1;
                    d >>= 1;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
