using Modules.Actors;
using Modules.Datas.Movement;
using Modules.Datas.Transforms;
using Modules.Render.Managers;
using UnityEngine;

namespace Modules.Behaviours.TickBehaviours
{
    [CreateAssetMenu(fileName = "New Third Person Rotation Behaviour", menuName = "Behaviours/Third Person Rotation Behaviour")]
    public class ThirdPersonRotationBehaviour : TickBehaviour
    {
        [SerializeField] private float _turnTime = 1.0f;
        private float _rotationInMovementDirection;
        private float _velocity;
        
        private Transform _actorTransform;
        
        private IMovementData _movementData;
        private ITransformData _transformData;
        private IRotationData _rotationData;
        private Transform _cameraTransform;
        
        protected override void OnInitialize(IActor owner)
        {
            _cameraTransform = owner.GetData<TransformData>().GetTransform();
            
            base.OnInitialize(owner);
        }
        
        public void SetActorToFollow(IActor actor)
        {
            _movementData = actor.GetData<MovementData>();
            _transformData = actor.GetData<TransformData>();
            _rotationData = actor.GetData<RotationData>();
            _actorTransform = _transformData.GetTransform();
        }

        public override void Tick()
        {
            if (_rotationData.CanRotate) ApplyRotation();
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
    }
}