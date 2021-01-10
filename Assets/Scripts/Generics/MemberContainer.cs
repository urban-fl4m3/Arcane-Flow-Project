using System;
using System.Collections.Generic;
using Modules.Actors;

namespace Generics
{
    public class MemberContainer<TComponent> where TComponent : class, IActorMember
    {
        private readonly Dictionary<Type, TComponent> _components = new Dictionary<Type, TComponent>();

        public T GetComponent<T>() where T : TComponent, IActorMember
        {
            Type t = typeof(T);
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
    }
}