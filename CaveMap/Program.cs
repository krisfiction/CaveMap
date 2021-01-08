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

            const bool _keepPlaying = true;
            do
            {
                ConsoleKey aInput = Console.ReadKey().Key;
                if (aInput == ConsoleKey.F5) //reload for testing
                {
                    caveMap.Fill(40); // % chance to be wall
                }

                if (aInput == ConsoleKey.Spacebar) // key to step through map creation
                {
                    caveMap.Filter(); // 2 steps at 40% fill seems to look good
                }

                caveMap.Display();
            } while (_keepPlaying);
        }
    }
}