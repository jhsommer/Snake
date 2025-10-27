namespace Snake;

public class Snake
{
    private int prevHeadX, prevHeadY;
    private int _headPositionX =  1;
    private int _headPositionY = 1;
    private Directions _currentDirection = Directions.Start;
    private Controller _controller = null!;
    
    public void ChangeDirection(Directions direction)
    {
        _currentDirection = direction;
        Move();
    }
    
    public void Initialize()
    {
        SetPlayerStart();
    }

   public int GetHeadPositionX()
    {
        return _headPositionX;
    }

    public int GetHeadPositionY()
    {
        return _headPositionY;
    }

    public int GetPreviousHeadPositionX()
    {
        return prevHeadX;
    }

    public int GetPreviousHeadPositionY()
    {
        return prevHeadY;
    }

    void PossessedBy(Controller newController)
    {
        _controller = newController;
    }
    
    public void Move()
    {
        prevHeadX = _headPositionX;
        prevHeadY = _headPositionY;
        
        switch (_currentDirection)
        {
            case Directions.Up:
                _headPositionY--;
                break;
            
            case Directions.Down:
                _headPositionY++;
                break;
            
            case Directions.Left:
                _headPositionX--;
                break;
            
            case Directions.Right:
                _headPositionX++;
                break;
        }
    }

    public void SetPlayerStart()
    {
        _headPositionX = Program.Width / 2;
        _headPositionY = Program.Height / 2;
    }


}