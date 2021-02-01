using System.Collections.Generic;
using Modules.Actors;
using Modules.Datas;
using UnityEngine;

namespace Modules.Behaviours
{
    public abstract class BaseBehaviour : ScriptableObject, IBaseBehaviour
    {
        public IEnumerable<BaseData> Data => _behaviourData;
        [SerializeField] private List<BaseData> _behaviourData = new List<BaseData>(); 
        
        public IActor Owner { get; private set; }
        public ScriptableObject Instance => this;

        public void Initialize(IActor owner)
        {
            if (owner.Enabled)
            {
                Resume();
            }
            
            Owner = owner;
            OnInitialize(owner);
        }

        protected abstract void OnInitialize(IActor owner);
        
        public virtual void Dispose()
        {
            Destroy(this);
        }

        public virtual void Stop()
        {
            
        }

        public virtual void Resume()
        {
            
        }
    }
}