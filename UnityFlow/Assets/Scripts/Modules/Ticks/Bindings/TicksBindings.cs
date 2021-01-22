using Modules.Ticks.Managers;
using Zenject;

namespace Modules.Ticks.Bindings
{
    public class TicksBinding
    {
        public static void Bind(DiContainer container)
        {
            container.Bind<ITickManager>().To<TickManager>().AsSingle();
        }
    }
}