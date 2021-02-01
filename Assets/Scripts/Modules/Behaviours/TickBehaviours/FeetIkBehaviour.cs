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
            AdjustFeetTarget(ref _rightFootPosition, HumanBodyBones.RightFoot);
            AdjustFeetTarget(ref _leftFootPosition, HumanBodyBones.LeftFoot);
            
            FeetPositionSolver(_rightFootPosition, ref _rightFootIkPosition, ref _rightFootIkRotation);
            FeetPositionSolver(_leftFootPosition, ref _leftFootIkPosition, ref _leftFootIkRotation);
        }

        private void HandleAnimatorIKTick(object sender, int layerIndex)
        {
            MovePelvisHeight();
            var animator = _animationData.Component;
            
            animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, 1);
            
            if (false)
            {
                animator.SetIKRotationWeight(AvatarIKGoal.RightFoot, 
                    animator.GetFloat(_ikData.RightFootAnimVariableName));
            }
            
            MoveFeetToIkPoint(AvatarIKGoal.RightFoot, _rightFootIkPosition, _rightFootIkRotation, 
                ref _lastRightFootPositionY);
            
            animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 1);
            
            if (false)
            {
                animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, 
                    animator.GetFloat(_ikData.LeftFootAnimVariableName));
            }
            
            MoveFeetToIkPoint(AvatarIKGoal.LeftFoot, _leftFootIkPosition, _leftFootIkRotation, 
                ref _lastLeftFootPositionY);
        }

        private void MoveFeetToIkPoint(AvatarIKGoal foot, Vector3 positionIkHolder, Quaternion rotationIkHolder,
            ref float lastFootPositionY)
        {
            var targetIkPosition = _animationData.Component.GetIKPosition(foot);

            if (positionIkHolder != Vector3.zero)
            {
                targetIkPosition = _transformData.Component.InverseTransformPoint(targetIkPosition);
                positionIkHolder = _transformData.Component.InverseTransformPoint(positionIkHolder);

                var yVariable = Mathf.Lerp(lastFootPositionY, positionIkHolder.y, _ikData.FeetToIkPositionSpeed);
                targetIkPosition.y += yVariable;

                lastFootPositionY = yVariable;
                targetIkPosition = _transformData.Component.TransformPoint(targetIkPosition);
                
                 _animationData.Component.SetIKRotation(foot, rotationIkHolder);
            }
            
            _animationData.Component.SetIKPosition(foot, targetIkPosition);
        }

        private void MovePelvisHeight()
        {
            if (_rightFootIkPosition == Vector3.zero ||
                _leftFootIkPosition == Vector3.zero ||
                _lastPelvisPositionY == 0.0f)
            {
                _lastPelvisPositionY = _animationData.Component.bodyPosition.y;
                return;
            }

            var position = _transformData.Component.position;
            
            var lOffsetPosition = _leftFootIkPosition.y - position.y;
            var rOffsetPosition = _rightFootIkPosition.y - position.y;

            var totalOffset = Mathf.Min(lOffsetPosition, rOffsetPosition);
            var newPelvisPosition = _animationData.Component.bodyPosition + Vector3.up * totalOffset;

            newPelvisPosition.y = Mathf.Lerp(_lastPelvisPositionY, newPelvisPosition.y, _ikData.PelvisUpAndDownSpeed);
            _animationData.Component.bodyPosition = newPelvisPosition;
            _lastPelvisPositionY = _animationData.Component.bodyPosition.y;
        }

        private void FeetPositionSolver(Vector3 fromPosition, ref Vector3 feetIkPositions,
            ref Quaternion feetIkRotations)
        {
            RaycastHit feetOutHit;

            var raycastLength = _ikData.RayCastDownDistance + _ikData.HeightFromGroundRaycast;
            
            if (_ikData.ShowSolverDebug)
            {
                Debug.DrawLine(fromPosition, fromPosition + Vector3.down * raycastLength, Color.yellow);
            }

            if (Physics.Raycast(fromPosition, Vector3.down, out feetOutHit, raycastLength,
                _ikData.EnvironmentLayer))
            {
                feetIkPositions = fromPosition;
                feetIkPositions.y = feetOutHit.point.y + _ikData.PelvisOffset;
                feetIkRotations = Quaternion.FromToRotation(Vector3.up, feetOutHit.normal) *
                                  _transformData.Component.rotation;
                
                return;
            }

            feetIkPositions = Vector3.zero;
        }

        private void AdjustFeetTarget(ref Vector3 feetPositions, HumanBodyBones foot)
        {
            feetPositions = _animationData.Component.GetBoneTransform(foot).position;
            feetPositions.y = _transformData.Component.position.y + _ikData.HeightFromGroundRaycast;
        }
    }
}