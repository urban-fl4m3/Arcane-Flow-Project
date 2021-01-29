using System;

namespace Modules.Animations
{
    public interface IAnimationEventHandler
    {
        void Subscribe(string key, EventHandler handler);
        void Unsubscribe(string key);
    }
}