using TicTacToe.Enums;

namespace TicTacToe.Controllers
{
    public class GameController
    {
        private readonly BoardController _boardController;
        private StateBoard playerTurn;
        public GameController()
        {
            _boardController = new BoardController();
            playerTurn = StateBoard.X;
            InitGame();
            _boardController.DrawBoard();
        }

        #region Actions
        private void InitGame()
        {
            bool endGameWinner = false;
            while(!_boardController.VerifySquaresFull() && !endGameWinner)
            {
                try
                {
                    _boardController.DrawBoard();
                    Console.WriteLine("Jogador {0:D}, sua vez! Informe o número da linha e coluna desejada para esta rodada. (Ex.: 1 1)", (int)playerTurn);
                    string coordinatesInLine = Console.ReadLine();
                    string[] coordinatesString = coordinatesInLine.Split(" ");
                    int[] coordinates = coordinatesString.Select(int.Parse).ToArray();

                    if(PlayTurn(playerTurn, coordinates[0], coordinates[1]))
                    {
                        if(VerifyWinner(playerTurn))
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
                catch(Exception)
                {
                    Console.WriteLine("Oops! O jogo apresentou falhas na última tentativa de jogada :c. Tente novamente.");
                }
            }
        }
        #endregion
        #region Methods
        public bool PlayTurn(StateBoard player, int xAxis, int yAxis)
        {
            return _boardController.Play(player, xAxis, yAxis);
        }
        public bool VerifyWinner(StateBoard player)
        {
            return (_boardController.VerifyHorizontal(player) || _boardController.VerifyVertical(player) || _boardController.VerifyDiagonal(player));
        }
        public StateBoard getWinner()
        {
            return playerTurn;
        }
        #endregion
    }
}