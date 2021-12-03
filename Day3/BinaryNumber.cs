using System.Collections;
using System.Linq;
using System.Text;

namespace Day3
{
    public class BinaryNumber
    {
        public int Length { get; }
        public int Mask { get; private set; }

        private int BitOffset(int offset) => Length - 1 - offset;

        public void SetBit(int bitIdx, bool value)
        {
            Mask |= (value ? 0x1 : 0x0) << (BitOffset(bitIdx));
        }

        public bool IsBitSet(int bitIdx) => (Mask & (0x1 << (BitOffset(bitIdx)))) != 0;
        
        public BinaryNumber(string line)
        {
            Length = line.Length;
            foreach (var (c, idx) in line.Select((c, idx) => (c, idx)))
            {
                SetBit(idx, c == '1');
            }
        }

        public BinaryNumber(int length)
        {
            Length = length;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"BinaryNumber (Mask={Mask}, Len={Length}): ");
            foreach (var bitIdx in Enumerable.Range(0, Length))
            {
                sb.Append(IsBitSet(bitIdx) ? "1" : "0");
            }

            return sb.ToString();
        }
    }
}