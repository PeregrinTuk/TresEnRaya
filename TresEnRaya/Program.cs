using System;

namespace TresEnRaya
{
    public static class Game
    {
        public static string[,] board = { {" ", " ", " "},
                                          {" ", " ", " "},
                                          {" ", " ", " "}
                                        };
        public static int round = 0;
    }
    class Program
    {
        public static void PrintStartScreen()
        {
            do {
                Console.Clear();

                Console.WriteLine("================================================");
                Console.WriteLine("================= TRES EN RAYA =================");
                Console.WriteLine("================================================");
                Console.WriteLine("///////////////////////||///////////////////////");
                Console.WriteLine("///////////////////////||///////////////////////");
                Console.WriteLine("///////////////////////||///////////////////////");
                Console.WriteLine("///////////////////////||///////////////////////");
                Console.WriteLine("///////////////////////||///////////////////////");
                Console.WriteLine("///////////////////////||///////////////////////");
                Console.WriteLine("///////////////////////||///////////////////////");
                Console.WriteLine("///////////////////////||///////////////////////");
                Console.WriteLine("///////////////////////||///////////////////////");
                Console.WriteLine("///////////////////////||///////////////////////");
                Console.WriteLine("///////////////////////||///////////////////////");
                Console.WriteLine("///////////////////////||///////////////////////");
                Console.WriteLine("///////////////////////||///////////////////////");
                Console.WriteLine("////////////////| Press ENTER |/////////////////");
                Console.WriteLine("///////////////////////||///////////////////////");
                Console.WriteLine("///////////////////////||///////////////////////");
            } while (Console.ReadKey().Key != ConsoleKey.Enter);

            //while (Console.ReadKey().Key != ConsoleKey.Enter) { }

            Game.round = 0;
        }

        public static void GameMain()
        {

        }

        public static void PrintGameScreen()
        {
            string turn = ChekTurn();
            string playerSquare;

            do
            {
                Console.Clear();

                Console.WriteLine("================================================");
                Console.WriteLine("================= TRES EN RAYA =================");
                Console.WriteLine("================================================");
                Console.WriteLine("////////////////////////////////////////////////");
                Console.WriteLine("/////////////  P1 = X  ||  P2 = O  /////////////");
                Console.WriteLine("////////////////////////////////////////////////");
                Console.WriteLine("////////////////////////////////////////////////");
                Console.WriteLine("/////////////      1    2    3     /////////////");
                Console.WriteLine("/////////////   ||---||---||---||  /////////////");
                Console.WriteLine("///////////// A || {0} || {1} || {2} ||  /////////////", Game.board[0,0], Game.board[0,1], Game.board[0,2]);
                Console.WriteLine("/////////////   ||---||---||---||  /////////////");
                Console.WriteLine("///////////// B || {0} || {1} || {2} ||  /////////////", Game.board[1,0], Game.board[1,1], Game.board[1,2]);
                Console.WriteLine("/////////////   ||---||---||---||  /////////////");
                Console.WriteLine("///////////// C || {0} || {1} || {2} ||  /////////////", Game.board[2,0], Game.board[2,1], Game.board[2,2]);
                Console.WriteLine("/////////////   ||---||---||---||  /////////////");
                Console.WriteLine("/////////////                      /////////////");
                Console.WriteLine("////////////////////////////////////////////////");
                Console.WriteLine("////////////////////////////////////////////////");
                Console.WriteLine("// Es el turno de {0}:  ||///////////////////////", turn);
                playerSquare = Console.ReadLine().ToUpper().Trim();
            } while (FilterSquare(playerSquare));
        }

        public static string ChekTurn()
        {
            string currentTurn;
            if (Game.round % 2 == 0) { currentTurn = "P1"; }
            else { currentTurn = "P2"; }

            return currentTurn;
        }

        public static bool FilterSquare(string userSquare)
        {
            char[] rightCharacters = { 'A', 'B', 'C', '1', '2', '3' };
            bool check1, check2, filter;
            check1 = true;
            check2 = true;
            filter = true;
            if (userSquare.Length == 2)
            {
                char[] vectorUSquare = userSquare.ToCharArray();

                //Console.WriteLine("{0} - {1}", vectorUSquare[0], vectorUSquare[1]);
                //Array.Sort(vectorUSquare);
                //Console.WriteLine("{0} - {1}", vectorUSquare[0], vectorUSquare[1]);
                //Console.ReadKey();

                /*if (vectorUSquare[0] == 'A' || vectorUSquare[0] == 'B' || vectorUSquare[0] == 'C')
                {
                    if (vectorUSquare[1] == '1' || vectorUSquare[1] == '2' || vectorUSquare[1] == '3')
                    {
                        filter = false;
                    }
                }
                else if (vectorUSquare[0] == '1' || vectorUSquare[0] == '2' || vectorUSquare[0] == '3')
                {
                    if (vectorUSquare[1] == 'A' || vectorUSquare[1] == 'B' || vectorUSquare[1] == 'C')
                    {
                        filter = false;
                    }
                }*/
                foreach (char character in rightCharacters)
                {
                    if (vectorUSquare[0] == character) { check1 = false; }
                    if (vectorUSquare[1] == character) { check2 = false; }
                }
                if(!check1 && !check2) { filter = false; }

            }
            
            return filter;
        }

        public static void AssignSquare(string squareLetter, int squareNum)
        {

        }


        static void Main(string[] args)
        {
            do
            {
                PrintStartScreen();
                // Console.Clear();
                PrintGameScreen();
            } while (true);
        }
    }
}
