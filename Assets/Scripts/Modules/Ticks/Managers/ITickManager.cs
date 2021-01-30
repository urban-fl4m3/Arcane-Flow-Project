﻿using Modules.Ticks.Processors;

namespace Modules.Ticks.Managers
{
    public interface ITickManager
    {
        void SetTickProcessor(TickProcessor tickProcessor);

        void AddTick(object owner, ITickUpdate tick);
        void AddTick(object owner, ITickLateUpdate tick);
        void RemoveTick(ITickUpdate tickUpdate);
        void RemoveTick(ITickLateUpdate tickUpdate);

        void CheckActorTicksState(bool enabled);
    }
}