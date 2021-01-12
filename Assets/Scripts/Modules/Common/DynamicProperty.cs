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

                PropertyChanged?.Invoke(this, EventArgs.Empty);
                _value = value;

            }
        }

        public event EventHandler PropertyChanged;
    }
}