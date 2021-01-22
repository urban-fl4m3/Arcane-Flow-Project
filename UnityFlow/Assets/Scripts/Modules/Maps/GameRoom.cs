using Modules.Actors.Types;
using Modules.Enemies.Configs;
using Modules.Enemies.Managers;
using Modules.Maps.Actors;
using Modules.Player.Managers;
using Modules.Ticks.Processors;

namespace Modules.Maps
{
    public class GameRoom
    {
        private readonly IMapActor _map;
        private readonly IActorBase _illumination;
        private readonly IEnemyManager _enemyManager;
        private readonly IPlayerManager _playerManager;
        private readonly ITickProcessor _tickProcessor;
        private readonly IAvailableEnemiesConfig _availableEnemiesConfig;

        public GameRoom(IMapActor map, IActorBase illumination, IEnemyManager enemyManager, 
            IPlayerManager playerManager)
        {
            _map = map;
            _illumination = illumination;
            _enemyManager = enemyManager;
            _playerManager = playerManager;
        }

        public void Run()
        {
            var enemy = _enemyManager.SpawnEnemy();
            _map.AddPlayer(_playerManager.PlayerActor);
            _map.AddEnemy(enemy);
        }
    }
}