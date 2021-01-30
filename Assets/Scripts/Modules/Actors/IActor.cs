using System;
using Modules.Behaviours;
using Modules.Datas;
using Modules.Render.Actors;
using Modules.Ticks.Managers;
using Modules.Ticks.Processors;
using UnityEngine;

namespace Modules.Actors
{
    public interface IActor
    {
        event EventHandler OnInitializeComplete;

        ITickManager TickManager { get; }
        Camera Camera { get; }
        
        void Init(ITickManager tickManager, CameraActor mainCamera);
        void Init(ITickManager tickManager, Camera mainCamera);
        void Init();
        void DestroyActor();
        
        GameObject GetGameObject();

        Actor GetChild();

        void Stop();
        void Resume();

        TBehaviour GetBehaviour<TBehaviour>() where TBehaviour : class, IBaseBehaviour;
        TData GetData<TData>() where TData : class, IBaseData;
    }
}