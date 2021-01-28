namespace Modules.Logger
{
    public interface ILogger
    {
        void Log(string message);
        void Log(string tag, string message);
    }
}