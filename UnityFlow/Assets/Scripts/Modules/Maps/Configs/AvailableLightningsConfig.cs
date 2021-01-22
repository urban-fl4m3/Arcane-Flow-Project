using Modules.Actors.Types;
using UnityEngine;

namespace Modules.Maps.Configs
{
    [CreateAssetMenu(fileName = "AvailableLightnings", menuName = "Maps/Available lightnings config")]
    public class AvailableLightningsConfig : ScriptableObject, IAvailableLightningsConfig
    {
        [SerializeField] private ActorBase _lightningActor;
        
        public ActorBase GetLightningActor()
        {
            return _lightningActor;
        }
    }
}