using Modules.SpellSystem.Inputs;
using Modules.SpellSystem.Models;

namespace Modules.SpellSystem.Base
{
    public interface ISpell
    {
        string Id { get; }
        ISpellInput SpellInput { get; }
        
        AnimationContext AnimationContext { get; }
    }
}