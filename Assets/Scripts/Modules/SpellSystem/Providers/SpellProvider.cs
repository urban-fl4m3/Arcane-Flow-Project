using System.Collections.Generic;
using System.Linq;
using Modules.Actors;
using Modules.SpellSystem.Base;
using Modules.SpellSystem.Enum;
using Modules.SpellSystem.Presets;
using UnityEngine;

namespace Modules.SpellSystem.Providers
{
    public static class SpellProvider
    {
        private static readonly Dictionary<string, ISpellPreset> _presetsDictionary = new Dictionary<string, ISpellPreset>();

        static SpellProvider()
        {
            var presets = Resources.LoadAll<SpellPreset>("Spells").ToList();
            foreach (var preset in presets)
            {
                _presetsDictionary.Add(preset.Id, preset);
            }
        }

        public static ISpell CreateSpell(IActor caster, string ID)
        {
            var preset = _presetsDictionary[ID];

            ISpell spell = null;

            switch (preset.Type)
            {
                case SpellType.PointAndClick:
                {
                    spell = new ProjectileSpell();
                    break;
                }
                case SpellType.AreaSelector:
                {
                    spell = new AoeSpell();
                    break;
                }
            }

            spell?.Init(caster, preset);
            return spell;
        }
    }
}