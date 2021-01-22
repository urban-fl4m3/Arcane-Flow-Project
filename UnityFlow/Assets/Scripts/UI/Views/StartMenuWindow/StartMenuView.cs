using System;
using UI.Helpers;
using UI.Views.GameHudWindow;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Views.StartMenuWindow
{
    public class StartMenuView : BaseGenericView<StartMenuModel>
    {
        [SerializeField] private Button _startButton;

        protected override void OnInitialize(StartMenuModel model)
        {
            _startButton.onClick.AddListener(StartButtonPress);
        }

        private void StartButtonPress()
        {
            Model.StartButtonPressed?.Invoke(this, EventArgs.Empty);
            CloseView();
        }

        protected override void Clear()
        {
            _startButton.onClick.RemoveListener(StartButtonPress);
            base.Clear();
        }
    }
}