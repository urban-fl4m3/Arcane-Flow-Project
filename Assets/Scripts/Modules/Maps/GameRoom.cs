using Modules.Actors.Types;
using Modules.Maps.Actors;
using Modules.Maps.Configs;
using Modules.Ticks.Processors;
using UnityEngine;

namespace Modules.Maps
{
    public class GameRoom
    {
        private readonly IMapActor _map;
        private readonly IActorBase _illumination;
        private readonly ITickProcessor _tickProcessor;
        private readonly IAvailableEnemiesConfig _availableEnemiesConfig;

        public GameRoom(IMapActor map, IActorBase illumination, ITickProcessor tickProcessor,
            IAvailableEnemiesConfig availableEnemiesConfig)
        {
            _map = map;
            _illumination = illumination;
            _tickProcessor = tickProcessor;
            _availableEnemiesConfig = availableEnemiesConfig;
        }

        public void Run()
        {
            var enemyActor =  Object.Instantiate(_availableEnemiesConfig.GetAvailableEnemy());
            enemyActor.Init(_tickProcessor);
            _map.AddEnemy(enemyActor);
        }
    }
}