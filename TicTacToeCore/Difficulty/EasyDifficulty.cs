using System;

namespace TicTacToeCore.Difficulty
{
    internal static class EasyDifficulty
    {
        public static int GetIndex(Piece[] board)
        {
            var randomNumberGenerator = new Random();
            int randomCell;
            do
                randomCell = randomNumberGenerator.Next(0, 9);
            while (board[randomCell] != Piece.Empty);

            return randomCell;
        }
    }
}