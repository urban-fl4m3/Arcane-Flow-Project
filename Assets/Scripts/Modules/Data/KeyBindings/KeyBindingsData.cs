using Modules.Actors;
using UnityEngine;

namespace Modules.Data.KeyBindings
{
    [CreateAssetMenu(fileName = "New Binding Data", menuName = "Data/Key bindings")]
    public class KeyBindingsData : BaseData, IKeyBindingsData    
    {
        [SerializeField] private string _horizontalKeyAxis;
        [SerializeField] private string _verticalKeyAxis;
        [SerializeField] private KeyCode _dodge;
        [SerializeField] private KeyCode _attack;

        public string HorizontalKeyAxis() => _horizontalKeyAxis;
        public string VerticalKeyAxis() => _verticalKeyAxis;
        public KeyCode GetDodgeKey() => _dodge;
        public KeyCode GetAttackKey() => _attack;

        protected override void OnInitialize(IActor owner)
        {
            
        }
    }
}