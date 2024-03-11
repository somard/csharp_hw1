using System;
using System.Threading;

namespace ConsoleBouncingBall
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = 50;
            int height = 50;
            int ballX = width / 2;
            int ballY = height / 2;
            int ballVelocityX = 1;
            int ballVelocityY = 1;
	    string ball = "O";
            
            Console.WriteLine("Press ESC to stop");
            

            // Draw the top and bottom borders
            for (int x = 0; x <= width; x++)
            {
                    Console.SetCursorPosition(x, 0);
                    Console.Write("#");
                    Console.SetCursorPosition(x, height);
                    Console.Write("#");
                }

            // Draw the left and right borders
            for (int y = 0; y <= height; y++)
            {
                    Console.SetCursorPosition(0, y);
                    Console.Write("#");
                    Console.SetCursorPosition(width, y);
                    Console.Write("#");
            }
            SetCursorPosition(ballX, ballY);
            WriteLine(ball);
        }
    
    }
}
