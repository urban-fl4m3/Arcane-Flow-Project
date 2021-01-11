using Modules.Player.Managers;

namespace UI.Views.GameHudWindow
{
    public class GameHudModel : ICustomModel
    {
        public GameHudModel(IPlayerManager playerManager)
        {
            PlayerManager = playerManager;
        }
        
        public IPlayerManager PlayerManager { get; }
    }
}