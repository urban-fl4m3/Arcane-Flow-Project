using Modules.Actors;

namespace Modules.Player.Configs
{
    public interface IPlayerConfig
    {
        Actor GetActor(int index);
    }
}