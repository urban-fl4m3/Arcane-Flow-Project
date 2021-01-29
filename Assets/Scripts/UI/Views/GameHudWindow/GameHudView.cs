using System;
using System.Collections;
using Modules.Common;
using Modules.Datas.Attributes;
using Modules.Maps.Managers;
using Modules.Player.Managers;
using UI.Views.RestartPopupWindow;
using UnityEngine;
using UnityEngine.UI;
using Attribute = Modules.Common.Attribute;

namespace UI.Views.GameHudWindow
{
    public class GameHudView : BaseGenericView<GameHudModel>
    {
        [SerializeField] private float _deltaDelay;
        [SerializeField] private Image _healthBar;
        [SerializeField] private RestartPopupView _restartPopupView;
        
        private float _lastValue;
        private DynamicFloat _healthProperty;
        private Coroutine _healthBarUpdate;

        private World _world;
        
        protected override void OnInitialize(GameHudModel model)
        {
            _world = World.CurrentInstance;
            
            var attributesData = _world.ResolveManager<PlayerManager>().PlayerActor.GetData<AttributesData>();
            _healthProperty = attributesData.Attributes[Attribute.Health];
            _healthProperty.PropertyChanged += HandleHealthChanged;
            
            _healthBar.material.SetFloat("_value", _healthProperty.Percentage());
            _healthBarUpdate = StartCoroutine(UpdateHealthBar());
        }

        private void HandleHealthChanged(object sender, float value)
        {
            _healthBar.material.SetFloat("_value", _healthProperty.Percentage());

            if (value <= 0)
            {
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

            _lastValue = _healthProperty.Value;
            _healthBar.material.SetFloat("_value", _healthProperty.Percentage());
            _healthBarUpdate = StartCoroutine(UpdateHealthBar());
        }

        private IEnumerator UpdateHealthBar()
        {
            while (true)
            {
                _lastValue = Mathf.Lerp(_lastValue, _healthProperty.Percentage(), _deltaDelay);
                _healthBar.material.SetFloat("_value", _healthProperty.Percentage());
                _healthBar.material.SetFloat("_delta", _lastValue);
                yield return null;
            }
        }

        protected override void Clear()
        {
            StopCoroutine(_healthBarUpdate);
            _healthProperty.PropertyChanged -= HandleHealthChanged;
            base.Clear();
        }
    }
}