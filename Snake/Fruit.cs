namespace Snake;


public class Fruit : IRendable
{
    private readonly Random _random = new Random();
    
    public int X { get; private set; }
    public int Y { get; private set; }

    public void Initialize()
    {
        CreateFruit();
    }
    
    public void CreateFruit()
    {
        X = _random.Next(1, 100) % Program.Width;
        Y = _random.Next(1, 100) % Program.Height;
    }

    public void Draw()
    {
        Console.SetCursorPosition(X, Y);
        Console.Write('*');
    }
}