using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2020Classes.Day22
{
    public class Combat
    {
        public Combat(IReadOnlyCollection<int> playerOneCards, IReadOnlyCollection<int> playerTwoCards)
        {
            GameStates = new List<string>();
            PlayerOneCards = new Queue<int>(playerOneCards);
            PlayerTwoCards = new Queue<int>(playerTwoCards);

            PlayerOneInitial = new List<int>(playerOneCards);
            PlayerTwoInitial = new List<int>(playerTwoCards);
        }
        
        public int Play()
        {
            Init();
            while (PlayerOneCards.Any() && PlayerTwoCards.Any())
            {
                var playerOneCard = PlayerOneCards.Dequeue();
                var playerTwoCard = PlayerTwoCards.Dequeue();

                if (playerOneCard >= playerTwoCard)
                {
                    PlayerOneCards.Enqueue(playerOneCard);
                    PlayerOneCards.Enqueue(playerTwoCard);
                }
                else
                {
                    PlayerTwoCards.Enqueue(playerTwoCard);
                    PlayerTwoCards.Enqueue(playerOneCard);
                }
            }

            var winnerScore = CalculateGameWinnerScore();
            return winnerScore;
        }

        public Player PlayRecursiveBattle()
        {
            Init();
            while (PlayerOneCards.Any() && PlayerTwoCards.Any())
            {
                if (IsRoundRepeated())
                {
                    return Player.PlayerOne;
                }
                UpdateGameStates();
                
                Player roundWinner;
                var playerOneCard = PlayerOneCards.Dequeue();
                var playerTwoCard = PlayerTwoCards.Dequeue();

                if (playerOneCard <= PlayerOneCards.Count && playerTwoCard <= PlayerTwoCards.Count)
                {
                    var nextSubGamePlayerOneCards = PlayerOneCards.ToList().GetRange(0, playerOneCard);
                    var nextSubGamePlayerTwoCards = PlayerTwoCards.ToList().GetRange(0, playerTwoCard);
                    
                    var subGame = new Combat(nextSubGamePlayerOneCards, nextSubGamePlayerTwoCards);
                    roundWinner = subGame.PlayRecursiveBattle();
                }
                else
                {
                    roundWinner = playerOneCard >= playerTwoCard ? Player.PlayerOne : Player.PlayerTwo;
                }

                switch (roundWinner)
                {
                    case Player.PlayerOne:
                        PlayerOneCards.Enqueue(playerOneCard);
                        PlayerOneCards.Enqueue(playerTwoCard);
                        break;
                    case Player.PlayerTwo:
                        PlayerTwoCards.Enqueue(playerTwoCard);
                        PlayerTwoCards.Enqueue(playerOneCard);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                
            }

            var gameWinner = PlayerOneCards.Any() ? Player.PlayerOne : Player.PlayerTwo;

            return gameWinner;
        }

        public int CalculateGameWinnerScore()
        {
            if (PlayerOneCards.Any() && PlayerTwoCards.Any()) return default;
            
            var winnerScore = 0;

            var winnersCards = PlayerOneCards.Any() ? PlayerOneCards : PlayerTwoCards;

            var scoreWeight = winnersCards.Count;

            foreach (var card in winnersCards)
            {
                winnerScore += card * scoreWeight;
                scoreWeight -= 1;
            }

            return winnerScore;

        }

        public override string ToString()
        {
            var player1Cards = string.Join(", ", PlayerOneCards);
            var player2Cards = string.Join(", ", PlayerTwoCards);

            return $"1:{player1Cards}, 2:{player2Cards}";
        }

        private Queue<int> PlayerOneCards { get; set; }
        private Queue<int> PlayerTwoCards { get; set; }
        private List<int> PlayerOneInitial { get; }
        private List<int> PlayerTwoInitial { get; }
        private List<string> GameStates { get; set; }

        private void Init()
        {
            PlayerOneCards = new Queue<int>(PlayerOneInitial);
            PlayerTwoCards = new Queue<int>(PlayerTwoInitial);
        }

        private void UpdateGameStates()
        {
            GameStates.Add(ToString());
        }

        private bool IsRoundRepeated()
        {
            return GameStates.Contains(ToString());
        }
    }
}