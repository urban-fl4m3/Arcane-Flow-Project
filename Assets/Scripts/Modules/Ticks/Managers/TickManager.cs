using System;
using System.Collections.Generic;
using System.Linq;
using Modules.Actors;
using Modules.Ticks.Processors;

namespace Modules.Ticks.Managers
{
    public class TickManager : ITickManager
    {
        private TickProcessor _processor;

        private readonly Dictionary<object, List<ITick>> _allTicks = new Dictionary<object, List<ITick>>();
            
        public void SetTickProcessor(TickProcessor tickProcessor)
        {
            if (_processor != null)
            {
                UnityEngine.Object.Destroy(tickProcessor.Processor);
                tickProcessor.Dispose();
                
                throw new Exception($"Tick processor is already exists");
            }
            
            _processor = tickProcessor;
        }

        public void AddTick(object owner, ITickUpdate tick)
        {
            AddTickInternal(owner, tick);
            _processor.TickUpdates.Add(tick);
        }

        public void AddTick(object owner, ITickLateUpdate tick)
        {
            AddTickInternal(owner, tick);
            _processor.TickLateUpdates.Add(tick);
        }

        public void RemoveTick(ITickUpdate tickUpdate)
        {
            _processor.TickUpdates.Remove(tickUpdate);
        }

        public void RemoveTick(ITickLateUpdate tickUpdate)
        {
            _processor.TickLateUpdates.Remove(tickUpdate);
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