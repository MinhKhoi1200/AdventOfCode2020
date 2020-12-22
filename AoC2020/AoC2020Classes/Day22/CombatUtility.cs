using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2020Classes.Day22
{
    public class CombatUtility
    {
        public static (List<int> firstPlayerCards, List<int> secondPlayerCard) ConvertInputList(string player1,
            string player2, string[] delimiter)
        {
            var player1Cards = player1.Split(delimiter, StringSplitOptions.RemoveEmptyEntries).ToList();
            var player2Cards = player2.Split(delimiter, StringSplitOptions.RemoveEmptyEntries).ToList();

            var convertedPlayer1Cards = player1Cards.GetRange(1, player1Cards.Count - 1).Select(int.Parse).ToList();
            var convertedPlayer2Cards = player2Cards.GetRange(1, player2Cards.Count - 1).Select(int.Parse).ToList();

            return (convertedPlayer1Cards, convertedPlayer2Cards);
        }
    }
}