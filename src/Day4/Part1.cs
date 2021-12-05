namespace Day4
{
    public class Part1
    {
        private readonly IList<int> _calls;
        private readonly IList<BingoBoard> _boards;

        public Part1(IList<int> calls, IList<BingoBoard> boards)
        {
            _calls = calls;
            _boards = boards;
        }

        public void Solve()
        {
            BingoBoard? winningBoard = null;
            var lastCall = 0;
            foreach (
                var (call, board) in
                from call in _calls
                from board in _boards
                select (call, board)
            )
            {
                // Save the last call to use in our calculation at the end.
                lastCall = call;
                
                // Call the number.
                board.Call(call);
                
                // Check if we won
                if (board.HasWon)
                {
                    Console.WriteLine("Winning Board:");
                    Console.WriteLine(board);
                    winningBoard = board;
                    break;
                }
            }
            
            if (winningBoard is null)
            {
                throw new InvalidOperationException("Nobody won.");
            }

            // Sum all the unmarked numbers
            var unmarkedSum =
                (
                    from row in winningBoard.Rows
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