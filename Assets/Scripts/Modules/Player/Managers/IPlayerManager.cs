using System;
using Modules.Actors;

namespace Modules.Player.Managers
{
    public interface IPlayerManager
    {
        event EventHandler<IActor> PlayerActorSpawned;

        void Init();
    }
}