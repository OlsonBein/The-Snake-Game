using System;

namespace GameSnake
{
    class GameSettings
    {
        public const int FieldWidth = 20;
        public const int FieldHeight = 20;
        public const int AddScore = 1;
        public static bool IsGameOver = false;
        public static int Speed = 1000;
        public static int Score = 0;
        public static int Length = 3;
        public int step = 1;
        public static bool print;
        public const int LengthToSelfCollision = 4;
        public const int CollisionIndex = 3;
        public static Direction direction = Direction.Up;
        public static ConsoleKeyInfo PressedKey;

        public static void TimerCallback(Object o)
        {
            if (Speed > 200)
            {
                Speed -= 100;
            }
        }
    }
    public enum Direction
    {
        Up,
        Down,
        Right,
        Left
    }

}


