namespace Snake;

public class GameManager
{
   // private Snake _player =  new Snake();
   private Controller _controller =  new Controller();
   private Fruit []  _fruits =  new Fruit[20];

    public void Start()
    {
        _controller.Initialize();
    }

   public void Update()
    {
        
    }
}