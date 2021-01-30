using System;
using Modules.Common;
using Modules.Datas.Attributes;
using Modules.Maps.Managers;
using Modules.Player.Managers;
using UI.Views.RestartPopupWindow;
using UnityEngine;
using Attribute = Modules.Common.Attribute;

namespace UI.Views.GameHudWindow
{
    public class GameHudView : BaseGenericView<GameHudModel>
    {
        [SerializeField] private UiBarComponent _bar;
        [SerializeField] private RestartPopupView _restartPopupView;
        
        private DynamicFloat _healthProperty;
        private World _world;
        
        protected override void OnInitialize(GameHudModel model)
        {
            _world = World.CurrentInstance;
            
            var attributesData = _world.ResolveManager<PlayerManager>().PlayerActor.GetData<AttributesData>();
            _healthProperty = attributesData.Attributes[Attribute.Health];
            
            _healthProperty.PropertyChanged += HandleHealthChanged;
         
            _bar.Init(_healthProperty);
            Model.TickManager.AddTick(this, _bar);
        }

        private void HandleHealthChanged(object sender, float value)
        {
            if (value <= 0)
            {
                Model.TickManager.AddTick(this, _bar);
                
                Cursor.lockState = CursorLockMode.None;
                _world.MapReset += HandleLevelRestart;
                
                AddNestedView(_restartPopupView, new RestartPopupModel());
                _world.Stop();
                _healthProperty.PropertyChanged -= HandleHealthChanged;
            }
        }

        private void HandleLevelRestart(object sender, EventArgs e)
        {
            _world.MapReset -= HandleLevelRestart;
            
            var attributesData = _world.ResolveManager<PlayerManager>().PlayerActor.GetData<AttributesData>();
            _healthProperty = attributesData.Attributes[Attribute.Health];
            _healthProperty.PropertyChanged += HandleHealthChanged;

            _bar.Init(_healthProperty);
        }

        protected override void Clear()
        {
            _healthProperty.PropertyChanged -= HandleHealthChanged;
            Model.TickManager.RemoveTick(_bar);
            base.Clear();
        }
    }
}