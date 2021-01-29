using System;
using Modules.Ticks.Processors;

namespace Modules.Ticks.Managers
{
    public class TickManager : ITickManager
    {
        public ITickProcessor Processor { get; private set; }

        public void SetTickProcessor(ITickProcessor tickProcessor)
        {
            if (Processor != null)
            {
                UnityEngine.Object.Destroy(tickProcessor.Processor);
                tickProcessor.Dispose();
                
                throw new Exception($"Tick processor is already exists");
            }
            
            Processor = tickProcessor;
        }

        public void StopUpdating()
        {
            Processor.IsUpdating = false;
        }

        public void StartUpdating()
        {
            Processor.IsUpdating = true;
        }
    }
}