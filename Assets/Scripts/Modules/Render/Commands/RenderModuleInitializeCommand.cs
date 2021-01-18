using Modules.Commands.Concrete;
using Modules.Render.Managers;

namespace Modules.Render.Commands
{
    public class RenderModuleInitializeCommand : InitializeCommand
    {
        private readonly ICameraManager _cameraManager;
        
        public RenderModuleInitializeCommand(ICameraManager cameraManager)
        {
            _cameraManager = cameraManager;
        }

        public override void Execute()
        {
            _cameraManager.LoadMainCamera();
            _cameraManager.Init();
            CompleteCommand();
        }
    }
}