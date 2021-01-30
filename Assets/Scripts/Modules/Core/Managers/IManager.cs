namespace Modules.Core.Managers
{
    public interface IManager
    {
        void Init();
        void Stop();
        void Resume();
    }
}