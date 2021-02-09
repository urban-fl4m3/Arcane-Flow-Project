using Modules.Actors;
using Modules.Behaviours.AbstractTicks;
using Modules.Data.Transforms;
using UnityEngine;

namespace Modules.Behaviours.TickBehaviours
{
    [CreateAssetMenu(fileName = "New Look At Object Behaviour", menuName = "Behaviours/Look At Cursor")]
    public class LookAtObjectBehaviour : TickBehaviour
    {
        private RotationData _rotationData;
        private TransformData _transformData;
        private Camera _camera;
        
        protected override void OnInitialize(IActor owner)
        {
            base.OnInitialize(owner);
            
            _rotationData = Owner.GetData<RotationData>();
            _transformData = Owner.GetData<TransformData>();
            _camera = Owner.Camera;

            _rotationData.LookAtMouseCursor.PropertyChanged += HandleLookAtMouseCursorChanged;
            OnMouseCursorStateChanged(_rotationData.LookAtMouseCursor.Value);
        }

        protected override void OnTick()
        {
            var ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (!Physics.Raycast(ray, out var hit, 100, 1 >> 0)) return;
            var lookAtPosition = new Vector3(hit.point.x, _transformData.Component.position.y, hit.point.z);
            _transformData.Component.LookAt(lookAtPosition);
        }

        private void HandleLookAtMouseCursorChanged(object sender, bool value)
        {
            OnMouseCursorStateChanged(value);
        }

        private void OnMouseCursorStateChanged(bool state)
        {
            if (state)
            {
                StartTick();
            }
            else
            {
                DisposeTick();
            }
        }

        public override void Dispose()
        {
            base.Dispose();
            _rotationData.LookAtMouseCursor.PropertyChanged -= HandleLookAtMouseCursorChanged;
        }
    }
}