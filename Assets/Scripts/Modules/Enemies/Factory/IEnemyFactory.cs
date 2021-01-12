using Modules.Actors;

namespace Modules.Enemies.Factory
{
    public interface IEnemyFactory
    {
        IActor CreateEnemy();
    }
}