using Modules.Maps.Actors;
using UnityEngine;

namespace Modules.Maps.Configs
{
    [CreateAssetMenu(fileName = "AvailableMaps", menuName = "Maps/Available maps config")]
    public class AvailableMapsConfig : ScriptableObject, IAvailableMapsConfig
    {
        [SerializeField] private MapActor _availableMap;

        public MapActor GetAvailableMap()
        {
            return _availableMap;
        }
    }
}