using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace BouncingBall
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random ranNumberGenerator = new Random();
            int randomNumber;
            randomNumber = ranNumberGenerator.Next(1, 39);

            int width = 40;
            int height = 40;
            int ballX = randomNumber / 2;
            int ballY = randomNumber / 2;
            int ballVelocityX = 1;
            int ballVelocityY = 1;

            Console.WriteLine("Press ESC to stop");

            do
            {   
                while (!Console.KeyAvailable)

                // Draw the top and bottom borders
                for (int x = 0; x <= width; x++)
                {
                    SetCursorPosition(x, 0);
                    Console.Write("-");
                    Console.SetCursorPosition(x, height);
                    Console.Write("_");
                }

                // Draw the left and right borders
                for (int y = 0; y <= height; y++)
                {
                    Console.SetCursorPosition(0, y);
                    Console.Write("|");
                    Console.SetCursorPosition(width, y);
                    Console.Write("|");
                }


                ballX += ballVelocityX;
                ballY += ballVelocityY;

                bool hasHit = false;

                if (ballX <= 1 || ballX >= width - 1)
                {
                    ballVelocityX = -ballVelocityX;
                    hasHit = true;
                }

                if (ballY <= 1 || ballY >= height - 1)
                {
                    ballVelocityY = -ballVelocityY;
                    hasHit = true;
                }
                if (hasHit)
                {
                    Console.Beep();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Thread.Sleep(1000);
                    Console.SetCursorPosition(ballX, ballY);
                    Thread.Sleep(400);
                    Console.Write("\x26BD");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Thread.Sleep(1000);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.SetCursorPosition(ballX, ballY);
                Console.Write("\x26BD");

                Thread.Sleep(100);
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
         }

    }
    }


