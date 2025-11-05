namespace Logic;

public class Rectangle
{
    //TODO: strip out Width, Height, CenterX, CenterY, Top, Bottom, Left, Right - but give them ToStyle()
    //TODO: top, bottom, left, right need to be expression properties (calculated value in the getter, no backing field)

    public float Width { get; set; }
    public float Height { get; set; }
    public float CenterX { get; set; }
    public float CenterY { get; set; }

    public float Top => CenterY - Height / 2;
    public float Bottom => CenterY + Height / 2;
    public float Left => CenterX - Width / 2;
    public float Right => CenterX + Width / 2;

    public string ToStyle() => $@"
top: {Top}%;
left: {Left}%;
";
}
