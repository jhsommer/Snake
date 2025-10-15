using System;
namespace Snake;


class Program
{
    public const int Height = 20;
    public const int Width = 40;
    static void Main(string[] args)
    {
        GameManager gameManager = new GameManager();
        gameManager.Start();
        
        //while()
        //{}
        for (int i = 0; i < Width + 2; i++)
        {
            Console.WriteLine("-");
        }
        Console.WriteLine("\n");

        for (int i = 0; i < Height + 2; i++)
        {
            for (int j = 0; j < Width + 2; j++)
            {
                if(j == 0 || j == Width)
                {
                    Console.Write("#");
                }
            }
        }
    }
}
