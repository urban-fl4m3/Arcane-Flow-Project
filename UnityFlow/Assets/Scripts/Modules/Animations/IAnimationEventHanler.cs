using System;

namespace Modules.Animations
{
    public interface IAnimationEventHandler
    {
        void AddEvent(string key, EventHandler handler);
    }
}