using Modules.SpellSystem.Configs;
using Modules.SpellSystem.Models;
using UnityEngine;

namespace Modules.SpellSystem.Base
{
    public class AoeSpell : SpellBase
    {

        public AoeSpell(ISpellPreset preset) : base(preset)
        {
        
        }
    
        public override void Cast(TransformContext context)
        {
            var endPoint = context.SpawnPoint + context.Direction * 5.0f;
            var spellInstance = Object.Instantiate(_actor, endPoint, Quaternion.identity);
        }
    }
}
