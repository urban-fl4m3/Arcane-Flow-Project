using Modules.Actors;
using Modules.Actors.Types;
using Modules.Behaviours.TickBehaviours;

namespace Modules.Render.Actors
{
    public class CameraActor : ActorBase
    {
        private IActor _followingActor;
        
        public void FollowActor(IActor actor)
        {
            _followingActor = actor;

            var playerFollowerBehavior = GetBehaviour<PlayerFollowerBehavior>();
            playerFollowerBehavior.SetActorToFollow(_followingActor);
            
            var thirdPersonRotationBehaviour = GetBehaviour<ThirdPersonRotationBehaviour>();
            thirdPersonRotationBehaviour.SetActorToFollow(_followingActor);
        }
    }
}