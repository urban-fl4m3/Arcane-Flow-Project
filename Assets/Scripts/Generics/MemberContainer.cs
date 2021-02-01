using System;
using System.Collections.Generic;
using Modules.Actors;

namespace Generics
{
    [Serializable]
    public class MemberContainer<TComponent> where TComponent : class, IActorMember
    {
        public IReadOnlyDictionary<Type, TComponent> Components => _components;
        private readonly Dictionary<Type, TComponent> _components = new Dictionary<Type, TComponent>();
        private readonly Dictionary<Type, int> _componentsCount = new Dictionary<Type, int>();
        
        public T GetComponent<T>() where T : TComponent, IActorMember
        {
            var t = typeof(T);
            if (!_components.ContainsKey(t))
            {
                throw new ArgumentException($"{ToString()} doesn't have {t.Name}");
            }

            return (T)_components[t];
        }

        public bool AddComponent(IActor actor, TComponent actorMember)
        {
            var memberType = actorMember.GetType();
            
            if (_componentsCount.ContainsKey(memberType))
            {
                _componentsCount[memberType]++;
                return false;
            }
            
            actorMember.Initialize(actor);
            _components.Add(memberType, actorMember);
            _componentsCount.Add(memberType, 1);

            return true;
        }

        public bool RemoveComponent(Type type)
        {
            if (!_componentsCount.ContainsKey(type))
            {
                return false;
            }
            
            _componentsCount[type]--;

            if (_componentsCount[type] > 0)
            {
                return false;
            }
            
            var instance = Components[type];
            instance.Dispose();
            _components.Remove(type);
            _componentsCount.Remove(type);

            return true;
        }

        public void Clear()
        {
            foreach (var component in _components)
            {
                component.Value.Dispose();
            }
            
            _components.Clear();
            _componentsCount.Clear();
        }
    }
}