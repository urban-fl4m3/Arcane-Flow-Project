using System.Collections.Generic;
using Modules.Actors;

namespace Modules.Enemies.Managers
{
    public interface IEnemyManager
    {
        IReadOnlyList<IActor> SpawnedEnemies { get; }
        IActor SpawnEnemy();
        void ClearAllEnemies();
    }
}