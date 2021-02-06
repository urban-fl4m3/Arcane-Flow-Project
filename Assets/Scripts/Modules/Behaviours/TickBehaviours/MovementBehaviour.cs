using Modules.Actors;
using Modules.Data.Animation;
using Modules.Data.KeyBindings;
using Modules.Data.Movement;
using Modules.Data.Transforms;
using UnityEngine;

namespace Modules.Behaviours.TickBehaviours
{
    [CreateAssetMenu(fileName = "New Movement Behaviour", menuName = "Behaviours/Movement")]
    public class MovementBehaviour: TickBehaviour
    {
        private Animator _animator;

        private AnimationData _animationData;
        private MovementData _movementData;
        private KeyBindingsData _bindingData;
        private RotationData _rotationData;
        private TransformData _transformData;
        
        private string _horizontalKeyAxis;
        private string _verticalKeyAxis;

        private delegate float InputAxis(string key);
        private InputAxis _inputAxisDelegate;

        protected override void OnInitialize(IActor owner)
        {
            base.OnInitialize(owner);
            
            _animationData = Owner.GetData<AnimationData>();
            _movementData = Owner.GetData<MovementData>();
            _bindingData = Owner.GetData<KeyBindingsData>();
            _transformData = Owner.GetData<TransformData>();
            _rotationData = Owner.GetData<RotationData>();
            
            _animator = _animationData.Component;

            _horizontalKeyAxis = _bindingData.HorizontalKeyAxis();
            _verticalKeyAxis = _bindingData.VerticalKeyAxis();

            _inputAxisDelegate = _movementData.SmoothInput ? (InputAxis) Input.GetAxis : Input.GetAxisRaw;

            _movementData.CanMove = true;
        }
        
        protected override void OnTick()
        {
            if (Input.GetKeyDown(_bindingData.GetAttackKey()))
            {
                _animator.SetTrigger(_animationData.AttackAnimationKey);
            }

            if (_movementData.CanMove)
            {
                Move();   
            }
        }

        private void Move()
        {
            var horizontalMovement = _inputAxisDelegate(_horizontalKeyAxis);
            var verticalMovement = _inputAxisDelegate(_verticalKeyAxis);

            var isMoving = !Mathf.Approximately(horizontalMovement, 0)
                           || !Mathf.Approximately(verticalMovement, 0);

            _animator.SetBool(_animationData.MovingAnimationKey, isMoving);

            if (!isMoving)
            {
                horizontalMovement = _animator.GetFloat(_horizontalKeyAxis);
                horizontalMovement = Mathf.Lerp(horizontalMovement, 0, 0.01f);

                verticalMovement = _animator.GetFloat(_verticalKeyAxis);
                verticalMovement = Mathf.Lerp(verticalMovement, 0, 0.01f);
            }
            else
            {
                if (_rotationData.ApplyMovementRotation)
                {
                    Rotate(horizontalMovement, verticalMovement);
                }

                if (!_animationData.ApplyRootMotion)
                {
                    _transformData.Component.position += _transformData.Component.forward * (2 * Time.deltaTime);
                }
            }

            var movement = Mathf.Abs(horizontalMovement) + Mathf.Abs(verticalMovement);
            _animator.SetFloat(_horizontalKeyAxis, movement);
        }

        private void Rotate(float horizontal, float vertical)
        {
            var atanAngle = Mathf.Atan2(horizontal, vertical);
            var angle = atanAngle / Mathf.PI * 180;
            var rotation = Quaternion.AngleAxis(angle, Vector3.up);
            rotation = Quaternion.Slerp(_transformData.Component.rotation, rotation, 0.1f);
            _transformData.Component.rotation = rotation;
        }
    }
}