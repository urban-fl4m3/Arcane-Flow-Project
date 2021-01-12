using System.Collections.Generic;
using Modules.Actors;
using Modules.Enemies.Factory;
using Modules.Enemies.Providers;

namespace Modules.Enemies.Managers
{
    public class EnemyManager : IEnemyManager
    {
        private readonly IEnemyProvider _enemyProvider;
        private readonly IEnemyFactory _enemyFactory;

        private List<IActor> _spawnedEnemies = new List<IActor>();
        
        public EnemyManager(IEnemyFactory enemyFactory)
        {
            _enemyFactory = enemyFactory;
        }

        public IActor SpawnEnemy()
        {
            var spawnedEnemy = _enemyFactory.CreateEnemy();
            _spawnedEnemies.Add(spawnedEnemy);

            return spawnedEnemy;
        }
    }
}