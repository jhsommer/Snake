namespace Snake;

public class Controller
{
    private Snake _pawn =  new Snake();

    public void Initialize()
    {
        Main();
    }

    void Main()
    {
        ConsoleKeyInfo keyInfo;
        while (true)
        {
            int X = _pawn.GetHeadPositionX();
            int Y = _pawn.GetHeadPositionY();
            
            if (Console.KeyAvailable)
            {
                keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        _pawn.SetHeadPositionX(X--);
                        Console.WriteLine("Up");
                        break;
                    
                    case ConsoleKey.DownArrow:
                        _pawn.SetHeadPositionX(X++);
                        Console.WriteLine("Down");
                        break;
                    
                    case ConsoleKey.LeftArrow:
                        _pawn.SetHeadPositionY(Y--);
                        Console.WriteLine("Left");
                        break;
                    
                    case ConsoleKey.RightArrow:
                        _pawn.SetHeadPositionY(Y++);
                        Console.WriteLine("Right");
                        break;
                }
            }
            Thread.Sleep(100);
        }
    }
}