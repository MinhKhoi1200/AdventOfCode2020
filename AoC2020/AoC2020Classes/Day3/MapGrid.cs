using System.Collections.Generic;
using System.Linq;

namespace AoC2020Classes.Day3
{
    public class MapGrid
    {
        private const char TreeSquare = '#';
        private const char OpenSquare = '.';

        public MapGrid(List<List<char>> grid)
        {
            CurrentPosition = new Node(0,0);
            Grid = grid;
        }

        public List<List<char>> Grid { get; set; }
        public int Width => Grid[0].Count;
        public int Height => Grid.Count;
        public Node CurrentPosition { get; set; }

        public int NumberOfTreesEncountered(TraversePath traversePath)
        {
            var traversedTiles = TraverseToTheBottomAndReadPositions(traversePath);

            return traversedTiles.Count(tile => tile == TreeSquare);
        }


        private List<char> TraverseToTheBottomAndReadPositions(TraversePath traversePath)
        {
            ResetCurrentPosition();
            var traversedTiles = new List<char>();
            while (!IsYPositionOutOfBound())
            {
                var currentTile = ReadCurrentPosition();
                traversedTiles.Add(currentTile);

                Traverse(traversePath);

                if (IsXPositionOutOfBound())
                {
                    WarpXPosition();
                }

            }

            return traversedTiles;
        }

        private void Traverse(TraversePath traversePath)
        {
            CurrentPosition.XPosition += traversePath.RightSteps;
            CurrentPosition.YPosition += traversePath.DownSteps;
        }

        private void ResetCurrentPosition()
        {
            CurrentPosition = new Node(0, 0);
        }

        private char ReadCurrentPosition() => Grid[CurrentPosition.YPosition][CurrentPosition.XPosition];

        private bool IsXPositionOutOfBound() => CurrentPosition.XPosition >= Width;
        private bool IsYPositionOutOfBound() => CurrentPosition.YPosition >= Height;

        private void WarpXPosition() => CurrentPosition.XPosition = CurrentPosition.XPosition % Width;
    }
}