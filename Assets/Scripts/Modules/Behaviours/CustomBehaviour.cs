using Modules.Actors;
using UnityEngine;

namespace Modules.Behaviours
{
    [CreateAssetMenu(fileName = "New Custom Behaviour", menuName = "Behaviours/CustomBehaviour")]
    public class CustomBehaviour : BaseBehaviour
    {
        protected override void OnInitialize(IActor owner)
        {
            
        }
    }
}