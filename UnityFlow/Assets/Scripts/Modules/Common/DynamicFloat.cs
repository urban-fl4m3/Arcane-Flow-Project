using System;
using UnityEngine;

namespace Modules.Common
{
    [Serializable]
    public class DynamicFloat : DynamicProperty<float>
    {
        [SerializeField] private float _value;
        [SerializeField] private float _minValue;
        [SerializeField] private float _maxValue;
        
        protected override float DynamicValue
        {
            get => _value;
            set => _value = value;
        }

        protected override bool Equals(float lhs, float rhs)
        {
            return Mathf.Approximately(lhs, rhs);
        }

        protected override void UpdateValue(float value)
        {
            _value = Mathf.Clamp(value, _minValue, _maxValue);
        }

        public float Percentage()
        {
            return (_value - _minValue) / (_maxValue - _minValue);
        }
    }
}