using TicTacToe.Enums;

namespace TicTacToe.Controllers
{
    /// <summary>
    /// Classe utilizada para realizar o controle da partida
    /// </summary>
    public class GameController
    {
        /// <summary>
        /// Atributo de consulta aos métodos da classe BoardController
        /// </summary>
        private readonly BoardController _boardController;
        /// <summary>
        /// Atributo de controle para definição de qual jogador jogará a rodada atual
        /// </summary>
        private StateBoard playerTurn;
        /// <summary>
        /// Método construtor, instanciando atributos e chamando método que dá início a disputa da partida
        /// </summary>
        public GameController()
        {
            _boardController = new BoardController();
            playerTurn = StateBoard.X;
            InitGame();
            _boardController.DrawBoard();
        }

        #region Actions
        /// <summary>
        /// Realiza o comando do jogo, solicitando a jogada do próximo jogador e verificando se a partida já pode ser encerrada
        /// </summary>
        private void InitGame()
        {
            bool endGameWinner = false;
            while (!_boardController.VerifySquaresFull() && !endGameWinner)
            {
                try
                {
                    _boardController.DrawBoard();
                    Console.WriteLine("Jogador {0:D}, sua vez! Informe respectivamente o número da linha e coluna desejada para esta rodada. (Ex.: 1 1)", (int)playerTurn);
                    string? coordinatesInLine = Console.ReadLine();
                    string[] coordinatesString = String.IsNullOrEmpty(coordinatesInLine) ? new string[0] : coordinatesInLine.Split(" ");
                    int[] coordinates = coordinatesString.Select(int.Parse).ToArray();

                    if (PlayTurn(playerTurn, coordinates[0], coordinates[1]))
                    {
                        if (VerifyWinner(playerTurn))
                        {
                            endGameWinner = true;
                        }
                        else
                        {
                            playerTurn = playerTurn == StateBoard.X ? StateBoard.O : StateBoard.X;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Oops! O jogo não conseguiu realizar sua última jogada :c. Tente novamente.");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Oops! O jogo apresentou falhas na última tentativa de jogada :c. Tente novamente.");
                }
            }
        }
        #endregion
        #region Methods
        /// <summary>
        /// Chama o método da classe BoardController que realizará a jogada no Board
        /// </summary>
        /// <param name="player"></param>
        /// <param name="xAxis"></param>
        /// <param name="yAxis"></param>
        /// <returns> Retorna booleano de verificação de jogada bem sucedida </returns>
        public bool PlayTurn(StateBoard player, int xAxis, int yAxis)
        {
            return _boardController.Play(player, xAxis, yAxis);
        }
        /// <summary>
        /// Chama o método da classe BoardController que verificará se o jogador que realizou a última jogada ganhou a partida
        /// </summary>
        /// <param name="player"></param>
        /// <returns> Retorna booleano de verificação de partida vencida pelo player </returns>
        public bool VerifyWinner(StateBoard player)
        {
            return (_boardController.VerifyHorizontal(player) || _boardController.VerifyVertical(player) || _boardController.VerifyDiagonal(player));
        }
        /// <summary>
        /// Retorna o resultado final da partida
        /// </summary>
        /// <returns> Retorna se a partida foi vencida pelo Jogador 1 ou pelo Jogador 2 ou se deu empate </returns>
        public StateBoard getWinner()
        {
            if (_boardController.VerifySquaresFull())
            {
                return StateBoard.Void;
            }
            return playerTurn;
        }
        #endregion
    }
}