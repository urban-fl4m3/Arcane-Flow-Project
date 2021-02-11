using System;
using UnityEngine;

namespace Modules.Actors.Components
{
    [RequireComponent(typeof(Animator))]
    public class IkAnimationComponent : MonoBehaviour
    {
        public event EventHandler<int> AnimatorIkTick;
        
        private void OnAnimatorIK(int layerIndex)
        {
            AnimatorIkTick?.Invoke(this, layerIndex);    
        }
    }
}