using System.Collections.Generic;
using Generics;
using Modules.Actors;
using Modules.Enemies.Factory;
using Modules.Maps.Managers;
using Modules.Render.Managers;
using Modules.SpellSystem.Data;
using Modules.SpellSystem.Managers;
using Modules.Ticks.Managers;

namespace Modules.Enemies.Managers
{
    public class EnemyManager : BaseManager
    {
        private readonly IEnemyFactory _enemyFactory;
        private readonly ISpellManager _spellManager;
        
        private readonly List<IActor> _spawnedEnemies = new List<IActor>();

        private readonly World _world;

        public EnemyManager()
        {
            _world = World.CurrentInstance;
            _spellManager = _world.ResolveManager<ISpellManager>();
            _enemyFactory = new EnemyFactory(_world.ResolveManager<ITickManager>(),
                _world.ResolveManager<ICameraManager>(), _world.Settings.AvailableEnemies);
        }

        public IActor SpawnEnemy()
        {
            var spawnedEnemy = _enemyFactory.CreateEnemy();
            _spawnedEnemies.Add(spawnedEnemy);
            spawnedEnemy.GetData<SpellData>().Add(_spellManager.GetDefaultSpell());

            return spawnedEnemy;
        }

        public void ClearAllEnemies()
        {
            foreach (var spawnedEnemy in _spawnedEnemies)
            {
                spawnedEnemy.DestroyActor();
            }
            
            _spawnedEnemies.Clear();
        }
    }
}