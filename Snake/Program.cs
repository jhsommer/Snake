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
    private static readonly Random _random = new Random();
    
    public static float CountTicks = 0;
    private static int TailSpawnTicks = 0;
    private static int snakeTailLength = 0;
    private static int [] snakeTailX = new int[100];
    private static int [] snakeTailY = new int[100];
    private static int _score = 0;
    
    private static int fruitX = _random.Next(1, 100) % Width;
    private static int fruitY = _random.Next(1, 100) % Height;
    
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
            TailSpawnTicks++;
            
            _controller.HandleInput();
            
            Draw(_controller);
            Logic(_controller);
            
            if( CountTicks == 20.0f)
            {
                _controller.Pawn.Move();
                _doOnce.Reset();
                
                CountTicks = 0;
            }
            
            
            if (_controller.Pawn.GetHeadPositionX() < 0 || _controller.Pawn.GetHeadPositionX() >= Width ||
                _controller.Pawn.GetHeadPositionY() < 0 || _controller.Pawn.GetHeadPositionY() >= Height)
            {
                _gameOver = true;
            }
            
            for (int i = 0; i < snakeTailLength; i++)
            {
                if (snakeTailX[i] == _controller.Pawn.GetHeadPositionX() &&
                    snakeTailY[i] == _controller.Pawn.GetHeadPositionY())
                {
                    _gameOver = true;
                }
            }
            
            

        }
    }

    private static void Logic(Controller controller)
    {
            for (int i = snakeTailLength -1; i > 0; i--)
            {
                snakeTailX[i]= snakeTailX[i - 1];
                snakeTailY[i]= snakeTailY[i - 1];
                
            }
        
            snakeTailX[0] = controller.Pawn.GetPreviousHeadPositionX();
            snakeTailY[0] = controller.Pawn.GetPreviousHeadPositionY();
            
        if (controller.Pawn.GetHeadPositionX() == fruitX && controller.Pawn.GetHeadPositionY() == fruitY)
        {
            _doOnce.Do(() => FruitCollected());
        }
        
    }

    private static void FruitCollected()
    {
        _score += 10;
        
        fruitX = _random.Next(1, 100) % Width;
        fruitY = _random.Next(1, 100) % Height;
        
        snakeTailLength++;
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
                    //Console.Write((i, j));
                }

                else if (i == fruitY && j == fruitX)
                {
                    Console.Write("*");
                }

                else
                {
                    bool prTail = false;
                    for (int k = 0; k < snakeTailLength; k++)
                    {
                        if (snakeTailX[k] == j && snakeTailY[k] == i)
                        {
                            //Console.Write((j, k));
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

