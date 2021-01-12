using Modules.Actors;
using Modules.Datas.Transforms;
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
            _ownerTransform = transformData.GetTransform();
        }

        public void SetActor(IActor actor)
        {
            var transformData = actor.GetData<TransformData>();
            _lookTransform = transformData.GetTransform();
            StartTick();
        }

        public override void Tick()
        {
            _lookTransform.LookAt(_ownerTransform);
        }
    }
}