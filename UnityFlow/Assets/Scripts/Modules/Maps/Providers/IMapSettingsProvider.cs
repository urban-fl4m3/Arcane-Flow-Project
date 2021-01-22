using Modules.Maps.Models;

namespace Modules.Maps.Providers
{
    public interface IMapSettingsProvider
    {
        GeneratedMapModel GenerateMapModel();
    }
}