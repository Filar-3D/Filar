using System;

namespace Debugger
{
    /// <summary>
    /// Provides methods for logging messages with different verbosity levels.
    /// </summary>
    public interface ILogger
    {
        void Log(LogVerbosity verbosity, string message, params object[] args);
        void LogInfo(string message, params object[] args);
        void LogWarning(string message, params object[] args);
        void LogError(string message, params object[] args);
        void ThrowException(Exception exception);
    }
}
