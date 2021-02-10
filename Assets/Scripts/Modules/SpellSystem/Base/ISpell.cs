using Modules.Actors;
using Modules.SpellSystem.Models;
using Modules.SpellSystem.Presets;

namespace Modules.SpellSystem.Base
{
    public interface ISpell
    {
        string Id { get; }
        AnimationContext AnimationContext { get; }
        
        void Init(IActor caster, ISpellPreset preset);
        
        void RaiseSpell(TransformContext context);
        void OnCastStart();
        void OnCastContinue();
        void OnCastEnd();
    }
}