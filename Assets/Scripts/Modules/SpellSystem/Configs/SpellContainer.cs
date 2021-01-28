using System.Collections.Generic;
using Modules.SpellSystem.Enum;
using UnityEngine;

namespace Modules.SpellSystem.Configs
{
    [CreateAssetMenu(fileName = "SpellContainer", menuName = "Spells/Spells Container")]
    public class SpellContainer : ScriptableObject, ISpellContainer
    {
        [SerializeField] private SpellType _debugDefaultSpell;
        [SerializeField] private List<SpellPreset> _presets;

        private Dictionary<SpellType, ISpellPreset> _presetsDictionary;

        public SpellType DebugDefaultType => _debugDefaultSpell;

        public IReadOnlyDictionary<SpellType, ISpellPreset> SpellPresets
        {
            get
            {
                if (_presetsDictionary == null)
                {
                    _presetsDictionary = new Dictionary<SpellType, ISpellPreset>();
                    
                    foreach (var preset in _presets)
                    {
                        _presetsDictionary.Add(preset.Type, preset);
                    }
                }

                return _presetsDictionary;
            }
        }
    }
}