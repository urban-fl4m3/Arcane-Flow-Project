using Modules.Actors;

namespace Modules.Behaviours
{
    public interface IBaseBehaviour : IActorMember
    {
        void Stop();
        void Resume();
    }
}