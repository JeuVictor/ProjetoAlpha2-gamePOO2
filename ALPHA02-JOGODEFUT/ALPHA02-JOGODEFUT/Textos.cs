﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALPHA02_JOGODEFUT
{
    public class Textos
    {
        public const string FormatoTela = "| {0,-100} {1,3} |";
        public string linhaPontilhada = new string('*', 120);
        public const string LBordadaUp = "╔══════════════════════════════════════════════════╗";
        public const string LBordadaDown = "╚══════════════════════════════════════════════════╝";
        public string[] textoJogo = new string[]
        {
           /* 0 */ "--- Bem vindo ao jogo de cartas e futebol ---",
           /* 1 */"GOOOOOOOOOOOLLLL!!!! Do ",
           /* 2 */"Total de gols é de ",
           /* 3 */"Incrivel defesa do Goleiro!! Não foi dessa fez que vemos um Gol!",
           /* 4 */"Parabens! ",
           /* 5 */" É o(a) ganhador(a)!",
           /* 6 */"Infelizmente o jogador ",
           /* 7 */" não ganhou dessa vez!",
           /* 8 */"Apesar do empate, parabens aos jogadores! ",
           /* 9 */"Penalidade MAXIMA!",
           /* 10 */" É uma boa chance de tentar marcar um gol",
           /* 11 */" Rodada da vez : Jogador ",
           /* 12 */"Pontuação: ",
           /* 13 */"║                Jogador  {0,-23}  ║",
           /* 14 */"Energia restante: ",
           /* 15 */"║ Pontuação: {0,-37} ║",
           /* 16 */  "║ Gols marcados: {0,-34}║",
           /* 17 */  "║ Energia restante: {0,-30} ║"

        };

        public void LinhaDestacada()
        {
         
            
            Console.WriteLine(linhaPontilhada.PadLeft(Console.WindowWidth / 2 + linhaPontilhada.Length / 2));
        }
        public void LinhaDestacada2()
        {
            string linhaPontilhada = new string('_', 120);
            Console.WriteLine(linhaPontilhada.PadLeft(Console.WindowWidth / 2 + linhaPontilhada.Length / 2));
        }
       
    }
    }

