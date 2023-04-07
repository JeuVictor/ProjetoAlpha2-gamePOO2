using ALPHA02_JOGODEFUT;

class Program
{
    static void Main(string[] args)
    {
        bool encerrou = true;
        bool sair = false;
        int r = 0;
        int r1 = 0;
        
        Random aleatorio = new Random();
        List<PlayerX> Player1 = new List<PlayerX>();
        List<PlayerX> Player2 = new List<PlayerX>();
        PlayerX p = new PlayerX();
        PlayerX p2 = new PlayerX();
        CartasJogos c = new CartasJogos();
        Console.WriteLine("********* Player 1 ********");
        p.NomePlayer();
        Console.WriteLine("********* Player 2 ********");
        p2.NomePlayer();
        Console.Clear();

        while (sair == false)
        {
            for (int i = 0; encerrou; i++)
            {
                if (p.Acabou == false)
                {
                    c.SorteioCartas();
                    p.Score += c.ScoreCartas;
                    Player1.Add(p);
                    p.Pontuacao();
                    Console.ReadKey();
                    p.encerrandoRodada();
                    r++;

                }
                else { Console.WriteLine("Jogador {0} está sem energia! ", p.Nome); encerrou = true; }

                if (p2.Acabou == false)
                {
                    c.SorteioCartas();
                    p2.Score += c.ScoreCartas;
                    Player2.Add(p2);
                    p2.Pontuacao();
                    Console.ReadKey();
                    p2.encerrandoRodada();
                    r1++;
                }

                if (p2.Acabou == true && p.Acabou == true) { encerrou = false; sair = true; }
            }

        }
        if (p.Score > p2.Score) {p.Ganhador(); p.Pontuacao(); p2.Pontuacao(); Console.WriteLine("Rodadas {0} e {1}", r, r1); }
        else if ( p2.Score > p.Score ) {p2.Ganhador(); p.Pontuacao(); p2.Pontuacao(); Console.WriteLine("Rodadas {0} e {1}", r, r1); }
        else { p.Empate(); p.Pontuacao(); p2.Pontuacao(); Console.WriteLine("Rodadas {0} e {1}", r, r1); }
        
    }
}