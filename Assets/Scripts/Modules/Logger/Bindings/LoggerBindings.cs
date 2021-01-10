using Zenject;

namespace Modules.Logger.Bindings
{
    public static class LoggerBindings
    {
        public static void Bind(DiContainer container)
        {
            container.Bind<ILoggerManager>().To<LoggerManager>().AsSingle();
        }
    }
}