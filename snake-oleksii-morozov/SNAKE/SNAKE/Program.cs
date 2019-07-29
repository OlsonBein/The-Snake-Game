using System.Threading;

namespace GameSnake
{
    class Program
    {
        static void Main(string[] args)
        {
            SnakeService mySnake = new SnakeService();
            MealService apple = new MealService();
            Timer speedIncreasing = new Timer(GameSettings.TimerCallback, null, 0, 10000);

            apple.CreateApple();

            while (!GameSettings.IsGameOver)
            {
                mySnake.Move();
            }
        }
    }
}