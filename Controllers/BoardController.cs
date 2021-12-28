using TicTacToe.Models;
using TicTacToe.Enums;

namespace TicTacToe.Controllers
{
    public class BoardController
    {
        private Board board;
        public BoardController()
        {
            board = new Board();
            board.BoardGame = new StateBoard[3,3];
            board.TurnsPlayed = 0;
            for (int i = 0; i < board.BoardGame.GetLength(0); i++)
            {
                for (int j = 0; j < board.BoardGame.GetLength(1); j++)
                {
                    board.BoardGame[i,j] = StateBoard.Void;
                }
            }
        }

        #region Actions
        public void DrawBoard()
        {
            Console.WriteLine("============");
            Console.WriteLine();
            for(int i = 0; i < board.BoardGame.GetLength(1); i++)
            {
                string[] line = new string[board.BoardGame.GetLength(0)];
                for(int j = 0; j < line.Length; j++)
                {
                    line[j] = board.BoardGame[i,j] != StateBoard.Void ? board.BoardGame[i,j].ToString() : " ";
                }
                Console.WriteLine(" {0} | {1} | {2}", line[0], line[1], line[2]);
                if(board.BoardGame.GetLength(1) != i+1)
                    Console.WriteLine("-----------");
            }
            Console.WriteLine();
            Console.WriteLine("============");
        }
        #endregion

        #region Methods
        public bool Play(StateBoard player, int xAxis, int yAxis)
        {
            if(board.BoardGame[xAxis,yAxis] == StateBoard.Void && !VerifySquaresFull())
            {
                board.BoardGame[xAxis,yAxis] = player;
                board.TurnsPlayed++;
                return true;
            }
            return false;
        }
        public bool VerifyHorizontal(StateBoard player)
        {
            for(int i = 0; i < board.BoardGame.GetLength(0); i++)
            {
                if(board.BoardGame[i,0] == player)
                    if(board.BoardGame[i,0] == board.BoardGame[i,1] && board.BoardGame[i,0] == board.BoardGame[i,2])
                        return true;
            }
            return false;
        }
        public bool VerifyVertical(StateBoard player)
        {
            for(int i = 0; i < board.BoardGame.GetLength(1); i++)
            {
                if(board.BoardGame[0,i] == player)
                    if(board.BoardGame[0,i] == board.BoardGame[1,i] && board.BoardGame[0,i] == board.BoardGame[2,i])
                        return true;
            }
            return false;
        }
        public bool VerifyDiagonal(StateBoard player)
        {
            if(board.BoardGame[1,1] == player)
                if((board.BoardGame[0,0] == board.BoardGame[1,1] && board.BoardGame[0,0] == board.BoardGame[2,2]) ||
                    (board.BoardGame[0,2] == board.BoardGame[1,1] && board.BoardGame[0,2] == board.BoardGame[2,0]))
                    return true;
            return false;            
        }
        public bool VerifySquaresFull()
        {
            return (board.TurnsPlayed == (board.BoardGame.GetLength(0) * board.BoardGame.GetLength(1)));
        }
        #endregion
    }
}