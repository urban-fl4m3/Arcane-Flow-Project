using Modules.Core.Managers;

namespace Modules.SpellSystem.Managers
{
    public interface ISpellManager : IManager
    {
        ISpell GetDefaultSpell();
    }
}