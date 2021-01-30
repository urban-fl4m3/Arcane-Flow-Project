using Modules.Actors;
using Modules.Datas.Transforms;
using UnityEngine;

namespace Modules.Behaviours.TickBehaviours
{
    [CreateAssetMenu(fileName = "New Player Follow Behaviour", menuName = "Behaviours/PlayerFollower")]
    public class PlayerFollowerBehavior : TickBehaviour
    {
        private Transform _followingActorTransform;
        private Transform _ownerActorTransform;

        protected override void OnInitialize(IActor owner)
        {
            ITransformData ownerTransformData = Owner.GetData<TransformData>();
            _ownerActorTransform = ownerTransformData.GetTransform();
        }

        public void SetActorToFollow(IActor actor)
        {
            ITransformData actorTransformData = actor.GetData<TransformData>();
            _followingActorTransform = actorTransformData.GetTransform();
            
            StartTick();
        }

        public void StopFollow()
        {
            DisposeTick();
        }
        
        protected override void OnTick()
        {
            _ownerActorTransform.position = _followingActorTransform.position;
        }
    }
}