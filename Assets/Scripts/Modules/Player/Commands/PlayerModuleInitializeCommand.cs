using Modules.Commands.Concrete;
using Modules.Player.Managers;

namespace Modules.Player.Commands
{
    public class PlayerModuleInitializeCommand : InitializeCommand
    {
        public PlayerModuleInitializeCommand()
        {
            
        }

        public override void Execute()
        {
            
            CompleteCommand();
        }
    }
}