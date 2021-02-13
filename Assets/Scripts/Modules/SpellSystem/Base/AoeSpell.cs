using System;
using Modules.Animations.Data;
using Modules.Data.Animation;
using Modules.SpellSystem.Actors;
using Modules.SpellSystem.Models;
using Modules.SpellSystem.Presets;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Modules.SpellSystem.Base
{
    public class AoeSpell : SpellBase<AoeSpellPreset, AoeActor>
    {
        private AnimationData _casterAnimationData;
        private AnimationEventHandlerData _casterEventHandlerData;

        private GameObject _selectionObject;
        private TransformContext _context;
        
        protected override void OnInitialize()
        {
            _casterAnimationData = _owner.GetData<AnimationData>();
            _casterEventHandlerData = _owner.GetData<AnimationEventHandlerData>();

            _casterEventHandlerData.EventHandler.Subscribe("Cast", Cast);

            _context = new TransformContext();
        }


        public override void RaiseSpell(TransformContext context)
        {
            var spellInstance = Object.Instantiate(_actor, _context.SelectedPoint, Quaternion.identity);

            if (spellInstance != null)
            {
                spellInstance.Init(null, null);
            }
        }

        public override void OnCastStart()
        {
            if (_selectionObject == null)
            {
                _selectionObject = new GameObject("AoE_Selection");
                var spriteRenderer = _selectionObject.AddComponent<SpriteRenderer>();
                spriteRenderer.sprite = _preset.SelectionContext.SelectionSprite;
                _selectionObject.transform.localScale = new Vector3(20, 20, 1);
            }

            _selectionObject.gameObject.SetActive(true);
        }

        public override void OnCastContinue()
        {
            var ray = _owner.Camera.ScreenPointToRay(Input.mousePosition);

            if (!Physics.Raycast(ray, out var hit, 100, 1 >> 0)) return;
            _selectionObject.transform.position = new Vector3(hit.point.x, hit.point.y + 0.1f, hit.point.z);

            var b = Quaternion.LookRotation(hit.normal);
            _selectionObject.transform.rotation = b;
            _context.SelectedPoint = hit.point;
        }

        public override void OnCastEnd()
        {
            _casterAnimationData.Component.SetTrigger(_casterAnimationData.AttackAnimationKey);

            _selectionObject.gameObject.SetActive(false);
        }

        private void Cast(object sender, EventArgs e)
        {
            RaiseSpell(_context);
        }

        public override void Dispose()
        {
            _casterEventHandlerData.EventHandler.Unsubscribe("Cast", Cast);
        }
    }
}
