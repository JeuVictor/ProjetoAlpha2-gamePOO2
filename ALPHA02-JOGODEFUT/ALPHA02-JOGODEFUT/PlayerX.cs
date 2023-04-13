using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace ALPHA02_JOGODEFUT
{
    public class PlayerX
    {
        CartasJogos Card = new CartasJogos();
        public string Nome { get; set; }
        public int Energe { get; set; }
        Random Sorteio = new Random();
        public int Gol { get; set; }
        public int Chute { get; set; }
        public int Defesa { get; set; }
        public int ContaAmarelo { get; set; }
        public int Score { get; set; }
        public int PlayerPC { get; set; }
        public int CartAmarelo { get; set; }
        public bool PC { get; set; }
        public bool Acabou { get; set; }

        public void Apresentacao()
        {
            Console.WriteLine("**********************************************");
            Console.WriteLine("--- Bem vindo ao jogo de cartas e futebol ---");
            Console.WriteLine("**********************************************");
            Console.WriteLine("Prefere jogar:");
            Console.WriteLine("1x1 - Player x Player: Digite 1");
            Console.WriteLine("1xPC - player x Computador: Digite 2");
            PlayerPC = int.Parse(Console.ReadLine());
            Console.Clear();
        }
        public void NomePlayer () 
        {
            if (string.IsNullOrEmpty(Nome))
            {            
                Energe = 10;
                Acabou= false;
                if (PC == true)
                {
                    this.Nome = "Computador";
                }
                else 
                {
                    Console.WriteLine("Digite o nome do jogador: ");
                    this.Nome = Console.ReadLine().ToUpper();
                    Console.Clear();
                }
            }
        }
        public void Pontuacao() 
        {
            Console.WriteLine("Rodada da vez : Jogador " + Nome);
            Console.WriteLine("Pontuação atual: " + Score);
            Console.WriteLine("Gols marcado: " + Gol);
            Console.WriteLine("Energia restante: " + Energe);
            Console.WriteLine("_______________________________________");
            Console.WriteLine("");
            
        }
        public void GolMarcado ()
        {
            Console.WriteLine("GOOOOOOOOOOOLLLL!!!! Do " + this.Nome);
            Console.WriteLine("°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°");
            this.Gol ++;
            Console.WriteLine("Total de gols é de " + this.Gol);
            Console.WriteLine("");
            Console.ReadKey();
        }

        public void Ganhador()
        {
            Console.Clear();
            Console.WriteLine("Parabens o jogador " + Nome + " é o ganhador!");
        }
        public void Perdedor()
        {
            Console.WriteLine("__________________________________");
            Console.WriteLine("Infelizmente o jogador " + Nome + " não ganhou dessa vez!");
        }
        public void Empate()
        {
            Console.WriteLine("_________________________________________________________");
            Console.WriteLine("Apesar do empate, parabens o jogador " + Nome);
        }
        public void encerrandoRodada()
        {
            Energe--;
            if (Energe == 0) 
            {
                Console.WriteLine();
                Acabou = true;
            }
        }
        public void Penalidade()
        {
            Console.WriteLine("Penalidade MAXIMA!");
            Console.WriteLine("O jogador {0} deverá tentar marcar um gol agora.", Nome);
            Console.WriteLine("Digite: [1] - Chute na Esquerda | | [2] Chute no Centro | | [3] Chute a direita");
            Chute = int.Parse(Console.ReadLine());
      
            Console.WriteLine("Agora a vez da defesa, o Goleiro deverá tentar defender o chute.");
            Console.WriteLine("Digite: [1] - Defesa na Esquerda | | [2] Defesa no Centro | | [3] Defesa a direita");
            Defesa = int.Parse(Console.ReadLine());

            if (Chute != Defesa)
            { GolMarcado(); }
        }
        public void JogoRodando()
        {
            Card.SorteioCartas();
            if (Card.Repeticao == false)
            {
                this.Score += Card.ScoreCartas;
            }
            Card.CartaoGol();
            if (Card.golBool == true)
            { 
                GolMarcado();
                Card.golBool = false;
            }
            Card.CartaoPenalti();
            if (Card.Penalti == true)
            {
                Penalidade();
                Card.Penalti = false;
            }
            Card.CartaoEnergia();
            if (Card.Energia == true)
            { 
                Energe++;
                Card.Energia= false;
            }

            Card.CartaoAmarelo();
            if (Card.Amarela == true) 
            {
                ContaAmarelo++;
                if (ContaAmarelo > 1) { Energe = Energe - 2; }
                else { encerrandoRodada(); }
                Card.Amarela= false;
            }
            Card.CartaoVermelho();
            if (Card.Vermelho == true) 
            {
                Energe = Energe - 2;
                Card.Vermelho = false;
            }
        }


    }
}
