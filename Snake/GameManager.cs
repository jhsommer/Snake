namespace Snake;

public class GameManager
{
    private static GameManager _instance = null!;

    public static GameManager Instance
    {
        get
        {
            _instance = new GameManager();
            return _instance;
        }
    }
    
    private bool _wasInitialized;
    
    private Controller _controller;
    private Fruit _fruit;

    private GameManager()
    { 
        _wasInitialized =  false;
        _controller =  Controller.Instance;
       _fruit = new Fruit();
    }

    public Fruit GetFruit()
    {
        return _fruit;
    }

    public Controller GetController()
    {
        return _controller;
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
        _fruit.CreateFruit();
        _wasInitialized =  true;
    }
    
}