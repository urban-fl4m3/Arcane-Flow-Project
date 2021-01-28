using UnityEngine;

namespace Modules.Datas.KeyBindings
{
    public interface IKeyBindingsData
    {
        string HorizontalKeyAxis();
        string VerticalKeyAxis();
        KeyCode GetDodgeKey();
        KeyCode GetAttackKey();
    }
}