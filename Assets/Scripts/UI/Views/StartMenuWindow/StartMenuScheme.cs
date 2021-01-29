using System;
using Modules.Maps.Configs;
using Modules.Maps.Managers;
using Modules.Render.Managers;
using Modules.SpellSystem.Managers;
using Modules.Ticks.Managers;
using UI.Helpers;
using UI.Managers;
using UI.Schemes;
using UI.Views.GameHudWindow;
using UnityEngine;

namespace UI.Views.StartMenuWindow
{
    public class StartMenuScheme : BaseViewScheme
    {
        private readonly ITickManager _tickManager;
        private readonly ISpellManager _spellManager;
        private readonly ICameraManager _cameraManager;

        public StartMenuScheme(IViewManager viewManager, ITickManager tickManager,
            ISpellManager spellManager, ICameraManager cameraManager) : base(viewManager)
        {
            _tickManager = tickManager;
            _spellManager = spellManager;
            _cameraManager = cameraManager;
        }

        public override Scheme SchemeType => Scheme.StartMenu;
        
        protected override void Behave()
        {
            _viewManager.AddView(Window.StartMenu, new StartMenuModel(HandleStartButtonPressed));
        }

        private void HandleStartButtonPressed(object sender, EventArgs e)
        {
            Cursor.lockState = CursorLockMode.Locked;

            var worldSettings = Resources.Load<WorldSettings>("Maps/Worlds/DefaultWorld");
            var world = new World(_tickManager, _cameraManager, _spellManager, worldSettings);
            world.LoadMap();
            world.RunWorld();
            
            CompleteBehaviour(Scheme.GameHud);
        }
    }
}