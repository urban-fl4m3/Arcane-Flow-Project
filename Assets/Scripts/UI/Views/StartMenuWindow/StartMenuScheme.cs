using System;
using Modules.Maps.Configs;
using Modules.Maps.Managers;
using Modules.Render.Managers;
using Modules.Ticks.Managers;
using UI.Helpers;
using UI.Managers;
using UI.Schemes;
using UnityEngine;

namespace UI.Views.StartMenuWindow
{
    public class StartMenuScheme : BaseViewScheme
    {
        private readonly ITickManager _tickManager;
        private readonly ICameraManager _cameraManager;

        public StartMenuScheme(IViewManager viewManager, ITickManager tickManager, ICameraManager cameraManager) : base(viewManager)
        {
            _tickManager = tickManager;
            _cameraManager = cameraManager;
        }

        public override Scheme SchemeType => Scheme.StartMenu;
        
        protected override void Behave()
        {
            _viewManager.AddView(Window.StartMenu, new StartMenuModel(HandleStartButtonPressed));
        }

        private void HandleStartButtonPressed(object sender, int state)
        {
            _cameraManager.SetState(state);
            var worldSettings = Resources.Load<WorldSettings>("Maps/Worlds/DefaultWorld");
            var world = new World(_tickManager, _cameraManager, worldSettings);
            world.LoadMap();
            world.RunWorld(state);

            CompleteBehaviour(Scheme.GameHud);
        }
    }
}