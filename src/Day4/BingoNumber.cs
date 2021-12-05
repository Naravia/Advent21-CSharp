using System.Text;

namespace Day4
{
    public class BingoNumber
    {
        public BingoNumber(int number, bool marked = false)
        {
            Number = number;
            Marked = marked;
        }

        public int Number { get; }
        public bool Marked { get; set; }

        public void Deconstruct(out int number, out bool marked)
        {
            number = Number;
            marked = Marked;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(Marked ? '[' : ' ');
            sb.Append(Number.ToString("00"));
            sb.Append(Marked ? ']' : ' ');
            return sb.ToString();
        }
    }
}