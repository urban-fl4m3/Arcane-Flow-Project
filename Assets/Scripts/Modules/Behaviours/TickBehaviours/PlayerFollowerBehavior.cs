using Modules.Actors;
using Modules.Data.Transforms;
using UnityEngine;

namespace Modules.Behaviours.TickBehaviours
{
    [CreateAssetMenu(fileName = "New Player Follow Behaviour", menuName = "Behaviours/PlayerFollower")]
    public class PlayerFollowerBehavior : TickLateBehaviour
    {
        private Transform _followingActorTransform;
        private Transform _ownerActorTransform;

        protected override void OnInitialize(IActor owner)
        {
            ITransformData ownerTransformData = Owner.GetData<TransformData>();
            _ownerActorTransform = ownerTransformData.Component;
        }

        public void SetActorToFollow(IActor actor)
        {
            ITransformData actorTransformData = actor.GetData<TransformData>();
            _followingActorTransform = actorTransformData.Component;
            
            StartTick();
        }

        public void StopFollow()
        {
            DisposeTick();
        }
        
        protected override void OnTick()
        {
            _ownerActorTransform.position = _followingActorTransform.position;

            _ownerActorTransform.position = Vector3.Slerp(_ownerActorTransform.position,
                _followingActorTransform.position,
                0.01f);
        }
    }
}