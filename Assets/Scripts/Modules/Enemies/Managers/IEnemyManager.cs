using System.Collections.Generic;
using Modules.Actors;
using Modules.Core.Managers;

namespace Modules.Enemies.Managers
{
    public interface IEnemyManager : IManager
    {
        List<EnemyRoot> SpawnEnemy();
        void ClearAllEnemies();
    }
}