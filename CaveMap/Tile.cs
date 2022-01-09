namespace CaveMap;

public class Tile
{
    public int X { get; set; }
    public int Y { get; set; }
    public string Icon { get; set; }
    public bool IsWalkable { get; set; }
    public bool IsHallway { get; set; }
    public bool IsWall { get; set; }

    public Tile(int _x, int _y, string _icon, bool _iswalkable, bool _ishallway, bool _iswall)
    {
        X = _x;
        Y = _y;
        Icon = _icon;
        IsWalkable = _iswalkable;
        IsHallway = _ishallway;
        IsWall = _iswall;
    }

    public string DisplayIcon()
    {
        return Icon;
    }
}