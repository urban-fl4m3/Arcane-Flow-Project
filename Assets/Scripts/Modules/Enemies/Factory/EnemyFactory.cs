using System;
using System.Collections.Generic;
using Modules.Actors;
using Modules.Enemies.Configs;
using Modules.Render.Managers;
using Modules.Ticks.Managers;
using UnityEngine;
using Object = UnityEngine.Object;

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

        public List<EnemyRoot> CreateEnemy()
        {
            var enemyRoots = _enemiesConfig.GetAvailableEnemy();
            var instantiatedEnemyRoots = new List<EnemyRoot>();

            foreach (var enemyRoot in enemyRoots._enemyBunchRoots)
            {
                EnemyRoot newEnemy = Object.Instantiate(enemyRoot);
                foreach (var enemy in newEnemy.EnemyActors)
                {
                    enemy.Init(_tickManager, _cameraManager.GameCamera);
                }
                instantiatedEnemyRoots.Add(newEnemy);
            }

            return instantiatedEnemyRoots;
        }
    }
}