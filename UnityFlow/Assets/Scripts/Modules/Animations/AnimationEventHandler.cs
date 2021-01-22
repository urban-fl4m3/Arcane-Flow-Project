using System;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.Animations
{
    public class AnimationEventHandler :MonoBehaviour, IAnimationEventHandler
    {
        private readonly Dictionary<string, EventHandler> _eventsDictionary
            = new Dictionary<string, EventHandler>();
        
        public void RaiseEvent(string key)
        {
            var isExists = _eventsDictionary.TryGetValue(key, out var handler);

            if (isExists)
            {
                handler?.Invoke(this, EventArgs.Empty);
            }
        }

        public void AddEvent(string key, EventHandler handler)
        {
            if (!_eventsDictionary.ContainsKey(key))
            {
                _eventsDictionary.Add(key, null);
            }

            _eventsDictionary[key] += handler;
        }
    }
}