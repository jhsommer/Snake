namespace Snake;

public class Controller
{
    private static Controller _instance = null!;

    public static Controller Instance
    {
        get
        {
            _instance = new Controller();
            return _instance;
        }
    }
    
    private bool _wasInitialized;
    internal Snake Pawn = new Snake();

    private Controller()
    {
        
    }

    public void Initialize()
    {
        if (_wasInitialized) 
            return;
        
        SetPawn(Pawn);
        Pawn.Initialize();
        //Pawn.SetPlayerStart();
        _wasInitialized = true;
        //Main();
    }

    private void SetPawn(Snake pawn)
    {
        Pawn = pawn;
    }

    public void HandleInput()
    {
        if(!Console.KeyAvailable)
        {
            return;
        }
        
        ConsoleKey key = Console.ReadKey(true).Key;

        switch (key)
        {
            case ConsoleKey.W :
                GameManager.Instance.MovePlayer(Directions.Up);
                break;
            
            case ConsoleKey.S :
                GameManager.Instance.MovePlayer(Directions.Down);
                break;
            
            case ConsoleKey.A :
                GameManager.Instance.MovePlayer(Directions.Left);
                break;
            
            case ConsoleKey.D :
                GameManager.Instance.MovePlayer(Directions.Right);
                break;
            
            default:
                break;
        }
        
        Thread.Sleep(100);
    }
    
}