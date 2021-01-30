using Modules.Actors;
using Modules.Core.Managers;

namespace Modules.Enemies.Managers
{
    public interface IEnemyManager : IManager
    {
        IActor SpawnEnemy();
        void ClearAllEnemies();
    }
}