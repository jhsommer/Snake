namespace Snake;

public class Snake : IRendable
{
    private int _prevHeadX, _prevHeadY;
    private int _headPositionX =  1;
    private int _headPositionY = 1;
    private Directions _currentDirection = Directions.Start;
    
    private readonly List<(int X, int Y)> _body = [];
    public IReadOnlyList<(int X, int Y)> Body => _body.AsReadOnly();
    
    public void ChangeDirection(Directions direction)
    {
        _currentDirection = direction;
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

    public bool IsOutOfBounds()
    {
        if (_headPositionX < 0 || _headPositionY < 0 || _headPositionX >= Program.Width ||
            _headPositionY >= Program.Height)
        {
            return true;
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
    
    public void Move()
    {
        //Console.Write(_body.Count);
        _prevHeadX = _headPositionX;
        _prevHeadY = _headPositionY;
        
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
            _body[0] = (_prevHeadX,  _prevHeadY);
        }

    }

    public void Grow()
    {
        if (_body.Count > 0)
        {
            _body.Insert(0, (_prevHeadX,  _prevHeadY));
        }
        else if (_body.Count == 0)
        {
            _body.Add((_prevHeadX,  _prevHeadY));
        }
    }
    
    private void SetPlayerStart()
    {
        _headPositionX = Program.Width / 2;
        _headPositionY = Program.Height / 2;
    }

    public void Draw()
    {
        Console.SetCursorPosition(_headPositionX, _headPositionY);
        Console.Write('O');
    }
}