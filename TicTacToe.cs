using System;

namespace TicTacToe
{
    class Program
    {
        static char[] board = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int player = 1; // Player 1 starts
        static int choice; // Stores the choice of where to mark
        static int flag = 0; // 1 means game is over with a result, -1 means game is a draw, 0 means game is still running

        static void Main(string[] args)
        {
            do
            {
                Console.Clear(); // Whenever the loop restarts, clear the console
                Console.WriteLine("Player 1: X and Player 2: O");
                Console.WriteLine("\n");
                if (player % 2 == 0)
                {
                    Console.WriteLine("Player 2's turn");
                }
                else
                {
                    Console.WriteLine("Player 1's turn");
                }
                Console.WriteLine("\n");
                Board();

                string input = Console.ReadLine();
                if (!int.TryParse(input, out choice))
                {
                    Console.WriteLine("Please enter a valid number");
                    continue;
                }
                if (choice < 1 || choice > 9)
                {
                    Console.WriteLine("Please enter a number between 1 and 9.");
                    continue;
                }

                // Check the spot on the board
                if (board[choice] != 'X' && board[choice] != 'O')
                {
                    if (player % 2 == 0)
                    {
                        board[choice] = 'O';
                        player++;
                    }
                    else
                    {
                        board[choice] = 'X';
                        player++;
                    }
                }
                else
                {
                    Console.WriteLine("Sorry the row {0} is already marked with a {1}", choice, board[choice]);
                    Console.WriteLine("\n");
                    Console.WriteLine("Please wait 2 seconds board is loading again.....");
                    System.Threading.Thread.Sleep(2000);
                }
                flag = CheckWin();
            } while (flag != 1 && flag != -1);

            Console.Clear();
            Board();
            if (flag == 1)
            {
                Console.WriteLine("Player {0} has won", (player % 2) + 1);
            }
            else
            {
                Console.WriteLine("Draw");
            }
            Console.ReadLine();
        }

        // Function to draw the board
        private static void Board()
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[1], board[2], board[3]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[4], board[5], board[6]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[7], board[8], board[9]);
            Console.WriteLine("     |     |      ");
        }

        // Function to check win
        private static int CheckWin()
        {
            #region Horizontal Winning Condition
            // Winning Condition For First Row
            if (board[1] == board[2] && board[2] == board[3])
            {
                return 1;
            }
            // Winning Condition For Second Row
            else if (board[4] == board[5] && board[5] == board[6])
            {
                return 1;
            }
            // Winning Condition For Third Row
            else if (board[7] == board[8] && board[8] == board[9])
            {
                return 1;
            }
            #endregion

            #region Vertical Winning Condition
            // Winning Condition For First Column
            else if (board[1] == board[4] && board[4] == board[7])
            {
                return 1;
            }
            // Winning Condition For Second Column
            else if (board[2] == board[5] && board[5] == board[8])
            {
                return 1;
            }
            // Winning Condition For Third Column
            else if (board[3] == board[6] && board[6] == board[9])
            {return 1;
            }
            #endregion

            #region Diagonal Winning Condition
            else if (board[1] == board[5] && board[5] == board[9])
            {
                return 1;
            }
            else if (board[3] == board[5] && board[5] == board[7])
            {
                return 1;
            }
            #endregion

            #region Checking For Draw
            // If all places on the board have been filled and no winner, it's a draw
            else if (board[1] != '1' && board[2] != '2' && board[3] != '3'
                     && board[4] != '4' && board[5] != '5' && board[6] != '6'
                     && board[7] != '7' && board[8] != '8' && board[9] != '9')
            {
                return -1;
            }
            #endregion

            else
            {
                return 0;
            }
        }
    }
}
