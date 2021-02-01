using UnityEngine;

namespace Modules.Data.KeyBindings
{
    public interface IKeyBindingsData
    {
        string HorizontalKeyAxis();
        string VerticalKeyAxis();
        KeyCode GetDodgeKey();
        KeyCode GetAttackKey();
    }
}