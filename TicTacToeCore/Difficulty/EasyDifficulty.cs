using System;
using System.Windows;

namespace TicTacToeCore.Difficulty
{
    internal class EasyDifficulty
    {
        public int MakeMove(char[] board)
        {
            var randomNumberGenerator = new Random();
            int randomCell;
            do
                randomCell = randomNumberGenerator.Next(0, 9);
            while (!char.IsWhiteSpace(board[randomCell]));

            return randomCell;
        }
    }
}