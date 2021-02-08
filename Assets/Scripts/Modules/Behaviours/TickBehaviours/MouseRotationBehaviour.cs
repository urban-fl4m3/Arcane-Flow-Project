using Modules.Actors;
using Modules.Behaviours.AbstractTicks;
using Modules.Data.Transforms;
using UnityEngine;

namespace Modules.Behaviours.TickBehaviours
{
    [CreateAssetMenu(fileName = "New Mouse Rotation Behaviour", menuName = "Behaviours/Mouse Rotation")]
    public class MouseRotationBehaviour : TickLateBehaviour
    {
        
        //todo: Move To Concrete Data!!
        [SerializeField] private Vector2 _verticalRotationEdges = new Vector2(-90.0f, 90.0f);
        private const float _mouseSpeed = 0.1f;
        
        private TransformData _transformData;


        private Transform _rootTransform;

        private float _xRotation;
        private float _yRotation;

        protected override void OnInitialize(IActor owner)
        {
            _rootTransform = Owner.GetData<TransformData>().Component;
            base.OnInitialize(owner);
        }

        protected override void OnTick()
        {
            _yRotation += Mathf.Asin(Mathf.Clamp(Input.GetAxis("Mouse X"), -1.0f, 1.0f)) * _mouseSpeed;
            _xRotation += Mathf.Asin(Mathf.Clamp(Input.GetAxis("Mouse Y"), -1.0f, 1.0f)) * _mouseSpeed;
            _xRotation = Mathf.Clamp(_xRotation, _verticalRotationEdges.x * Mathf.Deg2Rad, _verticalRotationEdges.y * Mathf.Deg2Rad);
            _rootTransform.rotation = Quaternion.Euler(_xRotation * -Mathf.Rad2Deg, _yRotation * Mathf.Rad2Deg, 0.0f);
        }
    }
}