using System;
using System.Collections.Generic;
using System.Linq;

namespace Day4
{
    public class Part2
    {
        private readonly IList<int> _calls;
        private readonly IList<BingoBoard> _boards;

        public Part2(IList<int> calls, IList<BingoBoard> boards)
        {
            _calls = calls;
            _boards = boards;
        }

        public void Solve()
        {
            BingoBoard? lastBoardToWin = null;
            var lastCall = 0;
            
            foreach (
                var (call, board) in
                from call in _calls
                from board in _boards
                select (call, board)
            )
            {
                // Check if this board has already won.
                if (board.HasWon)
                {
                    continue;
                }
                
                // Call the number.
                board.Call(call);
                
                // Check if we won
                if (board.HasWon)
                {
                    lastCall = call;
                    lastBoardToWin = board;
                }
            }
            
            if (lastBoardToWin is null)
            {
                throw new InvalidOperationException("Nobody won.");
            }
            
            Console.WriteLine("Last board to win:");
            Console.WriteLine(lastBoardToWin);

            // Sum all the unmarked numbers
            var unmarkedSum =
                (
                    from row in lastBoardToWin.Rows
                    where row.Marked == false
                    from number in row.Numbers
                    where number.Marked == false
                    select number.Number
                )
                .Sum();

            var product = unmarkedSum * lastCall;
            
            Console.WriteLine($"Unmarked Sum: {unmarkedSum}, Last Call: {lastCall}, Product: {product}");
        }
    }
}