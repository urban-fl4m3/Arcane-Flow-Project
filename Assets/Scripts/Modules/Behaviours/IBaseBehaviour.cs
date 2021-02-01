using System.Collections.Generic;
using Modules.Actors;
using Modules.Data;

namespace Modules.Behaviours
{
    public interface IBaseBehaviour : IActorMember
    {
        IEnumerable<BaseData> Data { get; }
        
        void Stop();
        void Resume();
    }
}