namespace Day3
{
    public class Part2
    {
        private readonly IList<BinaryNumber> _numbers;

        public Part2(IList<BinaryNumber> numbers)
        {
            _numbers = numbers;
        }

        public void Solve()
        {
            var length = _numbers.First().Length;
            IEnumerable<BinaryNumber> oxygenRange = _numbers;
            IEnumerable<BinaryNumber> co2Range = _numbers;

            var oxygenCounters = new int[length];
            var co2Counters = new int[length];
            // ReSharper disable PossibleMultipleEnumeration
            foreach (var bitIdx in Enumerable.Range(0, length))
            {
                if (oxygenRange.Count() != 1)
                {
                    oxygenCounters[bitIdx] = CountBitsForRange(oxygenRange, bitIdx);
                    oxygenRange = oxygenRange.Where(n => n.IsBitSet(bitIdx) == oxygenCounters[bitIdx] >= 0);
                }

                if (co2Range.Count() != 1)
                {
                    co2Counters[bitIdx] = CountBitsForRange(co2Range, bitIdx);
                    co2Range = co2Range.Where(n => n.IsBitSet(bitIdx) == co2Counters[bitIdx] < 0);
                }
            }
            
            var (oxygen, co2) = (oxygenRange.Single(), co2Range.Single());
            // ReSharper restore PossibleMultipleEnumeration

            Console.WriteLine($"Oxygen: {oxygen.Mask}, CO2: {co2.Mask}, Product: {oxygen.Mask * co2.Mask}");
        }

        private int CountBitsForRange(IEnumerable<BinaryNumber> range, int bitIdx)
        {
            return range.Sum(number => number.IsBitSet(bitIdx) ? 1 : -1);
        }
    }
}