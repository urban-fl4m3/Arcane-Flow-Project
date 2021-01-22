using UnityEngine;

namespace Modules.Logger
{
    public class UnityLogger : ILogger
    {
        public void Log(string message)
        {
#if UNITY_EDITOR
            Debug.Log(message);
#endif
        }

        public void Log(string tag, string message)
        {
#if UNITY_EDITOR
            Debug.Log($"[{tag}]: {message}");
#endif
        }
    }
}