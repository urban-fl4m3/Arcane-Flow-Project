using Modules.Logger;
using Modules.Player.Managers;
using ILogger = Modules.Logger.ILogger;

namespace Modules.Core.Initializers
{
    public class SceneInitializer
    {
        private readonly ILoggerManager _loggerManager;
        private readonly IPlayerManager _playerManager;
        
        private ILogger _logger;
        
        public SceneInitializer(ILoggerManager loggerManager,
            IPlayerManager playerManager)
        {
            _loggerManager = loggerManager;
            _playerManager = playerManager;
        }

        public void Init()
        {
            _logger = _loggerManager.GetLogger();
            _logger.Log("Debug", "Logger test");
            _playerManager.SpawnPlayer();
        }
    }
}