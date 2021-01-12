using System;
using System.Collections.Generic;
using System.Linq;
using Modules.Actors;
using Modules.Common;
using UnityEngine;
using Attribute = Modules.Common.Attribute;

namespace Modules.Datas.Attributes
{
    [CreateAssetMenu(fileName = "HealthData", menuName = "Attributes Data/Health")]
    public class AttributesData : BaseData, IAttributesData
    {
        private Dictionary<Attribute, DynamicProperty> _attributesMap 
            = new Dictionary<Attribute, DynamicProperty>();
        
        [SerializeField] private List<AttributeModel> _attributeList;
        
        public IReadOnlyDictionary<Attribute, DynamicProperty> Attributes => _attributesMap;

        protected override void OnInitialize(IActor owner)
        {
            _attributesMap = _attributeList.ToDictionary(x => x.Attribute,
                x => x.Property);
        }
        
        [Serializable]
        private class AttributeModel
        {
            [SerializeField] public Attribute Attribute;
            [SerializeField] public DynamicProperty Property;
        }
    }
}