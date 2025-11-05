using Logic;

namespace Lab09Tests;

public class GameTesting
{
    [Fact]
    public void ScoreTest()
    {
        var left = new Paddle(false, 1f);
        var right = new Paddle(true, 1f);
        var ball = new Ball();
        var game = new Game(left, right, ball, 0, 0);
        ball.CenterX = 100f;
        ball.XDirection = 1;
        game.Tick();
        Assert.Equal(1, game.ScoreAI);
        Assert.Equal(50f, ball.CenterX);
        Assert.Equal(50f, ball.CenterY);

    }

    [Fact]
    public void ScoreResetTest()
    {
        var left = new Paddle(false, 1f);
        var right = new Paddle(true, 1f);
        var ball = new Ball();
        var game = new Game(left, right, ball, 9, 0);
        ball.CenterX = 100f;
        ball.XDirection = 1;
        game.Tick();
        Assert.Equal(0, game.ScoreAI);
        Assert.Equal(0, game.ScorePlayer);

    }
    [Fact]
    public void BallDirectionTest()

    {
        var left = new Paddle(false, 1f);
        var right = new Paddle(true, 1f);
        var ball = new Ball();
        var game = new Game(left, right, ball, 9, 0);
        ball.CenterY = 1f;
        ball.SpeedY = 1f;
        ball.YDirection = -1;
        game.Tick();
        Assert.Equal(1, ball.YDirection);

    }
}
