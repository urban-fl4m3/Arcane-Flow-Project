using System.Collections.Generic;
using Modules.Actors.Types;
using Modules.SpellSystem.Enum;
using Modules.SpellSystem.Inputs;
using Modules.SpellSystem.Models;
using Modules.SpellSystem.Presets;

namespace Modules.SpellSystem.Base
{
    public abstract class SpellBase<TSpellPreset> : ISpell where TSpellPreset : ISpellPreset
    {
        protected TSpellPreset _preset { get; private set; }
        protected ActorBase _actor { get; private set; }
        
     
        private string _id;
        private IEnumerable<Tag> _tags;

        public void Init(ISpellPreset preset)
        {
            InitInternal((TSpellPreset)preset);    
        }

        private void InitInternal(TSpellPreset preset)
        {
            _preset = preset;
            
            _id = preset.Id;
            _actor = preset.Actor;
            _tags = preset.Tags;

            AnimationContext = preset.AnimationContext;
            
            OnInitialize(preset);
        }

        public abstract ISpellInput GenerateInputs();
        protected abstract void OnInitialize(TSpellPreset preset);
        
        public string Id { get; }
        public AnimationContext AnimationContext { get; private set; }

        public abstract void Cast(TransformContext context);
    }
}