using System;
namespace Snake;

public class DoOnce
{
    private bool done = false;

    public void Do(Action action)
    {
        if(done) return;
        
        done = true;
        action();
    }

    public void Reset()
    {
        done = false;
    }
}


class Program
{
    public static DoOnce _doOnce = new DoOnce();
    public const int Height = 20;
    public const int Width = 40;
    
    public static float CountTicks = 0;

    private static int _score = 0;
    
    private static Controller _controller;
    private static readonly GameManager GameManager = GameManager.Instance;
    private static bool _gameOver = false;

    private static void Main()
    {
        
        
        GameManager.Start();
        _controller = GameManager._controller;
        Console.CursorVisible = false;

        while (!_gameOver)
        {
            
            CountTicks++;
            
            _controller.HandleInput();
            
            if (_controller.Pawn.GetHeadPositionX() == GameManager._fruit._x && _controller.Pawn.GetHeadPositionY() == GameManager._fruit._y)
            {
                _doOnce.Do(() => FruitCollected());
            }
            
            if( CountTicks == 20.0f)
            {
                _controller.Pawn.Move();
                
                _doOnce.Reset();
                
                CountTicks = 0;
            }

            if (_controller.Pawn.CollidesWithSelf())
            {
                _gameOver = true;
            }

            if (_controller.Pawn.IsOutOfBounds())
            {
                _gameOver = true;
            }
            
            Draw(_controller);

        }
    }
    
    private static void FruitCollected()
    {
        _score += 10;
        GameManager._fruit.CreateFruit();
        _controller.Pawn.Grow();
    }

    private static void Draw(Controller controller)
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

                if (i == controller.Pawn.GetHeadPositionY() && j == controller.Pawn.GetHeadPositionX())
                {
                    Console.Write("O");
                }

                else if (i == GameManager._fruit._y && j == GameManager._fruit._x)
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

