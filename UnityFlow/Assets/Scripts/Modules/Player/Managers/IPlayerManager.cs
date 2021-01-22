using Modules.Actors;

namespace Modules.Player.Managers
{
    public interface IPlayerManager
    {
        void Init();
        IActor PlayerActor { get; }
        void SpawnPlayer();
    }
}