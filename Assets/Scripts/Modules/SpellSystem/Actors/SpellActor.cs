using System;
using Modules.Actors.Types;
using Modules.SpellSystem.Enum;
using UnityEngine;

namespace Modules.SpellSystem.Actors
{
    public class SpellActor : ActorBase
    {
        public event EventHandler OnCastEventHandler;
        public event EventHandler OnHitEventHandler;
        
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

        private void Update()
        {
            transform.position += Direction.normalized * (_speed * Time.deltaTime);
        }
    }
}