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
            var rayStart = leftLegPosition + Vector3.up * 0.3f;
            Debug.DrawLine(rayStart, rayStart + Vector3.down * 0.4f);
            
            var rayDown = new Ray(leftLegPosition + Vector3.up * 0.3f, Vector3.down);
            var height = _transformData.Component.position.y;
            var middle = 0.0f;

            float FootPlaceStateLeft = 0.0f;
            
            RaycastHit hit;
            if (Physics.Raycast(rayDown, out hit, 0.45f, _ikData.EnvironmentLayer))
            {
                FootPlaceStateLeft = 1.0f;
                height = Mathf.Max(height, hit.point.y);
                middle += height;

                leftLegPosition = hit.point + Vector3.up * 0.06f;
            }

            var rightLegPosition = _animationData.Component.GetIKPosition(AvatarIKGoal.RightFoot);

            rayDown = new Ray(rightLegPosition + Vector3.up * 0.3f, Vector3.down);
            float FootPlaceStateRight = 0.0f;
            if (Physics.Raycast(rayDown, out hit, 0.45f, _ikData.EnvironmentLayer))
            {
                FootPlaceStateRight = 1.0f;
                height = Mathf.Max(height, hit.point.y);
                middle += height;
                
                rightLegPosition = hit.point + Vector3.up * 0.06f;
            }
            // middle = leftLegPosition.y + rightLegPosition.y;
            // middle /= 2.0f;
            // var a = _transformData.Component.position;
            // a.y = middle;
            //
            // _transformData.Component.position = a;

            // var b = animator.bodyPosition;
            // b.y = middle + _ikData.PelvisOffset;
            // animator.bodyPosition = b;

            animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, FootPlaceStateLeft);
            animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, FootPlaceStateRight);
            animator.SetIKPosition(AvatarIKGoal.LeftFoot, leftLegPosition);
            animator.SetIKPosition(AvatarIKGoal.RightFoot, rightLegPosition);
            
            middle = animator.GetBoneTransform(HumanBodyBones.LeftFoot).position.y + animator.GetBoneTransform(HumanBodyBones.RightFoot).position.y;
            middle /= 2.0f;
            // var a = _transformData.Component.position;
            // a.y = middle;
            //
            // _transformData.Component.position = a;

            var b = animator.bodyPosition;
            b.y = (_transformData.Component.position.y + _ikData.PelvisOffset);
            animator.bodyPosition = b;
        }
        
    }
}