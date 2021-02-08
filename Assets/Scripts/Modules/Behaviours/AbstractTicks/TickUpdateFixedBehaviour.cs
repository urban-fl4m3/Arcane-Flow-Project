using Modules.Actors;
using Modules.Ticks;

namespace Modules.Behaviours.AbstractTicks
{
    public abstract class TickUpdateFixedBehaviour : BaseBehaviour, ITickUpdate, ITickFixedUpdate
    {
        public bool Enabled { get; set; }

        void ITickUpdate.Tick()
        {
            if (Enabled)
            {
                OnTickUpdate();
            }
        }
        
        void ITickFixedUpdate.Tick()
        {
            if (Enabled)
            {
                OnTickFixed();
            }
        }

        protected override void OnInitialize(IActor owner)
        {
            StartTick();
        }
        
        protected abstract void OnTickUpdate();
        protected abstract void OnTickFixed();
        

        protected void StartTick()
        {
            Owner.TickManager.AddTick(Owner, (ITickUpdate)this);
            Owner.TickManager.AddTick(Owner, (ITickFixedUpdate)this);
        }
        
        protected void DisposeTick()
        {
            Owner.TickManager.RemoveTick((ITickUpdate)this);
            Owner.TickManager.RemoveTick((ITickFixedUpdate)this);
        }

        public override void Dispose()
        {
            base.Dispose();
            DisposeTick();
        }

        public override void Stop()
        {
            base.Stop();
            Enabled = false;
        }

        public override void Resume()
        {
            base.Resume();
            Enabled = true;
        }
    }
}