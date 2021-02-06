using Modules.Actors;
using UnityEngine;

namespace Modules.Data.Movement
{
    [CreateAssetMenu(fileName = "New Movement Data", menuName = "Data/Movement")]
    public class MovementData : BaseData
    {
        [SerializeField] private bool _smoothInput;

        protected override void OnInitialize(IActor owner)
        {
            
        }

        public bool SmoothInput => _smoothInput;
        public bool CanMove { get; set; }
    }
}