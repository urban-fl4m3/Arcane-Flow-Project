namespace Modules.Player.Movement
{
    public interface IMovement
    {
        void TryMove();
        void TryFixedMove();

        void SpeedUp(float percentage);
        void SlowDown(float percentage);
    }
}