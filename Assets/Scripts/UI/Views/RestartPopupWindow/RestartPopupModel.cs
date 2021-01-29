using Modules.Maps.Managers;

namespace UI.Views.RestartPopupWindow
{
    public class RestartPopupModel : ICustomModel
    {
        public RestartPopupModel(IMapManager mapManager)
        {
            MapManager = mapManager;
        }
        
        public IMapManager MapManager { get; }
    }
}