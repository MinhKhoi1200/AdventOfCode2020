using System;
using System.Collections.Generic;

namespace AoC2020Classes.Day12
{
    public class Ship
    {
        public Ship()
        {
            NorthCoord = 0;
            EastCoord = 0;
            ShipBearing = ShipBearing.East;
            WayPoint = new WayPoint(1, 10);
        }

        public int NorthCoord { get; set; }
        public int EastCoord { get; set; }
        public int ManhattanDistFromOrigin => Math.Abs(NorthCoord) + Math.Abs(EastCoord);
        public WayPoint WayPoint { get; set; }
        public ShipBearing ShipBearing { get; set; }

        public void ExecuteInstructionsList(IEnumerable<ShipInstruction> instructions)
        {
            foreach (var shipInstruction in instructions) ExecuteInstruction(shipInstruction);
        }

        public void ExecuteInstructionsListWithWayPoint(IEnumerable<ShipInstruction> instructions)
        {
            foreach (var shipInstruction in instructions) ExecuteInstructionWithWayPoint(shipInstruction);
        }

        public void ExecuteInstruction(ShipInstruction instruction)
        {
            switch (instruction.ShipCommand)
            {
                case ShipCommand.GoNorth:
                    NorthCoord += instruction.UnitsToMove;
                    break;
                case ShipCommand.GoSouth:
                    NorthCoord -= instruction.UnitsToMove;
                    break;
                case ShipCommand.GoEast:
                    EastCoord += instruction.UnitsToMove;
                    break;
                case ShipCommand.GoWest:
                    EastCoord -= instruction.UnitsToMove;
                    break;
                case ShipCommand.TurnLeft:
                    ShipBearing = ConvertDegreesToShipBearing((int) ShipBearing - instruction.UnitsToMove);
                    break;
                case ShipCommand.TurnRight:
                    ShipBearing = ConvertDegreesToShipBearing((int) ShipBearing + instruction.UnitsToMove);
                    break;
                case ShipCommand.GoForward:
                    GoForward(instruction.UnitsToMove);
                    break;
                case ShipCommand.UnknownCommand:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void ExecuteInstructionWithWayPoint(ShipInstruction instruction)
        {
            switch (instruction.ShipCommand)
            {
                case ShipCommand.GoNorth:
                    WayPoint.NorthCoord += instruction.UnitsToMove;
                    break;
                case ShipCommand.GoSouth:
                    WayPoint.NorthCoord -= instruction.UnitsToMove;
                    break;
                case ShipCommand.GoEast:
                    WayPoint.EastCoord += instruction.UnitsToMove;
                    break;
                case ShipCommand.GoWest:
                    WayPoint.EastCoord -= instruction.UnitsToMove;
                    break;
                case ShipCommand.TurnLeft:
                    WayPoint.RotateWayPointLeftRelToShip(instruction.UnitsToMove);
                    break;
                case ShipCommand.TurnRight:
                    WayPoint.RotateWayPointRightRelToShip(instruction.UnitsToMove);
                    break;
                case ShipCommand.GoForward:
                    NorthCoord += WayPoint.NorthCoord * instruction.UnitsToMove;
                    EastCoord += WayPoint.EastCoord * instruction.UnitsToMove;
                    break;
                case ShipCommand.UnknownCommand:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override string ToString()
        {
            var nsDirection = NorthCoord >= 0 ? "North" : "South";
            var weDirection = EastCoord >= 0 ? "East" : "West";

            return
                $"Ship - {weDirection} {Math.Abs(EastCoord)}, {nsDirection} {Math.Abs(NorthCoord)}, facing {ShipBearing}";
        }

        private ShipBearing ConvertDegreesToShipBearing(int degrees)
        {
            if (degrees % 90 != 0) return ShipBearing.Unknown;

            if (degrees < 0)
                return (ShipBearing) 360 + degrees;
            if (degrees >= 360)
                return (ShipBearing) degrees - 360;
            return (ShipBearing) degrees;
        }

        private void GoForward(int unitsToMove)
        {
            switch (ShipBearing)
            {
                case ShipBearing.North:
                    NorthCoord += unitsToMove;
                    break;
                case ShipBearing.East:
                    EastCoord += unitsToMove;
                    break;
                case ShipBearing.South:
                    NorthCoord -= unitsToMove;
                    break;
                case ShipBearing.West:
                    EastCoord -= unitsToMove;
                    break;
                case ShipBearing.Unknown:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}