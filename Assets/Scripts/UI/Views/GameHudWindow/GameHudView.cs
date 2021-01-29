﻿using System;
using System.Collections;
using Modules.Common;
using Modules.Datas.Attributes;
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
        
        protected override void OnInitialize(GameHudModel model)
        {
            var attributesData = model.PlayerManager.PlayerActor.GetData<AttributesData>();
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
                Model.MapManager.MapReset += HandleLevelRestart;
                
                AddNestedView(_restartPopupView, new RestartPopupModel(Model.MapManager));
                
                _healthProperty.PropertyChanged -= HandleHealthChanged;
            }
        }

        private void HandleLevelRestart(object sender, EventArgs e)
        {
            Model.MapManager.MapReset -= HandleLevelRestart;
            
            var attributesData = Model.PlayerManager.PlayerActor.GetData<AttributesData>();
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