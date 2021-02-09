using System.Collections.Generic;
using Modules.Actors.Types;
using Modules.SpellSystem.Configs;
using Modules.SpellSystem.Enum;
using Modules.SpellSystem.Models;

namespace Modules.SpellSystem.Base
{
    public abstract class SpellBase : ISpell
    {
        protected readonly ActorBase _actor;
     
        private readonly string _id;
        private readonly SpellType _type;
        private readonly IEnumerable<Tag> _tags;

        protected SpellBase(ISpellPreset preset)
        {
            _id = preset.Id;
            _type = preset.Type;
            _actor = preset.Actor;
            _tags = preset.Tags;

            AnimationContext = preset.AnimationContext;
        }
        
        public string Id { get; }
        public AnimationContext AnimationContext { get; }

        public abstract void Cast(TransformContext context);
    }
}