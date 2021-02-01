﻿using Modules.Core.Managers;
using Modules.Ticks.Processors;

namespace Modules.Ticks.Managers
{
    public interface ITickManager : IManager
    {
        void SetTickProcessor(TickProcessor tickProcessor);

        void AddTick(object owner, ITickUpdate tick);
        void AddTick(object owner, ITickLateUpdate tick);
        void AddTick(object owner, ITickFixedUpdate tick);
        void RemoveTick(ITickUpdate tickUpdate);
        void RemoveTick(ITickLateUpdate tickLate);
        void RemoveTick(ITickFixedUpdate tickFixed);

    }
}