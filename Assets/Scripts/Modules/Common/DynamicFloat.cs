using System;
using UnityEngine;

namespace Modules.Common
{
    [Serializable]
    public class DynamicFloat : DynamicProperty<float>
    {
        [SerializeField] private float _value;

        protected override float DynamicValue
        {
            get => _value;
            set => _value = value;
        }

        protected override bool Equals(float lhs, float rhs)
        {
            return Mathf.Approximately(lhs, rhs);
        }
    }
}