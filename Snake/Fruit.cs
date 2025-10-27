namespace Snake;


public class Fruit
{
    private Random _random = new Random();
    
    public int _x { get; private set; }
    public int _y { get; private set; }
    public void CreateFruit()
    {
        _x = _random.Next(1, 100) % Program.Width;
        _y = _random.Next(1, 100) % Program.Height;
    }
}