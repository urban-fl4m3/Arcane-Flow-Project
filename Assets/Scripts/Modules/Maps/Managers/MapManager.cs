using System;
using Modules.Enemies.Managers;
using Modules.Maps.Providers;
using Modules.Player.Managers;

namespace Modules.Maps.Managers
{
    public class MapManager : IMapManager
    {
        public event EventHandler OnMapLoaded;
        
        private readonly IMapSettingsProvider _mapSettingsProvider;
        private readonly IEnemyManager _enemyManager;
        private readonly IPlayerManager _playerManager;

        private GameRoom _gameRoom;
        
        public MapManager(IMapSettingsProvider mapSettingsProvider, IEnemyManager enemyManager,
            IPlayerManager playerManager)
        {
            _mapSettingsProvider = mapSettingsProvider;
            _enemyManager = enemyManager;
            _playerManager = playerManager;
        }

        public void LoadMap()
        {
            var generatedMapModel = _mapSettingsProvider.GenerateMapModel();
            var currentMap = generatedMapModel.MapActor;
            var currentLightnings = generatedMapModel.MapLightnings;
            _playerManager.SpawnPlayer();
            
            _gameRoom = new GameRoom(currentMap, currentLightnings, _enemyManager, _playerManager);
            OnMapLoaded?.Invoke(this, EventArgs.Empty);
        }

        public void RunGameRoom()
        {
            _gameRoom.Run();
        }
    }
}