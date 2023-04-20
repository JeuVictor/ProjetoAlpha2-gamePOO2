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
        public List<int> ScoreDaRodada = new List<int>();
        public int CartaJogada { get; set; }
        public int ScoreCartas { get; set; }
        public bool Amarela { get; set; }
        public bool Vermelho { get; set; }
        public bool Energia { get; set; }
        public bool Penalti { get; set; }
        public bool golBool { get; set; }
        public bool Repeticao { get; set; }
        public const string LBordadaAcima = "╔═══════════════════════════════╗";
        public const string LBordadaAbaixo = "╚═══════════════════════════════╝";
        Random Sorteio = new Random();

        public void BordaCima()
        {
            Console.WriteLine("");
            Console.WriteLine(LBordadaAcima);
            
            // Console.WriteLine("║                                 ║");
            // Console.WriteLine("║      Texto com bordas          ║");
            // Console.WriteLine("║                                 ║");
            // Console.WriteLine("╚═══════════════════════════════╝");


        }
        public void BordaBaixo()
        {
            Console.WriteLine(LBordadaAbaixo);
            Console.WriteLine("");
            
        }
        public void SorteioCartas()
        {
            CartasRodada.Clear();
            ScoreDaRodada.Clear();
            ScoreCartas = 0;
            BordaCima();
            for (int i = 0; i < 3; i++)
            {

                CartaJogada = Sorteio.Next(6);
                CartasRodada.Add(Cards[CartaJogada]);
                ScoreDaRodada.Add(PontCards[CartaJogada]);
                ScoreCartas += PontCards[CartaJogada];
                string CartaDaVez = Cards[CartaJogada];
                const string formatoCarta = "║ {0,-21}Pts: {1,3} ║";
               string Pontos = $"{PontCards[CartaJogada]}";
                string linhaCarta = string.Format(formatoCarta, CartaDaVez, Pontos).PadRight(LBordadaAcima.Length - 2); 
                Console.WriteLine(linhaCarta);
                Console.ReadKey();
            
            }
            BordaBaixo();
            if (CartasRodada[0] == CartasRodada[1] && CartasRodada[1] == CartasRodada[2])
            {
                Repeticao = true;
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                BordaCima();
               // Console.WriteLine("║ Score da Rodada: " + ScoreCartas);
                Console.WriteLine($"║ Score da Rodada: {ScoreCartas.ToString().PadRight(13)}║");
                BordaBaixo();
            }
        }

        public void CartaoAmarelo()
        {
            if (Repeticao == true && CartaJogada == 4)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
                BordaCima();
                Console.WriteLine("Cartão Amarelo!");
                BordaBaixo();
                this.Amarela = true;
                Repeticao = false;
                Console.ResetColor();
            }
        }
        public void CartaoVermelho()
        {
            if (Repeticao == true && CartaJogada == 5)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
                BordaCima();
                Console.WriteLine("Cartão Vermelho!");
                Console.WriteLine(" O jogador Perdeu 2 energias!  ");
                BordaBaixo();
                this.Vermelho = true;
                Repeticao = false;
                Console.ResetColor();
            }
        }
        public void CartaoEnergia()
        {
            if (Repeticao == true && CartaJogada == 2)
            {
                BordaCima();
                Console.WriteLine("Energia extra!");
                BordaBaixo();
                this.Energia = true;
                Repeticao = false;
                Console.ResetColor();
            }
        }
        public void CartaoPenalti()
        {
            if (Repeticao == true && CartaJogada == 1)
            {
                BordaCima();
                Console.WriteLine("Penalti");
                BordaBaixo(); ;
                this.Penalti = true;
                Repeticao = false;
                Console.ResetColor();
            }
        }
        public void CartaoGol()
        {
            if (Repeticao == true && CartaJogada == 0)
            {
                BordaCima();
                Console.WriteLine("Gol");
                BordaBaixo();
                this.golBool = true;
                Repeticao = false;
                Console.ResetColor();
            }
        }
        public void CartaoFalta()
        {
            if (Repeticao == true && CartaJogada == 3)
            {
                BordaCima();
                Console.WriteLine("Falta!! Perdeu uma rodada");
                Repeticao = false;
                BordaBaixo();
                Console.ResetColor();
            }
        }

    }
}
