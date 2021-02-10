using Modules.SpellSystem.Inputs;
using Modules.SpellSystem.Models;
using Modules.SpellSystem.Presets;
using UnityEngine;

namespace Modules.SpellSystem.Base
{
    public class AoeSpell : SpellBase<AoeSpellPreset>
    {
        protected override void OnInitialize(AoeSpellPreset preset)
        {
            
        }

        public override void Cast(TransformContext context)
        {
            var endPoint = context.SpawnPoint + context.Direction * 5.0f;
            var spellInstance = Object.Instantiate(_actor, endPoint, Quaternion.identity);
        }
        
        public override ISpellInput GenerateInputs()
        {
            return new AreaSelectionSpellInput();
        }
    }
}
