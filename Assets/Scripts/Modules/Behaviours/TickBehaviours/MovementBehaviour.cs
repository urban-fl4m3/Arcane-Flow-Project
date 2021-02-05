using Modules.Actors;
using Modules.Data.Animation;
using Modules.Data.KeyBindings;
using Modules.Data.Movement;
using UnityEngine;

namespace Modules.Behaviours.TickBehaviours
{
    [CreateAssetMenu(fileName = "New Movement Behaviour", menuName = "Behaviours/Movement")]
    public class MovementBehaviour: TickBehaviour
    {
        private Animator _animator;

        private IAnimationData _animationData;
        private IMovementData _movementData;
        private IKeyBindingsData _bindingData;

        private string _horizontalKeyAxis;
        private string _verticalKeyAxis;
        
        protected override void OnInitialize(IActor owner)
        {
            base.OnInitialize(owner);
            
            _animationData = Owner.GetData<AnimationData>();
            _animator = _animationData.Component;
            _movementData = Owner.GetData<MovementData>();
            _bindingData = Owner.GetData<KeyBindingsData>();

            _horizontalKeyAxis = _bindingData.HorizontalKeyAxis();
            _verticalKeyAxis = _bindingData.VerticalKeyAxis();
        }
        
        protected override void OnTick()
        {
            if (Input.GetKeyDown(_bindingData.GetAttackKey()))
            {
                _animator.SetTrigger(_animationData.AttackAnimationKey);
            }
            
            var horizontalMovement = Input.GetAxis(_horizontalKeyAxis);
            var verticalMovement = Input.GetAxis(_verticalKeyAxis);

            var isMoving = !Mathf.Approximately(horizontalMovement, 0) 
                           || !Mathf.Approximately(verticalMovement, 0);
            
            _movementData.IsMoving = isMoving;
            
            _animator.SetBool(_animationData.MovingAnimationKey, isMoving);
            _animator.SetFloat(_horizontalKeyAxis, horizontalMovement);
            _animator.SetFloat(_verticalKeyAxis, verticalMovement);
        }
    }
}