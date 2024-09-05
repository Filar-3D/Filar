using System;
using UnityEngine;

namespace Debugger
{
    /// <summary>
    /// An implementation of <see cref="ILogWriter"/> that writes log messages to the Unity Console.
    /// </summary>
    public class UnityConsoleLogger: ILogWriter
    {
        /// <summary>
        /// Writes a log message with a specified verbosity level to the Unity Console.
        /// </summary>
        /// <param name="verbosity">The verbosity level of the log message. See <see cref="LogVerbosity"/> for possible values.</param>
        /// <param name="log">The log message with optional placeholders for arguments.</param>
        /// <param name="args">Optional arguments to format the log message.</param>
        /// <seealso cref="LogVerbosity"/>
        public void Write(LogVerbosity verbosity, string log, params object[] args)
        {
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
    }
}
