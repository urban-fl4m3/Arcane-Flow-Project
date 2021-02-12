using Modules.Actors;
using Modules.Data.Attributes;
using UnityEngine;
using Attribute = Modules.Common.Attribute;

namespace Modules.SpellSystem.Actors
{
    public class AoeActor : SpellActor
    {
        [SerializeField] private Vector2 _minMaxSize;
        [SerializeField] private float _speed;
        [SerializeField] private float _damage;
        
        private float _startLiveTime;

        protected override void OnAwake()
        {
            _startLiveTime = Time.time;
            transform.localScale = new Vector3(_minMaxSize.x, _minMaxSize.x, _minMaxSize.x);
        }

        private void Update()
        {
            var sizeValue = Mathf.Sin((Time.time - _startLiveTime) * _speed);
        
            if (sizeValue < 0.0f) {
                Destroy(gameObject);
                return;
            }
        
            var newSizeValue = Mathf.Lerp(_minMaxSize.x, _minMaxSize.y, sizeValue);
            var newSize = new Vector3(newSizeValue, newSizeValue, newSizeValue);
        
            transform.localScale = newSize;
        }

        private void OnCollisionEnter(Collision other)
        {
            OnHit(other);

            var isActor = other.gameObject.TryGetComponent<Actor>(out var actor);

            if (!isActor)
            {
                return;
            }
            
            var hasAttributesData = actor.TryGetData<AttributesData>(out var data);
            
            if (!hasAttributesData)
            {
                return;
            }
            
            var healthProperty = data.Attributes[Attribute.Health];
            healthProperty.Value -= _damage;
            Destroy(gameObject);
        }
    }
}
