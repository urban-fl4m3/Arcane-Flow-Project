using System.Collections.Generic;
using Modules.Actors;
using Modules.Actors.Types;
using Modules.SpellSystem.Enum;
using Modules.SpellSystem.Models;
using Modules.SpellSystem.Presets;

namespace Modules.SpellSystem.Base
{
    public abstract class SpellBase<TSpellPreset, TActor> : ISpell 
        where TSpellPreset : ISpellPreset
        where TActor : ActorBase
    {
        protected TSpellPreset _preset { get; private set; }
        protected TActor _actor { get; private set; }
        protected IActor _owner { get; private set; }

        private string _id;
        private IEnumerable<Tag> _tags;

        public void Init(IActor caster, ISpellPreset preset)
        {
            _owner = caster;
            InitInternal((TSpellPreset)preset);    
        }

        private void InitInternal(TSpellPreset preset)
        {
            _preset = preset;
            _id = preset.Id;
            _tags = preset.Tags;
            _actor = (TActor)preset.Actor;

            AnimationContext = preset.AnimationContext;
            
            OnInitialize();
        }
        
        protected abstract void OnInitialize();
        
        public string Id { get; }
        public AnimationContext AnimationContext { get; private set; }

        public abstract void RaiseSpell(TransformContext context);
        public abstract void OnCastStart();
        public abstract void OnCastContinue();
        public abstract void OnCastEnd();
    }
}