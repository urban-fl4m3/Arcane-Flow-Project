using Modules.Actors;
using Modules.Enemies.Configs;
using Modules.Render.Managers;
using Modules.Ticks.Managers;
using UnityEngine;

namespace Modules.Enemies.Factory
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly ITickManager _tickManager;
        private readonly ICameraManager _cameraManager;
        private readonly IAvailableEnemiesConfig _enemiesConfig;

        public EnemyFactory(ITickManager tickManager, ICameraManager cameraManager,
            IAvailableEnemiesConfig enemiesConfig)
        {
            _tickManager = tickManager;
            _cameraManager = cameraManager;
            _enemiesConfig = enemiesConfig;
        }

        public IActor CreateEnemy()
        {
            var enemyActor = Object.Instantiate(_enemiesConfig.GetAvailableEnemy());
            enemyActor.Init(_tickManager, _cameraManager.GameCamera);

            return enemyActor;
        }
    }
}