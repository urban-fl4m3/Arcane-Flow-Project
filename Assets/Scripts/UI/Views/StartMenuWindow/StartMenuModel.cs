using System;

namespace UI.Views.StartMenuWindow
{
    public class StartMenuModel : ICustomModel
    {
        
        public StartMenuModel(EventHandler<int> startButtonPressed)
        {
            StartButtonPressed = startButtonPressed;
        }

        public readonly EventHandler<int> StartButtonPressed;
    }
}