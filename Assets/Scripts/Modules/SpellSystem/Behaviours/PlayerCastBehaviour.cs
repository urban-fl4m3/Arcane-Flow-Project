using Modules.Actors;
using Modules.Data.Animation;
using Modules.Data.KeyBindings;
using UnityEngine;

namespace Modules.SpellSystem.Behaviours
{
    [CreateAssetMenu(fileName = "New Player Cast Behaviour", menuName = "Behaviours/Player/Cast")]
    public class PlayerCastBehaviour : CastBehaviour
    {
        private KeyBindingsData _bindingsData;
        private AnimationData _animationData;
        
        protected override void OnInitialize(IActor owner)
        {
            base.OnInitialize(owner);

            _bindingsData = Owner.GetData<KeyBindingsData>();
            _animationData = Owner.GetData<AnimationData>();
            
            StartTick();
        }

        protected override void OnTick()
        {
            base.OnTick();
            
            if (Input.GetKeyDown(_bindingsData.AttackKey))
            {
                _animationData.Component.SetTrigger(_animationData.AttackAnimationKey);
            }
        }
    }
}