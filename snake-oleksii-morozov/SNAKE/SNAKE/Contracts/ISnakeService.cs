using GameSnake;

namespace GameSnake.Contracts
{
    public interface ISnakeService
    {
        void CheckForOppositeSide(Direction direction);

        void Move();

        void FeedSnake();

        void AddTail();
    }
}
