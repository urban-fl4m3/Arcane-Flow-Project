using System;
using Modules.Behaviours;
using Modules.Datas;
using Modules.Ticks.Managers;
using Modules.Ticks.Processors;
using UnityEngine;

namespace Modules.Actors
{
    public interface IActor
    {
        ITickProcessor TickProcessor { get; }
        event EventHandler OnInitializeComplete;

        void Init(ITickProcessor tickProcessor);
        
        GameObject GetGameObject();

        Actor GetChild();

        TBehaviour GetBehaviour<TBehaviour>() where TBehaviour : class, IBaseBehaviour;
        TData GetData<TData>() where TData : class, IBaseData;
    }
}