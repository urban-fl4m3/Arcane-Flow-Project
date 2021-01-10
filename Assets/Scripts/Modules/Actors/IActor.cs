using System;
using Modules.Behaviours;
using Modules.Datas;
using UnityEngine;

namespace Modules.Actors
{
    public interface IActor
    {
        event EventHandler OnInitializeComplete;

        void Init();
        
        GameObject GetGameObject();

        Actor GetChild();

        TBehaviour GetBehaviour<TBehaviour>() where TBehaviour : class, IBaseBehaviour;
        TData GetData<TData>() where TData : class, IBaseData;
    }
}