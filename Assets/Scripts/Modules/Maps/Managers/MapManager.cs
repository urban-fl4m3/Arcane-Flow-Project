using System;
using Modules.Actors.Types;
using Modules.Maps.Actors;
using Modules.Maps.Providers;
using Modules.Player.Managers;
using Modules.Render.Managers;

namespace Modules.Maps.Managers
{
    public class MapManager : IMapManager
    {
        public event EventHandler OnMapLoaded;
        
        private readonly IMapSettingsProvider _mapSettingsProvider;

        private IMapActor _currentMap;
        private IActorBase _currentLightnings;
        
        public MapManager(IMapSettingsProvider mapSettingsProvider)
        {
            _mapSettingsProvider = mapSettingsProvider;
        }

        public void LoadMap()
        {
            var generatedMapModel = _mapSettingsProvider.GenerateMapModel();
            _currentMap = generatedMapModel.MapActor;
            _currentLightnings = generatedMapModel.MapLightnings;
            
            OnMapLoaded?.Invoke(this, EventArgs.Empty);
        }
    }
}