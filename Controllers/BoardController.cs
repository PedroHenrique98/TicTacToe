using TicTacToe.Models;
using TicTacToe.Enums;

namespace TicTacToe.Controllers
{
    /// <summary>
    /// Classe utilizada para realizar o controle do tabuleiro da partida
    /// </summary>
    public class BoardController
    {
        /// <summary>
        /// Instância do tabuleiro
        /// </summary>
        private Board board;
        /// <summary>
        /// Construtor da classe
        /// </summary>
        public BoardController()
        {
            board = new Board();
        }

        #region Actions
        /// <summary>
        /// Exibe o desenho atual do tabuleiro da partida
        /// </summary>
        public void DrawBoard()
        {
            Console.WriteLine("============");
            Console.WriteLine();
            for (int i = 0; i < board.BoardGame.GetLength(1); i++)
            {
                string[] line = new string[board.BoardGame.GetLength(0)];
                for (int j = 0; j < line.Length; j++)
                {
                    line[j] = board.BoardGame[i, j] != StateBoard.Void ? board.BoardGame[i, j].ToString() : " ";
                }
                Console.WriteLine(" {0} | {1} | {2}", line[0], line[1], line[2]);
                if (board.BoardGame.GetLength(1) != i + 1)
                    Console.WriteLine("-----------");
            }
            Console.WriteLine();
            Console.WriteLine("============");
        }
        #endregion

        #region Methods
        /// <summary>
        /// Realiza a marcação da jogada do player nas coordenadas xAxis e yAxis
        /// </summary>
        /// <param name="player"></param>
        /// <param name="xAxis"></param>
        /// <param name="yAxis"></param>
        /// <returns> Retorna booleano de controle se jogada foi bem sucedida </returns>
        public bool Play(StateBoard player, int xAxis, int yAxis)
        {
            if (board.BoardGame[xAxis, yAxis] == StateBoard.Void && !VerifySquaresFull())
            {
                board.BoardGame[xAxis, yAxis] = player;
                board.TurnsPlayed++;
                return true;
            }
            return false;
        }
        /// <summary>
        /// Verifica se o jogador player venceu o jogo através de uma linha horizontal
        /// </summary>
        /// <param name="player"></param>
        /// <returns> Retorna booleano de controle se player venceu a partida com uma linha horizontal</returns>
        public bool VerifyHorizontal(StateBoard player)
        {
            for (int i = 0; i < board.BoardGame.GetLength(0); i++)
            {
                if (board.BoardGame[i, 0] == player)
                    if (board.BoardGame[i, 0] == board.BoardGame[i, 1] && board.BoardGame[i, 0] == board.BoardGame[i, 2])
                        return true;
            }
            return false;
        }
        /// <summary>
        /// Verifica se o jogador player venceu o jogo através de uma linha vertical
        /// </summary>
        /// <param name="player"></param>
        /// <returns> Retorna booleano de controle se player venceu a partida com uma linha vertical</returns>
        public bool VerifyVertical(StateBoard player)
        {
            for (int i = 0; i < board.BoardGame.GetLength(1); i++)
            {
                if (board.BoardGame[0, i] == player)
                    if (board.BoardGame[0, i] == board.BoardGame[1, i] && board.BoardGame[0, i] == board.BoardGame[2, i])
                        return true;
            }
            return false;
        }
        /// <summary>
        /// Verifica se o jogador player venceu o jogo através de uma linha diagonal
        /// </summary>
        /// <param name="player"></param>
        /// <returns>Retorna booleano de controle se player venceu a partida com uma linha diagonal</returns>
        public bool VerifyDiagonal(StateBoard player)
        {
            if (board.BoardGame[1, 1] == player)
                if ((board.BoardGame[0, 0] == board.BoardGame[1, 1] && board.BoardGame[0, 0] == board.BoardGame[2, 2]) ||
                    (board.BoardGame[0, 2] == board.BoardGame[1, 1] && board.BoardGame[0, 2] == board.BoardGame[2, 0]))
                    return true;
            return false;
        }
        /// <summary>
        /// Verifica se o tabuleiro ja foi totalmente preenchido
        /// </summary>
        /// <returns>Retorna booleano de controle para todas as posições do tabuleiro preenchidas</returns>
        public bool VerifySquaresFull()
        {
            return (board.TurnsPlayed == (board.BoardGame.GetLength(0) * board.BoardGame.GetLength(1)));
        }
        #endregion
    }
}