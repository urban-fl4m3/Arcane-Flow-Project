using Modules.Actors;
using UnityEngine;

namespace Modules.Data.Transforms
{
    [CreateAssetMenu(fileName = "New Rotation Data", menuName = "Data/Rotation")]
    public class RotationData : BaseData
    {
        [SerializeField] private float _rotationFade;
        [SerializeField] private bool _applyMovementRotation;

        protected override void OnInitialize(IActor owner)
        {
            ApplyMovementRotation = true;
        }

        public float RotationFade => _rotationFade;

        public bool ApplyMovementRotation
        {
            get => _applyMovementRotation;
            set => _applyMovementRotation = value;
        }
    }
}