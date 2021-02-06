using Modules.Core.Managers;
using Modules.Ticks.Processors;

namespace Modules.Ticks.Managers
{
    public interface ITickManager : IManager
    {
        void SetTickProcessor(TickProcessor tickProcessor);

        void AddTick(object owner, ITickUpdate tick);
        void AddTick(object owner, ITickFixedUpdate tick);
        void AddTick(object owner, ITickLateUpdate tick);
        void RemoveTick(ITickUpdate tick);
        void RemoveTick(ITickFixedUpdate tick);
        void RemoveTick(ITickLateUpdate tick);

    }
}