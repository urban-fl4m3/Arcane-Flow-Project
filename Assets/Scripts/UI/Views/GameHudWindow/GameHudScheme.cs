using Modules.Ticks.Managers;
using UI.Helpers;
using UI.Managers;
using UI.Schemes;

namespace UI.Views.GameHudWindow
{
    public class GameHudScheme : BaseViewScheme
    {
        private readonly ITickManager _tickManager;
        
        public override Scheme SchemeType => Scheme.GameHud;
        
        public GameHudScheme(IViewManager viewManager, ITickManager tickManager) : base(viewManager)
        {
            _tickManager = tickManager;
        }
       
        protected override void Behave()
        {
            _viewManager.AddView(Window.GameHud, new GameHudModel(_tickManager));
        }
    }
}