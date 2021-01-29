using UnityEngine;
using UnityEngine.UI;

namespace UI.Views.RestartPopupWindow
{
    public class RestartPopupView : BaseGenericView<RestartPopupModel>
    {
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _toMainMenuButton;
        
        protected override void OnInitialize(RestartPopupModel model)
        {
            _restartButton.onClick.AddListener(RestartButtonPressed);
        }

        private void RestartButtonPressed()
        {
            Model.MapManager.RestartGameRoom();
            CloseView();
        }

        protected override void Clear()
        {
            base.Clear();
            _restartButton.onClick.RemoveListener(RestartButtonPressed);
        }
    }
}