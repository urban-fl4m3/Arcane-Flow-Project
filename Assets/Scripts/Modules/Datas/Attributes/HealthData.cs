using Modules.Actors;
using UnityEngine;

namespace Modules.Datas.Attributes
{
    [CreateAssetMenu(fileName = "HealthData", menuName = "Attributes Data/Health")]
    public class HealthData : BaseData, IHealthData
    {
        [SerializeField] private float _healthPoints;

        public float HealthPoints => _healthPoints;

        protected override void OnInitialize(IActor owner)
        {
            
        }
    }
}