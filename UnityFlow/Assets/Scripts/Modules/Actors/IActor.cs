using System;
using Modules.Behaviours;
using Modules.Datas;
using Modules.Render.Actors;
using Modules.Ticks.Processors;
using UnityEngine;

namespace Modules.Actors
{
    public interface IActor
    {
        event EventHandler OnInitializeComplete;

        ITickProcessor TickProcessor { get; }
        Camera Camera { get; }
        
        void Init(ITickProcessor tickProcessor, CameraActor mainCamera);
        
        GameObject GetGameObject();

        Actor GetChild();

        TBehaviour GetBehaviour<TBehaviour>() where TBehaviour : class, IBaseBehaviour;
        TData GetData<TData>() where TData : class, IBaseData;
    }
}