using Modules.SpellSystem.Actors;
using Modules.SpellSystem.Configs;
using Modules.SpellSystem.Inputs;
using Modules.SpellSystem.Models;
using UnityEngine;

namespace Modules.SpellSystem.Base
{
    public class PointAndClickSpell : SpellBase
    {
        public PointAndClickSpell(ISpellPreset preset) : base(preset)
        {
            SpellInput = new PointAndClickSpellInput();
        }

        public override ISpellInput SpellInput { get; }

        protected override void Cast(TransformContext context)
        {
            var spellInstance = (ProjectileActor)Object.Instantiate(_actor, context.SpawnPoint, Quaternion.identity);
            
            if (spellInstance != null)
            {
                spellInstance.Direction = context.Direction;
            }
        }
    }
}