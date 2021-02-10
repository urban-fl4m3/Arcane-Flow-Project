using Modules.Actors;
using Modules.Behaviours.AbstractTicks;
using Modules.Data.Transforms;
using Modules.Render.Data;
using UnityEngine;

namespace Modules.Behaviours.TickBehaviours
{
    [CreateAssetMenu(fileName = "New Third Person Rotation Behaviour", menuName = "Behaviours/Third Person Rotation Behaviour")]
    public class ThirdPersonRotationBehaviour : TickBehaviour
    {
        private float _rotationInMovementDirection;
        private float _velocity;
        
        private Transform _actorTransform;
        private Transform _cameraTransform;
        
        private TransformData _transformData;
        private RotationData _rotationData;
        private FollowActorData _followActorData;
        
        protected override void OnInitialize(IActor owner)
        {
            _cameraTransform = owner.GetData<TransformData>().Component;
            _followActorData = owner.GetData<FollowActorData>();

            _followActorData.ActorToFollow.PropertyChanged += HandleActorToFollowChanged;
        }

        private void HandleActorToFollowChanged(object sender, IActor e)
        {
            if (e == null)
            {
                DisposeTick();
            }
            else
            {
                SetActorToFollow(e);
            }
        }
        
        private void SetActorToFollow(IActor actor)
        {
            _transformData = actor.GetData<TransformData>();
            _rotationData = actor.GetData<RotationData>();
            _actorTransform = _transformData.Component;
            
            StartTick();
        }

        protected override void OnTick()
        {
            if (_rotationData.ApplyMovementRotation) ApplyRotation();
        }

        private void ApplyRotation()
        {
            var actorTransformForward = _actorTransform.forward;
            actorTransformForward.Scale(new Vector3(1.0f, 0.0f, 1.0f));
            actorTransformForward.Normalize();

            var cameraForward = _cameraTransform.forward;
            cameraForward.Scale(new Vector3(1.0f, 0.0f, 1.0f));
            cameraForward.Normalize();

            var inCameraRotation = Vector3.SignedAngle(actorTransformForward, cameraForward, Vector3.up);
           
            var newRotation = _actorTransform.rotation;
            newRotation = Quaternion.Slerp(newRotation,
                newRotation * Quaternion.Euler(0.0f, inCameraRotation, 0.0f), 0.1f);

            _actorTransform.rotation = newRotation;
        }
        
        public override void Dispose()
        {
            base.Dispose();
            _followActorData.ActorToFollow.PropertyChanged -= HandleActorToFollowChanged;
        }
    }
}