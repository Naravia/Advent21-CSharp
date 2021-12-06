namespace Day2;

public class Part2
{
    private readonly IList<SubmarineCommand> _commands;

    public Part2(IList<SubmarineCommand> commands)
    {
        _commands = commands;
    }

    public void Solve()
    {
        var position = (x: 0, z: 0, aim: 0);
        foreach (var command in _commands)
        {
            switch (command.Direction)
            {
                case SubmarineDirection.Forward:
                    position.x += command.Modifier;
                    position.z += command.Modifier * position.aim;
                    break;
                case SubmarineDirection.Up:
                    position.aim -= command.Modifier;
                    break;
                case SubmarineDirection.Down:
                    position.aim += command.Modifier;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        Console.WriteLine($"Final Position: X = {position.x}, Z = {position.z}, Product = {position.x * position.z}");
    }
}