using System;

namespace Modules.Commands
{
    public interface ICommandQueue
    {
        event EventHandler OnComplete;
        
        void Add(ICommand command);
        void ExecuteAll();
    }
}