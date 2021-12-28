using TicTacToe.Enums;

namespace TicTacToe.Models
{
    /// <summary>
    /// Model de definição do tabuleiro
    /// </summary>
    public class Board
    {
        /// <summary>
        /// Atributo do tipo matriz de StateBoard para representar as posições do tabuleiro
        /// </summary>
        public StateBoard[,] BoardGame { get; set; }
        /// <summary>
        /// Atributo de controle de quantos turnos já foram jogados
        /// </summary>
        public int TurnsPlayed { get; set; }
        /// <summary>
        /// Construtor da classe, instanciando a matriz 3x3 com valores do tipo StateBoard.Void
        /// </summary>
        public Board()
        {
            BoardGame = new StateBoard[3, 3];
            TurnsPlayed = 0;
            for (int i = 0; i < BoardGame.GetLength(0); i++)
            {
                for (int j = 0; j < BoardGame.GetLength(1); j++)
                {
                    BoardGame[i, j] = StateBoard.Void;
                }
            }
        }
    }
}