using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALPHA02_JOGODEFUT
{
    public class Textos
    {
        public string[] textoJogo = new string[]
        {
           "--- Bem vindo ao jogo de cartas e futebol ---",
           "GOOOOOOOOOOOLLLL!!!! Do ",
           "Total de gols é de ",
           "Incrivel defesa do Goleiro!! Não foi dessa fez que vemos um Gol!",
           "Parabens! ",
           " É o(a) ganhador(a)!",
           "Infelizmente o jogador ",
           " não ganhou dessa vez!",
           "Apesar do empate, parabens aos jogadores! ",
           "Penalidade MAXIMA!",
           " É uma boa chance de tentar marcar um gol",
           "Rodada da vez : Jogador "

        };

        public void LinhaDestacada()
        {
            string linhaPontilhada = new string('*', 120);
            Console.WriteLine(linhaPontilhada.PadLeft(Console.WindowWidth / 2 + linhaPontilhada.Length / 2));
        }
        public void LinhaDestacada2()
        {
            string linhaPontilhada = new string('_', 120);
            Console.WriteLine(linhaPontilhada.PadLeft(Console.WindowWidth / 2 + linhaPontilhada.Length / 2));
        }
    }
}
