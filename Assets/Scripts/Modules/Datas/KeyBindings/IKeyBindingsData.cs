using UnityEngine;

namespace Modules.Datas.KeyBindings
{
    public interface IKeyBindingsData
    {
        KeyCode GetForwardKey();
        KeyCode GetBackKey();
        KeyCode GetLeftKey();
        KeyCode GetRightKey();
        KeyCode GetDodgeKey();
        KeyCode GetAttackKey();


        Vector2 GetMovementAxis();
        bool IsMovementButtonHolding();
    }
}