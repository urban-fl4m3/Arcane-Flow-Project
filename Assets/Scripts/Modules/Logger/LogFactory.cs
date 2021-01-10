using System;
using Modules.Logger.Helpers;

namespace Modules.Logger
{
    public class LogFactory
    {
        public static ILogger GenerateLogger(Log logType)
        {
            switch (logType)
            {
                case Log.Fake: return new FakeLogger();
                case Log.Unity: return new UnityLogger();
                default: throw new Exception();
            }
        }
    }
}