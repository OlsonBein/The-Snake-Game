using GameSnake.Contracts;
using System;
using System.Collections.Generic;

namespace GameSnake
{
    public class SnakeService : ISnakeService
    {        
        public static List<Point> SnakeBody = new List<Point>();

        public static Point SnakeHead = new Point(GameSettings.FieldWidth / 2, GameSettings.FieldHeight / 2);

        private void ExtendSnake()
        {
            SnakeBody.Insert(0, SnakeHead);
        }

        private void ReduceSnake()
        {
            SnakeBody.Insert(0, SnakeHead);
            SnakeBody.RemoveAt(SnakeBody.Count - 1);
        }

        public void CheckForOppositeSide(Direction direction)
        {
            CollisionDetectorService detector = new CollisionDetectorService();
            FieldGeneratorService generator = new FieldGeneratorService();

            GameSettings.direction = direction;

            int incrementX = 0;
            int incrementY = 0;

            switch (direction)
            {
                case Direction.Up:
                    incrementY = -1;
                    break;
                case Direction.Down:
                    incrementY = +1;
                    break;
                case Direction.Right:
                    incrementX = 1;
                    break;
                case Direction.Left:
                    incrementX = -1;
                    break;
            }

            while (!Console.KeyAvailable)
            {
                SnakeHead = new Point(SnakeBody[0].X + incrementX, SnakeBody[0].Y + incrementY);

                try
                {
                    detector.WallCollisionCheck();
                    detector.CheckSelfCollision();
                }
                catch (Exception)
                {
                    Console.Write(Environment.NewLine);
                    Console.WriteLine("Game Over");
                    Console.WriteLine("Your score: " + GameSettings.Score + "!");
                    break;
                }
                FeedSnake();
                generator.GenerateField();
            }
        }

        public void Move()
        {
            FieldGeneratorService generator = new FieldGeneratorService();

            SnakeBody.Add(SnakeHead);
            AddTail();
            generator.GenerateField();
            CheckForOppositeSide(Direction.Up);
            while (!GameSettings.IsGameOver)
            {
                GameSettings.PressedKey = Console.ReadKey();
                switch (GameSettings.PressedKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        Direction newDirection = (GameSettings.direction != Direction.Down) ? Direction.Up : Direction.Down;
                        CheckForOppositeSide(newDirection);
                        break;
                    case ConsoleKey.DownArrow:
                        newDirection = (GameSettings.direction != Direction.Up) ? Direction.Down : Direction.Up;
                        CheckForOppositeSide(newDirection);
                        break;
                    case ConsoleKey.LeftArrow:
                        newDirection = (GameSettings.direction != Direction.Right) ? Direction.Left : Direction.Right;
                        CheckForOppositeSide(newDirection);
                        break;
                    case ConsoleKey.RightArrow:
                        newDirection = (GameSettings.direction != Direction.Left) ? Direction.Right : Direction.Left;
                        CheckForOppositeSide(newDirection);
                        break;
                }
            }
        }

        public void FeedSnake()
        {
            MealService apple = new MealService();

            if (SnakeHead.X == MealService.ApplePoint.X && SnakeHead.Y == MealService.ApplePoint.Y)
            {
                apple.CreateApple();
                GameSettings.Length += 1;
                GameSettings.Score += GameSettings.AddScore;
                ExtendSnake();
            }
            else
            {
                ReduceSnake();
            }
        }

        public void AddTail()
        {
            while (SnakeBody.Count < GameSettings.Length)
            {
                SnakeBody.Add(new Point(SnakeBody[SnakeBody.Count - 1].X, SnakeBody[SnakeBody.Count - 1].Y + 1));
            }
        }
    }
}

