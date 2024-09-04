using System;

namespace Debugger
{
    /// <summary>
    /// Defines methods for logging messages at various verbosity levels and handling exceptions.
    /// </summary>
    /// <remarks>
    /// Implementations of this interface should provide mechanisms to log messages of different severities
    /// and handle exceptions based on the specified verbosity level and source information.
    /// </remarks>
    public interface ILogger
    {
        void Log<T>(LogVerbosity verbosity, string message, T source = null) where T: class;
        void LogInfo<T>(string message, T source = null) where T : class;
        void LogWarning<T>(string message, T source = null) where T : class;
        void LogError<T>(string message, T source = null) where T : class;
        void ThrowException<T>(Exception exception, T source = null) where T : class;
    }
}
