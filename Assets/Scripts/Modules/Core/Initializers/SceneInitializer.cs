using Modules.Logger;
using Modules.Maps.Managers;
using Modules.Player.Managers;
using Modules.Render.Managers;
using UI.Helpers;
using UI.Managers;
using UI.Views.GameHudWindow;
using UnityEngine;
using ILogger = Modules.Logger.ILogger;

namespace Modules.Core.Initializers
{
    public class SceneInitializer
    {
        private readonly ILoggerManager _loggerManager;
        private readonly IPlayerManager _playerManager;
        private readonly ICameraManager _cameraManager;
        private readonly IMapManager _mapManager;
        private readonly IViewManager _viewManager;

        private ILogger _logger;
        
        public SceneInitializer(ILoggerManager loggerManager,
            IPlayerManager playerManager,
            ICameraManager cameraManager,
            IMapManager mapManager,
            IViewManager viewManager)
        {
            _loggerManager = loggerManager;
            _playerManager = playerManager;
            _cameraManager = cameraManager;
            _mapManager = mapManager;
            _viewManager = viewManager;
        }

        public void Init()
        {
            Cursor.lockState = CursorLockMode.Locked;
            
            _cameraManager.LoadCamera();
            _mapManager.LoadMap();
            _viewManager.AddView(Window.GameHud, new GameHudModel(_playerManager));

            _mapManager.RunGameRoom();
        }
    }
}