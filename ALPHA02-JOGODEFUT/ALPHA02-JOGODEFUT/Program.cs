using ALPHA02_JOGODEFUT;

class Program
{
    static void Main(string[] args)
    {
        try
        {

        
        bool rodada = false;
        bool encerrou = true;
        bool sair = false;
        int r = 0;
        int r1 = 0;
        Random sorte= new Random();
        
        Random aleatorio = new Random();
        List<PlayerX> Player1 = new List<PlayerX>();
        List<PlayerX> Player2 = new List<PlayerX>();
        PlayerX p = new PlayerX();
        PlayerX p2 = new PlayerX();
        CartasJogos c = new CartasJogos();
        p.Apresentacao(); 
        if (p.PlayerPC == 2)
            { p2.PC = true; }
        Console.WriteLine("********* Player 1 ********");
        p.NomePlayer();
        Console.WriteLine("********* Player 2 ********");
        p2.NomePlayer();
        Console.Clear();
        rodada = sorte.Next(1, 3) == 1 ? true : false;

        while (sair == false)
        {
            for (int i = 0; encerrou; i++)
            {
                if (p.Acabou == false)
                {
                    if (rodada == false)
                    { 
                        p.JogoRodando();
                        if (p.PenaltiChute == true)
                        {
                            p2.PenaltiDefesa = true;
                        }
                        if (p.PenaltiDefesa== true && p2.PenaltiChute == true)
                        {
                          if (p.Defesa == p2.Chute){ p.DefesaGoleiro();}
                          else { p2.GolMarcado(); }
                          p.PenaltiDefesa = false; 
                          p2.PenaltiChute = false;
                        }
                        p.Score += c.ScoreCartas;
                        Player1.Add(p);
                        p.Pontuacao();
                        Console.ReadKey();
                        p.encerrandoRodada();
                        r++;
                        rodada = true;
                    }

                }
                else { Console.WriteLine("Jogador {0} está sem energia! ", p.Nome); encerrou = true; rodada = true; } 

                if (p2.Acabou == false)
                {
                    if (rodada == true)
                    { 
                        p2.JogoRodando();
                        if (p2.PenaltiChute == true)
                        {
                            p.PenaltiDefesa = true;
                        }
                        if (p2.PenaltiDefesa == true && p.PenaltiChute == true)
                        {
                            if (p2.Defesa == p.Chute) { p2.DefesaGoleiro(); }
                            else { p.GolMarcado(); }
                            p2.PenaltiDefesa = false;
                            p.PenaltiChute = false;
                        }
                p2.Score += c.ScoreCartas;
                        Player2.Add(p2);
                        p2.Pontuacao();
                        Console.ReadKey();
                        p2.encerrandoRodada();
                        r1++;
                        rodada = false;
                    }
                }
                else { Console.WriteLine("Jogador {0} está sem energia! ", p2.Nome); encerrou = true; rodada = false; }

                if (p2.Acabou == true && p.Acabou == true) { encerrou = false; sair = true;  } 
            }

        }
        if (p.Score > p2.Score) {p.Ganhador(); p.Pontuacao(); p2.Pontuacao(); Console.WriteLine("Rodadas {0} e {1}", r, r1); }
        else if ( p2.Score > p.Score ) {p2.Ganhador(); p.Pontuacao(); p2.Pontuacao(); Console.WriteLine("Rodadas {0} e {1}", r, r1); }
        else { p.Empate(); p.Pontuacao(); p2.Pontuacao(); Console.WriteLine("Rodadas {0} e {1}", r, r1); }

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.ReadKey();
            throw;
        }

    }
}