﻿using Modules.Actors;
using Modules.Ticks;

namespace Modules.Behaviours
{ 
    public abstract class TickLateBehaviour : BaseBehaviour, ITickLateUpdate
    {
        protected override void OnInitialize(IActor owner)
        {
            StartTick();
        }

        public abstract void Tick();

        protected void StopTick()
        {
            Owner.TickProcessor.RemoveTick(this);
        }

        protected void StartTick()
        {
            Owner.TickProcessor.AddTick(this);
        }
    }
}