using Modules.SpellSystem.Enum;
using Modules.SpellSystem.Models;
using UnityEngine;

namespace Modules.SpellSystem.Presets
{
    [CreateAssetMenu(fileName = "New AoE Spell", menuName = "Spells/AoE Spell")]
    public class AoeSpellPreset : SpellPreset
    {
        [Header("AoE")]
        [SerializeField] private AreaSelectionContext _selectionContext;
        
        public override SpellType Type => SpellType.AreaSelector;

        public AreaSelectionContext SelectionContext => _selectionContext;
    }
}