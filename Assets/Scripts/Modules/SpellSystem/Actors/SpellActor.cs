using System;
using Modules.Actors;
using Modules.Actors.Types;
using Modules.Datas.Attributes;
using Modules.SpellSystem.Enum;
using UnityEngine;
using Attribute = Modules.Common.Attribute;

namespace Modules.SpellSystem.Actors
{
    public class SpellActor : ActorBase
    {
        public event EventHandler OnCastEventHandler;
        public event EventHandler<Collision> OnHitEventHandler;
        
        private Tag[] _tags;
        
        public void Init(Tag[] tags)
        {
            _tags = tags;
        }
        
        protected override void OnAwake()
        {
            
        }

        public Vector3 Direction { get; set; }

        [SerializeField] private float _speed;
        [SerializeField] private float _damage;

        private void Update()
        {
            transform.position += Direction.normalized * (_speed * Time.deltaTime);
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
                }
            }
            
            Destroy(gameObject);
        }
    }
}