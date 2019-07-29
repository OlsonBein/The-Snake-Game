using GameSnake.Contracts;
using System;
using System.Threading;

namespace GameSnake
{
    class FieldGeneratorService : IFieldGeneratorService
    {
        public void GenerateField()
        {
            Console.Clear();
            CreateLine();
            Console.Write(Environment.NewLine);

            for (int i = 1; i < GameSettings.FieldWidth; ++i)
            {
                for (int j = 1; j <= GameSettings.FieldHeight; ++j)
                {

                    DrawLeftAndRightBorders(j);
                    DrawObjects(i, j);
                    
                }
                Console.Write(Environment.NewLine);
            }
            CreateLine();
            Thread.Sleep(GameSettings.Speed);
        }
        
        private void CreateLine()
        {
            for (int i = 0; i <= GameSettings.FieldWidth; ++i)
            {
                Console.Write("#");
            }
        }

        private void DrawLeftAndRightBorders(int j)
        {
            if (j == 1 || j == GameSettings.FieldWidth)
            {
                Console.Write("#");
            }
        }

        private void DrawObjects(int i, int j)
        {
            if (j == MealService.ApplePoint.X && i == MealService.ApplePoint.Y)
            {
                Console.Write("@");
            }
            else
            {
                GameSettings.print = false;
                for (int k = 0; k < SnakeService.SnakeBody.Count; k++)
                {
                    if (SnakeService.SnakeBody[k].X == j && SnakeService.SnakeBody[k].Y == i)
                    {
                        Console.Write("*");
                        GameSettings.print = true;
                    }
                }
                if (!GameSettings.print)
                    Console.Write(" ");
            }
        }
    }
}

