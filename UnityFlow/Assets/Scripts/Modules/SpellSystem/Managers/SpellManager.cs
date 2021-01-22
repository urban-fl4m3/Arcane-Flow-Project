using Modules.SpellSystem.Providers;

namespace Modules.SpellSystem.Managers
{
    public class SpellManager : ISpellManager
    {
        private readonly ISpellProvider _spellProvider;

        public SpellManager(ISpellProvider spellProvider)
        {
            _spellProvider = spellProvider;
        }

        public ISpell GetDefaultSpell()
        {
            return _spellProvider.CreateDebugSpell();
        }
    }
}