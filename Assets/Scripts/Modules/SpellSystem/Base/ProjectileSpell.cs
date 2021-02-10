using System;
using Modules.Animations.Data;
using Modules.Data.Animation;
using Modules.Data.Transforms;
using Modules.SpellSystem.Actors;
using Modules.SpellSystem.Models;
using Modules.SpellSystem.Presets;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Modules.SpellSystem.Base
{
    public class ProjectileSpell : SpellBase<ProjectileSpellPreset>
    {
        private AnimationData _casterAnimationData;
        private TransformData _casterTransformData;
        private AnimationEventHandlerData _casterEventHandlerData;
        
        protected override void OnInitialize(ProjectileSpellPreset preset)
        {
            _casterTransformData = _owner.GetData<TransformData>();
            _casterAnimationData = _owner.GetData<AnimationData>();
            _casterEventHandlerData = _owner.GetData<AnimationEventHandlerData>();
            
            _casterEventHandlerData.EventHandler.Subscribe("Cast", Cast);
        }

        public override void RaiseSpell(TransformContext context)
        {
            var spellInstance = (ProjectileActor)Object.Instantiate(_actor, context.SpawnPoint, Quaternion.identity);
            
            if (spellInstance != null)
            {
                spellInstance.Direction = context.Direction;
            }
        }

        public override void OnCastStart()
        {
            _casterAnimationData.Component.SetTrigger(_casterAnimationData.AttackAnimationKey);
        }

        public override void OnCastContinue()
        {
            
        }

        public override void OnCastEnd()
        {
            
        }
        

        private void Cast(object sender, EventArgs e)
        {
            var caster = (ICaster) _owner;
            var context = new TransformContext(
                caster.SpawnPoint.position, _casterTransformData.Component.forward);
            RaiseSpell(context);
        }
    }
}