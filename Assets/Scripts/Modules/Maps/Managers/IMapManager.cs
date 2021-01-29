using System;

namespace Modules.Maps.Managers
{
    public interface IMapManager
    {
        event EventHandler MapReset;
        
        void LoadMap();
        void RunGameRoom();
        void RestartGameRoom();
    }
}