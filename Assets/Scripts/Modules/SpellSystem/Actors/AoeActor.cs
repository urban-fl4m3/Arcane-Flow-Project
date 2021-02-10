using System;
using Modules.Actors;
using Modules.Actors.Types;
using Modules.Data.Attributes;
using Modules.SpellSystem.Enum;
using UnityEngine;
using Attribute = Modules.Common.Attribute;

namespace Modules.SpellSystem.Actors
{
    public class AoeActor : ActorBase
    {
#pragma warning disable 67
        public event EventHandler OnCastEventHandler;
#pragma warning restore 67
        public event EventHandler<Collision> OnHitEventHandler;

        public Vector2 minMaxSize;

        private Transform _transform;
        
        private Tag[] _tags;

        private float _startLiveTime = 0.0f;

        private void Start()
        {
            _transform1 = GetComponent<Transform>();
            _startLiveTime = Time.time;
            _transform1.localScale = new Vector3(minMaxSize.x, minMaxSize.x, minMaxSize.x);
        }

        public void Init(Tag[] tags)
        {
            _tags = tags;
        }
        
        protected override void OnAwake()
        {
            _transform = GetComponent<Transform>();
        }
    

        [SerializeField] private float _speed;
        [SerializeField] private float _damage;
        private Transform _transform1;

        private void Update()
        {
            var sizeValue = Mathf.Sin((Time.time - _startLiveTime) * _speed);
        
            if (sizeValue < 0.0f) {
                Destroy(gameObject);
                return;
            }
        
            var newSizeValue = Mathf.Lerp(minMaxSize.x, minMaxSize.y, sizeValue);
            // Debug.Log(newSizeValue);
            Vector3 newSize = new Vector3(newSizeValue, newSizeValue, newSizeValue);
        
            _transform1.localScale = newSize;
        }

        private void OnCollisionEnter(Collision other)
        {
            OnHitEventHandler?.Invoke(this, other);

            var isActor = other.gameObject.TryGetComponent<Actor>(out var actor);

            if (isActor)
            {
                var hasAttributesData = actor.TryGetData<AttributesData>(out var data);
                if (hasAttributesData)
                {
                    var healthProperty = data.Attributes[Attribute.Health];
                    healthProperty.Value -= _damage;
                    Destroy(gameObject);
                }
            }
            
        }
    }
}
