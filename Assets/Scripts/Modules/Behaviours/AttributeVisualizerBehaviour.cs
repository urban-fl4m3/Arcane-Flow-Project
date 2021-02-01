using Modules.Actors;
using Modules.Common;
using Modules.Data.Attributes;
using Modules.Data.Transforms;
using UnityEngine;
using Attribute = Modules.Common.Attribute;

namespace Modules.Behaviours
{
    [CreateAssetMenu(fileName = "AttributeVisualizer", menuName = "Behaviours/Attribute visualizer")]
    public class AttributeVisualizerBehaviour : TickBehaviour
    {
        [SerializeField] private Attribute _attribute;
        [SerializeField] private float _height;
        [SerializeField] private MeshBarComponent _bar;

        private Transform _barTransform;
        private Camera _camera;
        private DynamicFloat _attributeFloat;

        protected override void OnInitialize(IActor owner)
        {
            var attributesData = owner.GetData<AttributesData>();

            var hasAttribute = attributesData.Attributes.TryGetValue(_attribute, out var property);

            if (!hasAttribute)
            {
                Debug.LogWarning($"Actor {owner.GetGameObject().name} doesn't have the {_attribute}" +
                                 " attribute in data");
                return;
            }
            
            _attributeFloat = property;
            _camera = owner.Camera;
            
            var ownerTransform = owner.GetData<TransformData>().Component;
            _bar = Instantiate(_bar, new Vector3(0, _height, 0), Quaternion.identity);
            _barTransform = _bar.transform;
            _barTransform.SetParent(ownerTransform, false);
            
            base.OnInitialize(owner);
        }

        protected override void OnTick()
        {
            var position = (_camera.transform.position - _bar.transform.position) * -1 
                           + _barTransform.position;
            _barTransform.LookAt(position);

            _bar.UpdateBar(_attributeFloat.Percentage());
        }
    }
}