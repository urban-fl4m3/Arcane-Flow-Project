using Modules.Maps.Configs;
using Modules.Maps.Models;
using UnityEngine;

namespace Modules.Maps.Providers
{
    public class MapSettingsProvider : IMapSettingsProvider
    {
        private readonly IAvailableMapsConfig _availableMapsConfig;
        private readonly IAvailableLightningsConfig _availableLightningsConfig;

        public MapSettingsProvider(IAvailableMapsConfig availableMapsConfig,
            IAvailableLightningsConfig availableLightningsConfig)
        {
            _availableMapsConfig = availableMapsConfig;
            _availableLightningsConfig = availableLightningsConfig;
        }

        public GeneratedMapModel GenerateMapModel()
        {
            var map = _availableMapsConfig.GetAvailableMap();
            var mapInstance = Object.Instantiate(map);

            var lightnings = _availableLightningsConfig.GetLightningActor();
            var lightningInstance = Object.Instantiate(lightnings);

            return new GeneratedMapModel
            {
                MapActor = mapInstance,
                MapLightnings = lightningInstance
            };
        }
    }
}