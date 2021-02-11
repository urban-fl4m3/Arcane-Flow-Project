using System;
using UI.Helpers;
using UI.Views.GameHudWindow;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Views.StartMenuWindow
{
    public class StartMenuView : BaseGenericView<StartMenuModel>
    {
        [SerializeField] private Button _startButton2D;
        [SerializeField] private Button _startButton3D;

        protected override void OnInitialize(StartMenuModel model)
        {
            _startButton2D.onClick.AddListener(StartButtonPress2D);
            _startButton3D.onClick.AddListener(StartButtonPress3D);
        }

        private void StartButtonPress2D()
        {
            Model.StartButtonPressed?.Invoke(this, 0);
            CloseView();
        }
        private void StartButtonPress3D()
        {
            Model.StartButtonPressed?.Invoke(this, 1);
            CloseView();
        }

        protected override void Clear()
        {
            _startButton2D.onClick.RemoveListener(StartButtonPress2D);
            _startButton3D.onClick.RemoveListener(StartButtonPress3D);
            base.Clear();
        }
    }
}