using System;
using Modules.Actors;
using Modules.Animations.Data;
using Modules.Behaviours.AbstractTicks;
using Modules.Data.Animation;
using Modules.Data.KeyBindings;
using Modules.Data.Movement;
using Modules.Data.Physics;
using Modules.Data.Transforms;
using Modules.Player.Movement;
using UnityEngine;

namespace Modules.Behaviours.TickBehaviours
{
    
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

        private IMovement _movement;
        
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

            _movement = _movementData.MoveWithPhysics
                ? (IMovement) new RigidbodyMovement(_transformData, _rotationData, _animationData, _movementData,
                    _bindingData, _rigidbodyData)
                : new TransformMovement(_transformData, _rotationData, _animationData, _movementData, _bindingData);

            _animationEventHandlerData.EventHandler.Subscribe("StartAttackAnimation", AttackAnimationStart);
            _animationEventHandlerData.EventHandler.Subscribe("EndAttackAnimation", AttackAnimationEnd);
        }

        protected override void OnTickUpdate()
        {
            _movement.TryMove();
        }

        protected override void OnTickFixed()
        {
            _movement.TryFixedMove();
        }

        private void AttackAnimationStart(object sender, EventArgs e)
        {
            _movement.SlowDown(0.5f);
            _rotationData.ApplyMovementRotation = false;
            _rotationData.LookAtMouseCursor.Value = true;
        }

        private void AttackAnimationEnd(object sender, EventArgs e)
        {
            _movement.SpeedUp(0.5f);
            _rotationData.ApplyMovementRotation = true;
            _rotationData.LookAtMouseCursor.Value = false;
        }
        
        
        public override void Dispose()
        {
            _animationEventHandlerData.EventHandler.Unsubscribe("StartAttackAnimation");
            _animationEventHandlerData.EventHandler.Unsubscribe("EndAttackAnimation");
            base.Dispose();
        }
    }
}