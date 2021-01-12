using Modules.Actors.Types;
using Modules.Enemies.Configs;

namespace Modules.Enemies.Providers
{
    public class EnemyProvider : IEnemyProvider
    {
        private readonly IEnemyCommonHelpersConfig _commonHelpersConfig;
        private readonly IAvailableEnemiesConfig _availableEnemiesConfig;

        public EnemyProvider(IEnemyCommonHelpersConfig commonHelpersConfig,
            IAvailableEnemiesConfig availableEnemiesConfig)
        {
            _commonHelpersConfig = commonHelpersConfig;
            _availableEnemiesConfig = availableEnemiesConfig;
        }

        public ActorBase GetAvailableEnemy()
        {
            return _availableEnemiesConfig.GetAvailableEnemy();
        }
    }
}