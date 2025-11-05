public interface IBall
{
    float MaxSpeedX { get; }
    float MaxSpeedY { get; }
    float SpeedX { get; set; }
    float SpeedY { get; set; }
    int XDirection { get; set; }
    int YDirection { get; set; }
}