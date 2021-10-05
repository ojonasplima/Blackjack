using System;

namespace Blackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            Tela tela = new Tela();
            Jogada jogada = new Jogada();
            jogada.jogador = 1;
            jogada.quantidade1 = 0;
            jogada.quantidade2 = 0;
            jogada.partida = true;

            while (jogada.partida == true)
            {
                tela.esperarJogada(jogada);
            }


        }
    }
}
