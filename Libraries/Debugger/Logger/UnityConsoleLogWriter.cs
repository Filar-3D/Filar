using System;
using UnityEngine;

namespace Debugger
{
    /// <summary>
    /// An implementation of <see cref="ILogWriter"/> that writes log messages to the Unity Console.
    /// </summary>
    public class UnityConsoleLogWriter: ILogWriter
    {
        public void Write(LogVerbosity verbosity, string log, params object[] args)
        {
            
        }

        public void Write(string fileName, LogVerbosity verbosity, string log, params object[] args)
        {
            string formattedLogString = LogFormat.GetConsoleLogFormatedString(verbosity, log, this);

            switch (verbosity)
            {
                case LogVerbosity.Assertion:
                    Debug.LogAssertionFormat(log, args);
                    break;
                case LogVerbosity.Info:
                    Debug.LogFormat(log, args);
                    break;
                case LogVerbosity.Warning:
                    Debug.LogWarningFormat(log, args);
                    break;
                case LogVerbosity.Error:
                    Debug.LogErrorFormat(log, args);
                    break;
                case LogVerbosity.Exception:
                    Debug.LogException(new Exception(log));
                    break;
            }
        }

        public void Clear()
        {

        }
    }
}
