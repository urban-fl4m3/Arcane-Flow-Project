using System;
using Modules.Commands;
using Modules.Logger.Commands;
using Modules.Player.Commands;
using Modules.Render.Commands;
using Modules.Ticks.Commands;

namespace Modules.Core.Initializers
{
    public class GameInitializer : IGameInitializer
    {
        private readonly ICommandQueue _commandQueue = new CommandQueue();
        
        private readonly SceneInitializer _sceneInitializer;
        private readonly TickModuleInitializeCommand _tickModuleInitializeCommand;
        private readonly LoggerModuleInitializeCommand _loggerModuleInitializeCommand;
        private readonly PlayerModuleInitializeCommand _playerModuleInitializeCommand;
        private readonly RenderModuleInitializeCommand _renderModuleInitializeCommand;

        public GameInitializer(
            SceneInitializer sceneInitializer,
            TickModuleInitializeCommand tickModuleInitializeCommand,
            LoggerModuleInitializeCommand loggerModuleInitializeCommand,
            PlayerModuleInitializeCommand playerModuleInitializeCommand,
            RenderModuleInitializeCommand renderModuleInitializeCommand)
        {
            _sceneInitializer = sceneInitializer;
            _tickModuleInitializeCommand = tickModuleInitializeCommand;
            _loggerModuleInitializeCommand = loggerModuleInitializeCommand;
            _playerModuleInitializeCommand = playerModuleInitializeCommand;
            _renderModuleInitializeCommand = renderModuleInitializeCommand;
        }

        public void PrepareInitializationCommands()
        {
            _commandQueue.Add(_tickModuleInitializeCommand);
            _commandQueue.Add(_loggerModuleInitializeCommand);
            _commandQueue.Add(_playerModuleInitializeCommand);
            _commandQueue.Add(_renderModuleInitializeCommand);

            _commandQueue.OnComplete += HandleAllCommandsComplete;
        }

        public void Run()
        {
            _commandQueue.ExecuteAll();
        }
        
        private void HandleAllCommandsComplete(object sender, EventArgs e)
        {
            _sceneInitializer.Init();
        }
    }
}