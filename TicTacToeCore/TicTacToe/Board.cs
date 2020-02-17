using TicTacToeCore.TicTacToe.Difficulty;

namespace TicTacToeCore.TicTacToe
{
    internal class Board
    {
        private readonly Piece[] _board = { Piece.Empty, Piece.Empty, Piece.Empty, Piece.Empty, Piece.Empty, Piece.Empty, Piece.Empty, Piece.Empty, Piece.Empty };
        public Piece CurrentTurn { get; private set; }
        public int LatestTurnIndex { get; private set; }
        private readonly IDifficultyCpuPlayer _cpuPlayer;

        public bool IsCellOccupied(int choice) => _board[choice] != Piece.Empty;

        public bool IsGameOver() => BoardAnalyzer.CheckGameWin(_board, SwitchPiece()) || BoardAnalyzer.CheckGameEnd(_board);

        public Piece SwitchPiece() => CurrentTurn == Piece.X ? Piece.O : Piece.X;

        public void MakeAiMove()
        {
            MakeMove(_cpuPlayer.GetNextMove(_board));
        }

        public void MakeMove(int choice)
        {
            _board[choice] = CurrentTurn;
            LatestTurnIndex = choice;
            CurrentTurn = SwitchPiece();
        }

        public Board(int difficulty)
        {
            CurrentTurn = Piece.X;
            _cpuPlayer = difficulty switch
            {
                0 => new EasyCpuPlayer(),
                1 => new MediumCpuPlayer(),
                2 => new ImpossibleCpuPlayer(),
                _ => _cpuPlayer
            };
        }
    }
}