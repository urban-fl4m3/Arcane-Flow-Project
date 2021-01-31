using System;
using System.Collections.Generic;
using Modules.Behaviours;
using Modules.Datas;
using Modules.Render.Actors;
using Modules.Ticks.Managers;
using UnityEngine;

namespace Modules.Actors
{
    public abstract class Actor : MonoBehaviour, IActor
    {
        [SerializeField] private Actor _child;
        [SerializeField] private List<BaseBehaviour> _behaviours = new List<BaseBehaviour>();
        [SerializeField] private List<BaseData> _datas = new List<BaseData>();

        [SerializeField] private ActorComponents _components;

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
            _components.Clear();
            
            TickManager = tickManager;
            Camera = mainCamera;
            
            if (_child) _child.Init(tickManager, mainCamera);
            
            _components.SetOwner(this);
            _components.AddExposedData();

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
            return _components.GetBehaviour<T>();
        }

        public T GetData<T>() where T : class, IBaseData
        {
            return _components.GetData<T>();
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
            _components.AddBehaviour(newBehaviour);
        }
        
        public void DestroyActor()
        {
            _components.Clear();
            
            Destroy(gameObject);
        }

        public virtual void Stop()
        {
            foreach (var behaviour in _components.GetAllBehaviours())
            {
                behaviour.Value.Stop();
            }
        }

        public virtual void Resume()
        {
            foreach (var behaviour in _components.GetAllBehaviours())
            {
                behaviour.Value.Resume();
            }
        }

        protected abstract void OnAwake();
    }
}
