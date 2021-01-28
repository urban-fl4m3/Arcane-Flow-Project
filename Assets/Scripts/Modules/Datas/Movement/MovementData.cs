using Modules.Actors;
using UnityEngine;

namespace Modules.Datas.Movement
{
    [CreateAssetMenu(fileName = "New Movement Data", menuName = "Data/Movement")]
    public class MovementData : BaseData, IMovementData
    {
        public bool IsMoving { get; set; }

        protected override void OnInitialize(IActor owner)
        {
            
        }
    }
}