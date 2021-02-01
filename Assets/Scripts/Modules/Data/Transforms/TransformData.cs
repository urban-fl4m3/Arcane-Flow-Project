using Modules.Actors;
using UnityEngine;

namespace Modules.Data.Transforms
{
    [CreateAssetMenu(fileName = "New Transform Data", menuName = "Data/Transform")]
    public class TransformData : BaseData, ITransformData
    {
        protected override void OnInitialize(IActor owner)
        {
            Component = Owner.GetGameObject().transform;
        }

        public Transform Component { get; private set; }
    }
}