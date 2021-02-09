﻿using System;
using Modules.Actors;
using Modules.Animations.Data;
using Modules.Behaviours;
using Modules.Behaviours.AbstractTicks;
using Modules.Data.Transforms;
using Modules.SpellSystem.Data;
using UnityEngine;

namespace Modules.SpellSystem.Behaviours
{
    [CreateAssetMenu(fileName = "New Cast Behaviour", menuName = "Behaviours/Cast")]
    public class CastBehaviour : TickBehaviour
    {
        private TransformData _ownerTransformData;
        private AnimationEventHandlerData _animationEventHandlerData;
        private SpellData _spellData;

        private ICaster _caster;
        
        protected override void OnInitialize(IActor owner)
        {
            _spellData = Owner.GetData<SpellData>();
            _ownerTransformData = Owner.GetData<TransformData>();
            _animationEventHandlerData = Owner.GetData<AnimationEventHandlerData>();
            
            if (owner is ICaster caster)
            {
                _caster = caster;
            }

            _animationEventHandlerData.EventHandler.Subscribe("Cast", Cast);
        }

        protected override void OnTick()
        {
            
        }

        private void Cast(object sender, EventArgs e)
        {
            var activeSpell = _spellData.Spells[_caster.ListOfSpellsID[_caster.activeSpell]];
            activeSpell.Cast(_caster.SpawnPoint, _ownerTransformData.Component.forward);
        }

        public override void Dispose()
        {
            _animationEventHandlerData.EventHandler.Unsubscribe("Cast");
            base.Dispose();
        }
    }
}