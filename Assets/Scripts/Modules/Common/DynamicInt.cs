using System;
using UnityEngine;

namespace Modules.Common
{
    [Serializable]
    public class DynamicInt : DynamicProperty<int>
    {
        [SerializeField] private int _value;
        
        protected override int DynamicValue
        {
            get => _value;
            set => _value = value;
        }
        
        protected override bool Equals(int lhs, int rhs)
        {
            return lhs == rhs;
        }
    }
}