namespace Snake;

public class Controller
{
    private static Controller instance;
    public static Controller Instance => instance ??= new Controller();
    
    private bool _wasInitialized;
    internal Snake Pawn;

    private Controller()
    {
        
    }

    public void Initialize()
    {
        if (_wasInitialized) 
            return;
        
        Pawn.SetPlayerStart();
        _wasInitialized = true;
        //Main();
    }

    public void SetPawn(Snake _pawn)
    {
        Pawn = _pawn;
    }

    public void HandleInput()
    {
        if(!Console.KeyAvailable)
            return;
        
        ConsoleKey key = Console.ReadKey(true).Key;

        switch (key)
        {
            case ConsoleKey.UpArrow :
                GameManager.Instance.MovePlayer(Directions.Up);
                break;
            
            case ConsoleKey.DownArrow :
                GameManager.Instance.MovePlayer(Directions.Down);
                break;
            
            case ConsoleKey.LeftArrow :
                GameManager.Instance.MovePlayer(Directions.Left);
                break;
            
            case ConsoleKey.RightArrow :
                GameManager.Instance.MovePlayer(Directions.Right);
                break;
            
            default:
                break;
        }
    }
    
}