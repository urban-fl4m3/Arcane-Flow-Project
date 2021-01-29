using System;
using UnityEngine;

namespace Modules.Actors
{
    public interface IActorMember : IDisposable
    {
        IActor Owner { get; }
        ScriptableObject Instance { get; }

        void Initialize(IActor owner);
    }
}