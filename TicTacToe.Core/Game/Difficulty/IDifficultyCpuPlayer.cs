namespace TicTacToe.Core.Game.Difficulty
{
    internal interface IDifficultyCpuPlayer
    {
        public abstract int GetNextMove(Piece[] board);
    }
}