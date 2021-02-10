using Modules.SpellSystem.Enum;
using UnityEngine;

namespace Modules.SpellSystem.Presets
{
    [CreateAssetMenu(fileName = "New AoE Spell", menuName = "Spells/AoE Spell")]
    public class AoeSpellPreset : SpellPreset
    {
        public override SpellType Type => SpellType.AreaSelector;
    }
}