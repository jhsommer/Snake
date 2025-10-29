namespace Snake;

public class DoOnce
{
    private bool _done = false;

    public void Do(Action action)
    {
        if(_done) return;
        
        _done = true;
        action();
    }

    public void Reset()
    {
        _done = false;
    }
}


class Program
{
    private static readonly DoOnce DoOnce = new DoOnce();
    
    public const int Height = 20;
    public const int Width = 40;

    private static float _countTicks = 0;
    private static int _score = 0;
    private static bool _gameOver = false;
    
    private static Controller _controller;
    private static readonly GameManager GameManager = GameManager.Instance;

    private static void Main()
    {
        
        
        GameManager.Start();
       _controller = GameManager.GetController();
        Console.CursorVisible = false;

        while (!_gameOver)
        {
            
            _countTicks++;
            
            _controller.HandleInput();
            
            if (_controller.Pawn.GetHeadPositionX() == GameManager.GetFruit().X && _controller.Pawn.GetHeadPositionY() == GameManager.GetFruit().Y)
            {
                DoOnce.Do(() => FruitCollected());
            }
            
            if( _countTicks == 20.0f)
            {
                _controller.Pawn.Move();
                
                DoOnce.Reset();
                
                _countTicks = 0;
            }

            if (_controller.Pawn.CollidesWithSelf())
            {
                _gameOver = true;
            }

            if (_controller.Pawn.IsOutOfBounds())
            {
                _gameOver = true;
            }
            
            Draw();

        }
    }
    
    private static void FruitCollected()
    {
        _score += 10;
        GameManager.GetFruit().CreateFruit();
        _controller.Pawn.Grow();
    }

    private static void Draw()
    {
        Console.SetCursorPosition(0, 0);
        Console.WriteLine(_score);
        
        for (int i = 0; i < Width + 2; i++)
        {
            Console.Write("-");
        }
        
        Console.Write("\n");

        for (int i = 0; i < Height; i++)
        {
            for (int j = 0; j <= Width; j++)
            {
                if (j == 0 || j == Width)
                {
                    Console.Write("#");
                }

                if (i == _controller.Pawn.GetHeadPositionY() && j == _controller.Pawn.GetHeadPositionX())
                {
                    Console.Write("O");
                }

                else if (i == GameManager.GetFruit().Y && j == GameManager.GetFruit().X)
                {
                    Console.Write("*");
                }

                else
                {
                    bool prTail = false;
                    for (int k = 0; k < _controller.Pawn.Body.Count; k++)
                    {
                        
                        if (_controller.Pawn.Body[k] == (j, i))
                        {
                            Console.Write("H");
                            prTail = true;
                        }
                    }

                    if (!prTail)
                    {
                        Console.Write(" ");
                    }
                }
                
            }
            Console.Write("\n");
        }
        
        for (int i = 0; i < Width + 2; i++)
        {
            Console.Write("-");
        }
        Console.Write("\n");
    }
}

