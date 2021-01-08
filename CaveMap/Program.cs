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

            caveMap.Fill(60); //60% chance to be wall

            //caveMap.Filter();

            caveMap.Display();

            const bool _keepPlaying = true;
            do
            {
                ConsoleKey aInput = Console.ReadKey().Key;
                if (aInput == ConsoleKey.F5) //reload for testing
                {
                    Main();
                }

                if (aInput == ConsoleKey.Spacebar) // key to step through map creation
                {
                    caveMap.Filter();

                    caveMap.Display();
                }
            } while (_keepPlaying);
        }
    }
}