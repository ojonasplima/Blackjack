using System;
using System.Collections.Generic;

namespace Blackjack
{
    class Tela : Jogada
    {

        public void iniciaPartida (Jogada jogada, bool partida = true)
        {
            jogada.jogador = 1;
            jogada.quantidade1 = 0;
            jogada.quantidade2 = 0;
            jogada.partida = partida;
        }
        public void esperarJogada(Jogada jogada)
        {
            Console.Clear();
            Console.WriteLine("Jogador 1: " + jogada.quantidade1);
            Console.WriteLine("Jogador 2: " + jogada.quantidade2);
            Console.WriteLine();
            Console.Write("Jogador ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("[" + jogada.jogador + "]");
            Console.ForegroundColor = aux;
            Console.WriteLine(" Deseja um novo número? Aperte enter.");
            Console.WriteLine(" Aperte ESC se deseja passar a rodada.");
            var menu = Console.ReadKey();

            verificaInput(menu, jogada);
            Console.Clear();
            Console.WriteLine("Jogador 1: " + jogada.quantidade1);
            Console.WriteLine("Jogador 2: " + jogada.quantidade2);
            Console.WriteLine();
            checaVencedor(jogada);
        }

        public void verificaInput(ConsoleKeyInfo menu, Jogada jogada)
        {
            if (menu.Key == ConsoleKey.Enter || menu.Key == ConsoleKey.Escape)
            {
                if (menu.Key == ConsoleKey.Enter)
                {
                    int number = gerarRandom();

                    realizaJogada(jogada, number);
                    mudarJogador(jogada);

                }
                if (menu.Key == ConsoleKey.Escape)
                {
                    mudarJogador(jogada);
                    jogada.turnos++;
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
                Console.WriteLine("Jogador " + jogada.jogador + ", você é o vencedor com " + jogada.quantidade1 + " pontos!");
                jogada.partida = false;
            }
            if (jogada.quantidade2 == 21)
            {
                Console.WriteLine("Jogador " + jogada.jogador + ", você é o vencedor com " + jogada.quantidade2 + " pontos!");
                jogada.partida = false;
            }

            if (jogada.quantidade1 > 21)
            {
                Console.WriteLine("Jogador " + jogada.jogador + ", você perdeu com " + jogada.quantidade1 + " pontos! O Jogador 2 foi o vencedor.");
                jogada.partida = false;
            }
            if (jogada.quantidade2 > 21)
            {
                Console.WriteLine("Jogador " + jogada.jogador + ", você perdeu com " + jogada.quantidade2 + " pontos! O Jogador 1 foi o vencedor.");
                jogada.partida = false;
            }

            if(jogada.turnos >= 10)
            {
                if (jogada.quantidade1 > jogada.quantidade2)
                {
                    Console.WriteLine("Jogador 2, você perdeu com " + jogada.quantidade2 + " pontos! O Jogador 1 foi o vencedor.");
                    jogada.partida = false;
                }
                if (jogada.quantidade1 == jogada.quantidade2)
                {
                    Console.WriteLine("Empate!");
                    jogada.partida = false;
                }
                else
                {
                    Console.WriteLine("Jogador 1, você perdeu com " + jogada.quantidade1 + " pontos! O Jogador 2 foi o vencedor.");
                    jogada.partida = false;
                }

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

            //List<int> vs = null;
            //if (number)
            //vs.Add(number);

            return number;
        }




    }
}

