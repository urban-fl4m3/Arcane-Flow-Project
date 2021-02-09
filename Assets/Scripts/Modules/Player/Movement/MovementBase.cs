using Modules.Data.Animation;
using Modules.Data.KeyBindings;
using Modules.Data.Movement;
using Modules.Data.Transforms;
using UnityEngine;

namespace Modules.Player.Movement
{
    internal delegate float InputAxis(string key);
    
    public abstract class MovementBase : IMovement
    {
        protected readonly TransformData _transformData;
        protected readonly MovementData _movementData;
        protected readonly RotationData _rotationData;
        private readonly KeyBindingsData _bindingsData;
        private readonly AnimationData _animationData;
        
        private readonly InputAxis _inputAxisDelegate;

        protected MovementBase(TransformData transformData, RotationData rotationData,
            AnimationData animationData, MovementData movementData, KeyBindingsData bindingsData)
        {
            _transformData = transformData;
            _rotationData = rotationData;
            _animationData = animationData;
            _movementData = movementData;
            _bindingsData = bindingsData;

            _inputAxisDelegate = _movementData.SmoothInput ? (InputAxis) Input.GetAxis : Input.GetAxisRaw;
        }
        
        public void SpeedUp(float percentage)
        {
            _movementData.MovementSpeed /= percentage;
        }

        public void SlowDown(float percentage)
        {
            _movementData.MovementSpeed *= percentage;
        }
        
        public virtual void TryMove()
        {
            
        }

        public virtual void TryFixedMove()
        {
            
        }

        protected virtual void PostFade()
        {
            
        }

        protected abstract void MovementCalculation(Vector3 direction, float speed);

        protected void InternalMovement()
        {
            var horizontalMovement = _inputAxisDelegate(_bindingsData.HorizontalKeyAxis);
            var verticalMovement = _inputAxisDelegate(_bindingsData.VerticalKeyAxis);
            
            var isMoving = !Mathf.Approximately(horizontalMovement, 0)
                           || !Mathf.Approximately(verticalMovement, 0);
            
            _animationData.Component.SetBool(_animationData.MovingAnimationKey, isMoving);
            
            if (!isMoving)
            {
                var fade = _movementData.MovementFade;
                horizontalMovement = FadeAxisValue(_bindingsData.HorizontalKeyAxis, fade);
                verticalMovement = FadeAxisValue(_bindingsData.VerticalKeyAxis, fade);
            
                PostFade();
            }
            else
            {
                if (_rotationData.ApplyMovementRotation)
                {
                    MovementRotate(horizontalMovement, verticalMovement);
                }
            
                if (!_animationData.ApplyRootMotion)
                {
                    var direction = GetDirection(horizontalMovement, verticalMovement);
                    MovementCalculation(direction, _movementData.MovementSpeed);
                }
            }
            
            var movement = Mathf.Abs(horizontalMovement) + Mathf.Abs(verticalMovement);
            _animationData.Component.SetFloat(_bindingsData.HorizontalKeyAxis, movement);
        }

        private Vector3 GetDirection(float horizontalDirection, float verticalDirection)
        {
            return _rotationData.ApplyMovementRotation && _rotationData.SyncRotationWithMovement
                ? _transformData.Component.forward
                : new Vector3(horizontalDirection, 0, verticalDirection);
        }

        private void MovementRotate(float horizontal, float vertical)
        {
            const float halfRound = 180;
            var atanAngle = Mathf.Atan2(horizontal, vertical);
            var angle = atanAngle / Mathf.PI * halfRound;
            var rotation = Quaternion.AngleAxis(angle, Vector3.up);
            rotation = Quaternion.Slerp(_transformData.Component.rotation, rotation, _rotationData.RotationSmooth);
            _transformData.Component.rotation = rotation;
        }
        
        private float FadeAxisValue(string key, float t)
        {
            var value = _animationData.Component.GetFloat(key);
            return Mathf.Lerp(value, 0, t);
        }
    }
}