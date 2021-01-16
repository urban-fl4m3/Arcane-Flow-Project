using System.Collections.Generic;
using Modules.Actors;
using Modules.Enemies.Factory;
using Modules.Enemies.Providers;
using Modules.SpellSystem.Data;
using Modules.SpellSystem.Managers;

namespace Modules.Enemies.Managers
{
    public class EnemyManager : IEnemyManager
    {
        private readonly IEnemyProvider _enemyProvider;
        private readonly IEnemyFactory _enemyFactory;
        private readonly ISpellManager _spellManager;

        private List<IActor> _spawnedEnemies = new List<IActor>();
        
        public EnemyManager(IEnemyFactory enemyFactory, ISpellManager spellManager)
        {
            _enemyFactory = enemyFactory;
            _spellManager = spellManager;
        }

        public IActor SpawnEnemy()
        {
            var spawnedEnemy = _enemyFactory.CreateEnemy();
            _spawnedEnemies.Add(spawnedEnemy);
            spawnedEnemy.GetData<SpellData>().Add(_spellManager.GetDefaultSpell());

            return spawnedEnemy;
        }
    }
}