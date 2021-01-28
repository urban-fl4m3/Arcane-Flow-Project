using System.Collections.Generic;
using Modules.SpellSystem.Actors;
using Modules.SpellSystem.Enum;
using UnityEngine;

namespace Modules.SpellSystem.Configs
{
    [CreateAssetMenu(fileName = "Custom Spell", menuName = "Spells/New Spell")]
    public class SpellPreset : ScriptableObject, ISpellPreset
    {
        [SerializeField] private string _id;
        [SerializeField] private SpellType _type;
        [SerializeField] private Tag[] _tags;
        [SerializeField] private SpellActor _actor;

        public string Id => _id;
        public SpellType Type => _type;
        public IEnumerable<Tag> Tags => _tags;
        public SpellActor Actor => _actor;
    }
}