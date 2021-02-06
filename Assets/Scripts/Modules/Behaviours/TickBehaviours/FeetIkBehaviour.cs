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

        private float rightFootWeightGoal = 0.0f;
        private float rightFootWeightValue = 0.0f;
        
        private float leftFootWeightGoal = 0.0f;
        private float leftFootWeightValue = 0.0f;


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
            rightFootWeightValue = Mathf.Lerp(rightFootWeightValue, rightFootWeightGoal, 0.05f);
            leftFootWeightValue = Mathf.Lerp(leftFootWeightValue, leftFootWeightGoal, 0.05f);
        }

        private void HandleAnimatorIKTick(object sender, int layerIndex)
        {
            var animator = _animationData.Component;

            var leftLegPosition = _animationData.Component.GetIKPosition(AvatarIKGoal.LeftFoot);
            var rayStart = leftLegPosition + Vector3.up * 0.3f;

            var rayDown = new Ray(leftLegPosition + Vector3.up * 0.3f, Vector3.down);

            float FootPlaceStateLeft0 = 0.0f;
            
            RaycastHit hit;
            if (Physics.Raycast(rayDown, out hit, 0.45f, _ikData.EnvironmentLayer))
            {
                FootPlaceStateLeft0 = 1.0f;

                leftLegPosition = hit.point + Vector3.up * 0.06f;
            }

            var rightLegPosition = _animationData.Component.GetIKPosition(AvatarIKGoal.RightFoot);

            rayDown = new Ray(rightLegPosition + Vector3.up * 0.3f, Vector3.down);
            float FootPlaceStateRight0 = 0.0f;
            if (Physics.Raycast(rayDown, out hit, 0.45f, _ikData.EnvironmentLayer))
            {
                FootPlaceStateRight0 = 1.0f; ;

                rightLegPosition = hit.point + Vector3.up * 0.06f;
            }

            leftFootWeightGoal = FootPlaceStateLeft0;
            rightFootWeightGoal = FootPlaceStateRight0;
            animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, leftFootWeightValue);
            animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, rightFootWeightValue);
            animator.SetIKPosition(AvatarIKGoal.LeftFoot, leftLegPosition);
            animator.SetIKPosition(AvatarIKGoal.RightFoot, rightLegPosition);
            var b = animator.bodyPosition;
            var minimumLegPosition = _transformData.Component.position.y;
            // Debug
            b.y = (minimumLegPosition + _ikData.PelvisOffset);
            animator.bodyPosition = b;

            if (layerIndex == 1)
            {
                leftLegPosition = _animationData.Component.GetBoneTransform(HumanBodyBones.LeftFoot).position;
                // rayStart = leftLegPosition + Vector3.up * 0.3f;
                // Debug.DrawLine(rayStart, rayStart + Vector3.down * 0.4f);
            
                rayDown = new Ray(leftLegPosition + Vector3.up * 0.3f, Vector3.down);

                float FootPlaceStateLeft1 = 0.0f;
                
                if (Physics.Raycast(rayDown, out hit, 0.45f, _ikData.EnvironmentLayer))
                {
                    FootPlaceStateLeft1 = 1.0f;

                    leftLegPosition = hit.point + Vector3.up * 0.06f;
                }

                rightLegPosition = _animationData.Component.GetBoneTransform(HumanBodyBones.RightFoot).position;

                rayDown = new Ray(rightLegPosition + Vector3.up * 0.3f, Vector3.down);
                float FootPlaceStateRight1 = 0.0f;
                if (Physics.Raycast(rayDown, out hit, 0.45f, _ikData.EnvironmentLayer))
                {
                    FootPlaceStateRight1 = 1.0f; ;

                    rightLegPosition = hit.point + Vector3.up * 0.06f;
                }

                if (FootPlaceStateLeft0 == 0.0f && FootPlaceStateLeft1 == 1.0f)
                {
                    animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, FootPlaceStateRight1);
                    animator.SetIKPosition(AvatarIKGoal.LeftFoot, leftLegPosition);
                }

                if (FootPlaceStateRight0 == 0.0f && FootPlaceStateRight1 == 1.0f)
                {
                    animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, FootPlaceStateLeft1);
                    animator.SetIKPosition(AvatarIKGoal.RightFoot, rightLegPosition);
                }
                
                // b = animator.bodyPosition;
                // minimumLegPosition =
                //     Mathf.Min(leftLegPosition,
                //         _animationData.Component.GetBoneTransform(HumanBodyBones.RightFoot).position.y);
                // b.y = (minimumLegPosition + _ikData.PelvisOffset);
                // animator.bodyPosition = b;
            }
        }
        
    }
}