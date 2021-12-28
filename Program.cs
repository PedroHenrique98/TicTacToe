/*
// Author: Pedro Henrique Eugenio de Medeiros
// Email: pedro.medeiros.001@acad.pucrs.br
// Program: TicTacToe Game
// Version: 1.0
*/
using TicTacToe.Controllers;
using TicTacToe.Enums;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bem vindo ao TicTacToe 2000! O jogo já irá começar......");
            //Instanciando controller da partida
            GameController g1 = new GameController();
            //Buscando resultado da partida
            StateBoard winner = g1.getWinner();
            //Exibindo resultado da partida
            if(winner == StateBoard.Void)
                Console.WriteLine("Vish, deu velha!");
            else
                Console.WriteLine("Parabéns jogador {0}, você ganhou!!!", (int)winner);
        }
    }
}