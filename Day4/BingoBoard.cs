using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace Day4
{
    [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
    public class BingoBoard
    {
        public BingoLine[] Rows { get; }
        public BingoLine[] Columns { get; }
        public bool HasWon => Rows.Any(r => r.Marked) || Columns.Any(c => c.Marked);

        public BingoBoard(IEnumerable<string> bingoLines)
        {
            Rows = new BingoLine[5];
            if (bingoLines.Count() != 5)
            {
                throw new ArgumentException("Must have exactly 5 bingo lines.", nameof(bingoLines));
            }

            // First, build the rows from the messy input.
            foreach (var (line, idx) in bingoLines.Select((l, idx) => (l, idx)))
            {
                var numbers = line
                    .Split(' ')
                    .Where(str => str is {Length: >0})
                    .Select(int.Parse)
                    .Select(n => new BingoNumber(n))
                    .ToArray();

                if (numbers is not {Length: 5})
                {
                    throw new InvalidOperationException(
                        $"Must have 5 numbers per line, but following line had {numbers.Length} numbers: {line}");
                }

                Rows[idx] = new BingoLine(numbers);
            }

            var columns = new BingoNumber[5][];

            // Now build columns from the rows.
            foreach (
                var (row, col) in
                from row in Rows.Select((r, idx) => (row: r, idx: idx))
                from col in row.row.Numbers.Select((n, idx) => (num: n, idx: idx))
                select (row, col)
            )
            {
                // ReSharper disable ConditionIsAlwaysTrueOrFalse (Rider is lying - this condition can absolutely pass)
                if (columns[col.idx] is null)
                {
                    columns[col.idx] = new BingoNumber[5];
                }

                columns[col.idx][row.idx] = new BingoNumber(col.num.Number);
                // ReSharper restore ConditionIsAlwaysTrueOrFalse
            }

            Columns = columns
                .Select(r => new BingoLine(r))
                .ToArray();
        }

        public void Call(int call)
        {
            foreach (
                var (rowNumber, colNumber) in 
                from row in Rows
                from rowNumber in row.Numbers
                from col in Columns
                from colNumber in col.Numbers
                where rowNumber.Number == colNumber.Number
                where rowNumber.Number == call
                select (rowNumber, colNumber)
            )
            {
                rowNumber.Marked = true;
                colNumber.Marked = true;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("BingoBoard");

            foreach (var line in Columns)
            {
                sb.Append(' ');
                sb.Append(' ');
                sb.Append(' ');
                sb.Append(line.Marked ? " *" : "  ");
                sb.Append(' ');
            }

            sb.AppendLine();
            
            foreach (var line in Rows)
            {
                sb.AppendLine(line.ToString());
            }

            return sb.ToString();
        }
    }
}