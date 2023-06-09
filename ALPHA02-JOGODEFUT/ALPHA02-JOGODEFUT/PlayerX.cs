﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace ALPHA02_JOGODEFUT
{
    public class PlayerX : Textos
    {
        
        CartasJogos Card = new CartasJogos();
        public string Nome { get; set; }
        public int NumPlayer { get; set; }
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
        public bool PenaltiChute { get; set; }
        public bool PenaltiDefesa { get; set; }

        public void Reset()
        {
            Nome = "";
            NumPlayer = 0;
            Energe = 10;
            Gol = 0;
            Chute = 0;
            Defesa = 0;
            ContaAmarelo = 0;
            Score = 0;
            PlayerPC = 0;
            CartAmarelo = 0;
            PC = false;
            Acabou = false;
            PenaltiChute = false;
            PenaltiDefesa = false;

        }
        public void Cabecario ()
        {
          
            Console.Clear();
            string TextoCentralizado = textoJogo[11] + Nome;

            // calcula o tamanho do espaço disponível entre as bordas
            int tamanhoEspacoDisponivel = LBordadaUp.Length - 2;

            // calcula o tamanho do texto centralizado
            int tamanhoTextoCentralizado = TextoCentralizado.Length;

            // calcula a quantidade de espaços em branco que precisa ser adicionada em cada lado do texto centralizado
            int espacosEmBranco = (tamanhoEspacoDisponivel - tamanhoTextoCentralizado) / 2;

            // concatena o texto centralizado com os espaços em branco
            string textoX = "║";
            string textoZ = "║";

            string textoFinal = textoX+ TextoCentralizado.PadLeft(espacosEmBranco + tamanhoTextoCentralizado).PadRight(tamanhoEspacoDisponivel) +textoZ;
            Console.WriteLine(LBordadaUp.PadLeft(Console.WindowWidth / 2 + LBordadaUp.Length / 2));
            Console.WriteLine(textoFinal.PadLeft(Console.WindowWidth / 2 + textoFinal.Length / 2) );
            Console.WriteLine(LBordadaDown.PadLeft(Console.WindowWidth / 2 + LBordadaDown.Length / 2));

        }

        public void Apresentacao()
        {
            Console.WriteLine(LBordadaUp.PadLeft(Console.WindowWidth / 2 + LBordadaUp.Length / 2));
            Console.WriteLine(textoJogo[0].PadLeft(Console.WindowWidth / 2 + textoJogo[0].Length / 2));  //"--- Bem vindo ao jogo de cartas e futebol ---",
            Console.WriteLine(LBordadaDown.PadLeft(Console.WindowWidth / 2 + LBordadaDown.Length / 2));
            Console.WriteLine("Prefere jogar:\n [ 1 ]  1x1 - Player x Player\n [ 2 ]  1xPC - player x Computador");

            PlayerPC = int.Parse(Console.ReadLine());
            Console.Clear();
        }

        public void PlayerNumero()
        {
            Console.WriteLine(LBordadaUp.PadLeft(Console.WindowWidth / 2 + LBordadaUp.Length / 2));
            string linha = ("Jogador " + NumPlayer);
            Console.WriteLine(linha.PadLeft(Console.WindowWidth / 2 + linha.Length / 2));
            Console.WriteLine(LBordadaDown.PadLeft(Console.WindowWidth / 2 + LBordadaDown.Length / 2));
        }
        public void NomePlayer()
        {
            if (string.IsNullOrEmpty(Nome))
            {
                Energe = 10;
                Acabou = false;
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
            Console.WriteLine(LBordadaUp.PadLeft(Console.WindowWidth / 2 + LBordadaUp.Length / 2));
            if (this.Energe <= 0) {
                string text4 = (string.Format(textoJogo[13], Nome));
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                
                Console.WriteLine(text4.PadLeft(Console.WindowWidth / 2 + text4.Length / 2));
                Console.ResetColor();
            }
            /*  Console.WriteLine(textoJogo[12].PadLeft(Console.WindowWidth / 2 + textoJogo[1].Length / 2) + Score); //"Pontuação: "
              Console.WriteLine(textoJogo[13].PadLeft(Console.WindowWidth / 2 + textoJogo[1].Length / 2) + Gol);   //"Gols marcado: "
              Console.WriteLine(textoJogo[14].PadLeft(Console.WindowWidth / 2 + textoJogo[1].Length / 2) + Energe); //"Energia restante: "  */

            string text1 = (string.Format(textoJogo[15], Score));
            string text2 = (string.Format(textoJogo[16], Gol));
            string text3 = (string.Format(textoJogo[17], Energe));
            Console.WriteLine(text1.PadLeft(Console.WindowWidth / 2 + text1.Length / 2));
            Console.WriteLine(text2.PadLeft(Console.WindowWidth /2 + text2.Length / 2));
            Console.WriteLine(text3.PadLeft(Console.WindowWidth /2 + text3.Length / 2));
          //  Console.WriteLine(string.Format(textoJogo[16], Gol));
            //Console.WriteLine(string.Format(textoJogo[17], Energe));




            Console.WriteLine(LBordadaDown.PadLeft(Console.WindowWidth / 2 + LBordadaDown.Length / 2));
            Console.WriteLine("");
           
        }
        public void GolMarcado()
        {
            this.Gol++;
            Console.WriteLine(LBordadaUp.PadLeft(Console.WindowWidth / 2 + LBordadaUp.Length / 2));
            Console.WriteLine(textoJogo[1].PadLeft(Console.WindowWidth / 2 + textoJogo[1].Length / 2) + this.Nome); //Console.WriteLine("GOOOOOOOOOOOLLLL!!!! Do " + this.Nome);
            Console.WriteLine(textoJogo[2].PadLeft(Console.WindowWidth / 2 + textoJogo[2].Length / 2) + this.Gol); //Console.WriteLine("Total de gols é de " + this.Gol);
            Console.WriteLine(LBordadaDown.PadLeft(Console.WindowWidth / 2 + LBordadaDown.Length / 2));
            Console.WriteLine("");
            Console.ReadKey();
        }
        public void DefesaGoleiro()
        {
            Console.WriteLine("");
            Console.WriteLine(textoJogo[3].PadLeft(Console.WindowWidth / 2 + textoJogo[3].Length / 2)); //("Incrivel defesa do Goleiro do {0}!! Não foi dessa fez que vemos um Gol!", Nome);
            
            Console.WriteLine("");
            Console.ReadKey();

        }

        public void Ganhador()
        {
            Console.Clear();
            Console.WriteLine(textoJogo[4].PadLeft(Console.WindowWidth / 2 + textoJogo[4].Length / 2) + Nome); // ("Parabens o jogador " + Nome + " é o ganhador!");
            Console.WriteLine(textoJogo[5].PadLeft(Console.WindowWidth / 2 + textoJogo[5].Length / 2));
            Pontuacao();
        }
        public void Perdedor()
        {
            
            Console.WriteLine(textoJogo[6].PadLeft(Console.WindowWidth / 2 + textoJogo[6].Length / 2) + Nome); // ("Infelizmente o jogador " + Nome + " não ganhou dessa vez!");
            Console.WriteLine(textoJogo[7].PadLeft(Console.WindowWidth / 2 + textoJogo[7].Length / 2));
            Pontuacao();
        }
        public void Empate()
        {
            
            Console.WriteLine(textoJogo[8].PadLeft(Console.WindowWidth / 2 + textoJogo[8].Length / 2)); // "Apesar do empate, parabens o jogador " + Nome);

        }
        public void encerrandoRodada()
        {
            Energe--;
            if (Energe <= 0)
            {
                Console.WriteLine("");
                Acabou = true;
            }
        }
        public void PenalidadeChute()
        {
            Console.WriteLine("");
            
            Console.WriteLine(textoJogo[9].PadLeft(Console.WindowWidth / 2 + textoJogo[9].Length / 2)); //"Penalidade MAXIMA!"
            Console.WriteLine(textoJogo[10].PadLeft(Console.WindowWidth / 2 + textoJogo[10].Length / 2));
            
            Console.WriteLine("");

            Console.WriteLine(Nome + ", o jogador da vez, deve tentar o chute.");
            if (PC == true) { Chute = Sorteio.Next(1, 4); Console.WriteLine("O chute foi {0}", Chute); }
            else
            {
                Console.WriteLine("Digite: [1] - Chute na Esquerda | | [2] Chute no Centro | | [3] Chute a direita");
                Chute = int.Parse(Console.ReadLine());
            }
            
        }
        public void PenalidadeDefesa()
        {
            Console.WriteLine("");
            
            Console.WriteLine(textoJogo[9].PadLeft(Console.WindowWidth / 2 + textoJogo[9].Length / 2)); //"Penalidade MAXIMA!"

            Console.WriteLine("Agora a vez da defesa, o Goleiro do jogador {0} deverá tentar defender o chute.", Nome);
            if (PC == true) { Defesa = Sorteio.Next(1, 4); Console.WriteLine("A Defesa foi {0}", Defesa); }
            else
            {
                Console.WriteLine("Digite: [1] - Defesa na Esquerda | | [2] Defesa no Centro | | [3] Defesa a direita");
                Defesa = int.Parse(Console.ReadLine());
            }
        }
        public void JogoRodando()
        {
            Console.Clear();
            Cabecario();
            Console.ResetColor();
            Console.WriteLine();
            Card.SorteioCartas();
            if (Card.Repeticao == false)
            {
                this.Score += Card.ScoreCartas;
            }
            Console.ResetColor();
            
            Card.CartaoGol();
            if (Card.golBool == true)
            {
                GolMarcado();
                Card.golBool = false;
            }
            Card.CartaoPenalti();
            if (Card.Penalti == true)
            {
                PenaltiChute = true;
                Card.Penalti = false;
            }
            if (PenaltiChute == true) { PenalidadeChute(); }

            Card.CartaoEnergia();
            if (Card.Energia == true)
            {
                Energe++;
                Card.Energia = false;
            }

            Card.CartaoAmarelo();
            if (Card.Amarela == true)
            {
                ContaAmarelo++;
                if (ContaAmarelo > 1) { Energe = Energe - 2; }
                else { encerrandoRodada(); }
                Card.Amarela = false;
            }
            Card.CartaoVermelho();
            if (Card.Vermelho == true)
            {
                Energe = Energe - 2;
                Card.Vermelho = false;
            }
            Card.CartaoFalta();
            Console.WriteLine("");
        }


    }
}
