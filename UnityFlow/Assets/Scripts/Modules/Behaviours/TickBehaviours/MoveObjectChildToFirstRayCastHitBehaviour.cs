using Modules.Actors;
using Modules.Datas.Transforms;
using UnityEngine;

namespace Modules.Behaviours.TickBehaviours
{
    [CreateAssetMenu(fileName = "New Move Object Child To First RayCast Hit Behaviour", menuName = "Behaviours/Move Object Child To First RayCast Hit")]
    public class MoveObjectChildToFirstRayCastHitBehaviour : TickBehaviour
    {
        private Transform _childTransform;
        private Transform _rootTransform;
        
        private float _defaultOffset;
        private RaycastHit _hit;
        private Vector3 _defaultLocalPosition;
        
        protected override void OnInitialize(IActor owner)
        {
            _childTransform = Owner.GetChild().GetData<TransformData>().GetTransform();
            _rootTransform = Owner.GetData<TransformData>().GetTransform();
            
            var localPosition = _childTransform.localPosition;
            _defaultLocalPosition = localPosition;
            _defaultOffset = localPosition.magnitude;
            
            base.OnInitialize(owner);
        }

        public override void Tick()
        {
            var offset = _defaultOffset;
            if (Physics.SphereCast(_rootTransform.position,
                0.1f, (_childTransform.position - _rootTransform.position).normalized,
                out _hit, _defaultOffset, LayerMask.GetMask("Default")))
            {
                offset = (_hit.point - _rootTransform.position).magnitude;
            }
            
            _childTransform.localPosition = _defaultLocalPosition.normalized * offset;
        }
    }
}