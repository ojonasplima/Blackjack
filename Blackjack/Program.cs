using System;

namespace Blackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            Tela tela = new Tela();
            Jogada jogada = new Jogada();

            tela.iniciaPartida(jogada);

            while (jogada.partida == true)
            {
                tela.esperarJogada(jogada);
                if(jogada.partida == false)
                {
                    Console.WriteLine();
                    Console.WriteLine("Deseja jogar novamente? Aperte Enter ou ESC para sair.");
                    var input = Console.ReadKey();

                    if(input.Key == ConsoleKey.Escape)
                    {
                        break;
                    }
                    if(input.Key == ConsoleKey.Enter)
                    {
                        tela.iniciaPartida(jogada, true);
                    }
                }
            }
        }
    }
}
