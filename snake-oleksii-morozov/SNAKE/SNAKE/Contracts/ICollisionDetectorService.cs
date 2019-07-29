namespace GameSnake.Contracts
{
    public interface ICollisionDetectorService
    {
        bool WallCollisionCheck();

        bool CheckSelfCollision();
    }
}
