using System;
using UnityEngine;

namespace Modules.Common
{
    [Serializable]
    public class DynamicBool : DynamicProperty<bool>, ISerializationCallbackReceiver
    {
        [SerializeField] private bool _value;

        private bool _defaultValue;
        
        protected override bool DynamicValue
        {
            get => _value;
            set => _value = value;
        }
        
        protected override bool Equals(bool lhs, bool rhs)
        {
            return lhs == rhs;
        }

        public void ToDefault()
        {
            Value = _defaultValue;
        }

        public void OnBeforeSerialize()
        {
            
        }

        public void OnAfterDeserialize()
        {
            _defaultValue = _value;
        }
    }
}