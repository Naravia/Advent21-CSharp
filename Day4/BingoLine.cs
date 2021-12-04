using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day4
{
    public class BingoLine
    {
        public BingoLine(IList<BingoNumber> numbers)
        {
            Numbers = numbers;
        }

        public IList<BingoNumber> Numbers { get; }
        public bool Marked => Numbers.All(n => n.Marked);

        public void Deconstruct(out IList<BingoNumber> bingoNumbers, out bool marked)
        {
            bingoNumbers = Numbers;
            marked = Marked;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(Marked ? '*' : ' ');
            foreach (var bingoNumber in Numbers)
            {
                sb.Append(' ');
                sb.Append(bingoNumber);
                sb.Append(' ');
            }
            return sb.ToString();
        }
    }
}