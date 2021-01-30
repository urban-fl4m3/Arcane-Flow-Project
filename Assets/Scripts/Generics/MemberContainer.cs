using System;
using System.Collections.Generic;
using Modules.Actors;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Generics
{
    public class MemberContainer<TComponent> where TComponent : class, IActorMember
    {
        public Dictionary<Type, TComponent> Components => _components;

        private readonly Dictionary<Type, TComponent> _components = new Dictionary<Type, TComponent>();

        public T GetComponent<T>() where T : TComponent, IActorMember
        {
            var t = typeof(T);
            if (!_components.ContainsKey(t))
            {
                throw new ArgumentException($"{ToString()} doesn't have {t.Name}");
            }

            return (T)_components[t];
        }

        public void SetAndInitialize(IActor actor, TComponent actorMember)
        {
            actorMember.Initialize(actor);
            _components.Add(actorMember.GetType(), actorMember);
        }

        public void Clear()
        {
            foreach (var component in _components)
            {
                component.Value.Dispose();
                Object.Destroy(component.Value.Instance);
            }
            
            _components.Clear();
        }
    }
}