using Modules.Actors;
using UnityEngine;

namespace Modules.Datas.KeyBindings
{
    [CreateAssetMenu(fileName = "New Binding Data", menuName = "Data/Key bindings")]
    public class KeyBindingsData : BaseData, IKeyBindingsData    
    {
        [SerializeField] private KeyCode _keyForward;
        [SerializeField] private KeyCode _keyBack;
        [SerializeField] private KeyCode _keyRight;
        [SerializeField] private KeyCode _keyLeft;
        [SerializeField] private KeyCode _dodge;
        [SerializeField] private KeyCode _attack;

        public KeyCode GetForwardKey() => _keyForward;
        public KeyCode GetBackKey() => _keyBack;
        public KeyCode GetLeftKey() => _keyRight;
        public KeyCode GetRightKey() => _keyLeft;
        public KeyCode GetDodgeKey() => _dodge;
        public KeyCode GetAttackKey() => _attack;

        public Vector2 GetMovementAxis()
        {
            Vector2 movementAxis = Vector2.zero;

            if (Input.GetKey(GetForwardKey())) movementAxis += Vector2.up;
            if (Input.GetKey(GetBackKey())) movementAxis += Vector2.down;
            if (Input.GetKey(GetRightKey())) movementAxis += Vector2.right;
            if (Input.GetKey(GetLeftKey())) movementAxis += Vector2.left;

            return movementAxis.normalized;
        }
        
        public bool IsMovementButtonHolding()
        {
            return Input.GetKey(GetForwardKey()) ||
                   Input.GetKey(GetBackKey()) ||
                   Input.GetKey(GetRightKey()) ||
                   Input.GetKey(GetLeftKey());
        }
        
        protected override void OnInitialize(IActor owner)
        {
            
        }
    }
}