namespace Day2;

public enum SubmarineDirection
{
    Forward,
    Up,
    Down
}

public class SubmarineCommand
{
    public SubmarineCommand(string input)
    {
        var commandArgs = input.Split(' ');
        Direction = commandArgs[0] switch
        {
            "forward" => SubmarineDirection.Forward,
            "up" => SubmarineDirection.Up,
            "down" => SubmarineDirection.Down,
            _ => throw new NotImplementedException()
        };
        Modifier = int.Parse(commandArgs[1]);
    }

    public SubmarineDirection Direction { get; set; }
    public int Modifier { get; set; }
}