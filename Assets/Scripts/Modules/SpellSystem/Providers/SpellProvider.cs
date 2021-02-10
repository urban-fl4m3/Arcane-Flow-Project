using System.Collections.Generic;
using System.Linq;
using Modules.SpellSystem.Base;
using Modules.SpellSystem.Configs;
using Modules.SpellSystem.Enum;
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

        public static ISpell CreateSpell(string ID)
        {
            var preset = _presetsDictionary[ID];
            
            switch (preset.Type)
            {
                case SpellType.PointAndClick:
                    return new PointAndClickSpell(preset);
                case SpellType.AreaSelector:
                    return new AoeSpell(preset);
            }

            return null;
        }
    }
}