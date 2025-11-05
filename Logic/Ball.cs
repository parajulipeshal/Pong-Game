using System.Drawing;
namespace Logic;

public class Ball : Rectangle, IBall
{
    public float MaxSpeedX { get; } = 2.5f;
    public float MaxSpeedY { get; } = 4f;
    private float speedX;
    private float speedY;
    public float SpeedX {
        get => speedX;
        set
        {
           Math.Min(Math.Abs(value), MaxSpeedX);
        }
     }
    public float SpeedY { 
        get => speedY;
        set
        {
           Math.Min(Math.Abs(value), MaxSpeedY);
        }
     }
    public int XDirection { get; set; }
    public int YDirection { get; set; }

    public Ball()
    {
        Height = 2f;
        Width = 2f;
        CenterX = 50;
        CenterY = 50;
    }
    public void DoMove()
    {
        CenterX += SpeedX * XDirection;
        CenterY += SpeedY * YDirection;
    }
    public void SetRandomStartVector()
    {
        CenterX = CenterY = 50;

        speedY = Random.Shared.NextSingle() * 0.3f * MaxSpeedY;
        YDirection = 1 - (2 * Random.Shared.Next(2));

        speedX = 0.3f * MaxSpeedX;
        XDirection = 1 - (2 * Random.Shared.Next(2));
    }
        
}