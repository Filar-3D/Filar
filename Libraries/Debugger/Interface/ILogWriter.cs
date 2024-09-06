namespace Debugger
{
    /// <summary>
    /// Defines a contract for writing logs with a specified verbosity level.
    /// </summary>
    public interface ILogWriter
    {
        /// <summary>
        /// Writes a log entry with the specified verbosity.
        /// </summary>
        /// <param name="verbosity">The verbosity level of the log entry.</param>
        /// <param name="log">The log message to be written.</param>
        /// <param name="args">Optional format arguments to include in the log message.</param>
        void Write(LogVerbosity verbosity, string log, params object[] args);

        /// <summary>
        /// Writes a log entry to a specified file with the specified verbosity.
        /// </summary>
        /// <param name="fileName">The name of the file to write the log entry to.</param>
        /// <param name="verbosity">The verbosity level of the log entry.</param>
        /// <param name="log">The log message to be written.</param>
        /// <param name="args">Optional format arguments to include in the log message.</param>
        void Write(string fileName, LogVerbosity verbosity, string log, params object[] args);

        /// <summary>
        /// Clears all logged entries.
        /// </summary>
        void Clear();
    }
}
