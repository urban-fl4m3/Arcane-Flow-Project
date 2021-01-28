using UnityEngine;

namespace Modules.Common
{
    public class MeshBarComponent : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _mesh;
        [SerializeField] private string _valueKey;
        [SerializeField] private string _deltaKey;
        [SerializeField] private float _lerpDelay;
        
        [SerializeField] private Material _material;
        
        private Material _materialInstance;
        private float _lastValue = 1.0f;
        
        private void Awake()
        {
            _materialInstance = Instantiate(_material);
            _mesh.material = _materialInstance;
        }

        public void UpdateBar(float value)
        {
            _lastValue = Mathf.Lerp(_lastValue, value, _lerpDelay);
            _materialInstance.SetFloat(_valueKey, value);
            _materialInstance.SetFloat(_deltaKey, _lastValue);
        }
    }
}