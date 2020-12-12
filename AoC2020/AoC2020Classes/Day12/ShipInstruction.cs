using System;

namespace AoC2020Classes.Day12
{
    public class ShipInstruction
    {
        public ShipInstruction(string rawInstruction)
        {
            var test = Enum.IsDefined(typeof(ShipCommand), (int) rawInstruction[0]);
            ShipCommand = test
                ? (ShipCommand) rawInstruction[0]
                : ShipCommand.UnknownCommand;

            UnitsToMove = int.Parse(rawInstruction.Substring(1));
        }

        public override string ToString()
        {
            var units = "units";
            if (ShipCommand == ShipCommand.TurnLeft || ShipCommand == ShipCommand.TurnRight)
            {
                units = "degrees";
            }

            if (UnitsToMove < 2)
            {
                units = units.Substring(0, units.Length - 1);
            }

            return $"{ShipCommand} by {UnitsToMove} {units}";
        }

        public ShipCommand ShipCommand { get; }
        public int UnitsToMove { get; }
    }
}