using Modules.Actors;
using Modules.Behaviours.AbstractTicks;
using Modules.Data.Transforms;
using Modules.Render.Data;
using UnityEngine;

namespace Modules.Behaviours.TickBehaviours
{
    [CreateAssetMenu(fileName = "New Player Follow Behaviour", menuName = "Behaviours/PlayerFollower")]
    public class PlayerFollowerBehavior : TickLateBehaviour
    {
        [SerializeField] private float _offset;
        
        private Transform _followingActorTransform;
        private Transform _ownerActorTransform;
        private FollowActorData _followActorData;

        protected override void OnInitialize(IActor owner)
        {
            var ownerTransformData = Owner.GetData<TransformData>();
            _ownerActorTransform = ownerTransformData.Component;

            _followActorData = Owner.GetData<FollowActorData>();
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
            var actorTransformData = actor.GetData<TransformData>();
            _followingActorTransform = actorTransformData.Component;
            
            StartTick();
        }
        
        protected override void OnTick()
        {
            _ownerActorTransform.position = Vector3.Lerp(
                _ownerActorTransform.position,
                _followingActorTransform.position,
                _offset);
        }

        public override void Dispose()
        {
            base.Dispose();
            _followActorData.ActorToFollow.PropertyChanged -= HandleActorToFollowChanged;
        }
    }
}