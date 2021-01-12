﻿using Modules.Actors;
using Modules.Common;
using Modules.Datas.Attributes;
using Modules.Datas.Transforms;
using UnityEngine;

namespace Modules.Behaviours
{
    [CreateAssetMenu(fileName = "AttributeVisualizer", menuName = "Behaviours/Attribute visualizer")]
    public class AttributeVisualizerBehaviour : TickBehaviour
    {
        [SerializeField] private Attribute _attribute;
        [SerializeField] private float _height;
        [SerializeField] private GameObject _healthBar;

        private Camera _camera;
        private DynamicProperty _attributeProperty;
        
        
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

            _attributeProperty = property;
            
            _camera = owner.Camera;
            
            var ownerTransform = owner.GetData<TransformData>().GetTransform();
            _healthBar = Instantiate(_healthBar, new Vector3(0, _height, 0), Quaternion.identity);
            _healthBar.transform.SetParent(ownerTransform, false);

            
            base.OnInitialize(owner);
        }

        public override void Tick()
        {
            _healthBar.transform.LookAt(_camera.transform);
        }
    }
}