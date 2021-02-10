using Modules.Actors;
using UnityEngine;

namespace Modules.Data.Transforms
{
    [CreateAssetMenu(fileName = "New Transform Data", menuName = "Data/Transform")]
    public class TransformData : BaseData
    {
        protected override void OnInitialize(IActor owner)
        {
            Component = Owner.Object.GetComponent<Transform>();
        }

        public Transform Component { get; private set; }
    }
}