using Modules.Commands.Concrete;
using Modules.Logger.Helpers;

namespace Modules.Logger.Commands
{
    public class LoggerModuleInitializeCommand : InitializeCommand
    {
        private readonly ILoggerManager _loggerManager;

        public LoggerModuleInitializeCommand(ILoggerManager loggerManager)
        {
            _loggerManager = loggerManager;
        }

        public override void Execute()
        {
            _loggerManager.Init(Log.Unity);
            CompleteCommand();
        }
    }
}