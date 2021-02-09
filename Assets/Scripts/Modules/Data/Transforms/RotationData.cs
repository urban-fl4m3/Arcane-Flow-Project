using Modules.Actors;
using Modules.Common;
using UnityEngine;

namespace Modules.Data.Transforms
{
    [CreateAssetMenu(fileName = "New Rotation Data", menuName = "Data/Rotation")]
    public class RotationData : BaseData
    {
        [SerializeField] private float _rotationSmooth;
        [SerializeField] private float _rotationFade;
        [SerializeField] private bool _applyMovementRotation;
        [SerializeField] private bool _syncRotationWithMovement;
        [SerializeField] private DynamicBool _lookAtMouseCursor;
        
        protected override void OnInitialize(IActor owner)
        {
            ApplyMovementRotation = true;
        }

        public float RotationSmooth => _rotationSmooth;
        public float RotationFade => _rotationFade;

        public DynamicBool LookAtMouseCursor => _lookAtMouseCursor;
        public bool SyncRotationWithMovement => _syncRotationWithMovement;
        public bool ApplyMovementRotation
        {
            get => _applyMovementRotation;
            set => _applyMovementRotation = value;
        }
    }
}