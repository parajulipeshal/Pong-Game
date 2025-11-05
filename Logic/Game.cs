namespace Logic;

public class Game
{
    public Paddle LeftPaddle { get; } = new(false, 1f);
    public Paddle RightPaddle { get; } = new(true, 2f);
    public Ball Ball { get; } = new();
    public int ScorePlayer { get; private set; }
    public int ScoreAI { get; private set; }

    public Game()
    {
    }

    /// <summary>
    /// This constructor is just for testing.  It lets you place a ball and paddles in a specific location.
    /// That way you can call Tick() and see how the game behaves.
    /// </summary>
    public Game(Paddle leftPaddle, Paddle rightPaddle, Ball ball, int aiScore, int playerScore)
    {
        LeftPaddle = leftPaddle;
        RightPaddle = rightPaddle;
        Ball = ball;
        ScoreAI = aiScore;
        ScorePlayer = playerScore;
    }

    public void Start()
    {
        Ball.SetRandomStartVector();
    }

    public void Tick()
    {
        Ball.DoMove();

        CheckWallCollision();

        CheckBarCollision();

        ComputerAIEngineMove();

        MoveBars();

        CheckGoal();
    }

    private void ComputerAIEngineMove()
    {
        var deltaY = Ball.CenterY - LeftPaddle.CenterY;
        LeftPaddle.MoveDirection = Math.Abs(deltaY) < 4 ? 0 : Math.Sign(deltaY);
    }

    private void MoveBars()
    {
        foreach (var b in (Paddle[])[LeftPaddle, RightPaddle])
        {
            b.CenterY += b.Speed * b.MoveDirection;
            if (b.Top < 0)
                b.CenterY += b.Speed;
            if (b.Bottom > 100)
                b.CenterY -= b.Speed;
        }
    }

    private void CheckBarCollision()
    {
        var targetPaddle = Ball.XDirection == 1 ? RightPaddle : LeftPaddle;

        if (Ball.Bottom < targetPaddle.Top
            || Ball.Top > targetPaddle.Bottom
            || Ball.Right < targetPaddle.Left
            || Ball.Left > targetPaddle.Right
            )
            return;

        Ball.XDirection *= -1;
        Ball.SpeedX += 0.1f;

        var deltaY = Math.Abs(targetPaddle.CenterY - Ball.CenterY);
        var rateY = deltaY / (targetPaddle.Height / 2);
        var ySpeedDeltaChange = 0f;
        if (rateY < 0.5f) //slow down just a little
            ySpeedDeltaChange -= 0.1f * (rateY * 2);
        else //accelerate
            ySpeedDeltaChange += 0.2f * (rateY * 2);

        Ball.SpeedY += ySpeedDeltaChange;
    }

    /// <summary>
    /// The CheckGoal() method in the Game class should handle checking if a goal has been scored. It should perform
    /// the following steps:
    ///  1.	Check if the Ball object's Left property is less than or equal to 0
    ///  2. Check if the Ball object's Right property is greater than or equal to 100
    ///  3.	If either of the above conditions are true, determine which player scored the goal based on the Ball 
    ///     object's XDirection property. If XDirection is 1, increment the ScoreAI property by 1. Otherwise, 
    ///     increment the ScorePlayer property by 1.
    ///  4.	Call the SetRandomStartVector() method of the Ball object to reset its position and direction.
    ///  5.	Check if either the ScoreAI or ScorePlayer property is greater than 9. If true, reset both ScoreAI and
    ///     ScorePlayer to 0.
    /// </summary>
    private void CheckGoal()
    {

        if (Ball.Left <= 0 || Ball.Right >= 100)
        {

            if (Ball.XDirection == 1)
                ScoreAI++;
            else
            ScorePlayer++;
            Ball.SetRandomStartVector();

            if (ScoreAI > 9 || ScorePlayer > 9)
            {
                ScoreAI = 0;
                ScorePlayer = 0;
            }
        }
    }

    /// <summary>
    /// The CheckWallCollision method in the Game class is responsible for checking if the ball has collided with
    /// the top or bottom walls of the game area. Here's a summary of the steps involved in implementing this method:
    ///   1. Check if the ball's Top property is less than or equal to 0 or if the ball's Bottom property is
    ///      greater than or equal to 100. This condition checks if the ball has collided with the top or bottom walls.
    ///   2. If the above condition is true, it means that a collision has occurred. In this case, you need to reverse
    ///      the ball's vertical direction by multiplying its YDirection property by -1. This will make the ball bounce
    ///      off the wall.
    /// </summary>
    private void CheckWallCollision()
    {
        if (Ball.Top <= 0 || Ball.Bottom >= 100)
            Ball.YDirection *= -1;
    }
}

