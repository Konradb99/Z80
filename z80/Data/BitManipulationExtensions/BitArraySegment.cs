using System;
using System.Collections;
using System.Collections.Generic;

namespace z80.Data.BitManipulationExtensions
{
    public class BitArraySegment : IEnumerable<bool>
    {
        public BitArray Array { get; private set; }
        public int Offset { get; private set; }
        public int Count { get; private set; }

        public BitArraySegment(BitArray bit)
            : this(bit, 0)
        {
        }

        public BitArraySegment(BitArray bit, int offset)
            : this(bit, offset, bit.Length - offset)
        {
        }

        public BitArraySegment(BitArray bit, int offset, int count)
        {
            Array = bit;
            Offset = offset;
            Count = count;
        }

        public int Length => Count;

        public bool Get(int index)
        {
            return Array[Offset + index];
        }

        public void Set(int index, bool value)
        {
            Array[Offset + index] = value;
        }

        public bool this[int index]
        {
            get => Get(index);
            set => Set(index, value);
        }

        public void And(BitArraySegment bas)
        {
            int l = Math.Min(Count, bas.Count);
            for (int i = 0; i < l; i++)
            {
                this[i] &= bas[i];
            }
        }

        public void And(BitArray bas)
        {
            And(new BitArraySegment(bas));
        }

        public BitArraySegment Sub(int offset)
        {
            return new BitArraySegment(Array, Offset + offset);
        }

        public BitArraySegment Sub(int offset, int count)
        {
            return new BitArraySegment(Array, Offset + offset, count);
        }

        public BitArraySegment this[int offset, int count] => Sub(offset, count);

        public IEnumerator<bool> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
