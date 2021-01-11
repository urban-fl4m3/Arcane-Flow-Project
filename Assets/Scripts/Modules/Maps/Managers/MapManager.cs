using System;
using Modules.Maps.Configs;
using Modules.Maps.Providers;
using Modules.Ticks.Managers;

namespace Modules.Maps.Managers
{
    public class MapManager : IMapManager
    {
        public event EventHandler OnMapLoaded;
        
        private readonly IMapSettingsProvider _mapSettingsProvider;
        private readonly IAvailableEnemiesConfig _availableEnemiesConfig;
        private readonly ITickManager _tickManager;

        private GameRoom _gameRoom;
        
        public MapManager(IMapSettingsProvider mapSettingsProvider, IAvailableEnemiesConfig availableEnemiesConfig,
            ITickManager tickManager)
        {
            _mapSettingsProvider = mapSettingsProvider;
            _availableEnemiesConfig = availableEnemiesConfig;
            _tickManager = tickManager;
        }

        public void LoadMap()
        {
            var generatedMapModel = _mapSettingsProvider.GenerateMapModel();
            var currentMap = generatedMapModel.MapActor;
            var currentLightnings = generatedMapModel.MapLightnings;
            
            _gameRoom = new GameRoom(currentMap, currentLightnings, _tickManager.Processor, _availableEnemiesConfig);
            OnMapLoaded?.Invoke(this, EventArgs.Empty);
        }

        public void RunGameRoom()
        {
            _gameRoom.Run();
        }
    }
}