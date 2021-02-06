using Modules.Actors;
using UnityEngine;

namespace Modules.Data.Transforms
{
    [CreateAssetMenu(fileName = "New Rotation Data", menuName = "Data/Rotation")]
    public class RotationData : BaseData
    {
        public bool ApplyMovementRotation { get; set; }

        protected override void OnInitialize(IActor owner)
        {
            ApplyMovementRotation = true;
        }
    }
}