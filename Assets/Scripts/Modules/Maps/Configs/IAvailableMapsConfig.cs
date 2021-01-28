using Modules.Maps.Actors;

namespace Modules.Maps.Configs
{
    public interface IAvailableMapsConfig
    {
        MapActor GetAvailableMap();
    }
}