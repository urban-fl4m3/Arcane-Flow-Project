using Modules.Actors.Types;

namespace Modules.Enemies.Configs
{
    public interface IAvailableEnemiesConfig
    {
        ActorBase GetAvailableEnemy();
    }
}