using Modules.Actors;
using Modules.Ticks;

namespace Modules.Behaviours
{ 
    public abstract class TickLateBehaviour : BaseBehaviour, ITickLateUpdate
    {
        public bool Enabled { get; set; }
        
        protected override void OnInitialize(IActor owner)
        {
            StartTick();
        }

        public void Tick()
        {
            if (Enabled)
            {
                OnTick();
            }    
        }
        
        protected abstract void OnTick();

        protected void StopTick()
        {
            Owner.TickManager.RemoveTick(this);
        }

        protected void StartTick()
        {
            Owner.TickManager.AddTick(Owner, this);
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