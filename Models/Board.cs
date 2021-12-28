using TicTacToe.Enums;

namespace TicTacToe.Models
{
    public class Board
    {
        public StateBoard[,] BoardGame {get;set;}
        public int TurnsPlayed {get;set;}
        public Board()
        {
            BoardGame = new StateBoard[3,3];
            TurnsPlayed = 0;
        }
    }
}