using System;
using System.Collections.Generic;
using System.Linq;
using Generics;
using Modules.Behaviours;
using Modules.Data;
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
        
        public void InitializeComponents(IActor owner, Action postDataInitCallback)
        {
            _owner = owner;
        
            foreach (var behaviour in _exposedBehaviours)
            {
                InitializeBehaviourData(behaviour.Data);
            }
            
            postDataInitCallback?.Invoke();

            foreach (var behaviour in _exposedBehaviours)
            {
                _behaviours.AddComponent(_owner, Object.Instantiate(behaviour));
            }
        }
        
        public void AddBehaviour<T>(T newBehaviour) where T : BaseBehaviour
        {
            InitializeBehaviourData(newBehaviour.Data);

            _exposedBehaviours.Add(newBehaviour);
            _behaviours.AddComponent(_owner, newBehaviour);
        }

        private void InitializeBehaviourData(IEnumerable<BaseData> dataCollection)
        {
            foreach (var data in dataCollection)
            {
                _data.AddComponent(_owner, Object.Instantiate(data));
            }
        }

        public void RemoveBehaviour(Type behaviourType)
        {
            var succeed = _behaviours.RemoveComponent(behaviourType);

            if (!succeed) return;
            foreach (var behaviour in _exposedBehaviours.Where(behaviour => behaviour.GetType() == behaviourType))
            {
                foreach (var data in behaviour.Data)
                {
                    _data.RemoveComponent(data.GetType());
                }
                
                _exposedBehaviours.Remove(behaviour);
                break;
            }
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