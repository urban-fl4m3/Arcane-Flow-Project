using System.Collections.Generic;
using System.Linq;
using Modules.SpellSystem.Configs;
using Modules.SpellSystem.Enum;
using NUnit.Framework;
using UnityEngine;

namespace Modules.SpellSystem.Providers
{
    public class SpellProvider : ISpellProvider
    {
        private Dictionary<SpellType, ISpellPreset> _presetsDictionary = new Dictionary<SpellType, ISpellPreset>();

        public SpellProvider(List<SpellPreset> presets)
        {
            foreach (var preset in presets)
            {
                _presetsDictionary.Add(preset.Type, preset);
            }
        }

        public ISpell CreateSpell(SpellType type)
        {
            
            var preset = _presetsDictionary[type];
            
            var spell = new Spell(
                preset.Id,
                preset.Type,
                preset.Actor,
                preset.Tags
            );
            return spell;
        }

        public ISpell CreateDebugSpell()
        {
            return CreateSpell(_presetsDictionary.ElementAt(0).Value.Type);
        }
    }
}