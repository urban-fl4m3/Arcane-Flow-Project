﻿using Modules.Actors;
using Modules.Data.KeyBindings;
using UnityEngine;

namespace Modules.SpellSystem.Behaviours
{
    [CreateAssetMenu(fileName = "New Player Cast Behaviour", menuName = "Behaviours/Player/Cast")]
    public class PlayerCastBehaviour : CastBehaviour
    {
        private KeyBindingsData _bindingsData;
        
        protected override void OnInitialize(IActor owner)
        {
            base.OnInitialize(owner);

            _bindingsData = Owner.GetData<KeyBindingsData>();
            
            StartTick();
        }

        protected override void OnTick()
        {
            base.OnTick();
            
            if (Input.GetKeyDown(_bindingsData.AttackKey))
            {
                _activeSpell.OnCastStart();
            }
            
            if (Input.GetKey(_bindingsData.AttackKey))
            {
                _activeSpell.OnCastContinue();
            }
            
            if (Input.GetKeyUp(_bindingsData.AttackKey))
            {
                _activeSpell.OnCastEnd();
            }
        }
    }
}