using Modules.Actors;
using UnityEngine;

namespace Modules.Datas.Attributes
{
    [CreateAssetMenu(fileName = "StaminaData", menuName = "Attributes Data/Stamina")]
    public class StaminaData : BaseData, IStaminaData
    {
        [SerializeField] private float _staminaPoints;

        public float StaminaPoints => _staminaPoints;

        protected override void OnInitialize(IActor owner)
        {
            
        }
    }
}