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
        Assertion,

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

    /// <summary>
    /// Defines the different log channels used for categorizing log messages in Unity's console.
    /// <para>Log channels help in filtering and organizing log output based on the type of message.</para>
    /// </summary>
    /// <remarks>
    /// The <see cref="LogChannel"/> enum can be used to specify the channel for log messages, allowing
    /// for better organization and filtering of logs in the Unity Editor's console. For more information
    /// about Unity's logging system and console, see <a href="https://docs.unity3d.com/Manual/script-Logging.html">Unity Logging Documentation</a>.
    /// </remarks>
    public enum LogChannel
    {
        /// <summary>
        /// Represents a debug log channel, typically used for general debugging messages.
        /// <para>Messages in this channel are intended for development and troubleshooting.</para>
        /// </summary>
        Debug,

        /// <summary>
        /// Represents a warning log channel, used to indicate potential issues or important warnings.
        /// <para>Warnings are less severe than errors but may indicate potential problems or areas for attention.</para>
        /// </summary>
        Warning,

        /// <summary>
        /// Represents an error log channel, used for critical issues that need immediate attention.
        /// <para>Errors indicate significant problems that may affect the functionality of the application.</para>
        /// </summary>
        Error
    }

    public enum LogWriterType
    {
        ConsoleWriter,
        FileWriter,
        ScreenWriter
    }
}
