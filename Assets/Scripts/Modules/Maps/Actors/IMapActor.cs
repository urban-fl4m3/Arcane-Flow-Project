using System.Collections.Generic;
using Modules.Actors;
using Modules.Enemies;

namespace Modules.Maps.Actors
{
    public interface IMapActor
    {
        void AddPlayer(IActor player);
        void AddEnemy(List<EnemyRoot> enemyRoots);
        void Dispose();
    }
}