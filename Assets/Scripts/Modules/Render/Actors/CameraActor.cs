using Modules.Actors;
using Modules.Actors.Types;
using Modules.Behaviours.TickBehaviours;
using UnityEngine;

namespace Modules.Render.Actors
{
    public class CameraActor : ActorBase
    {
        public Camera Component { get; private set; }
        
        private IActor _followingActor;

        protected override void OnAwake()
        {
            Component = GetChild().GetComponent<Camera>();
            base.OnAwake();
        }

        public void FollowActor(IActor actor)
        {
            _followingActor = actor;

            var playerFollowerBehavior = GetBehaviour<PlayerFollowerBehavior>();
            playerFollowerBehavior.SetActorToFollow(_followingActor);
            
            var thirdPersonRotationBehaviour = GetBehaviour<ThirdPersonRotationBehaviour>();
            thirdPersonRotationBehaviour.SetActorToFollow(_followingActor);
        }

        public void StopFollowing()
        {
            var playerFollowerBehavior = GetBehaviour<PlayerFollowerBehavior>();
            playerFollowerBehavior.StopFollow();
            
            var thirdPersonRotationBehaviour = GetBehaviour<ThirdPersonRotationBehaviour>();
            thirdPersonRotationBehaviour.StopFollow();
        }
    }
}