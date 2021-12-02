using System;
using System.Collections.Generic;

namespace Day2
{
    public class Part1
    {
        private readonly IList<SubmarineCommand> _commands;

        public Part1(IList<SubmarineCommand> commands)
        {
            _commands = commands;
        }

        public void Solve()
        {
            var position = (x: 0, z: 0);
            foreach (var command in _commands)
            {
                switch (command.Direction)
                {
                    case SubmarineDirection.Forward:
                        position.x += command.Modifier;
                        break;
                    case SubmarineDirection.Up:
                        position.z -= command.Modifier;
                        break;
                    case SubmarineDirection.Down:
                        position.z += command.Modifier;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            
            Console.WriteLine($"Final Position: X = {position.x}, Z = {position.z}, Product = {position.x * position.z}");
        }
    }
}