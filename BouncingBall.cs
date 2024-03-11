using System;
using System.Threading;
using static System.Console;

namespace ConsoleBouncingBall
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = 30;
            int height = 30;
            int ballX = width / 2;
            int ballY = height / 2;
            int ballVelocityX = 1;
            int ballVelocityY = 1;
	    string ball = "x26BD";
            
            Console.WriteLine("Press ESC to stop");
            

            // Draw the top and bottom borders
            for (int x = 0; x <= width; x++)
            {
                    SetCursorPosition(x, 0);
                    WriteLine("#");
                    SetCursorPosition(x, height);
                    WriteLine("#");
                }

            // Draw the left and right borders
            for (int y = 0; y <= height; y++)
            {
                    SetCursorPosition(0, y);
                    WriteLine("#");
                    SetCursorPosition(width, y);
                    WriteLine("#");
            }
            SetCursorPosition(ballX, ballY);
            WriteLine(ball);
        }
    
    }
}
