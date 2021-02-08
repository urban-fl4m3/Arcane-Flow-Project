using Modules.Actors;
using Modules.Behaviours.AbstractTicks;
using Modules.Data.Transforms;
using UnityEngine;

namespace Modules.Behaviours.TickBehaviours
{
    [CreateAssetMenu(fileName = "New Look At Object Behaviour", menuName = "Behaviours/Look At Cursor")]
    public class LookAtObjectBehaviour : TickBehaviour
    {
        private TransformData _transformData;
        private Camera _camera;
        
        protected override void OnInitialize(IActor owner)
        {
            _transformData = owner.GetData<TransformData>();
            _camera = owner.Camera;
            
            base.OnInitialize(owner);
        }

        protected override void OnTick()
        {
            var ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hit, 100, 1 >> 0))
            {
                var lookAtPosition = new Vector3(hit.point.x, _transformData.Component.position.y, hit.point.z);
                _transformData.Component.LookAt(lookAtPosition);
            }
        }
    }
}