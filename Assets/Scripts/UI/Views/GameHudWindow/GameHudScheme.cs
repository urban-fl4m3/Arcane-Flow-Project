using UI.Helpers;
using UI.Managers;
using UI.Schemes;

namespace UI.Views.GameHudWindow
{
    public class GameHudScheme : BaseViewScheme
    {
        public override Scheme SchemeType => Scheme.GameHud;
        
        public GameHudScheme(IViewManager viewManager) : base(viewManager)
        {
            
        }
       
        protected override void Behave(ISchemeModelMarkup model)
        {
            _viewManager.AddView(Window.GameHud, new GameHudModel());
        }
    }
}