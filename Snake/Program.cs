using System;
namespace Snake;


class Program
{
    public const int Height = 20;
    public const int Width = 40;
    
    private static readonly Controller Controller = Controller.Instance;
    private static readonly GameManager GameManager = GameManager.Instance;
    private static bool _gameOver = false;

    private static void Main()
    {
        GameManager.Start();
        //Console.WriteLine("Hello World!");

        int snakeTailLength = 0;
        int [] snakeTailX = new int[100];
        int [] snakeTailY = new int[100];
        
        int fruitX = 0;
        int fruitY = 0;

        while (!_gameOver)
        {
            if (Controller._pawn.GetHeadPositionX() < 0 || Controller._pawn.GetHeadPositionX() >= Width ||
                Controller._pawn.GetHeadPositionY() < 0 || Controller._pawn.GetHeadPositionY() >= Height)
            {
                _gameOver = true;
            }
            
            for (int i = 0; i < snakeTailLength; i++)
            {
                if (snakeTailX[i] == Controller._pawn.GetHeadPositionX() &&
                    snakeTailY[i] == Controller._pawn.GetHeadPositionY())
                {
                    _gameOver = true;
                }
            }
            
            Draw(Controller, fruitY, fruitX, snakeTailLength, snakeTailX, snakeTailY);
            

            snakeTailLength = Logic(Controller, fruitX, fruitY, snakeTailLength);
        }
    }

    private static int Logic(Controller controller, int fruitX, int fruitY, int snakeTailLength)
    {
        if (controller._pawn.GetHeadPositionX() == fruitX && controller._pawn.GetHeadPositionY() == fruitY)
        {
            snakeTailLength++;
        }

        return snakeTailLength;
    }

    private static void Draw(Controller controller, int fruitY, int fruitX, int snakeTailLength, int[] snakeTailX,
        int[] snakeTailY)
    {
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

                if (i == controller._pawn.GetHeadPositionY() && j == controller._pawn.GetHeadPositionX())
                {
                    Console.Write("U");
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

