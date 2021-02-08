﻿using Modules.Data.Animation;
using Modules.Data.KeyBindings;
using Modules.Data.Movement;
using Modules.Data.Physics;
using Modules.Data.Transforms;
using UnityEngine;

namespace Modules.Player.Movement
{
    public class RigidbodyMovement : MovementBase
    {
        private readonly RigidbodyData _rigidbodyData;

        public RigidbodyMovement(TransformData transformData, RotationData rotationData, AnimationData animationData,
            MovementData movementData, KeyBindingsData bindingsData, RigidbodyData rigidbodyData) 
            : base(transformData, rotationData, animationData, movementData, bindingsData)
        {
            _rigidbodyData = rigidbodyData;
        }

        protected override void MovementCalculation(float speed)
        {
            _rigidbodyData.Component.velocity = _transformData.Component.forward
                                                * (speed * Time.fixedDeltaTime);
        }

        protected override void PostFade()
        {   
            _rigidbodyData.Component.velocity = Vector3.Lerp(_rigidbodyData.Component.velocity, 
                Vector3.zero, 0.9f);
        }

        public override void TryFixedMove()
        {
            if (_movementData.CanMove)
            {
                InternalMovement();
            }
        }
    }
}