using Modules.Actors;
using UnityEngine;

namespace Modules.Datas.Transforms
{
    [CreateAssetMenu(fileName = "New Transform Data", menuName = "Data/Transform")]
    public class TransformData : BaseData, ITransformData
    {
        private Transform _transform;

        protected override void OnInitialize(IActor owner)
        {
            _transform = Owner.GetGameObject().transform;
        }
        
        public Transform GetTransform()
        {
            return _transform;
        }
    }
}