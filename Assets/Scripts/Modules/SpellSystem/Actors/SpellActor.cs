using System;
using Modules.Actors.Types;
using Modules.SpellSystem.Enum;
using UnityEngine;

namespace Modules.SpellSystem.Actors
{
    public class SpellActor : ActorBase
    {
#pragma warning disable 67
        public event EventHandler CastStarted;
#pragma warning restore 67
        public event EventHandler<Collision> Hit;
        
        private Tag[] _tags;
        
        public void Init(Tag[] tags)
        {
            _tags = tags;
        }

        protected virtual void OnCastStarted(EventArgs e)
        {
            CastStarted?.Invoke(this, e);
        }

        protected virtual void OnHit(Collision e)
        {
            Hit?.Invoke(this, e);
        }

        public virtual void SetLifetime(float lifeTime)
        {
            Destroy(Object, lifeTime);
        }
    }
}