using System;
using UnityEngine;

namespace Modules.Common
{
    [Serializable]
    public class DynamicProperty
    {
        [SerializeField] private float _value;

        public float Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (Mathf.Approximately(_value, value))
                {
                    return;
                }

                _value = value;
                PropertyChanged?.Invoke(this, _value);
            }
        }

        public event EventHandler<float> PropertyChanged;
    }
}