using Modules.Player.Managers;
using UI.Helpers;
using UI.Managers;
using UI.Schemes;

namespace UI.Views.GameHudWindow
{
    public class GameHudScheme : BaseViewScheme
    {
        private readonly IPlayerManager _playerManager;
        public override Scheme SchemeType => Scheme.GameHud;
        
        public GameHudScheme(IViewManager viewManager, IPlayerManager playerManager) : base(viewManager)
        {
            _playerManager = playerManager;
        }
       
        protected override void Behave(ISchemeModelMarkup model)
        {
            _viewManager.AddView(Window.GameHud, new GameHudModel(_playerManager));
        }
    }
}