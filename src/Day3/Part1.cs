namespace Day3
{
    public class Part1
    {
        private readonly IList<BinaryNumber> _numbers;

        public Part1(IList<BinaryNumber> numbers)
        {
            _numbers = numbers;
        }

        public void Solve()
        {
            var length = _numbers.First().Length;
            var counters = new int[length];
            foreach (var number in _numbers)
            {
                foreach (var idx in Enumerable.Range(0, length))
                {
                    counters[idx] += number.IsBitSet(idx) ? 1 : -1;
                }
            }

            var binaryNumber = new BinaryNumber(length);
            foreach (var (counter, index) in counters.Select((c, idx) => (c, idx)))
            {
                binaryNumber.SetBit(index, counter > 0);
            }

            var (gamma, epsilon) = (binaryNumber.Mask, binaryNumber.Mask ^ (uint.MaxValue >> (32 - length)));
            Console.WriteLine($"Gamma: {gamma}, Epsilon: {epsilon}, Product: {gamma * epsilon}");
        }
    }
}