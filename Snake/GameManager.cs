namespace Snake;

public class GameManager
{
    private static GameManager instance;
    public static GameManager Instance => instance ??= new GameManager();
    private bool _wasInitialized;
    
    internal Controller _controller;
    private Fruit[] _fruits;

    private GameManager()
    { 
        _wasInitialized =  false;
        
        _controller =  Controller.Instance;
        
        _fruits =  new Fruit[20];
    }

    public void MovePlayer(Directions direction)
    {
        _controller.Pawn.ChangeDirection(direction);
    }
    
   
    public void Start()
    {
        if (_wasInitialized)
            return;
        
        _controller.Initialize();
        
        _wasInitialized =  true;
    }
    
}