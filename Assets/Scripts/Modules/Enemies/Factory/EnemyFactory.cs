using System.Linq;
using Modules.Enemies.Configs;
using Modules.Enemies.Wave;
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

        public EnemyWave CreateWaveByIndex(int index)
        {
            var isExists = _enemiesConfig.TryGetWave(index, out var wave);
            return isExists ? CreateEnemyWave(wave) : null;
        }

        private EnemyWave CreateEnemyWave(EnemyWave fromWave)
        {
            var enemyWave = new EnemyWave();

            foreach (var enemyGroup in fromWave.EnemyWaveGroups.Select(Object.Instantiate))
            {
                foreach (var enemy in enemyGroup.Actors)
                {
                    enemy.Init(_tickManager, _cameraManager.GameCamera.Component);
                }
                
                enemyWave.Add(enemyGroup);
            }

            return enemyWave;
        }
    }
}