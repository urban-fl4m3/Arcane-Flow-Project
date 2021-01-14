using System.Collections.Generic;

namespace Modules.SpellSystem.Data
{
    public interface ISpellData
    {
        IReadOnlyDictionary<string, ISpell> Spells { get; }

        void Add(ISpell spell);
    }
}