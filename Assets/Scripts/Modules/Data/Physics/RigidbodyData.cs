using Modules.Actors;
using UnityEngine;

namespace Modules.Data.Physics
{
    [CreateAssetMenu(fileName = "New Rigidbody Data", menuName = "Data/Rigidbody")]
    public class RigidbodyData : BaseData
    {
        protected override void OnInitialize(IActor owner)
        {
            Component = owner.GetGameObject().GetComponent<Rigidbody>();
        }
        
        public Rigidbody Component { get; private set; }
    }
}