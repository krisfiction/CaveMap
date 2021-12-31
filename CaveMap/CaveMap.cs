using System;

namespace CaveMap
{
    internal class CaveMap
    {
        private readonly string WallIcon = "#";
        private readonly string FloorIcon = "·"; //middle dot

        private const int MapSizeX = 110;
        private const int MapSizeY = 35;

        private readonly Tile[,] GameMap = new Tile[MapSizeX, MapSizeY];

        private readonly Tile[,] TempMap = new Tile[MapSizeX, MapSizeY];

        private readonly Random random = new Random();

        public void Fill(int _wallChance) //? rename to Initialize() or Init()
        {
            for (int x = 0; x <= MapSizeX - 1; x++)
            {
                for (int y = 0; y <= MapSizeY - 1; y++)
                {
                    TempMap[x, y] = new Tile(x, y, WallIcon, false, false, true); //fill TempMap with all walls

                    if (random.Next(1, 101) <= _wallChance)
                        GameMap[x, y] = new Tile(x, y, WallIcon, false, false, true); //set tile to wall
                    else
                        GameMap[x, y] = new Tile(x, y, FloorIcon, false, false, false); //set tile to floor

                    if (x == 0 || y == 0 || x == MapSizeX - 1 || y == MapSizeY - 1) // create a border of all walls
                        GameMap[x, y] = new Tile(x, y, WallIcon, false, false, true);
                }
            }
        }

        public void Filter()
        {
            for (int x = 1; x <= MapSizeX - 2; x++) //skip outer wall
            {
                for (int y = 1; y <= MapSizeY - 2; y++) //skip outer wall
                {
                    Tile TempTile = (Tile)TempMap[x, y];

                    int WallCount = GetWallCount(x, y);

                    if (WallCount >= 5) //set as wall
                    {
                        TempTile.Icon = WallIcon;
                        TempTile.IsWall = true;
                    }
                    else if (WallCount <= 3) //set as floor
                    {
                        TempTile.Icon = FloorIcon;
                        TempTile.IsWall = false;
                    }
                }
            }
            CopyMap(TempMap, GameMap);
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

        public void CopyMap(Tile[,] oldMap, Tile[,] newMap)
        {
            for (int x = 0; x <= MapSizeX - 1; x++)
            {
                for (int y = 0; y <= MapSizeY - 1; y++)
                {
                    newMap[x, y] = oldMap[x, y];
                }
            }
        }

        public void Display()
        {
            for (int x = 0; x <= MapSizeX - 1; x++)
            {
                for (int y = 0; y <= MapSizeY - 1; y++)
                {
                    Tile tile = GameMap[x, y];

                    Console.SetCursorPosition(x, y);

                    Console.Write(tile.Icon);
                }
            }
        }
    }
}