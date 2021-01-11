using Modules.Actors.Types;

namespace Modules.Maps.Configs
{
    public interface IAvailableEnemiesConfig
    {
        ActorBase GetAvailableEnemy();
    }
}