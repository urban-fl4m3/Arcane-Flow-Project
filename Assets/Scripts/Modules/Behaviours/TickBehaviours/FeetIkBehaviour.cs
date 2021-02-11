using System;
using Modules.Actors;
using Modules.Data.Animation;
using Modules.Data.IK;
using Modules.Data.Transforms;
using UnityEngine;

namespace Modules.Behaviours.TickBehaviours
{
    [CreateAssetMenu(fileName = "New Feet IK Behaviour", menuName = "Behaviours/Feet IK")]
    public class FeetIkBehaviour : TickFixedBehaviour
    {
        private IkData _ikData;
        private AnimationData _animationData;
        private TransformData _transformData;

        private Vector3 _rightFootPosition;
        private Vector3 _leftFootPosition;
        private Vector3 _rightFootIkPosition;
        private Vector3 _leftFootIkPosition;

        private Quaternion _leftFootIkRotation;
        private Quaternion _rightFootIkRotation;

        private float _lastPelvisPositionY;
        private float _lastRightFootPositionY;
        private float _lastLeftFootPositionY;

        private float rightFootHeightGoal = 0.0f;
        private float rightFootHeightValue = 0.0f;
        
        private float leftFootHeightGoal = 0.0f;
        private float leftFootHeightValue = 0.0f;


        protected override void OnInitialize(IActor owner)
        {
            base.OnInitialize(owner);
            
            _ikData = owner.GetData<IkData>();
            _animationData = owner.GetData<AnimationData>();
            _transformData = owner.GetData<TransformData>();

            _ikData.Component.AnimatorIkTick += HandleAnimatorIKTick;
        }

        protected override void OnTick()
        {
            
        }

        private void HandleAnimatorIKTick(object sender, int layerIndex)
        {
            var animator = _animationData.Component;

            var leftLegPosition = _animationData.Component.GetIKPosition(AvatarIKGoal.LeftFoot);
            var newLeftLegPosition = leftLegPosition;
            newLeftLegPosition.y = _transformData.Component.position.y;
            
            var rayStart = leftLegPosition + Vector3.up * 0.3f;

            var rayDown = new Ray(rayStart, Vector3.down);

            if (Physics.Raycast(rayDown, out var hit, 1.0f, _ikData.EnvironmentLayer))
            {
                newLeftLegPosition = hit.point;
            }



            var rightLegPosition = _animationData.Component.GetIKPosition(AvatarIKGoal.RightFoot);
            var newRightPosition = rightLegPosition;
            newRightPosition.y = _transformData.Component.position.y;
            
            rayStart = rightLegPosition + Vector3.up * 0.3f;
            rayDown = new Ray(rayStart, Vector3.down);
            
            if (Physics.Raycast(rayDown, out hit, 1.0f, _ikData.EnvironmentLayer))
            {
                newRightPosition = hit.point;
            }




            var leftFootOffset = Math.Abs(leftLegPosition.y - _transformData.Component.position.y);
            var rightFootOffset = Mathf.Abs(rightLegPosition.y - _transformData.Component.position.y);

            leftFootHeightGoal = newLeftLegPosition.y;
            rightFootHeightGoal = newRightPosition.y;
                
            leftFootHeightValue = Mathf.Lerp(leftFootHeightValue, leftFootHeightGoal, _ikData.FeetToIkPositionSpeed);
            rightFootHeightValue = Mathf.Lerp(rightFootHeightValue, rightFootHeightGoal, _ikData.FeetToIkPositionSpeed);

            newLeftLegPosition.y = leftFootHeightValue;
            newRightPosition.y = rightFootHeightValue;
            
            animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, 1.0f);
            animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 1.0f);
            
            
            
            animator.SetIKPosition(AvatarIKGoal.RightFoot, newRightPosition + Vector3.up * rightFootOffset);
            animator.SetIKPosition(AvatarIKGoal.LeftFoot, newLeftLegPosition + Vector3.up * leftFootOffset);



            var bodyPosition = animator.bodyPosition;
            var minimumLegPosition = newLeftLegPosition.y;
            minimumLegPosition = Mathf.Min(minimumLegPosition,newRightPosition.y);
            bodyPosition.y = (minimumLegPosition + _ikData.PelvisOffset);
            animator.bodyPosition = bodyPosition;

         


        }

    }
}