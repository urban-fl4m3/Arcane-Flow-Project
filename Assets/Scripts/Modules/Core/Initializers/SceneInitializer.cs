using Modules.Logger;
using Modules.Maps.Managers;
using Modules.Player.Managers;
using Modules.Render.Managers;
using UI.Helpers;
using UI.Managers;
using UI.Views.StartMenuWindow;
using ILogger = Modules.Logger.ILogger;

namespace Modules.Core.Initializers
{
    public class SceneInitializer
    {
        private readonly IViewSchemeManager _schemeManager;

        private ILogger _logger;
        
        public SceneInitializer(IViewSchemeManager schemeManager)
        {
            _schemeManager = schemeManager;
        }

        public void Init()
        {
            _schemeManager.AddScheme(Scheme.StartMenu, new StartMenuSchemeModel());
        }
    }
}