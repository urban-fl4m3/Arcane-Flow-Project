using Modules.Maps.Managers;
using Modules.Player.Managers;
using UI.Helpers;
using UI.Managers;
using UI.Schemes;

namespace UI.Views.GameHudWindow
{
    public class GameHudScheme : BaseViewScheme
    {
        private readonly IPlayerManager _playerManager;
        private readonly IMapManager _mapManager;
        
        public override Scheme SchemeType => Scheme.GameHud;
        
        public GameHudScheme(IViewManager viewManager, IPlayerManager playerManager,
            IMapManager mapManager) : base(viewManager)
        {
            _playerManager = playerManager;
            _mapManager = mapManager;
        }
       
        protected override void Behave(ISchemeModelMarkup model)
        {
            _viewManager.AddView(Window.GameHud, new GameHudModel(_playerManager, _mapManager));
        }
    }
}