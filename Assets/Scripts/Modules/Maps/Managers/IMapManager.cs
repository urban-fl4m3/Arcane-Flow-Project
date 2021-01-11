using System;

namespace Modules.Maps.Managers
{
    public interface IMapManager
    {
        event EventHandler OnMapLoaded;
        void LoadMap();
    }
}