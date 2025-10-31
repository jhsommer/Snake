namespace Snake;


public class Fruit : IRendable
{
    private readonly Random _random = new Random();
    
    public int X { get; private set; }
    public int Y { get; private set; }

#if DEBUG
    public void SetPosition(int x, int y)
    {
        X = x;
        Y = y;
    }
#endif

    public void Initialize()
    {
        CreateFruit();
    }
    
    public void CreateFruit()
    {
        X = _random.Next(2, 39);
        Y = _random.Next(2, 19);;
    }

    public void Draw()
    {
        Console.SetCursorPosition(X, Y);
        Console.Write('*');
    }
}