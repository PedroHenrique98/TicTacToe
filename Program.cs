using TicTacToe.Controllers;
using TicTacToe.Enums;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start Project!");

            GameController g1 = new GameController();
            StateBoard winner = g1.getWinner();
            Console.WriteLine("Parabéns jogador {0}, você ganhou!!!", (int)winner);
        }
    }
}