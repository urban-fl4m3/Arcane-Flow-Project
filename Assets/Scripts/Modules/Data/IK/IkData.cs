using Modules.Actors;
using Modules.Actors.Components;
using UnityEngine;

namespace Modules.Data.IK
{
    [CreateAssetMenu(fileName = "New IK Data", menuName = "Data/IK")]
    public class IkData : BaseData
    {
        [SerializeField] private LayerMask _environmentLayer;
        [SerializeField] private float _pelvisOffset;
        [Range(0.0f, 1.0f)] [SerializeField] private float _feetToIkPositionSpeed;

        protected override void OnInitialize(IActor owner)
        {
            Component = owner.GetGameObject().GetComponent<IkAnimationComponent>();
        }
        
        public IkAnimationComponent Component { get; private set; }
        
        public LayerMask EnvironmentLayer => _environmentLayer;
        public float PelvisOffset => _pelvisOffset;
        public float FeetToIkPositionSpeed => _feetToIkPositionSpeed;

    }
}