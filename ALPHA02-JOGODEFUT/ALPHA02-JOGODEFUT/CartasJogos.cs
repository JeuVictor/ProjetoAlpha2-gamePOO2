using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALPHA02_JOGODEFUT
{
    public class CartasJogos
    {
       public List<string> Cards = new List<string> { "Gol", "Pênalti", "Energia", "Falta", "Cartão Amarelo", "Cartão Vermelho" };
       public List<int> PontCards = new List<int> { 3, 2, 2, 1, 1, 0 };
        public List<string> CartasRodada = new List<string>();
       public List<int> ScoreDaRodada= new List<int>();
        public int CartaJogada { get; set; }
        public int ScoreCartas { get; set; }
        public bool GolRodada { get; set; }
        public bool Amarela { get; set; }
        public bool Repeticao { get; set; }
        Random Sorteio = new Random();
       
        public void SorteioCartas()
        {
            ScoreCartas = 0;
            for ( int i = 0; i < 3; i++)
            {
                Console.WriteLine("___________________________");
                CartaJogada = Sorteio.Next(6);
                CartasRodada.Add(Cards[CartaJogada]);
                ScoreDaRodada.Add(PontCards[CartaJogada]);
                ScoreCartas += PontCards[CartaJogada];
                Console.WriteLine(Cards[CartaJogada]);
                Console.WriteLine(PontCards[CartaJogada]);
            }
            if (CartasRodada[0] != CartasRodada[1] && CartasRodada[1] != CartasRodada[2])
            {
                Console.WriteLine("Score da Rodada: " + ScoreCartas);
                Console.WriteLine("___________________________");
            }
            else 
            {
                Repeticao= true;
            }
        }
        public void CartaoAmarelo() 
        {
            if (Repeticao == true && CartaJogada == 4)
            {
               
                Console.WriteLine("Cartão Amarelo!");
                this.Amarela = true;
                

            }
        }


    }
}
