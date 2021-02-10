using Modules.SpellSystem.Actors;
using Modules.SpellSystem.Inputs;
using Modules.SpellSystem.Models;
using Modules.SpellSystem.Presets;
using UnityEngine;

namespace Modules.SpellSystem.Base
{
    public class ProjectileSpell : SpellBase<ProjectileSpellPreset>
    {
        protected override void OnInitialize(ProjectileSpellPreset preset)
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
        
        public override ISpellInput GenerateInputs()
        {
            return new PointAndClickSpellInput();
        }
    }
}