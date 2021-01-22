using Modules.Actors;
using UnityEngine;

namespace Modules.Behaviours
{
    public abstract class BaseBehaviour : ScriptableObject, IBaseBehaviour
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