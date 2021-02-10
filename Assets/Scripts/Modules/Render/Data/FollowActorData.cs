using Modules.Actors;
using Modules.Common;
using Modules.Data;
using UnityEngine;

namespace Modules.Render.Data
{
    [CreateAssetMenu(fileName = "New Follow Data", menuName = "Data/Follow Actor")]
    public class FollowActorData : BaseData
    {
        protected override void OnInitialize(IActor owner)
        {
            ActorToFollow = new DynamicActor();
        }
        
        public DynamicActor ActorToFollow { get; private set; }
    }
}