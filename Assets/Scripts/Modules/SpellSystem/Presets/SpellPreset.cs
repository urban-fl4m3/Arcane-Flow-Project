using System.Collections.Generic;
using Modules.Actors.Types;
using Modules.SpellSystem.Enum;
using Modules.SpellSystem.Models;
using UnityEngine;

namespace Modules.SpellSystem.Presets
{
    [CreateAssetMenu(fileName = "New Custom Spell", menuName = "Spells/Custom Spell")]
    public class SpellPreset : ScriptableObject, ISpellPreset
    {
        [SerializeField] private string _id;
        [SerializeField] private Tag[] _tags;
        [SerializeField] private ActorBase _actor;

        [Header("Contexts")] 
        [SerializeField] private AnimationContext _animationContext;
        
        public string Id => _id;
        public IEnumerable<Tag> Tags => _tags;
        public ActorBase Actor => _actor;
        public virtual SpellType Type => SpellType.None;

        public AnimationContext AnimationContext => _animationContext;
    }
}