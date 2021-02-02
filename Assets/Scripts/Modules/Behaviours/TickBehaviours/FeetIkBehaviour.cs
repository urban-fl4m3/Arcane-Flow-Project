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
            var leftLegPosition = _animationData.Component.GetBoneTransform(HumanBodyBones.LeftFoot).position;

            var rayDown = new Ray(leftLegPosition + new Vector3(0, 1, 0), Vector3.down);
            var height = _transformData.Component.position.y;
            var middle = 0.0f;
            
            RaycastHit hit;
            if (Physics.Raycast(rayDown, out hit, _ikData.RayCastDownDistance + 1.0f, _ikData.EnvironmentLayer))
            {
                height = Mathf.Max(height, hit.point.y);
                middle += height;
                
                leftLegPosition.y = hit.point.y;
            }

            var rightLegPosition = _animationData.Component.GetBoneTransform(HumanBodyBones.RightFoot).position;

            rayDown = new Ray(rightLegPosition + new Vector3(0, 1, 0), Vector3.down);

            if (Physics.Raycast(rayDown, out hit, _ikData.RayCastDownDistance + 1.0f, _ikData.EnvironmentLayer))
            {
                height = Mathf.Max(height, hit.point.y);
                middle += height;
                
                rightLegPosition.y = hit.point.y;
            }

            var a = _transformData.Component.position;
            a.y = height;
            _transformData.Component.position = a;

            middle /= 2;
            var b = animator.bodyPosition;
            b.y = middle + _ikData.PelvisOffset;
            animator.bodyPosition = b;
            
            animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 0.5f);
            animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, 0.5f);
            animator.SetIKPosition(AvatarIKGoal.LeftFoot, leftLegPosition);
            animator.SetIKPosition(AvatarIKGoal.RightFoot, rightLegPosition);
        }
    }
}