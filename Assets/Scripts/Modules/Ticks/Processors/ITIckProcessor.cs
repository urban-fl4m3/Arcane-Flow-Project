using System;
using UnityEngine;

namespace Modules.Ticks.Processors
{
    public interface ITickProcessor : IDisposable
    {
        bool IsUpdating { get; set; }
        
        GameObject Processor { get; }
        
        void AddTick(ITickUpdate tick);
        void RemoveTick(ITickUpdate tick);
        
        void AddTick(ITickLateUpdate tick);
        void RemoveTick(ITickLateUpdate tick);
        
        void AddTick(ITickFixedUpdate tick);
        void RemoveTick(ITickFixedUpdate tick);
    }
}