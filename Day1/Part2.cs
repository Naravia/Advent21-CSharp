using System;
using System.Collections.Generic;
using System.Linq;

#nullable enable

namespace Day1
{
    public class Part2
    {
        private readonly IList<Depth> _depths;

        public Part2(IList<Depth> depths)
        {
            _depths = depths;
        }

        public void Solve()
        {
            var window = new Window(_depths[0], _depths[1], _depths[2]);
            var largerMeasurements = 0;
            foreach (var depth in _depths.Skip(3))
            {
                if (window.PushDepth(depth))
                {
                    ++largerMeasurements;
                }
            }

            Console.WriteLine($"{largerMeasurements} sliding windows are larger than the previous sliding window.");
        }

        private class Window
        {
            private readonly Depth[] _window;
            private int _windowIdx;

            public Window(Depth depth1, Depth depth2, Depth depth3)
            {
                _window = new[] {depth1, depth2, depth3};
            }

            public int Sum()
            {
                return _window.Sum(d => d.Amount);
            }

            public bool PushDepth(Depth depth)
            {
                var oldSum = Sum();
                _window[_windowIdx++ % _window.Length] = depth;
                return oldSum < Sum();
            }
        }
    }
}