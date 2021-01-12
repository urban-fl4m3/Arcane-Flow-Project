using Modules.Actors.Types;
using Modules.Enemies.Configs;
using Modules.Enemies.Managers;
using Modules.Maps.Actors;
using Modules.Ticks.Processors;

namespace Modules.Maps
{
    public class GameRoom
    {
        private readonly IMapActor _map;
        private readonly IActorBase _illumination;
        private readonly IEnemyManager _enemyManager;
        private readonly ITickProcessor _tickProcessor;
        private readonly IAvailableEnemiesConfig _availableEnemiesConfig;

        public GameRoom(IMapActor map, IActorBase illumination, IEnemyManager enemyManager)
        {
            _map = map;
            _illumination = illumination;
            _enemyManager = enemyManager;
        }

        public void Run()
        {
            var enemy = _enemyManager.SpawnEnemy();
            _map.AddEnemy(enemy);
        }
    }
}