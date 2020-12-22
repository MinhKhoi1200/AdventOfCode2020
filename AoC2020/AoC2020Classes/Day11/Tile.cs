namespace AoC2020Classes.Day11
{
    public class Tile
    {
        public Tile(char inputChar)
        {
            switch (inputChar)
            {
                case 'L':
                    TileStatus = TileStatus.SeatEmpty;
                    break;
                case '#':
                    TileStatus = TileStatus.SeatOccupied;
                    break;
                case '.':
                    TileStatus = TileStatus.Floor;
                    break;
                default:
                    TileStatus = TileStatus.Unknown;
                    break;
            }

            ToBeSwapped = false;
        }

        public TileStatus TileStatus { get; set; }
        public bool ToBeSwapped { get; set; }

        public override string ToString()
        {
            return TileStatus.ToString();
        }
    }
}