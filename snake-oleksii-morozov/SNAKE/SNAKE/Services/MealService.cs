using GameSnake.Contracts;
using System;

namespace GameSnake
{
    class MealService : IMealService
    {
        public static Point ApplePoint;

        public void CreateApple()
        {
            Random random = new Random();
            Point temporaryPoint;

            do
                temporaryPoint = new Point(random.Next(1, GameSettings.FieldWidth - 1), random.Next(1, GameSettings.FieldHeight - 1));
            while (SnakeService.SnakeBody.Contains(temporaryPoint));

            ApplePoint = temporaryPoint;
        }
    }
}
