namespace Debugger
{
    /// <summary>
    /// Defines the verbosity levels for logging messages.
    /// </summary>
    /// <remarks>
    /// The <see cref="LogVerbosity"/> enum represents different levels of logging severity. These levels help categorize and filter log messages based on their importance.
    /// </remarks>
    public enum LogVerbosity
    {
        /// <summary>
        /// Represents an assertion level log message. Typically used for critical checks that should always be true.
        /// </summary>
        Assert,

        /// <summary>
        /// Represents an informational log message. Used for general information about the application's state or operations.
        /// </summary>
        Info,

        /// <summary>
        /// Represents a warning level log message. Indicates a potential issue or something that might require attention but is not an error.
        /// </summary>
        Warning,

        /// <summary>
        /// Represents an error level log message. Used for errors that impact the application's functionality and require attention.
        /// </summary>
        Error,

        /// <summary>
        /// Represents an exception level log message. Used for logging exceptions that occur during the application's execution.
        /// </summary>
        Exception
    }
}
