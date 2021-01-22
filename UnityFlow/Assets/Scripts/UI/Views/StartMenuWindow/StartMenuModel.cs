using System;

namespace UI.Views.StartMenuWindow
{
    public class StartMenuModel : ICustomModel
    {
        
        public StartMenuModel(EventHandler startButtonPressed)
        {
            StartButtonPressed = startButtonPressed;
        }

        public readonly EventHandler StartButtonPressed;
    }
}