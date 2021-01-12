﻿using System;
using System.Collections.Generic;
using Generics;
using Modules.Behaviours;
using Modules.Datas;
using Modules.Render.Actors;
using Modules.Ticks.Processors;
using UnityEngine;
using UnityEngine.Profiling;

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
        
        public ITickProcessor TickProcessor { get; private set; }
        public Camera Camera { get; private set; }
        
        public Actor GetChild()
        {
            return _child;
        }

        public void Init(ITickProcessor tickProcessor, CameraActor mainCamera)
        {
            TickProcessor = tickProcessor;
            Camera = mainCamera.Component;
            
            if (_child) _child.Init(tickProcessor, mainCamera);
            
            //PRE
            //if (_child) _child.PreInitialize();

            foreach (var data in _datas)
            {
                _actorDatas.SetAndInitialize(this, Instantiate(data));
            }
            
            OnAwake();
            //POST
            //if (_child) _child.PostInitialize();
            
            foreach (var behaviour in _behaviours)
            {
                _actorBehaviours.SetAndInitialize(this, Instantiate(behaviour));
            }

            OnInitializeComplete?.Invoke(this, null);
            OnInitializeComplete = null;

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

        public void AddData<T>(T newData) where T : class, IBaseData
        {
            _actorDatas.SetAndInitialize(this, newData);
        }

        protected abstract void OnAwake();
    }
}
