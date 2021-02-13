using Modules.Actors;
using Modules.Core.Managers;

namespace Modules.Player.Managers
{
    public interface IPlayerManager : IManager
    {
        IActor PlayerActor { get; }
        
        void SpawnPlayer(int state);
        void RemovePlayer();
    }
}