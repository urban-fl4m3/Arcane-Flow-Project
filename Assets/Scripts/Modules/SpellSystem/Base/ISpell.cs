using Modules.SpellSystem.Inputs;
using Modules.SpellSystem.Models;
using Modules.SpellSystem.Presets;

namespace Modules.SpellSystem.Base
{
    public interface ISpell
    {
        string Id { get; }
        void Init(ISpellPreset preset);
        void Cast(TransformContext context);

        ISpellInput GenerateInputs();
        
        AnimationContext AnimationContext { get; }
    }
}