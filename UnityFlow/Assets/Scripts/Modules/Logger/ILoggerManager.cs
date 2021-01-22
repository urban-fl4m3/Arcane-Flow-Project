using Modules.Logger.Helpers;

namespace Modules.Logger
{
    public interface ILoggerManager
    {
        ILogger GetLogger();
        void Init(Log logType);
    }
}