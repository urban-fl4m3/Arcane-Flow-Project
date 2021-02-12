using System;
using Modules.Animations.Data;
using Modules.Data.Animation;
using Modules.Data.Transforms;
using Modules.SpellSystem.Actors;
using Modules.SpellSystem.Data;
using Modules.SpellSystem.Models;
using Modules.SpellSystem.Presets;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Modules.SpellSystem.Base
{
    public class ProjectileSpell : SpellBase<ProjectileSpellPreset, ProjectileActor>
    {
        private AnimationData _casterAnimationData;
        private TransformData _casterTransformData;
        private AnimationEventHandlerData _casterEventHandlerData;
        private SpellData _spellData;
        
        protected override void OnInitialize()
        {
            _casterTransformData = _owner.GetData<TransformData>();
            _casterAnimationData = _owner.GetData<AnimationData>();
            _casterEventHandlerData = _owner.GetData<AnimationEventHandlerData>();
            _spellData = _owner.GetData<SpellData>();
            
            _casterEventHandlerData.EventHandler.Subscribe("Cast", Cast);
        }

        public override void RaiseSpell(TransformContext context)
        {
            var spellInstance = Object.Instantiate(_actor, context.SpawnPoint, Quaternion.identity);
            
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
            var context = new TransformContext(
                _spellData.SpawnPoint.position, _casterTransformData.Component.forward);
            RaiseSpell(context);
        }

        public override void Dispose()
        {
            _casterEventHandlerData.EventHandler.Unsubscribe("Cast", Cast);
        }
    }
}