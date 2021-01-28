using Modules.Logger.Helpers;

namespace Modules.Logger
{
    public class LoggerManager : ILoggerManager
    {
        private ILogger _currentLogger;
        
        public void Init(Log logType)
        {
            _currentLogger = LogFactory.GenerateLogger(logType);
        }

        public ILogger GetLogger()
        {
            return _currentLogger;
        }
    }
}