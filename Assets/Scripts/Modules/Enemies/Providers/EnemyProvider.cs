using Modules.Actors.Types;
using Modules.Enemies.Configs;

namespace Modules.Enemies.Providers
{
    public class EnemyProvider : IEnemyProvider
    {
        private readonly IAvailableEnemiesConfig _availableEnemiesConfig;

        public EnemyProvider(IAvailableEnemiesConfig availableEnemiesConfig)
        {
            _availableEnemiesConfig = availableEnemiesConfig;
        }

        public ActorBase GetAvailableEnemy()
        {
            return _availableEnemiesConfig.GetAvailableEnemy();
        }
    }
}