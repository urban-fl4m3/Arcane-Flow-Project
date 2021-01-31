using System.Collections.Generic;
using System.Linq;
using Modules.Actors;
using Modules.Enemies.Factory;
using Modules.Enemies.Wave;
using Modules.Maps.Managers;
using Modules.Render.Managers;
using Modules.SpellSystem.Data;
using Modules.Ticks.Managers;

namespace Modules.Enemies.Managers
{
    public class EnemyManager : IEnemyManager
    {
        private readonly IEnemyFactory _enemyFactory;

        private readonly List<IActor> _spawnedEnemies = new List<IActor>();

        private int _waveIndex;

        public EnemyManager()
        {
            var world = World.CurrentInstance;
            _enemyFactory = new EnemyFactory(world.ResolveManager<ITickManager>(),
                world.ResolveManager<ICameraManager>(), world.Settings.AvailableEnemies);
        }

        public EnemyWave SpawnEnemyWave()
        {
            var wave = _enemyFactory.CreateWaveByIndex(_waveIndex);

            if (wave == null)
            {
                return null;
            }
            
            foreach (var enemyActor in wave.EnemyWaveGroups.SelectMany(enemyRoot => enemyRoot.Actors))
            {
                _spawnedEnemies.Add(enemyActor);
            }

            return wave;
        }

        public void ClearAllEnemies()
        {
            foreach (var spawnedEnemy in _spawnedEnemies)
            {
                spawnedEnemy.DestroyActor();
            }
            
            _spawnedEnemies.Clear();
        }

        public void Init() { }
        
        public void Stop()
        {
            foreach (var enemy in _spawnedEnemies)
            {
                enemy.Stop();
            }
        }

        public void Resume()
        {
            foreach (var enemy in _spawnedEnemies)
            {
                enemy.Resume();
            }
        }
    }
}