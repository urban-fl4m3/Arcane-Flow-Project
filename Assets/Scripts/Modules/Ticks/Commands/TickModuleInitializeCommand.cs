using Modules.Commands.Concrete;
using Modules.Ticks.Managers;
using Modules.Ticks.Processors;
using UnityEngine;

namespace Modules.Ticks.Commands
{
    public class TickModuleInitializeCommand : InitializeCommand
    {
        private readonly ITickManager _tickManager;

        public TickModuleInitializeCommand(ITickManager tickManager)
        {
            _tickManager = tickManager;
        }

        public override void Execute()
        {
            var tickObject = new GameObject("_Tick_Processor");
            var tickProcessor = tickObject.AddComponent<TickProcessor>();
            _tickManager.SetTickProcessor(tickProcessor);
            _tickManager.StartUpdating();

            CompleteCommand();
        }
    }
}