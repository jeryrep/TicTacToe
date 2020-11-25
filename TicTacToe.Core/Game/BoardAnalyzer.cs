using System.Linq;

namespace TicTacToe.Core.Game
{
    internal class BoardAnalyzer
    {
        private static readonly int[,] WinConditions =
        {
            { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 },
            { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 },
            { 0, 4, 8 }, { 2, 4, 6 }
        };

        public static bool CheckGameWin(Piece[] grid, Piece player)
        {
            for (var i = 0; i < 8; i++)
                if (grid[WinConditions[i, 0]] == player &&
                    grid[WinConditions[i, 1]] == player &&
                    grid[WinConditions[i, 2]] == player)
                    return true;
            return false;
        }

        public static bool CheckGameEnd(Piece[] grid) => !grid.Contains(Piece.Empty);
    }
}