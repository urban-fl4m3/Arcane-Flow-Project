using Modules.Actors;
using UnityEngine;

namespace Modules.Data.Transforms
{
    [CreateAssetMenu(fileName = "New Rotation Data", menuName = "Data/Rotation")]
    public class RotationData : BaseData, IRotationData
    {
        public bool CanRotate { get; set; }

        protected override void OnInitialize(IActor owner)
        {
            CanRotate = true;
        }
    }
}