using System;
using System.Threading;

namespace ConsoleBouncingBall
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = 30;
            int height = 20;
            int ballX = width / 2;
            int ballY = height / 2;
            int aimX = width / 2; // Initialize aiming position
            int aimY = height /2 ; 
            int ballVelocityX = 1;
            int ballVelocityY = 1;
            ConsoleColor originalColor = Console.ForegroundColor;
            bool hit = false; // Track if the ball has been hit

            Console.WriteLine("Press ESC to stop. Use Left/Right arrows to move aim. Space to shoot.");
            do
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;
                    switch (key)
                    {
                        case ConsoleKey.LeftArrow:
                            if (aimX > 1) aimX--; // Move aim left
                            break;
                        case ConsoleKey.RightArrow:
                            if (aimX < width - 1) aimX++; // Move aim right
                            break;
                        case ConsoleKey.Spacebar:
                            // Check if the aim is on the ball
                            if (Math.Abs(aimX-ballX)<=3 && Math.Abs(aimY-ballY)<=3)
                            {
                                hit = true;
                            }
                            break;
                        case ConsoleKey.Escape:
                            return;
                    }
                }

                Console.Clear(); // Clear the console

                // Draw the borders, ball, and aim
                DrawBorders(width, height);
                DrawBall(ballX, ballY, hit ? "🐒" : "\u26BD"); // If hit, draw monkey, else draw ball
                
                if (!hit) // Only move the ball if it hasn't been hit
                {
                    UpdateBallPosition(ref ballX, ref ballY, ref ballVelocityX, ref ballVelocityY, width, height);
                }

                // Draw the aim
                Console.SetCursorPosition(aimX, aimY);
                Console.Write("|");

                Thread.Sleep(100); // Slow down the animation
            } while (true);
        }

        static void DrawBorders(int width, int height)
        {
            for (int x = 0; x <= width; x++)
            {
                Console.SetCursorPosition(x, 0);
                Console.Write("#");
                Console.SetCursorPosition(x, height);
                Console.Write("#");
            }

            for (int y = 0; y <= height; y++)
            {
                Console.SetCursorPosition(0, y);
                Console.Write("#");
                Console.SetCursorPosition(width, y);
                Console.Write("#");
            }
        }

        static void DrawBall(int x, int y, string icon)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(icon);
        }

        static void UpdateBallPosition(ref int x, ref int y, ref int velocityX, ref int velocityY, int width, int height)
        {
            x += velocityX;
            y += velocityY;

            if (x <= 1 || x >= width - 1)
            {
                velocityX = -velocityX;
            }
            if (y <= 1 || y >= height - 1)
            {
                velocityY = -velocityY;
            }
        }
    }
}
