using System;

namespace TresEnRaya
{
    static class Game
    {
        public static readonly char[] squareLetterCharacters = { 'A', 'B', 'C' };
        public static readonly char[] squareNumCharacters = { '1', '2', '3' };

        public static char[,] board = { {' ', ' ', ' '},
                                        {' ', ' ', ' '},
                                        {' ', ' ', ' '}
                                      };
        public static int round = 0;
        public static bool haveWiner = false;
    }
    class Program
    {
        static void PrintStartScreen() //commited
        {
            do
            {
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

            ResetBoard();
            Game.round = 0;
        }

        static void MainGame()
        {
            do
            {
                PrintGameScreen();
                Game.round++;
            } while (Game.round < 9 && !Game.haveWiner);
        }

        static void PrintGameScreen() //commited
        {
            string turn = CheckTurn();
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
            } while (!FilterUserSquare(playerSquare) || !CheckSquareOccupancy(playerSquare));
            AssignSquare(playerSquare);
        }
        
        static void PrintGameOverScreen()
        {
            string turn = CheckTurn();

            do
            {
                Console.Clear();

                Console.WriteLine("================================================");
                Console.WriteLine("================= TRES EN RAYA =================");
                Console.WriteLine("================================================");

                Console.WriteLine("////////////////////////////////////////////////");
                Console.WriteLine("/////////////  P1 = X  ||  P2 = O  /////////////");
                Console.WriteLine("////////////////////////////////////////////////");

                if (Game.haveWiner)
                {
                    Console.WriteLine("//////{1}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{2}//////", "\u2550", "\u2554", "\u2557");
                    Console.WriteLine("//////{1}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{1}//////", "\u2591", "\u2551");
                    Console.WriteLine("//////{1}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}  GAME  OVER  {0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{1}//////", "\u2591", "\u2551");
                    Console.WriteLine("//////{1}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}      --      {0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{1}//////", "\u2591", "\u2551");
                    Console.WriteLine("//////{1}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}   {2}  win!   {0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{1}//////", "\u2591", "\u2551", turn);
                    Console.WriteLine("//////{1}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{1}//////", "\u2591", "\u2551");
                    Console.WriteLine("//////{1}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{2}//////", "\u2550", "\u255A", "\u255D");
                }
                else
                {
                    Console.WriteLine("//////{1}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{2}//////", "\u2550", "\u2554", "\u2557");
                    Console.WriteLine("//////{1}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{1}//////", "\u2591", "\u2551");
                    Console.WriteLine("//////{1}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}      --      {0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{1}//////", "\u2591", "\u2551");
                    Console.WriteLine("//////{1}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}  GAME  OVER  {0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{1}//////", "\u2591", "\u2551");
                    Console.WriteLine("//////{1}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}      --      {0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{1}//////", "\u2591", "\u2551");
                    Console.WriteLine("//////{1}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{1}//////", "\u2591", "\u2551");
                    Console.WriteLine("//////{1}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{2}//////", "\u2550", "\u255A", "\u255D");

                }

                Console.WriteLine("///////////// C || {0} || {1} || {2} ||  /////////////", Game.board[2,0], Game.board[2,1], Game.board[2,2]);
                Console.WriteLine("/////////////   ||---||---||---||  /////////////");
                Console.WriteLine("/////////////                      /////////////");
                Console.WriteLine("////////////////////////////////////////////////");
                Console.WriteLine("////////////////| Press ENTER |/////////////////");
                Console.WriteLine("////////////////////////////////////////////////");
            } while (Console.ReadKey().Key != ConsoleKey.Enter);
        }

        static string CheckTurn() //commited
        {
            string currentTurn;
            if (Game.round % 2 == 0) { currentTurn = "P1"; }
            else { currentTurn = "P2"; }

            return currentTurn;
        }

        static bool FilterUserSquare(string userSquare) //commited
        {
            /* --------------------------------------------------------------------------------------------------- DESCARTE - Sustituido por 'Game.rightLetterCharacters'
            char[] rightLetterCharacters = { 'A', 'B', 'C' };
            char[] rightNumCharacters = { '1', '2', '3' };
            --------------------------------------------------------------------------------------------------- */
            bool check1, check2, filter;
            check1 = false;
            check2 = false;
            filter = false;

            if (userSquare.Length == 2)
            {
                /* ----------------------------------------------------------------------------------------------- DESCARTE - Sustituido por función 'ArrangeSquareCharacters(userSquare)'
                char[] vectorUserSquare = userSquare.ToCharArray();
                ----------------------------------------------------------------------------------------------- */
                char[] vectorUserSquare = ArrangeSquareCharacters(userSquare);

                /* ----------------------------------------------------------------------------------------------- TEST - PRUEBAS PARA ORDENAR EL VECTOR 'vectorUserSquare'
                Console.WriteLine("{0} - {1}", vectorUSquare[0], vectorUSquare[1]);
                Array.Sort(vectorUSquare);
                Console.WriteLine("{0} - {1}", vectorUSquare[0], vectorUSquare[1]);
                Array.Reverse(vectorUSquare);
                Console.WriteLine("{0} - {1}", vectorUSquare[0], vectorUSquare[1]);
                Console.ReadKey(); 
                ----------------------------------------------------------------------------------------------- */

                /* ----------------------------------------------------------------------------------------------- DESCARTE - Sustituido por función 'ArrangeSquareCharacters(userSquare)'
                //--- Ordenamos el vector para que la letra esté siempre en posición [0]
                Array.Sort(vectorUserSquare);
                Array.Reverse(vectorUserSquare);
                //---
                ----------------------------------------------------------------------------------------------- */


                /* ----------------------------------------------------------------------------------------------- DESCARTE - PRIMERA MANERA
                if (vectorUSquare[0] == 'A' || vectorUSquare[0] == 'B' || vectorUSquare[0] == 'C')
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
                }
                ----------------------------------------------------------------------------------------------- */

                foreach (char character in Game.squareLetterCharacters)
                {
                    if (vectorUserSquare[0] == character) { check1 = true; }
                }
                foreach (char character in Game.squareNumCharacters)
                {
                    if (vectorUserSquare[1] == character) { check2 = true; }
                }
                if(check1 && check2) { filter = true; }
            }
            
            return filter;
        }

        static char[] ArrangeSquareCharacters(string userSquare) //commited
        {
            char[] vectorUserSquare = userSquare.ToCharArray();

            //--- Ordenamos el vector para que la letra esté siempre en posición [0]
            Array.Sort(vectorUserSquare);
            Array.Reverse(vectorUserSquare);
            //---

            return vectorUserSquare;
        }

        static int[] TranslateUserSquare(string userSquare) //commited
        {
            int[] boardSquare= new int[2];
            char[] vectorUserSquare = ArrangeSquareCharacters(userSquare);

            switch (vectorUserSquare[0])
            {
                case 'A':
                    boardSquare[0] = 0;
                    break;
                case 'B':
                    boardSquare[0] = 1;
                    break;
                case 'C':
                    boardSquare[0] = 2;
                    break;
            }
            switch (vectorUserSquare[1])
            {
                case '1':
                    boardSquare[1] = 0;
                    break;
                case '2':
                    boardSquare[1] = 1;
                    break;
                case '3':
                    boardSquare[1] = 2;
                    break;
            }

            return boardSquare;
        }

        static bool CheckSquareOccupancy(string userSquare) //commited
        {
            bool check = false;

            int[] boardSquare = TranslateUserSquare(userSquare);

            if (Game.board[boardSquare[0],boardSquare[1]] == ' ') 
            {
                check = true;
            }

            return check;
        }

        static void AssignSquare(string userSquare) //commited
        {
            char token = ' ';
            string turn = CheckTurn();

            if(turn == "P1") { token = 'X'; }
            else if(turn == "P2") { token = 'O'; }

            if (FilterUserSquare(userSquare))
            {
                int[] boardSquare = TranslateUserSquare(userSquare);

                Game.board[boardSquare[0], boardSquare[1]] = token;
            }
        }

        static void ResetBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Game.board[i, j] = ' ';
                }
            }
                

        }



        static void Main()
        {
            do
            {
                PrintStartScreen();
                MainGame();
                PrintGameOverScreen();
            } while (true);
        }
    }
}
