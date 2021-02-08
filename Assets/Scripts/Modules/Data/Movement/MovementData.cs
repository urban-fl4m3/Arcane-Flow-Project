using Modules.Actors;
using UnityEngine;

namespace Modules.Data.Movement
{
    [CreateAssetMenu(fileName = "New Movement Data", menuName = "Data/Movement")]
    public class MovementData : BaseData
    {
        [SerializeField] private bool _smoothInput;
        [SerializeField] private bool _canMove;
        [SerializeField] private bool _moveWithPhysics;
        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _movementFade;
        
        protected override void OnInitialize(IActor owner)
        {
            
        }

        public float MovementSpeed
        {
            get => _movementSpeed;
            set => _movementSpeed = value;
        }
        
        public float MovementFade => _movementFade;
        public bool MoveWithPhysics => _moveWithPhysics;
        public bool SmoothInput => _smoothInput;
        public bool CanMove
        {
            get => _canMove;
            set => _canMove = value;
        }
    }
}