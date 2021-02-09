using Modules.SpellSystem.Actors;
using Modules.SpellSystem.Configs;
using Modules.SpellSystem.Models;
using UnityEngine;

namespace Modules.SpellSystem.Base
{
    public class ProjectileSpell : SpellBase
    {
        public ProjectileSpell(ISpellPreset preset) : base(preset)
        {
            
        }
        
        public override void Cast(TransformContext context)
        {
            var spellInstance = (ProjectileActor)Object.Instantiate(_actor, context.SpawnPoint, Quaternion.identity);
            
            if (spellInstance != null)
            {
                spellInstance.Direction = context.Direction;
            }
        }
    }
}