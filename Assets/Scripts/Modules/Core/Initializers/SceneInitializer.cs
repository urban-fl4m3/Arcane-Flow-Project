using Modules.Logger;
using Modules.Maps.Managers;
using Modules.Player.Managers;
using Modules.Render.Managers;
using ILogger = Modules.Logger.ILogger;

namespace Modules.Core.Initializers
{
    public class SceneInitializer
    {
        private readonly ILoggerManager _loggerManager;
        private readonly IPlayerManager _playerManager;
        private readonly ICameraManager _cameraManager;
        private readonly IMapManager _mapManager;

        private ILogger _logger;
        
        public SceneInitializer(ILoggerManager loggerManager,
            IPlayerManager playerManager,
            ICameraManager cameraManager,
            IMapManager mapManager)
        {
            _loggerManager = loggerManager;
            _playerManager = playerManager;
            _cameraManager = cameraManager;
            _mapManager = mapManager;
        }

        public void Init()
        {
            _cameraManager.LoadCamera();
            _mapManager.LoadMap();
        }
    }
}