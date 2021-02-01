using Modules.Actors;
using UnityEngine;

namespace Modules.Data
{
    public abstract class BaseData : ScriptableObject, IBaseData
    {
        public IActor Owner { get; private set; }
        public ScriptableObject Instance => this;

        public void Initialize(IActor owner)
        {
            Owner = owner;
            OnInitialize(owner);
        }

        protected abstract void OnInitialize(IActor owner);

        public virtual void Dispose()
        {
            
        }
    }
}