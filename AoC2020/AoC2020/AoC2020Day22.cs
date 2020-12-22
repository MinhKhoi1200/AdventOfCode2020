using System;
using System.Collections.Generic;
using AoC2020Classes.Day22;
using AoC2020Core;

namespace AoC2020
{
    public class AoC2020Day22
    {
        private static readonly string[] Delimiter = {Environment.NewLine + Environment.NewLine};

        private static readonly List<string> InputList =
            ReadInput.ConvertInputTextToStringList(@"..\..\..\Inputs\Day22InputText.txt", Delimiter);

        private static readonly (List<int> player1, List<int> player2) PlayersCards =
            CombatUtility.ConvertInputList(InputList[0], InputList[1], new[] {Environment.NewLine});

        private static readonly Combat CombatGame = new Combat(PlayersCards.player1, PlayersCards.player2);

        public static void SolvePartOne()
        {
            var score = CombatGame.Play();
            Console.WriteLine(score);
        }

        public static void SolvePartTwo()
        {
            CombatGame.PlayRecursiveBattle();
            var testOutput = CombatGame.CalculateGameWinnerScore();
            Console.WriteLine(testOutput);
        }
    }
}