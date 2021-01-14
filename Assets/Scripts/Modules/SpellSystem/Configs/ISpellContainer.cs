using System.Collections.Generic;
using Modules.SpellSystem.Enum;

namespace Modules.SpellSystem.Configs
{
    public interface ISpellContainer
    {
        SpellType DebugDefaultType { get; }
        IReadOnlyDictionary<SpellType, ISpellPreset> SpellPresets { get; } 
    }
}