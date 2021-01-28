using Modules.Core.Configs;
using UnityEngine;
using Zenject;

namespace Modules.Core.Installers
{
    [CreateAssetMenu(fileName = "New Project Settings", menuName = "Installers/Project Settings")]
    public class ProjectSettingsInstaller : ScriptableObjectInstaller<ProjectSettingsInstaller>
    {
        [SerializeField] private ProjectSettings _projectSettings;
        
        public override void InstallBindings()
        {
            Container.Bind<IProjectSettings>().To<ProjectSettings>().FromInstance(_projectSettings);
        }
    }
}