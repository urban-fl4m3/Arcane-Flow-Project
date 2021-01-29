using Modules.Ticks.Managers;

namespace UI.Views.GameHudWindow
{
    public class GameHudModel : ICustomModel
    {
        public GameHudModel(ITickManager tickManager)
        {
            TickManager = tickManager;
        }
        
        public ITickManager TickManager { get; }
    }
}