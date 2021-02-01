using System.Collections.Generic;
using Modules.Actors.Types;
using Modules.SpellSystem.Actors;
using Modules.SpellSystem.Enum;

namespace Modules.SpellSystem.Configs
{
    public interface ISpellPreset
    {
        string Id { get; }
        SpellType Type { get; }
        IEnumerable<Tag> Tags { get; }
        ActorBase Actor { get; }
    }
}