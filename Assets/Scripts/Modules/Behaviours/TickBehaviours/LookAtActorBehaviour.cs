using Modules.Actors;
using Modules.Data.Transforms;
using UnityEngine;

namespace Modules.Behaviours.TickBehaviours
{
    public class LookAtActorBehaviour : TickBehaviour
    {
        private Transform _lookTransform;
        private Transform _ownerTransform;
        
        protected override void OnInitialize(IActor owner)
        {
            var transformData = Owner.GetData<TransformData>();
            _ownerTransform = transformData.Component;
        }

        public void SetActor(IActor actor)
        {
            var transformData = actor.GetData<TransformData>();
            _lookTransform = transformData.Component;
            StartTick();
        }

        protected override void OnTick()
        {
            _lookTransform.LookAt(_ownerTransform);
        }
    }
}