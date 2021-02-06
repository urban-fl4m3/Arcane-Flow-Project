using Modules.Actors;
using UnityEngine;

namespace Modules.Data.KeyBindings
{
    [CreateAssetMenu(fileName = "New Binding Data", menuName = "Data/Key bindings")]
    public class KeyBindingsData : BaseData    
    {
        [SerializeField] private string _horizontalKeyAxis;
        [SerializeField] private string _verticalKeyAxis;
        [SerializeField] private KeyCode _attack;

        public string HorizontalKeyAxis => _horizontalKeyAxis;
        public string VerticalKeyAxis => _verticalKeyAxis;
        public KeyCode AttackKey => _attack;

        protected override void OnInitialize(IActor owner)
        {
            
        }
    }
}