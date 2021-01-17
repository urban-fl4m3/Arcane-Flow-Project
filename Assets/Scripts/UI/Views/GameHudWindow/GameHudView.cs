using Modules.Common;
using Modules.Datas.Attributes;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Views.GameHudWindow
{
    public class GameHudView : BaseGenericView<GameHudModel>
    {
        [SerializeField] private Image _healthBar;

        private DynamicFloat _healthProperty;
        
        protected override void OnInitialize(GameHudModel model)
        {
            var attributesData = model.PlayerManager.PlayerActor.GetData<AttributesData>();
            _healthProperty = attributesData.Attributes[Attribute.Health];
            _healthProperty.PropertyChanged += HandleHealthChanged;
            
            base.OnInitialize(model);
        }

        private void HandleHealthChanged(object sender, float value)
        {
            _healthBar.material.SetFloat("_value", _healthProperty.Percentage());
        }

        protected override void Clear()
        {
            _healthProperty.PropertyChanged -= HandleHealthChanged;
            base.Clear();
        }
    }
}