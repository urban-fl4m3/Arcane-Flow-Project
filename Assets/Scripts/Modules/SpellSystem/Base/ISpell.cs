using Modules.SpellSystem.Models;

namespace Modules.SpellSystem.Base
{
    public interface ISpell
    {
        string Id { get; }
        void Cast(TransformContext context);
        
        AnimationContext AnimationContext { get; }
    }
}