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
            
            base.OnInitialize(owner);
        }

        public void SetActorToFollow(IActor actor)
        {
            ITransformData actorTransformData = actor.GetData<TransformData>();
            _followingActorTransform = actorTransformData.GetTransform();
        }
        
        public override void Tick()
        {
            _ownerActorTransform.position = _followingActorTransform.position;
        }
    }
}