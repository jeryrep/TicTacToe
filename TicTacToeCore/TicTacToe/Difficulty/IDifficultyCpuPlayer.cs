namespace TicTacToeCore.TicTacToe.Difficulty
{
    internal interface IDifficultyCpuPlayer
    {
        public abstract int GetNextMove(Piece[] board);
    }
}