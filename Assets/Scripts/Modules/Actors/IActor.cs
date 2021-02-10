using System;
using Modules.Behaviours;
using Modules.Data;
using Modules.Render.Actors;
using Modules.Ticks.Managers;
using Modules.Ticks.Processors;
using UnityEngine;

namespace Modules.Actors
{
    public interface IActor
    {
        bool Enabled { get; }
        ITickManager TickManager { get; }
        Camera Camera { get; }
        GameObject Object { get; }
        Actor Child { get; }
        
        void Init(ITickManager tickManager, Camera mainCamera);
        void DestroyActor();
        void Stop();
        void Resume();
        
        TData GetData<TData>() where TData : class, IBaseData;
    }
}