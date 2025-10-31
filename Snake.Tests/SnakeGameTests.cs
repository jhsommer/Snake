namespace Snake.Tests;

public class SnakeGameTests
{
    [Fact]
    public void SnakeMovesUp()
    {
        var snake =  new Snake();
        snake.Initialize();
        var initialY = snake.GetHeadPositionY();
        
        snake.ChangeDirection(Directions.Up);
        snake.Move();
        
        Assert.Equal(initialY - 1, snake.GetHeadPositionY());
    }

    [Fact]
    public void SnakeOutOfBounds()
    {
        var snake = new Snake();
        snake.Initialize();
        
        typeof(Snake).GetField("_headPositionX", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)?.SetValue(snake,Program.Width + 1);
        
        Assert.True(snake.IsOutOfBounds());
    }

    [Fact]
    public void SnakeCollectsFruit()
    {
        var snake = new Snake();
        snake.Initialize();
        var initialLength = snake.Body.Count;
        
        var fruit = new Fruit();
        fruit.SetPosition(snake.GetHeadPositionX() + 1, snake.GetHeadPositionY());
        
        snake.ChangeDirection(Directions.Right);
        snake.Move();
        
        typeof(Fruit)
            .GetField("X", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            ?.SetValue(fruit, snake.GetHeadPositionX());
        
        typeof(Fruit)
            .GetField("Y", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            ?.SetValue(fruit, snake.GetHeadPositionY());

        if (snake.GetHeadPositionX() == fruit.X && snake.GetHeadPositionY() == fruit.Y)
        {
            snake.Grow();
        }
        
        Assert.Equal(initialLength + 1, snake.Body.Count);
    }
}