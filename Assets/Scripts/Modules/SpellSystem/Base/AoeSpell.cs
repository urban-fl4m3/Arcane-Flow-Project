using Modules.SpellSystem.Actors;
using Modules.SpellSystem.Models;
using Modules.SpellSystem.Presets;
using UnityEngine;

namespace Modules.SpellSystem.Base
{
    public class AoeSpell : SpellBase<AoeSpellPreset, AoeActor>
    {
        protected override void OnInitialize()
        {
            
        }

        public override void RaiseSpell(TransformContext context)
        {
            var endPoint = context.SpawnPoint + context.Direction * 5.0f;
            var spellInstance = Object.Instantiate(_actor, endPoint, Quaternion.identity);
        }

        public override void OnCastStart()
        {
            
        }

        public override void OnCastContinue()
        {
            
        }

        public override void OnCastEnd()
        {
            
        }
    }
}
