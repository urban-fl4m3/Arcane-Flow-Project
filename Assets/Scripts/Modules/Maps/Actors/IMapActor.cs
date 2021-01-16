using Modules.Actors;

namespace Modules.Maps.Actors
{
    public interface IMapActor
    {
        void AddPlayer(IActor player);
        void AddEnemy(IActor enemy);
    }
}