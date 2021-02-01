using Modules.Actors;
using Modules.Actors.Components;
using UnityEngine;

namespace Modules.Data.IK
{
    [CreateAssetMenu(fileName = "New IK Data", menuName = "Data/IK")]
    public class IkData : BaseData
    {
        [SerializeField] private string _rightFootAnimVariableName;
        [SerializeField] private string _leftFootAnimVariableName;
        
        [Range(0.0f, 2.0f)][SerializeField] private float _heightFromGroundRaycast;
        [Range(0.0f, 2.0f)] [SerializeField] private float _rayCastDownDistance;
        [SerializeField] private LayerMask _environmentLayer;
        [SerializeField] private float _pelvisOffset;
        [Range(0.0f, 1.0f)][SerializeField] private float _pelvisUpAndDownSpeed;
        [Range(0.0f, 1.0f)] [SerializeField] private float _feetToIkPositionSpeed;

        [SerializeField] private bool _showSolverDebug;
        
        protected override void OnInitialize(IActor owner)
        {
            Component = owner.GetGameObject().GetComponent<IkAnimationComponent>();
        }
        
        public IkAnimationComponent Component { get; private set; }

        public string RightFootAnimVariableName => _rightFootAnimVariableName;
        public string LeftFootAnimVariableName => _leftFootAnimVariableName;

        public float HeightFromGroundRaycast => _heightFromGroundRaycast;
        public float RayCastDownDistance => _rayCastDownDistance;
        public LayerMask EnvironmentLayer => _environmentLayer;
        public float PelvisOffset => _pelvisOffset;
        public float PelvisUpAndDownSpeed => _pelvisUpAndDownSpeed;
        public float FeetToIkPositionSpeed => _feetToIkPositionSpeed;

        public bool ShowSolverDebug => _showSolverDebug;
    }
}