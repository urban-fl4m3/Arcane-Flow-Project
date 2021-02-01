using System.Collections.Generic;
using System.Linq;
using Modules.SpellSystem.Configs;
using Modules.SpellSystem.Enum;
using NUnit.Framework;
using UnityEngine;

namespace Modules.SpellSystem.Providers
{
    public static class SpellProvider
    {
        private static readonly Dictionary<string, ISpellPreset> _presetsDictionary = new Dictionary<string, ISpellPreset>();

        static SpellProvider()
        {
            List<SpellPreset> presets = Resources.LoadAll<SpellPreset>("Spells").ToList();
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
                case SpellType.Projectile:
                    return new ProjectileSpell(
                        preset.Id,
                        preset.Type,
                        preset.Actor,
                        preset.Tags
                    );
                case SpellType.AOE:
                    return new AoeSpell(
                        preset.Id,
                        preset.Type,
                        preset.Actor,
                        preset.Tags
                        );

            }

            return null;
        }
    }
}