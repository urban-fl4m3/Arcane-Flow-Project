using Modules.Actors;
using Modules.Datas.Animation;
using Modules.Datas.KeyBindings;
using UnityEngine;

namespace Modules.Behaviours.TickBehaviours
{
    public interface ICaster
    {
        int Id { get; }
        Transform SpawnPoint { get; }
    }
    
    [CreateAssetMenu(fileName = "New Cast Behaviour", menuName = "Behaviours/Cast")]
    public class CastBehaviour : TickBehaviour
    {
        private Animator _animator;

        private IAnimationData _animationData;
        private IKeyBindingsData _bindingData;
        
        protected override void OnInitialize(IActor owner)
        {
            _animationData = Owner.GetData<AnimationData>();
            _animator = _animationData.GetAnimator();
            _bindingData = Owner.GetData<KeyBindingsData>();

            if (owner is ICaster caster)
            {
                
            }
            
            base.OnInitialize(owner);

        }

        public override void Tick()
        {
            if (Input.GetKeyDown(_bindingData.GetAttackKey()))
            {
                _animator.SetTrigger(_animationData.AttackAnimationKey);
            }
        }
    }
}