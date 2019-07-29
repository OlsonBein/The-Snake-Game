using GameSnake.Contracts;
using System;

namespace GameSnake
{
    public class CollisionDetectorService : ICollisionDetectorService
    {
        public bool WallCollisionCheck()
        {
            if (SnakeService.SnakeHead.X == 0 || SnakeService.SnakeHead.X == GameSettings.FieldWidth ||
                SnakeService.SnakeHead.Y == 0 || SnakeService.SnakeHead.Y == GameSettings.FieldHeight)
            {
                throw new Exception("Game Over!");
            }
            
            return false;
        }

        public bool CheckSelfCollision()
        {
            if (SnakeService.SnakeBody.Count >= GameSettings.LengthToSelfCollision)
            {
                var temporaryList = SnakeService.SnakeBody.GetRange(GameSettings.CollisionIndex,
                    SnakeService.SnakeBody.Count - GameSettings.LengthToSelfCollision);
                foreach (var point in temporaryList)
                {
                    if (point.Equals(SnakeService.SnakeHead))
                    {
                        throw new Exception("Game Over!");
                    }
                }              
            }

            return false;
        }
    }
}