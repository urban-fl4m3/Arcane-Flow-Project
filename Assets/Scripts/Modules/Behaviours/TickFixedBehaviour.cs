using Modules.Actors;
using Modules.Ticks;

namespace Modules.Behaviours
{
    public abstract class TickFixedBehaviour : BaseBehaviour, ITickFixedUpdate
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

        protected void DisposeTick()
        {
            Owner.TickManager.RemoveTick(this);
        }

        protected void StartTick()
        {
            Owner.TickManager.AddTick(Owner, this);
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