using Modules.Core.Managers;
using Modules.Enemies.Wave;

namespace Modules.Enemies.Managers
{
    public interface IEnemyManager : IManager
    {
        EnemyWave SpawnEnemyWave();
        void ClearAllEnemies();
    }
}