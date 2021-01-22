using Modules.Actors.Types;

namespace Modules.Enemies.Providers
{
    public interface IEnemyProvider
    {
        ActorBase GetAvailableEnemy();
    }
}