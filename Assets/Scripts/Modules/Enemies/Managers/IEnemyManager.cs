using Modules.Actors;

namespace Modules.Enemies.Managers
{
    public interface IEnemyManager
    {
        IActor SpawnEnemy();
    }
}