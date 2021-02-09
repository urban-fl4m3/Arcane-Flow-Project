using System.Collections.Generic;
using Modules.Actors.Types;
using Modules.SpellSystem.Enum;
using Modules.SpellSystem.Models;

namespace Modules.SpellSystem.Configs
{
    public interface ISpellPreset
    {
        string Id { get; }
        SpellType Type { get; }
        IEnumerable<Tag> Tags { get; }
        ActorBase Actor { get; }
        
        AnimationContext AnimationContext { get; }
    }
}