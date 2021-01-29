using System;
using System.Collections.Generic;
using Modules.Actors;
using Modules.Ticks.Processors;

namespace Modules.Ticks.Managers
{
    public class TickManager : ITickManager
    {
        public ITickProcessor Processor { get; private set; }

        private readonly Dictionary<object, List<ITick>> _allTicks = new Dictionary<object, List<ITick>>();
            
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

        public void CheckActorTicksState(bool enabled)
        {
            foreach (var pair in _allTicks)
            {
                if (pair.Key is IActor)
                {
                    foreach (var tick in pair.Value)
                    {
                        tick.Enabled = enabled;
                    }
                }
            }
        }

        public void AddTick(object owner, ITickLateUpdate tick)
        {
            AddTickInternal(owner, tick);
            Processor.AddTick(tick);
        }

        public void RemoveTick(ITickLateUpdate tickUpdate)
        {
            Processor.RemoveTick(tickUpdate);
        }
        
        public void AddTick(object owner, ITickUpdate tick)
        {
            AddTickInternal(owner, tick);
            Processor.AddTick(tick);
        }

        public void RemoveTick(ITickUpdate tickUpdate)
        {
            Processor.RemoveTick(tickUpdate);
        }

        private void AddTickInternal(object owner, ITick tick)
        {
            var hasOwner = _allTicks.TryGetValue(owner, out var tickList);

            if (hasOwner)
            {
                tickList.Add(tick);
            }
            else
            {
                tickList = new List<ITick> {tick};
                _allTicks.Add(owner, tickList);
            }
        }
    }
}