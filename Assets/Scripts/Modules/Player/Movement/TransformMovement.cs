﻿using Modules.Data.Animation;
using Modules.Data.KeyBindings;
using Modules.Data.Movement;
using Modules.Data.Transforms;
using UnityEngine;

namespace Modules.Player.Movement
{
    public class TransformMovement : MovementBase
    {
        public TransformMovement(TransformData transformData, RotationData rotationData, AnimationData animationData,
            MovementData movementData, KeyBindingsData bindingsData)
            : base(transformData, rotationData, animationData, movementData, bindingsData)
        {
        }

        protected override void MovementCalculation(Vector3 direction, float speed)
        {
            _transformData.Component.position += direction * (speed * Time.deltaTime);
        }

        public override void TryMove()
        {
            if (_movementData.CanMove)
            {
                InternalMovement();
            }
        }
    }
}