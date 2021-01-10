using Modules.Ticks.Processors;

namespace Modules.Ticks.Managers
{
    public interface ITickManager
    {
        ITickProcessor Processor { get; }
        
        void SetTickProcessor(ITickProcessor tickProcessor);
    }
}