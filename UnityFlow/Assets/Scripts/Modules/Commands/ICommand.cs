using System;

namespace Modules.Commands
{
    public interface ICommand
    {
        event EventHandler OnComplete;
        event EventHandler OnFail;
        
        void Execute();
    }
}