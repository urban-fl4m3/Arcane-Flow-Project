using System;
using Modules.Actors;
using Modules.Animations.Data;
using Modules.Behaviours.AbstractTicks;
using Modules.Data.Animation;
using Modules.Data.KeyBindings;
using Modules.Data.Movement;
using Modules.Data.Physics;
using Modules.Data.Transforms;
using UnityEngine;

namespace Modules.Behaviours.TickBehaviours
{
    internal delegate float InputAxis(string key);
    internal delegate void MovementAction(float speed);
    
    [CreateAssetMenu(fileName = "New Character Controller Behaviour", menuName = "Behaviours/Character Controller")]
    public class CharacterControllerBehaviour: TickUpdateFixedBehaviour
    {
        private AnimationEventHandlerData _animationEventHandlerData;
        private AnimationData _animationData;
        private TransformData _transformData;
        private RigidbodyData _rigidbodyData;
        private KeyBindingsData _bindingData;
        private MovementData _movementData;
        private RotationData _rotationData;

        private InputAxis _inputAxisDelegate;
        private MovementAction _movementActionDelegate;

        protected override void OnInitialize(IActor owner)
        {
            base.OnInitialize(owner);
            
            _animationEventHandlerData = Owner.GetData<AnimationEventHandlerData>();
            _animationData = Owner.GetData<AnimationData>();
            _bindingData = Owner.GetData<KeyBindingsData>();
            _transformData = Owner.GetData<TransformData>();
            _rigidbodyData = Owner.GetData<RigidbodyData>();
            _movementData = Owner.GetData<MovementData>();
            _rotationData = Owner.GetData<RotationData>();

            _inputAxisDelegate = _movementData.SmoothInput ? (InputAxis) Input.GetAxis : Input.GetAxisRaw;
            _movementActionDelegate = _movementData.MoveWithPhysics ? (MovementAction) MoveRigidbody : MoveTransform;
            
            _animationEventHandlerData.EventHandler.Subscribe("StartAttackAnimation", AttackAnimationStart);
            _animationEventHandlerData.EventHandler.Subscribe("EndAttackAnimation", AttackAnimationEnd);
        }

        protected override void OnTickUpdate()
        {
            if (_movementData.CanMove && !_movementData.MoveWithPhysics)
            {
                Move();   
            }
        }

        protected override void OnTickFixed()
        {
            if (_movementData.CanMove && _movementData.MoveWithPhysics)
            {
                Move();
            }
        }

        private void Move()
        {
            var horizontalMovement = _inputAxisDelegate(_bindingData.HorizontalKeyAxis);
            var verticalMovement = _inputAxisDelegate(_bindingData.VerticalKeyAxis);
            
            var isMoving = !Mathf.Approximately(horizontalMovement, 0)
                           || !Mathf.Approximately(verticalMovement, 0);
            
            _animationData.Component.SetBool(_animationData.MovingAnimationKey, isMoving);
            
            if (!isMoving)
            {
                var fade = _movementData.MovementFade;
                horizontalMovement = FadeAxisValue(_bindingData.HorizontalKeyAxis, fade);
                verticalMovement = FadeAxisValue(_bindingData.VerticalKeyAxis, fade);
            
                if (_movementData.MoveWithPhysics)
                {
                    _rigidbodyData.Component.velocity = Vector3.Lerp(_rigidbodyData.Component.velocity, 
                        Vector3.zero, 0.9f);
                }
            }
            else
            {
                if (_rotationData.ApplyMovementRotation)
                {
                    Rotate(horizontalMovement, verticalMovement);
                }
            
                if (!_animationData.ApplyRootMotion)
                {
                    _movementActionDelegate(_movementData.MovementSpeed);
                }
            }
            
            var movement = Mathf.Abs(horizontalMovement) + Mathf.Abs(verticalMovement);
            _animationData.Component.SetFloat(_bindingData.HorizontalKeyAxis, movement);
        }

        private void Rotate(float horizontal, float vertical)
        {
            const float halfRound = 180;
            var atanAngle = Mathf.Atan2(horizontal, vertical);
            var angle = atanAngle / Mathf.PI * halfRound;
            var rotation = Quaternion.AngleAxis(angle, Vector3.up);
            rotation = Quaternion.Slerp(_transformData.Component.rotation, rotation, _rotationData.RotationFade);
            _transformData.Component.rotation = rotation;
        }

        private float FadeAxisValue(string key, float t)
        {
            var value = _animationData.Component.GetFloat(key);
            return Mathf.Lerp(value, 0, t);
        }

        private void MoveTransform(float speed)
        {
            _transformData.Component.position += _transformData.Component.forward
                                                 * (_movementData.MovementSpeed * Time.deltaTime);
        }

        private void MoveRigidbody(float speed)
        {
            _rigidbodyData.Component.velocity = _transformData.Component.forward
                                                * (speed * Time.fixedDeltaTime);
        }

        private void AttackAnimationStart(object sender, EventArgs e)
        {
            
        }

        private void AttackAnimationEnd(object sender, EventArgs e)
        {
            
            if (_movementData.MoveWithPhysics)
            {
                
            }
            else
            {
                
            }
        }
        
        
        public override void Dispose()
        {
            _animationEventHandlerData.EventHandler.Unsubscribe("StartAttackAnimation");
            _animationEventHandlerData.EventHandler.Unsubscribe("EndAttackAnimation");
            base.Dispose();
        }
    }
}