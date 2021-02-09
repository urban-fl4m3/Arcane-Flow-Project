using System.Collections.Generic;
using Modules.Actors.Types;
using Modules.SpellSystem.Enum;
using Modules.SpellSystem.Models;
using UnityEngine;

namespace Modules.SpellSystem.Configs
{
    [CreateAssetMenu(fileName = "Custom Spell", menuName = "Spells/New Spell")]
    public class SpellPreset : ScriptableObject, ISpellPreset
    {
        [SerializeField] private string _id;
        [SerializeField] private SpellType _type;
        [SerializeField] private Tag[] _tags;
        [SerializeField] private ActorBase _actor;

        [Header("Contexts")] 
        [SerializeField] private AnimationContext _animationContext;
        
        public string Id => _id;
        public SpellType Type => _type;
        public IEnumerable<Tag> Tags => _tags;
        public ActorBase Actor => _actor;

        public AnimationContext AnimationContext => _animationContext;
    }
}