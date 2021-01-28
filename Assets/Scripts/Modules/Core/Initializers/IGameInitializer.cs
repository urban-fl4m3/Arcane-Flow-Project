namespace Modules.Core.Initializers
{
    public interface IGameInitializer
    {
        void PrepareInitializationCommands();
        void Run();
    }
}