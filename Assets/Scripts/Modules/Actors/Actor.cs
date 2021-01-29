using System;
using System.Collections.Generic;
using Generics;
using Modules.Behaviours;
using Modules.Datas;
using Modules.Render.Actors;
using Modules.Ticks.Managers;
using Modules.Ticks.Processors;
using UnityEngine;

namespace Modules.Actors
{
    public abstract class Actor : MonoBehaviour, IActor
    {
        [SerializeField] private Actor _child;
        [SerializeField] private List<BaseBehaviour> _behaviours = new List<BaseBehaviour>();
        [SerializeField] private List<BaseData> _datas = new List<BaseData>();

        private readonly MemberContainer<IBaseBehaviour> _actorBehaviours = new MemberContainer<IBaseBehaviour>();
        private readonly MemberContainer<IBaseData> _actorDatas = new MemberContainer<IBaseData>();

        public event EventHandler OnInitializeComplete;
        
        public ITickManager TickManager { get; private set; }
        public Camera Camera { get; private set; }
        
        public Actor GetChild()
        {
            return _child;
        }

        public void Init(ITickManager tickManager, CameraActor cameraActor)
        {
            InitInternal(tickManager, cameraActor.Component);
        }
        
        public void Init(ITickManager tickManager, Camera mainCamera)
        {
            InitInternal(tickManager, mainCamera);
        }

        /// <summary>
        /// Use only for Reinit
        /// </summary>
        /// <exception cref="MissingMemberException"></exception>
        public void Init()
        {
            if (TickManager == null || Camera == null)
            {
                throw new MissingMemberException($"Can't initialize Actor while Tick processor and camera are null");
            }
            InitInternal(TickManager, Camera);
        }

        private void InitInternal(ITickManager tickManager, Camera mainCamera)
        {
            _actorDatas.Clear();
            _actorBehaviours.Clear();
            
            TickManager = tickManager;
            Camera = mainCamera;
            
            if (_child) _child.Init(tickManager, mainCamera);
            
            foreach (var data in _datas)
            {
                _actorDatas.SetAndInitialize(this, Instantiate(data));
            }
            
            foreach (var behaviour in _behaviours)
            {
                _actorBehaviours.SetAndInitialize(this, Instantiate(behaviour));
            }

            OnInitializeComplete?.Invoke(this, null);
            OnInitializeComplete = null;

            OnAwake();
        }
        

        public GameObject GetGameObject()
        {
            return gameObject;
        }

        public T GetBehaviour<T>() where T : class, IBaseBehaviour
        {
            return _actorBehaviours.GetComponent<T>();
        }

        public T GetData<T>() where T : class, IBaseData
        {
            return _actorDatas.GetComponent<T>();
        }

        public bool TryGetData<T>(out T data) where T : class, IBaseData
        {
            try
            {
                data = GetData<T>();
                return true;
            }
            catch (Exception)
            {
                data = null;
                return false;
            }
        }
        
        public void AddBehaviour<T>(T newBehaviour) where T : BaseBehaviour
        {
            _behaviours.Add(newBehaviour);
            _actorBehaviours.SetAndInitialize(this, newBehaviour);
        }

        public void AddData<T>(T newData) where T : BaseData
        {
            _datas.Add(newData);
            _actorDatas.SetAndInitialize(this, newData);
        }

        public void DestroyActor()
        {
            _actorBehaviours.Clear();
            _actorDatas.Clear();
            
            Destroy(gameObject);
        }

        protected abstract void OnAwake();
    }
}
