using System;
using Modules.Maps.Managers;
using UI.Helpers;
using UI.Managers;
using UI.Schemes;
using UI.Views.GameHudWindow;
using UnityEngine;

namespace UI.Views.StartMenuWindow
{
    public class StartMenuScheme : BaseViewScheme
    {
        private readonly IMapManager _mapManager;

        public StartMenuScheme(IViewManager viewManager, IMapManager mapManager) : base(viewManager)
        {
            _mapManager = mapManager;
        }

        public override Scheme SchemeType => Scheme.StartMenu;
        
        protected override void Behave(ISchemeModelMarkup model)
        {
            _viewManager.AddView(Window.StartMenu, new StartMenuModel(HandleStartButtonPressed));
        }

        private void HandleStartButtonPressed(object sender, EventArgs e)
        {
            Cursor.lockState = CursorLockMode.Locked;
            _mapManager.LoadMap();
            _mapManager.RunGameRoom();
            
            CompleteBehaviour(Scheme.GameHud, new GameHudSchemeModel());
        }
    }
}