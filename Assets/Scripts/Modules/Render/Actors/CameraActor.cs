using Modules.Actors;
using Modules.Actors.Types;
using Modules.Render.Data;
using UnityEngine;

namespace Modules.Render.Actors
{
    public class CameraActor : ActorBase
    {
        public Camera Component { get; private set; }

        protected override void OnAwake()
        {
            Component = Child.GetComponent<Camera>();
            base.OnAwake();
        }

        public void FollowActor(IActor actor)
        {
            var followData = GetData<FollowActorData>();
            followData.ActorToFollow.Value = actor;
        }

        public void StopFollowing()
        {
            var followData = GetData<FollowActorData>();
            followData.ActorToFollow.Value = null;
        }
    }
}