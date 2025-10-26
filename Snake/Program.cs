using System;
namespace Snake;


class Program
{
    public const int Height = 20;
    public const int Width = 40;
    
    public static float CountTicks = 0;
    
    private static Controller _controller;
    private static readonly GameManager GameManager = GameManager.Instance;
    private static bool _gameOver = false;

    private static void Main()
    {
        
        
        GameManager.Start();
        _controller = GameManager._controller;
        Console.CursorVisible = false;
        
        
        
        Console.WriteLine("Hello World!");

        int snakeTailLength = 0;
        int [] snakeTailX = new int[100];
        int [] snakeTailY = new int[100];
        
        int fruitX = 0;
        int fruitY = 0;

        while (!_gameOver)
        {
            CountTicks++;
                
            
            _controller.HandleInput();
            
            if( CountTicks == 20.0f)
            {
                _controller.Pawn.Move();
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
            
            
            Draw(_controller, fruitY, fruitX, snakeTailLength, snakeTailX, snakeTailY);
            

            snakeTailLength = Logic(_controller, fruitX, fruitY, snakeTailLength);
        }
    }

    private static int Logic(Controller controller, int fruitX, int fruitY, int snakeTailLength)
    {
        if (controller.Pawn.GetHeadPositionX() == fruitX && controller.Pawn.GetHeadPositionY() == fruitY)
        {
            snakeTailLength++;
        }

        return snakeTailLength;
    }

    private static void Draw(Controller controller, int fruitY, int fruitX, int snakeTailLength, int[] snakeTailX,
        int[] snakeTailY)
    {
        Console.SetCursorPosition(0, 0);
        
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

