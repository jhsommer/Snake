namespace Snake;

public class GameManager
{
    private static GameManager instance;
    public static GameManager Instance => instance ??= new GameManager();
    private bool _wasInitialized;

    private Snake _snake;
    private Controller _controller;
    private Fruit[] _fruits;

    private GameManager()
    { 
        _wasInitialized =  false;
        
        _snake = Snake.Instance;
        _controller =  Controller.Instance;
        
        _fruits =  new Fruit[20];
    }

    public void MovePlayer(Directions direction)
    {
        _snake.ChangeDirection(direction);
    }
    
   // private Snake _player =  new Snake();

    public void Start()
    {
        if (_wasInitialized)
            return;
        
        _controller.SetPawn(_snake);
        _controller.Initialize();
        
        _snake.Initialize();
        
        _wasInitialized =  true;
    }

   public void Update()
    {
        
    }
}