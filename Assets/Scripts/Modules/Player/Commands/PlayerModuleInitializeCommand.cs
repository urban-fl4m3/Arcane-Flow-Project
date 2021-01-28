using Modules.Commands.Concrete;
using Modules.Player.Managers;

namespace Modules.Player.Commands
{
    public class PlayerModuleInitializeCommand : InitializeCommand
    {
        private readonly IPlayerManager _playerManager;

        public PlayerModuleInitializeCommand(IPlayerManager playerManager)
        {
            _playerManager = playerManager;
        }

        public override void Execute()
        {
            _playerManager.Init();
            CompleteCommand();
        }
    }
}