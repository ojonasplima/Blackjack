using System;
using System.Collections.Generic;

namespace Blackjack
{
    class Tela : Jogada
    {
        public void esperarJogada(Jogada jogada)
        {
            Console.Clear();
            Console.WriteLine("Jogador 1: " + jogada.quantidade1);
            Console.WriteLine("Jogador 2: " + jogada.quantidade2);
            Console.WriteLine("Jogador [" + jogada.jogador + "] Deseja um novo número? Aperte enter.");
            Console.WriteLine("Aperte ESC se deseja passar a rodada.");
            var menu = Console.ReadKey();

            verificaInput(menu, jogada);
            checaVencedor(jogada);
        }

        public void verificaInput(ConsoleKeyInfo menu, Jogada jogada)
        {
            if (menu.Key == ConsoleKey.Enter || menu.Key == ConsoleKey.Escape)
            {
                if (menu.Key == ConsoleKey.Enter)
                {
                    int number = gerarRandom();
                    Console.WriteLine("Seu número é: " + number);

                    realizaJogada(jogada, number);
                    mudarJogador(jogada);
                    Console.WriteLine("Jogador " + jogada.jogador + ", é a sua vez.");

                }
                if (menu.Key == ConsoleKey.Escape)
                {
                    mudarJogador(jogada);
                    Console.WriteLine("Jogador " + jogada.jogador + ", é a sua vez.");
                }
            }
            else
            {
                Console.WriteLine("Aperte Enter ou ESC para prosseguir.");
            }
        }

        public void checaVencedor(Jogada jogada)
        {
            if (jogada.quantidade1 == 21)
            {
                Console.WriteLine("Jogador " + jogador + "você é o vencedor com " + quantidade1 + " pontos!");
                partida = false;
            }
            if (jogada.quantidade2 == 21)
            {
                Console.WriteLine("Jogador " + jogador + "você é o vencedor com " + quantidade2 + " pontos!");
                partida = false;
            }

            if (jogada.quantidade1 > 21)
            {
                Console.WriteLine("Jogador " + jogador + "você perdeu com " + quantidade1 + " pontos! O Jogador 2 foi o vencedor.");
                partida = false;
            }
            if (jogada.quantidade2 > 21)
            {
                Console.WriteLine("Jogador " + jogador + "você perdeu com " + quantidade2 + " pontos! O Jogador 1 foi o vencedor.");
                partida = false;
            }
        }
        public void realizaJogada(Jogada jogada, int random)
        {
            if (jogada.jogador == 1)
            {
                
                jogada.quantidade1 = jogada.quantidade1 + random;
            }
            else
            {
                jogada.quantidade2 = jogada.quantidade2 + random;
            }
        }

        public void mudarJogador(Jogada jogada)
        {
            if (jogada.jogador == 1)
            {
                jogada.jogador = 2;
            }
            else
            {
                jogada.jogador = 1;
            }
        }

        public int gerarRandom()
        {
            Random rnd = new Random();

            int number = rnd.Next(1, 21);

            return number;
        }




    }
}

