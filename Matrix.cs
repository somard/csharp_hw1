using System;
using static System.Console;
using static System.ConsoleKey;
using System.Threading;

namespace MatrixEffect
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

            int width = 30; //Console.WindowWidth;
            int height = 30; // Console.WindowHeight;

            int[] y = new int[width];

            // Initialize the starting y positions of the drops
            for (int x = 0; x < width; ++x) y[x] = -1;

            Random random = new Random();

            while (true) // Infinite loop to keep the effect going
            {
                for (int x = 0; x < width; ++x)
                {
                    // Clear the character at the current position
                    if( y[x] > 0 ) {
			Console.SetCursorPosition(x, y[x]%height);
                    	Console.Write(" ");
		    }

                    // Move the y position down for the next character
                    y[x] = (y[x] + 1) % height;

                    // Draw the new character
                    Console.SetCursorPosition(x, y[x]);
                    Console.Write((char)('a' + random.Next(26))); // Random lowercase letter

                    // Occasionally reset the drop to the top
                    if (random.Next(height) == 0) y[x] = 0;
                }

                Thread.Sleep(100); // Small delay to slow down the effect
		if( KeyAvailable && ReadKey(true).Key == Escape )
			break;
            }
        }
    }
}
