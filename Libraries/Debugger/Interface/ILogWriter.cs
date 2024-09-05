namespace Debugger
{
    /// <summary>
    /// Defines a contract for writing logs with a specified verbosity level.
    /// </summary>
    public interface ILogWriter
    {
        void Write(LogVerbosity verbosity, string log, params object[] args);
    }
}
