using Modules.Logger.Commands;
using Modules.Ticks.Commands;
using Zenject;

namespace Modules.Core.Bindings
{
    public static class InitializationBindings
    {
        public static void Bind(DiContainer container)
        {
            container.Bind<TickModuleInitializeCommand>().AsTransient();
            container.Bind<LoggerModuleInitializeCommand>().AsTransient();
        }
    }
}