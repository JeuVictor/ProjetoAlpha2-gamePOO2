using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace ALPHA02_JOGODEFUT
{
    public class PlayerX : CartasJogos
    {
        public string Nome { get; set; }
        public int Energe { get; set; }
        Random Sorteio = new Random();
        public int Gol { get; set; }
        public int Score { get; set; }
        public int CartAmarelo { get; set; }
        public bool PC { get; set; }
        public bool Acabou { get; set; }
        public void NomePlayer () 
        {
            if (string.IsNullOrEmpty(Nome))
            {
                Console.WriteLine("Digite o nome do jogador: ");
                this.Nome = Console.ReadLine();
                Energe = 10;
                Acabou= false;
                if (PC == true)
                {
                    this.Nome = "Computador";
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
         


    }
}
