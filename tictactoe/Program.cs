using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text;
using System.IO;

namespace tictactoe
{
    public class Player
    {
        public string Name;
        public int Wins;
        public int Draws;

    }
    class Program
    {
        static char[] board = new char[] { '0','1','2','3','4','5','6','7','8','9' };
        static char border = '#';
        static string[] players = new string[2];
        static int winner;
        static bool isWin = false;
        static char p1 = 'X';
        static char p2 = 'O';
        static int move = 1;
        static int choice;
        static int choose = 0;
        static void drawBoard()
        {
            Console.WriteLine("      1        2       3     ");
            Console.WriteLine("          {0}       {0}            ", border);
            Console.WriteLine("     {0}    {3}    {1}  {3}     {2}     ",board[0], board[1], board[2], border);
            Console.WriteLine("          {0}       {0}            ", border);
            for (int i = 0; i < 29; i++)
            {
                Console.Write("{0}", border);
            }
            Console.WriteLine("          {0}       {0}            ", border);
            Console.WriteLine("          {0}       {0}            ", border);
            Console.WriteLine("     {0}    {3}   {1}   {3}    {2}     ",board[3], board[4], board[5], border);
            Console.WriteLine("          {0}       {0}            ", border);
           for (int i = 0; i < 29; i++)
            {
                Console.Write("{0}", border);
            }
            Console.WriteLine("          {0}       {0}            ", border);
            Console.WriteLine("          {0}       {0}            ", border);
            Console.WriteLine("     {0}    {3}   {1}   {3}    {2}     ", board[6], board[7], board[8], border);
            Console.WriteLine("          {0}       {0}            ", border);
       
        }

       /* static void initPlayers()
        {
            string tmp = "";
            Player p1 = new Player();
            Player p2 = new Player();

            Console.WriteLine("Graczu nr. 1 - jak na Ciebie wołają?");
            tmp = Console.ReadLine();
            players[0] = tmp;
            p1.Name = tmp;
            Console.WriteLine("Graczu nr. 2 - a jak na Ciebie wołają?");
            tmp = Console.ReadLine();
            players[1] = tmp;
            p2.Name = tmp;


            Console.WriteLine("Witamy na polu walki {0} oraz {1} ", players[0], players[1]);
        }*/

        static void play()
        {
         
            do
            {
                if (move % 2 == 0)
                {
                    Console.WriteLine("Jedziesz {0}!", players[1]);
                }
                else
                {
                    Console.WriteLine("Jedziesz {0}!", players[0]);
                }

                drawBoard();

                Console.WriteLine("Podaj pole");
                try
                {
                    choice = Int32.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Niepoprawne pole");
                    throw;
                }

                if (board[choice] != p1 && board[choice] != p2)
                {
                    if (move % 2 == 0)
                    {
                        board[choice] = p1;
                        move++;

                    }
                    else
                    {
                        board[choice] = p2;
                        move++;
                    }
                }
                else
                {
                    Console.WriteLine("Sory byczku, ale to pole już jest zajete {0} {1}", choice, board[choice]);
                    Console.WriteLine(" ");
                    Console.WriteLine("Ładuję plansze...");
                    System.Threading.Thread.Sleep(3000);

                }
                winner = checkWinner();
                Console.WriteLine("test {0}", winner);
            } while (winner != 1 && winner != -1);

            Console.Clear();
            drawBoard();

            if (winner == 1)
            {
                if (((move % 2) + 1) == 1)
                {
                    Console.WriteLine("{0} wygrał!", players[0]);
                }
                else
                {
                    Console.WriteLine("{0} wygrał!", players[1]);
                }
                Console.WriteLine("Wracam do menu...");
                System.Threading.Thread.Sleep(3000);
                Console.Clear();
                initGame();
            }
            else
            {
                Console.WriteLine("remis");
            }
            Console.ReadLine();


        }
        static int checkWinner()
        {
            if (board[0] == board[1] && board[1] == board[2])
            {
                return 1;
            }
            else if (board[3] == board[4] && board[4] == board[5])
            {
                return 1;
            }
            else if (board[6] == board[7] && board[7] == board[8])
            {
                return 1;
            }
            else if (board[0] == board[3] && board[3] == board[6])
            {
                return 1;
            }
            else if (board[1] == board[4] && board[4] == board[7])
            {
                return 1;
            }
            else if (board[2] == board[5] && board[5] == board[8])
            {
                return 1;
            }
            else if(board[0] == board[4] && board[4] == board[8])
            {
                return 1;
            }
            else if(board[2] == board[4] && board[4] == board[6])
            {
                return 1;
            }
            else if(board[3] == board[5] && board[5] == board[7])
            {
                return 1;
            }
            else if(board[1] != '1' && board[2] != '2' && board[3] != '3' && board[4] != '4' && board[5] != '5' && board[6] != '6' && board[7] != '7' && board[8] != '8' && board[9] != '9')
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
      /*  static void stats(object obj)
        {
           
            string JSONresult = JsonSerializer.Serialize(obj);
            Console.WriteLine(JSONresult);
            using (StreamWriter str = new StreamWriter(@"../../../stats.txt", false))
            {
                str.WriteLine("test");
                str.WriteLine(JSONresult);
                str.Close();
                Console.WriteLine("stworzono json");
            }
        }
        */
        static void initGame()
        {
            Player p1 = new Player();
            Player p2 = new Player();
            Console.WriteLine("Witaj w grze Kółko i Krzyżyk - projekt wykonał Michał Wolny gr. K35");
            Console.WriteLine("");
            Console.WriteLine("1. Nowa gra");
            Console.WriteLine("2. Statystyki");
            Console.WriteLine("3. Wyjście");

            try
            {
                choose = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Niepoprawny wybór");
                throw;
            }



            switch (choose)
            {
                case 1:
                    Console.WriteLine("Nowa gra");
                    //initPlayers();

                    string tmp = "";
                    

                    Console.WriteLine("Graczu nr. 1 - jak na Ciebie wołają?");
                    tmp = Console.ReadLine();
                    players[0] = tmp;
                    p1.Name = tmp;
                    Console.WriteLine("Graczu nr. 2 - a jak na Ciebie wołają?");
                    tmp = Console.ReadLine();
                    players[1] = tmp;
                    p2.Name = tmp;

                   // stats(p1);
                   // stats(p2);
                    Console.WriteLine("Witamy na polu walki {0} oraz {1} ", players[0], players[1]);



                    play();
                    break;
                case 2:
                    Console.WriteLine("Statystyki");
                    Console.Write("Niestety, ale trochę przekombinowałem, próbowałem oprzeć mechanizm statystyk na JSONie, " +
                    "ponieważ mam pewne doświadczenie w tym z JSa, ale w C# nie udało mi się tego zaimplementować, no i nie starczyło też czasu aby dłużej przy tym posiedzieć" +
                    "Ogólnie zamysł był taki aby w JSONie przechowywać obiekty gracza z odpowiednia jego nazwa i przypisanym id, w tym obiekcie byłby wszystkie pary key=>value z iloscia wygranych oraz remisow a potem zczytywać je i wyswietlac w konsoli");
                    break;
                case 3:
                    Console.WriteLine("Żegnaj");
                    System.Threading.Thread.Sleep(1000);
                    Environment.Exit(0);
                    break;

            }
        }
        static void Main(string[] args)
        {

            initGame();

            Console.ReadKey();
        }
    }
}
