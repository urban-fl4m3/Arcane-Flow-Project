﻿using Modules.Actors;
using Modules.Data.Transforms;
using UnityEngine;

namespace Modules.Behaviours.TickBehaviours
{
    [CreateAssetMenu(fileName = "New Move Object Child To First RayCast Hit Behaviour", menuName = "Behaviours/Move Object Child To First RayCast Hit")]
    public class MoveObjectChildToFirstRayCastHitBehaviour : TickBehaviour
    {
        private Transform _childTransform;
        private Transform _rootTransform;
        
        private float _defaultOffset;
        private RaycastHit _hit;
        private Vector3 _defaultLocalPosition;
        private float _oldOffset = 0.0f;
        
        protected override void OnInitialize(IActor owner)
        {
            _childTransform = Owner.GetChild().GetData<TransformData>().Component;
            _rootTransform = Owner.GetData<TransformData>().Component;
            
            var localPosition = _childTransform.localPosition;
            _defaultLocalPosition = localPosition;
            _defaultOffset = localPosition.magnitude;
            
            base.OnInitialize(owner);
        }

        protected override void OnTick()
        {
            var offset = _defaultOffset;
            if (Physics.SphereCast(_rootTransform.position,
                0.001f, (_childTransform.position - _rootTransform.position).normalized,
                out _hit, _defaultOffset, LayerMask.GetMask("Default")))
            {
                // var hitObject = _hit.transform.gameObject;
                // var meshComponent = hitObject.GetComponent<MeshRenderer>();
                // var currColor = meshComponent.material.color;
                // currColor.a = 0.5f;
                // currColor = Color.black;
                // meshComponent.material.color = currColor;
                offset = (_hit.point - _rootTransform.position).magnitude;
            }

            _oldOffset = Mathf.Lerp(_oldOffset, offset, 0.3f);
            _childTransform.localPosition = _defaultLocalPosition.normalized * _oldOffset;
        }
    }
}