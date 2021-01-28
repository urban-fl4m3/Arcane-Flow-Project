using System.Collections.Generic;
using Modules.SpellSystem.Actors;
using Modules.SpellSystem.Enum;

namespace Modules.SpellSystem.Configs
{
    public interface ISpellPreset
    {
        string Id { get; }
        SpellType Type { get; }
        IEnumerable<Tag> Tags { get; }
        SpellActor Actor { get; }
    }
}