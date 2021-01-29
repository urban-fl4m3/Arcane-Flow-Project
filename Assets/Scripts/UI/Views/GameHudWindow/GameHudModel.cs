using Modules.Maps.Managers;
using Modules.Player.Managers;

namespace UI.Views.GameHudWindow
{
    public class GameHudModel : ICustomModel
    {
        public GameHudModel(IPlayerManager playerManager, IMapManager mapManager)
        {
            PlayerManager = playerManager;
            MapManager = mapManager;
        }
        
        public IPlayerManager PlayerManager { get; }
        public IMapManager MapManager { get; }
    }
}