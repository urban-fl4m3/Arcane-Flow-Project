using System;
using System.Collections.Generic;
using System.Linq;
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
            foreach (var data in from behaviour in _exposedBehaviours 
                from data in behaviour.Data
                where !_data.Components.ContainsKey(data.GetType())
                select data)
            {
                _data.SetAndInitialize(_owner, Object.Instantiate(data));
            }

            foreach (var behaviour in _exposedBehaviours)
            {
                _behaviours.SetAndInitialize(_owner, Object.Instantiate(behaviour));
            }
        }
        
        public void AddBehaviour<T>(T newBehaviour) where T : BaseBehaviour
        {
            foreach (var data in newBehaviour.Data)
            {
                if (_data.Components.ContainsKey(data.GetType()))
                {
                    continue;
                }

                _data.SetAndInitialize(_owner, Object.Instantiate(data));
            }

            _exposedBehaviours.Add(newBehaviour);
            _behaviours.SetAndInitialize(_owner, newBehaviour);
        }

        public void RemoveBehaviour(Type behaviourType)
        {
            foreach (var behaviour in _exposedBehaviours)
            {
                if (behaviour.GetType() == behaviourType)
                {
                    _exposedBehaviours.Remove(behaviour);
                    break;
                }
            }

            var behaviourInstance = _behaviours.Components[behaviourType];
            behaviourInstance.Dispose();
            _behaviours.Components.Remove(behaviourType);
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