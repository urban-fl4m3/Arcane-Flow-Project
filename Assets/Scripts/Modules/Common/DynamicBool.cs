using System;
using UnityEngine;

namespace Modules.Common
{
    [Serializable]
    public class DynamicBool : DynamicProperty<bool>
    {
        [SerializeField] private bool _value;

        protected override bool DynamicValue
        {
            get => _value;
            set => _value = value;
        }
        
        protected override bool Equals(bool lhs, bool rhs)
        {
            return lhs == rhs;
        }
    }
}