using Modules.Common;
using Modules.Ticks;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Views.GameHudWindow
{
    public class UiBarComponent : MonoBehaviour, ITickUpdate
    {
        public bool Enabled { get; set; }
        
        [SerializeField] private string _valueKey;
        [SerializeField] private string _deltaKey;
        [SerializeField] private float _deltaDelay;
        [SerializeField] private Image _healthBar;

        private float _lastValue = 1.0f;

        private DynamicFloat _property;
        
        public void Init(DynamicFloat barProperty)
        {
            _property = barProperty;
            _lastValue = _property.Value;
            _healthBar.material.SetFloat(_valueKey, _property.Percentage());

            Enabled = true;
        }
        
        public void Tick()
        {
            if (Enabled)
            {
                if (_property.Percentage() >= 0)
                {
                    _lastValue = Mathf.Lerp(_lastValue, _property.Percentage(), _deltaDelay);
                    _healthBar.material.SetFloat(_valueKey, _property.Percentage());
                    _healthBar.material.SetFloat(_deltaKey, _lastValue);
                }
            }
        }
    }
}