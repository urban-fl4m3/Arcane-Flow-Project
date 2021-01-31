using System;
using System.Collections.Generic;
using Generics;
using Modules.Behaviours;
using Modules.Datas;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Modules.Actors
{
    [Serializable]
    public class ActorComponents
    {
        [SerializeField] private List<BaseBehaviour> _exposedBehaviours = new List<BaseBehaviour>();
        
        private readonly MemberContainer<IBaseBehaviour> _behaviours = new MemberContainer<IBaseBehaviour>();
        private readonly MemberContainer<IBaseData> _data = new MemberContainer<IBaseData>();

        private IActor _owner;
        
        public void SetOwner(IActor owner)
        {
            _owner = owner;
        }
        
        public void AddExposedData()
        {
            foreach (var behaviour in _exposedBehaviours)
            {
                _behaviours.SetAndInitialize(_owner, Object.Instantiate(behaviour));
            }
        }
        
        public void AddBehaviour<T>(T newBehaviour) where T : BaseBehaviour
        {
            _exposedBehaviours.Add(newBehaviour);
            _behaviours.SetAndInitialize(_owner, newBehaviour);
        }
        
        public T GetBehaviour<T>() where T : class, IBaseBehaviour
        {
            return _behaviours.GetComponent<T>();
        }

        public T GetData<T>() where T : class, IBaseData
        {
            return _data.GetComponent<T>();
        }

        public IReadOnlyDictionary<Type, IBaseBehaviour> GetAllBehaviours()
        {
            return _behaviours.Components;
        }

        public void Clear()
        {
            _behaviours.Clear();
            _data.Clear();
        }
    }
}