using System;
using Modules.Actors;
using Modules.Data.Attributes;
using Modules.SpellSystem.Enum;
using UnityEngine;
using Attribute = Modules.Common.Attribute;

namespace Modules.SpellSystem.Actors
{
    public class ProjectileActor : SpellActor
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _damage;
        
        public Vector3 Direction { get; set; }
        
        private void Update()
        {
            transform.position += Direction.normalized * (_speed * Time.deltaTime);
        }

        private void OnCollisionEnter(Collision other)
        {
            OnHit(other);

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