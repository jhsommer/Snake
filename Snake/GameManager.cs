namespace Snake;

public class GameManager
{
    private static GameManager instance;
    public static GameManager Instance => instance ??= new GameManager();
    private bool _wasInitialized;
    
    internal Controller _controller;
    internal Fruit _fruit;

    private GameManager()
    { 
        _wasInitialized =  false;
        _controller =  Controller.Instance;
       _fruit = new Fruit();
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