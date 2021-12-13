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
        public static bool haveWinner = false;
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
        }

        static void MainGame() //commited
        {
            do
            {
                PrintGameScreen();
                if (!Game.haveWinner) { Game.round++; }
            } while (Game.round < 9 && !Game.haveWinner);
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
            CheckWinner(playerSquare);
        }
        
        static void PrintGameOverScreen() //commited
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

                if (Game.haveWinner)
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
            bool check1, check2, filter;
            check1 = false;
            check2 = false;
            filter = false;

            if (userSquare.Length == 2)
            {
                char[] vectorUserSquare = ArrangeSquareCharacters(userSquare);

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
            char token = AssignToken();

            if (FilterUserSquare(userSquare))
            {
                int[] boardSquare = TranslateUserSquare(userSquare);

                Game.board[boardSquare[0], boardSquare[1]] = token;
            }
        }

        static char AssignToken()
        {
            string turn = CheckTurn();

            if (turn == "P1") { return 'X'; }
            else if (turn == "P2") { return 'O'; }
            else { return ' '; }
        }

        static void CheckWinner(string userSquare)
        {
            bool haveLine, haveDiagonal;
            char currentToken = AssignToken();
            int[] currentSquare = TranslateUserSquare(userSquare);
            int currentRow = currentSquare[0];
            int currentCol = currentSquare[1];
            
            haveLine = CheckLine(in currentToken, currentRow, currentCol);
            haveDiagonal = CheckDiagonal(in currentToken, currentRow, currentCol);

            if (haveLine || haveDiagonal) { Game.haveWinner = true; }
        }

        /*  -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   DESCARTE
        static bool CheckRow(in char token, int row, int col)
        {
            bool haveLine = false;
            char tokenA, tokenB;
            int[] adjacentColumns = SearchAdjacentSquares(col);

            tokenA = Game.board[row, adjacentColumns[0]];
            tokenB = Game.board[row, adjacentColumns[1]];

            if (tokenA == token && tokenB == token) { haveLine = true; }

            return haveLine;
        }
        -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   */

        /*  -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   DESCARTE
        static bool CheckColumn(in char token, int row, int col)
        {
            bool haveLine = false;
            char tokenA, tokenB;
            int[] adjacentRows = SearchAdjacentSquares(row);

            tokenA = Game.board[adjacentRows[0], col];
            tokenB = Game.board[adjacentRows[1], col];

            if (tokenA == token && tokenB == token) { haveLine = true; }

            return haveLine;
        }
        -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   */

        static bool CheckLine(in char token, int row, int col)
        {
            bool haveLine = false;
            char tokenRow_A, tokenRow_B, tokenCol_A, tokenCol_B;
            int[] adjacentColumns = SearchAdjacentSquares(col);
            int[] adjacentRows = SearchAdjacentSquares(row);

            tokenRow_A = Game.board[row, adjacentColumns[0]];
            tokenRow_B = Game.board[row, adjacentColumns[1]];

            tokenCol_A = Game.board[adjacentRows[0], col];
            tokenCol_B = Game.board[adjacentRows[1], col];

            if (tokenRow_A == token && tokenRow_B == token) { haveLine = true; }
            else if (tokenCol_A == token && tokenCol_B == token) { haveLine = true; }

            return haveLine;
        }

        static bool CheckDiagonal(in char token, int row, int col)
        {
            bool haveDiagonal = false;
            char token_A, token_B, token_C, token_D;
            int[,] diagonalSquares = SearchDiagonalSquares(row, col);

            token_A = Game.board[diagonalSquares[0, 0], diagonalSquares[0, 1]];
            token_B = Game.board[diagonalSquares[1, 0], diagonalSquares[1, 1]];
            token_C = Game.board[diagonalSquares[2, 0], diagonalSquares[2, 1]];
            token_D = Game.board[diagonalSquares[3, 0], diagonalSquares[3, 1]];

            if (token_A == token && token_B == token) { haveDiagonal = true; }
            else if (token_C == token && token_D == token) { haveDiagonal = true; }

            return haveDiagonal;
        }

        static int[] SearchAdjacentSquares(int line)
        {
            int[] adjacentPositions = new int[2];

            switch (line)
            {
                case 0:
                    adjacentPositions[0] = 1;
                    adjacentPositions[1] = 2;
                    break;
                
                case 1:
                    adjacentPositions[0] = 0;
                    adjacentPositions[1] = 2;
                    break;

                case 2:
                    adjacentPositions[0] = 0;
                    adjacentPositions[1] = 1;
                    break;
            }

            return adjacentPositions;
        }

        static int[,] SearchDiagonalSquares(int row, int col)
        {
            int[,] diagonalPositions = new int[4, 2];

            switch (row)
            {
                case 0:
                    diagonalPositions[0, 0] = 1;
                    diagonalPositions[0, 1] = 1;

                    diagonalPositions[2, 0] = 1;
                    diagonalPositions[2, 1] = 1;

                    if(col == 0)
                    {
                        diagonalPositions[1, 0] = 2;
                        diagonalPositions[1, 1] = 2;

                        diagonalPositions[3, 0] = 2;
                        diagonalPositions[3, 1] = 2;
                    }
                    else if(col == 2)
                    {
                        diagonalPositions[1, 0] = 2;
                        diagonalPositions[1, 1] = 0;

                        diagonalPositions[3, 0] = 2;
                        diagonalPositions[3, 1] = 0;
                    }
                    break;

                case 1:
                    diagonalPositions[0, 0] = 0;
                    diagonalPositions[0, 1] = 0;

                    diagonalPositions[1, 0] = 2;
                    diagonalPositions[1, 1] = 2;

                    diagonalPositions[2, 0] = 0;
                    diagonalPositions[2, 1] = 2;

                    diagonalPositions[3, 0] = 2;
                    diagonalPositions[3, 1] = 0;
                    break;

                case 2:
                    diagonalPositions[0, 0] = 1;
                    diagonalPositions[0, 1] = 1;

                    diagonalPositions[2, 0] = 1;
                    diagonalPositions[2, 1] = 1;

                    if(col == 0)
                    {
                        diagonalPositions[1, 0] = 0;
                        diagonalPositions[1, 1] = 2;

                        diagonalPositions[3, 0] = 0;
                        diagonalPositions[3, 1] = 2;
                    }
                    else if(col == 2)
                    {
                        diagonalPositions[1, 0] = 0;
                        diagonalPositions[1, 1] = 0;

                        diagonalPositions[3, 0] = 0;
                        diagonalPositions[3, 1] = 0;
                    }
                    break;
            }

            return diagonalPositions;
        }

        static void ResetGame() //commited // MODIFICADO [ antes-> ResetBoard() ]
        {
            Game.round = 0;
            Game.haveWinner = false;

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
                ResetGame();
            } while (true);
        }
    }
}
