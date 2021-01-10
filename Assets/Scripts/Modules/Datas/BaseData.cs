using Modules.Actors;
using UnityEngine;

namespace Modules.Datas
{
    public abstract class BaseData : ScriptableObject, IBaseData
    {
        public IActor Owner { get; private set; }
        
        public void Initialize(IActor owner)
        {
            Owner = owner;
            OnInitialize(owner);
        }

        protected abstract void OnInitialize(IActor owner);
    }
}