using System;
namespace Snake;


class Program
{
    public const int Height = 20;
    public const int Width = 40;

    private static void Main()
    {
        Controller controller = new Controller();
        bool gameOver = false;

        int snaikTailLength = 0;
        int [] snakeTailX = new int[100];
        int [] snakeTailY = new int[100];
        
        int fruitX = 0;
        int fruitY = 0;

        GameManager gameManager = new GameManager();
        gameManager.Start();

        while (!gameOver)
        {
            if (controller._pawn.GetHeadPositionX() < 0 || controller._pawn.GetHeadPositionX() >= Width ||
                controller._pawn.GetHeadPositionY() < 0 || controller._pawn.GetHeadPositionY() >= Height)
            {
                gameOver = true;
            }
            
            for (int i = 0; i < snaikTailLength; i++)
            {
                if (snakeTailX[i] == controller._pawn.GetHeadPositionX() &&
                    snakeTailY[i] == controller._pawn.GetHeadPositionY())
                {
                    gameOver = true;
                }
            }
            
            for (int i = 0; i < Width + 2; i++)
            {
                Console.WriteLine("-");
            }

            Console.WriteLine("\n");

            for (int i = 0; i < Height + 2; i++)
            {
                for (int j = 0; j < Width + 2; j++)
                {
                    if (j == 0 || j == Width)
                    {
                        Console.Write("#");
                    }

                    if (i == controller._pawn.GetHeadPositionX() && j == controller._pawn.GetHeadPositionY())
                    {
                        Console.Write("U");
                    }

                    else if (i == fruitX && j == fruitY)
                    {
                        Console.Write("*");
                    }

                    else
                    {
                        bool prTail = false;
                        for (int k = 0; k < snaikTailLength; k++)
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

                    Console.Write("\n");
                }
            }

            for (int i = 0; i < Width + 2; i++)
            {
                Console.WriteLine("-");
            }
            Console.WriteLine("\n");
        }
    }
}

