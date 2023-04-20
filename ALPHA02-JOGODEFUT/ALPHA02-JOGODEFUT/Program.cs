using ALPHA02_JOGODEFUT;

class Program
{
    static void Main(string[] args)
    {





        int EncerrarJogo = 0;

        Random sorte = new Random();
        while (EncerrarJogo == 0)
        {
            bool sair = false;
            int r = 0;
            int r1 = 0;
            bool rodada = false;
            bool encerrou = true;
            Random aleatorio = new Random();
            List<PlayerX> Player1 = new List<PlayerX>();
            List<PlayerX> Player2 = new List<PlayerX>();
            PlayerX p = new PlayerX();
            PlayerX p2 = new PlayerX();
            CartasJogos c = new CartasJogos();


            p.Reset();
            p2.Reset();

            p.Apresentacao();
            if (p.PlayerPC == 2)
            { p2.PC = true; }

            string linha1 = " Player 1 ";
            string linha2 = " Player 2 ";
            p.NumPlayer = 1;
            p.PlayerNumero();
            p.NomePlayer();
            p2.NumPlayer = 2;
            p2.PlayerNumero();
            p2.NomePlayer();

            Console.Clear();
            rodada = sorte.Next(1, 3) == 1 ? true : false;

            while (sair == false)
            {
                // for (int i = 0; encerrou; i++)
                // {
                if (rodada == false)
                {
                    if (p.PenaltiDefesa == true && p2.PenaltiChute == true)
                    {
                        if (p.PenaltiDefesa == true) { p.PenalidadeDefesa(); }
                        if (p.Defesa == p2.Chute) { p.DefesaGoleiro(); }
                        else { p2.GolMarcado(); }
                        p.PenaltiDefesa = false;
                        p2.PenaltiChute = false;
                    }
                    if (p.Acabou == false)
                    {
                        p.JogoRodando();
                        if (p.PenaltiChute == true)
                        {
                            p2.PenaltiDefesa = true;
                        }

                        p.Score += c.ScoreCartas;
                        Player1.Add(p);
                        p.Pontuacao();
                        Console.ReadKey();
                        p.encerrandoRodada();
                        r++;
                        rodada = true;
                    }
                    else { /*Console.WriteLine("Jogador {0} está sem energia! ", p.Nome); encerrou = true; */ rodada = true; }

                }


                if (rodada == true)
                {
                    if (p2.Acabou == false)
                    {
                        if (p2.PenaltiDefesa == true) { p2.PenalidadeDefesa(); }
                        if (p2.PenaltiDefesa == true && p.PenaltiChute == true)
                        {
                            if (p2.Defesa == p.Chute) { p2.DefesaGoleiro(); }
                            else { p.GolMarcado(); }
                            p2.PenaltiDefesa = false;
                            p.PenaltiChute = false;
                        }
                        p2.JogoRodando();
                        if (p2.PenaltiChute == true)
                        {
                            p.PenaltiDefesa = true;
                        }

                        p2.Score += c.ScoreCartas;
                        Player2.Add(p2);
                        p2.Pontuacao();
                        Console.ReadKey();
                        p2.encerrandoRodada();
                        r1++;
                        rodada = false;
                    }
                    else
                    {
                        /* Console.WriteLine("Jogador {0} está sem energia! ", p2.Nome);  
                         * encerrou = true; */
                        rodada = false;
                    }
                }


                if (p2.Acabou == true && p.Acabou == true) { encerrou = false; sair = true; }


            }

            if (p.Gol > p2.Gol) { p.Ganhador(); p2.Perdedor(); }
            else if (p2.Gol > p.Gol) { p2.Ganhador(); p.Perdedor(); }
            else if (p.Gol == p2.Gol && p2.Score > p.Score) { p2.Ganhador(); p.Perdedor(); }
            else if (p.Gol == p2.Gol && p.Score > p2.Score) { p.Ganhador(); p2.Perdedor(); }
            else { p.Empate(); Console.WriteLine(p.Nome + " e " + p2.Nome); p.Pontuacao(); p2.Pontuacao(); }
            Console.WriteLine("Rodadas {0} e {1}", r, r1);
            p.LinhaDestacada2();
            Console.WriteLine("");
            Console.WriteLine("Deseja Continuar? \n [ 0 ] - Sim; \n [ 1 ] - Não;");
            EncerrarJogo = int.Parse(Console.ReadLine());
        }




    }
}