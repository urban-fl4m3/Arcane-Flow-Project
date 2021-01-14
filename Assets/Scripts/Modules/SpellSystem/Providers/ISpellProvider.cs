using Modules.SpellSystem.Enum;

namespace Modules.SpellSystem.Providers
{
    public interface ISpellProvider
    {
        ISpell CreateDebugSpell();
        ISpell CreateSpell(SpellType type);
    }
}