using System;

namespace CaveMap
{
    internal class CaveMap
    {
        private readonly string WallIcon = "#";
        private readonly string FloorIcon = "·"; //ascii #183 middle dot

        private const int MapSizeX = 110;
        private const int MapSizeY = 35;

        private readonly Tile[,] GameMap = new Tile[MapSizeX, MapSizeY];

        private readonly Tile[,] TempMap = new Tile[MapSizeX, MapSizeY];

        private readonly Random random = new Random();

        //todo display()
        //todo generate()

        /*
         * init full blank map
         * fill with random walls
         * run through 4/5 algorithm
         *
         */

        public void Fill(int _wallChance) //? rename to Initialize() or Init()
        {
            for (int x = 0; x <= MapSizeX - 1; x++)
            {
                for (int y = 0; y <= MapSizeY - 1; y++)
                {
                    TempMap[x, y] = new Tile(x, y, WallIcon, false, false, true);

                    if (random.Next(1, 101) < _wallChance)
                        GameMap[x, y] = new Tile(x, y, WallIcon, false, false, true);
                    else
                        GameMap[x, y] = new Tile(x, y, FloorIcon, false, false, false);

                    if (x == 0 || y == 0 || x == MapSizeX - 1 || y == MapSizeY - 1) // create a border
                        GameMap[x, y] = new Tile(x, y, WallIcon, false, false, true);
                }
            }
        }

        public void Filter()
        {
            /* https://en.wikipedia.org/wiki/Cellular_automaton
             *
             * get x,y location
             * check all 8 squares around x,y location
             */
            
            Console.SetCursorPosition(0, 35);

            for (int x = 1; x <= MapSizeX - 2; x++) //skip outer wall
            {
                for (int y = 1; y <= MapSizeY - 2; y++) //skip outer wall
                {
                    //Tile CurrentTile = (Tile)GameMap[x, y];
                    Tile TempTile = (Tile)TempMap[x, y];

                    int WallCount = GetWallCount(x, y);

                    Console.Write(WallCount);

                    if (WallCount >= 5)
                    {
                        //GameMap[x, y] = new Tile(x, y, WallIcon, false, false, true);
                        TempTile.Icon = WallIcon;
                        TempTile.IsWall = true;
                    }
                    else
                    {
                        //GameMap[x, y] = new Tile(x, y, FloorIcon, false, false, false);
                        TempTile.Icon = FloorIcon;
                        TempTile.IsWall = false;
                    }
                }
            }
            TempMapToGameMap();
        }


        public int GetWallCount(int LOCx, int LOCy)
        {
            int _wallCount = 0;

            for (int x = (LOCx - 1); x <= (LOCx + 1); x++)
            {
                for (int y = (LOCy - 1); y <= (LOCy + 1); y++)
                {
                    if (!(x == LOCx && y == LOCy)) //dont count itself
                    {
                        if (GameMap[x, y].IsWall)
                            _wallCount++;
                    }
                }
            }
            return _wallCount;
        }


        public void TempMapToGameMap()
        {
            for (int x = 0; x <= MapSizeX - 1; x++)
            {
                for (int y = 0; y <= MapSizeY - 1; y++)
                {
                    GameMap[x, y] = (Tile)TempMap[x, y];
                }
            }
        }



        public void Display()
        {
            for (int x = 0; x <= MapSizeX - 1; x++)
            {
                for (int y = 0; y <= MapSizeY - 1; y++)
                {
                    Tile _currentTile = (Tile)GameMap[x, y];

                    Console.SetCursorPosition(x, y);

                    Console.WriteLine(_currentTile.Icon);
                }
            }
        }
    }
}