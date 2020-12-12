using System;

namespace AoC2020Classes.Day12
{
    public class WayPoint
    {
        public WayPoint(int northCoord, int eastCoord)
        {
            NorthCoord = northCoord;
            EastCoord = eastCoord;
        }

        public void RotateWayPointLeftRelToShip(int degrees)
        {
            if (degrees % 90 != 0) return;
            for (var i = 0; i < degrees / 90; i++)
            {
                RotateWayPointRelToShipBy90Deg(ShipCommand.TurnLeft);
            }
        }

        public void RotateWayPointRightRelToShip(int degrees)
        {
            if (degrees % 90 != 0) return;
            for (var i = 0; i < degrees / 90; i++)
            {
                RotateWayPointRelToShipBy90Deg(ShipCommand.TurnRight);
            }
        }

        public override string ToString()
        {
            var nsDirection = NorthCoord >= 0 ? "North" : "South";
            var weDirection = EastCoord >= 0 ? "East" : "West";

            return $"WayPoint - {weDirection} {Math.Abs(EastCoord)}, {nsDirection} {Math.Abs(NorthCoord)}";
        }

        public int NorthCoord { get; set; }
        public int EastCoord { get; set; }

        private void RotateWayPointRelToShipBy90Deg(ShipCommand shipCommand)
        {
            if (shipCommand != ShipCommand.TurnRight && shipCommand != ShipCommand.TurnLeft) return;
            var tempNorthCoord = NorthCoord;
            NorthCoord = shipCommand == ShipCommand.TurnLeft ? EastCoord : -EastCoord;
            EastCoord = shipCommand == ShipCommand.TurnLeft ? -tempNorthCoord : tempNorthCoord;
        }
    }
}