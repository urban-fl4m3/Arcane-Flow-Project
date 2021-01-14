using System.Collections.Generic;
using Modules.SpellSystem.Enum;
using UnityEngine;

namespace Modules.SpellSystem.Configs
{
    [CreateAssetMenu(fileName = "SpellContainer", menuName = "Spells/Spells Container")]
    public class SpellContainer : ScriptableObject, ISpellContainer, ISerializationCallbackReceiver
    {
        [SerializeField] private SpellType _debugDefaultSpell;
        [SerializeField] private List<SpellPreset> _presets;

        private Dictionary<SpellType, ISpellPreset> _presetsDictionary;
        
        public void OnBeforeSerialize()
        {
            _presetsDictionary = new Dictionary<SpellType, ISpellPreset>();

            foreach (var preset in _presets)
            {
                _presetsDictionary.Add(preset.Type, preset);
            }
        }

        public void OnAfterDeserialize()
        {
        }

        public SpellType DebugDefaultType => _debugDefaultSpell;
        public IReadOnlyDictionary<SpellType, ISpellPreset> SpellPresets => _presetsDictionary;
    }
}