using Modules.SpellSystem.Configs;
using Modules.SpellSystem.Enum;

namespace Modules.SpellSystem.Providers
{
    public class SpellProvider : ISpellProvider
    {
        private readonly ISpellContainer _spellContainer;

        public SpellProvider(ISpellContainer spellContainer)
        {
            _spellContainer = spellContainer;
        }

        public ISpell CreateSpell(SpellType type)
        {
            var preset = _spellContainer.SpellPresets[type];
            
            var spell = new Spell(
                preset.Id,
                preset.Type,
                preset.Actor,
                preset.Tags
            );
            return spell;
        }

        public ISpell CreateDebugSpell()
        {
            return CreateSpell(_spellContainer.DebugDefaultType);
        }
    }
}