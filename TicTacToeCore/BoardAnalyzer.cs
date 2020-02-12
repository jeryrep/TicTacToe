namespace TicTacToeCore
{
    internal class BoardAnalyzer
    {
        private static readonly int[,] WinConditions = new int[8, 3]
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
    }
}