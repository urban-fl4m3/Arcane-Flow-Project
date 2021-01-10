using System;
using Modules.Commands;
using Modules.Logger.Commands;
using Modules.Ticks.Commands;

namespace Modules.Core.Initializers
{
    public class GameInitializer : IGameInitializer
    {
        private readonly ICommandQueue _commandQueue = new CommandQueue();
        
        private readonly SceneInitializer _sceneInitializer;
        private readonly TickModuleInitializeCommand _tickModuleInitializeCommand;
        private readonly LoggerModuleInitializeCommand _loggerModuleInitializeCommand;

        public GameInitializer(
            SceneInitializer sceneInitializer,
            TickModuleInitializeCommand tickModuleInitializeCommand,
            LoggerModuleInitializeCommand loggerModuleInitializeCommand)
        {
            _sceneInitializer = sceneInitializer;
            _tickModuleInitializeCommand = tickModuleInitializeCommand;
            _loggerModuleInitializeCommand = loggerModuleInitializeCommand;
        }

        public void PrepareInitializationCommands()
        {
            _commandQueue.Add(_tickModuleInitializeCommand);
            _commandQueue.Add(_loggerModuleInitializeCommand);

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