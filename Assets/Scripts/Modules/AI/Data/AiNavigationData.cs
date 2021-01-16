using Modules.Actors;
using Modules.Common;
using Modules.Datas;
using UnityEngine;
using UnityEngine.AI;

namespace Modules.AI.Data
{
    [CreateAssetMenu(fileName = "Nav Mesh Data", menuName = "Data/Nav Mesh")]
    public class AiNavigationData : BaseData
    {
        public DynamicActor Player { get; set; }
        public NavMeshAgent NavMeshAgent { get; private set; }
        
        protected override void OnInitialize(IActor owner)
        {
            NavMeshAgent = owner.GetGameObject().GetComponent<NavMeshAgent>();
            Player = new DynamicActor();
        }

        public void HandlePlayerChanged(object sender, IActor actor)
        {
            Player.Value = actor;
        }
    }
}