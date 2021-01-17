using Modules.Actors;
using Modules.Enemies.Configs;
using Modules.Enemies.Providers;
using Modules.Render.Managers;
using Modules.Ticks.Managers;
using UnityEngine;

namespace Modules.Enemies.Factory
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly ITickManager _tickManager;
        private readonly ICameraManager _cameraManager;
        private readonly IEnemyProvider _enemyProvider;
        private readonly IAvailableEnemiesConfig _availableEnemiesConfig;

        public EnemyFactory(ITickManager tickManager, ICameraManager cameraManager,
            IEnemyProvider enemyProvider)
        {
            _tickManager = tickManager;
            _cameraManager = cameraManager;
            _enemyProvider = enemyProvider;
        }

        public IActor CreateEnemy()
        {
            var enemyActor = Object.Instantiate(_enemyProvider.GetAvailableEnemy());
            enemyActor.Init(_tickManager.Processor, _cameraManager.GameCamera);

            return enemyActor;
        }
    }
}