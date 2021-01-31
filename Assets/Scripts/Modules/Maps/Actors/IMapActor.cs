using Modules.Actors;
using Modules.Enemies.Wave;

namespace Modules.Maps.Actors
{
    public interface IMapActor
    {
        void AddPlayer(IActor player);
        void AddWave(EnemyWave enemyRoots);
        void Dispose();
    }
}