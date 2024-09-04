using System;
using Debugger;
using UnityEngine;

namespace Native
{
    /// <summary>
    /// A MonoBehaviour class that handles logging with different verbosity levels in Unity.
    /// Implements the <see cref="Debugger.ILogger"/> interface to provide custom logging functionality.
    /// </summary>
    /// <remarks>
    /// The <see cref="LogMonoBehaviour"/> class allows for logging messages with varying levels of verbosity
    /// and includes support for logging exceptions. The verbosity of the logs can be controlled via the
    /// <see cref="EnabledLogVerbosity"/> property. Logs are formatted using the <see cref="LogFormat"/> class.
    /// </remarks>
    public class LogMonoBehaviour: MonoBehaviour, Debugger.ILogger
    {
        /// <summary>
        /// The current verbosity level for logging. Only logs at this level or higher will be processed.
        /// </summary>
        [field: SerializeField]
        public LogVerbosity EnabledLogVerbosity { get; private set; }

        /// <summary>
        /// Logs a message with the specified verbosity and an optional source.
        /// </summary>
        /// <typeparam name="T">The type of the source. Must be a class.</typeparam>
        /// <param name="verbosity">The verbosity level of the log message.</param>
        /// <param name="message">The message to be logged.</param>
        /// <param name="source">An optional source of the log message. Can be <c>null</c>.</param>
        public void Log<T>(LogVerbosity verbosity, string message, T source = null) where T : class
        {
            if (EnabledLogVerbosity < verbosity)
            {
                return;
            }

            string formattedLogString = LogFormat.GetLogFormatedString(verbosity, message, source);
            Debug.Log(formattedLogString);
        }

        /// <summary>
        /// Logs an informational message with an optional source.
        /// </summary>
        /// <typeparam name="T">The type of the source. Must be a class.</typeparam>
        /// <param name="message">The informational message to be logged.</param>
        /// <param name="source">An optional source of the log message. Can be <c>null</c>.</param>
        public void LogInfo<T>(string message, T source = null) where T : class
        {
            if (EnabledLogVerbosity < LogVerbosity.Info)
            {
                return;
            }

            string formattedLogString = LogFormat.GetLogFormatedString(LogVerbosity.Info, message, source);
            Debug.Log(formattedLogString);
        }

        /// <summary>
        /// Logs a warning message with an optional source.
        /// </summary>
        /// <typeparam name="T">The type of the source. Must be a class.</typeparam>
        /// <param name="message">The warning message to be logged.</param>
        /// <param name="source">An optional source of the log message. Can be <c>null</c>.</param>
        public void LogWarning<T>(string message, T source = null) where T : class
        {
            if (EnabledLogVerbosity < LogVerbosity.Warning)
            {
                return;
            }

            string formattedLogString = LogFormat.GetLogFormatedString(LogVerbosity.Warning, message, source);
            Debug.Log(formattedLogString);
        }

        /// <summary>
        /// Logs an error message with an optional source.
        /// </summary>
        /// <typeparam name="T">The type of the source. Must be a class.</typeparam>
        /// <param name="message">The error message to be logged.</param>
        /// <param name="source">An optional source of the log message. Can be <c>null</c>.</param>
        public void LogError<T>(string message, T source = null) where T : class
        {
            if (EnabledLogVerbosity < LogVerbosity.Error)
            {
                return;
            }

            string formattedLogString = LogFormat.GetLogFormatedString(LogVerbosity.Error, message, source);
            Debug.Log(formattedLogString);
        }

        /// <summary>
        /// Logs an exception message with an optional source and throws the exception.
        /// </summary>
        /// <typeparam name="T">The type of the source. Must be a class.</typeparam>
        /// <param name="exception">The exception to be logged and thrown.</param>
        /// <param name="source">An optional source of the log message. Can be <c>null</c>.</param>
        /// <exception cref="Exception">The exception being logged and thrown.</exception>
        public void ThrowException<T>(Exception exception, T source = null) where T : class
        {
            string formattedLogString = LogFormat.GetLogFormatedString(LogVerbosity.Exception, exception.Message, source);
            Debug.Log(formattedLogString);
            throw exception;
        }
    }
}
