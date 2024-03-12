using System;
using System.Threading;
using static System.Console;
using static System.ConsoleKey;

namespace ConsoleBouncingBall
{
    class Program
    {
        enum Level { HARD, MEDIUM, EASY=3};
        static void Main(string[] args)
        {
            int width = 30;
            int height = 20;
            int ballX = new Random().Next(1, width-1);
            int ballY = new Random().Next(1, height-1);

            int aimX = width / 2; 
            int aimY = height /2 ; 
            int ballVelocityX = 1;
            int ballVelocityY = 1;
            const string BALL = "\u26BD";
            const string FIREWORK = "\U0001F386";

            ConsoleColor originalColor = Console.ForegroundColor;
            
            bool hit = false; // Track if the ball has been hit

            Console.WriteLine("Press ESC to stop. Use arrows to move aim. Space to shoot.");
            try {
                    do
                    {
                        if (KeyAvailable)
                        {
                            var key = ReadKey(true).Key;
                            switch (key)
                            {
                                case LeftArrow:
                                    if (aimX > 1) aimX--; // Move aim left
                                    break;
                                case RightArrow:
                                    if (aimX < width - 1) aimX++; // Move aim right
                                    break;
                                case UpArrow:
                                    if( aimY >1) aimY--;
                                    break;
                                case DownArrow:
                                    if( aimY < height-1) aimY++;
                                    break;
                                case Spacebar:
                                    // Check if the aim is on the ball
                                    if (Math.Abs(aimX-ballX)<=(int)Level.EASY && Math.Abs(aimY-ballY)<=(int)Level.EASY )
                                    {
                                        hit = true;
                                    }
                                    break;
                                case Escape:
                                    return;
                            }
                        }

                        Clear(); 

                        // Draw the borders, ball, and aim
                        DrawBorders(width, height);
                        DrawBall(ballX, ballY, hit ? FIREWORK : BALL); // If hit, draw firework, else draw ball
                        
                        if (!hit) // Only move the ball if it hasn't been hit
                        {
                            UpdateBallPosition(ref ballX, ref ballY, ref ballVelocityX, ref ballVelocityY, width, height);
                        }

                        // Draw the aim
                        SetCursorPosition(aimX, aimY);
                        Write("<|>");

                        Thread.Sleep(100); // Slow down the animation
                    } while (true);
            }
            catch(Exception e) { 
                Write(e.Message); 
            }
            finally {
                Clear();
            }
        }

        static void DrawBorders(int width, int height)
        {
            for (int x = 0; x <= width; x++)
            {
                SetCursorPosition(x, 0);
                Write("#");
                SetCursorPosition(x, height);
                Write("#");
            }

            for (int y = 0; y <= height; y++)
            {
                SetCursorPosition(0, y);
                Write("#");
                SetCursorPosition(width, y);
                Write("#");
            }
        }

        static void DrawBall(int x, int y, string icon)
        {
            SetCursorPosition(x, y);
            Write(icon);
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
