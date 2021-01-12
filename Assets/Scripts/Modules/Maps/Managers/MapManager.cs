using System;
using Modules.Enemies.Managers;
using Modules.Maps.Providers;

namespace Modules.Maps.Managers
{
    public class MapManager : IMapManager
    {
        public event EventHandler OnMapLoaded;
        
        private readonly IMapSettingsProvider _mapSettingsProvider;
        private readonly IEnemyManager _enemyManager;

        private GameRoom _gameRoom;
        
        public MapManager(IMapSettingsProvider mapSettingsProvider, IEnemyManager enemyManager)
        {
            _mapSettingsProvider = mapSettingsProvider;
            _enemyManager = enemyManager;
        }

        public void LoadMap()
        {
            var generatedMapModel = _mapSettingsProvider.GenerateMapModel();
            var currentMap = generatedMapModel.MapActor;
            var currentLightnings = generatedMapModel.MapLightnings;
            
            _gameRoom = new GameRoom(currentMap, currentLightnings, _enemyManager);
            OnMapLoaded?.Invoke(this, EventArgs.Empty);
        }

        public void RunGameRoom()
        {
            _gameRoom.Run();
        }
    }
}