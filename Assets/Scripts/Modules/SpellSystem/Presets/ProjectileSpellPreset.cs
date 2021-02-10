using Modules.SpellSystem.Enum;
using UnityEngine;

namespace Modules.SpellSystem.Presets
{
    [CreateAssetMenu(fileName = "New Projectile Spell", menuName = "Spells/Projectile Spell")]
    public class ProjectileSpellPreset : SpellPreset
    {
        public override SpellType Type => SpellType.PointAndClick;
    }
}