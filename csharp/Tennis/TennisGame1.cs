using System;
using System.Collections.Generic;

namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private static readonly Dictionary<int, string> PointDescriptions =
            new Dictionary<int, string>
            {
                { 0, "Love" },
                { 1, "Fifteen" },
                { 2, "Thirty" },
                { 3, "Forty" }
            };

        private int player1Points = 0;
        private int player2Points = 0;
        private readonly string player1Name;
        private readonly string player2Name;

        public TennisGame1(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == this.player1Name)
            {
                player1Points += 1;
            }
            else if (playerName == this.player2Name)
            {
                player2Points += 1;
            }
            else
            {
                throw new ArgumentException(nameof(playerName));
            }
        }
        
        public string GetScore()
        {
            if (IsDeuce())
            {
                return "Deuce";
            }

            if (IsRegularTie())
            {
                return $"{PointDescriptions[player1Points]}-All";
            }

            if (IsRegularPoints())
            {
                return $"{PointDescriptions[player1Points]}-{PointDescriptions[player2Points]}";
            }

            if (IsAdvantage())
            {
                return $"Advantage {GetHighestPointsPlayerName()}";
            }

            return $"Win for {GetHighestPointsPlayerName()}";
        }

        private string GetHighestPointsPlayerName()
        {
            var highestPointsPlayerName = player1Name;

            if (player2Points > player1Points)
            {
                highestPointsPlayerName = player2Name;
            }

            return highestPointsPlayerName;
        }

        private bool IsAdvantage()
        {
            return Math.Abs(player1Points - player2Points) == 1;
        }

        private bool IsRegularPoints()
        {
            return player1Points <= 3 && player2Points <= 3;
        }

        private bool IsRegularTie()
        {
            return player1Points == player2Points;
        }

        private bool IsDeuce()
        {
            return player1Points == player2Points && player1Points >= 3;
        }
    }
}

