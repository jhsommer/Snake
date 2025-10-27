namespace Snake;

public class Snake
{
    private int prevHeadX, prevHeadY;
    private int _headPositionX =  1;
    private int _headPositionY = 1;
    private Directions _currentDirection = Directions.Start;
    private Controller _controller = null!;
    
    private readonly List<(int X, int Y)> _body = new List<(int X, int Y)>();
    public IReadOnlyList<(int X, int Y)> Body => _body.AsReadOnly();
    
    public void ChangeDirection(Directions direction)
    {
        _currentDirection = direction;
        //Move();
    }

    public bool CollidesWithSelf()
    {
        for (int i = 0; i < _body.Count; i++)
        {
            if (_body[i] == (_headPositionX, _headPositionY))
            {
                return true;
            }
        }
        return false;
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
        Console.Write(_body.Count);
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
        
        for (int i = _body.Count -1; i > 0; i--)
        {
            _body[i] = _body[i - 1];
        }
        
        if (_body.Count > 0)
        {
            _body[0] = (prevHeadX,  prevHeadY);
        }

    }

    public void Grow()
    {
        if (_body.Count > 0)
        {
            _body.Insert(0, (prevHeadX,  prevHeadY));
        }
        else if (_body.Count == 0)
        {
            _body.Add((prevHeadX,  prevHeadY));
        }
    }
    
    public void SetPlayerStart()
    {
        _headPositionX = Program.Width / 2;
        _headPositionY = Program.Height / 2;
    }
    
}