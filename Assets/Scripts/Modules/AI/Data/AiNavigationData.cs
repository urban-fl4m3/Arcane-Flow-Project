using Modules.Actors;
using Modules.Datas;
using UnityEngine;
using UnityEngine.AI;

namespace Modules.AI.Data
{
    [CreateAssetMenu(fileName = "Nav Mesh Data", menuName = "Data/Nav Mesh")]
    public class AiNavigationData : BaseData
    {
        public IActor Player { get; set; }
        public NavMeshData NavMeshData { get; set; }
        public NavMeshAgent NavMeshAgent { get; private set; }
        
        protected override void OnInitialize(IActor owner)
        {
            NavMeshAgent = owner.GetGameObject().GetComponent<NavMeshAgent>();
        }
    }
}