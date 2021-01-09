using System;

namespace CaveMap
{
    internal static class Program
    {
        private static void Main()
        {
            Console.Title = "CaveMap";
            Console.SetWindowSize(140, 46);
            Console.CursorVisible = false; //to hide the cursor
            Console.Clear();

            CaveMap caveMap = new CaveMap();

            caveMap.Fill(40); // % chance to be wall

            caveMap.Display();

            int passes = 0;
            Console.WriteLine($"\n\nFilter Pass: {passes}.");
            Console.WriteLine("\n[SPACE BAR] to run filter, [F5] to create new map");
            Console.WriteLine("\nPass 0 = initialize map, Pass 2 looks the best to me, More passes will smooth the walls out.");

            const bool _keepPlaying = true;
            do
            {
                ConsoleKey aInput = Console.ReadKey().Key;
                if (aInput == ConsoleKey.F5) //reload for testing
                {
                    caveMap.Fill(40); // % chance to be wall
                    passes = 0;
                }

                if (aInput == ConsoleKey.Spacebar) // key to step through map creation
                {
                    caveMap.Filter(); // 2 steps at 40% fill seems to look good
                    passes++;
                }

                caveMap.Display();
                Console.WriteLine($"\n\nFilter Pass: {passes}.");
                Console.WriteLine("\n[SPACE BAR] to run filter, [F5] to create new map");
                Console.WriteLine("\nPass 0 = initialize map, Pass 2 looks the best to me, More passes will smooth the walls out.");
            } while (_keepPlaying);
        }
    }
}