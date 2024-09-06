using System;

namespace Debugger
{
    /// <summary>
    /// A factory class for creating instances of log writers based on the specified type.
    /// </summary>
    /// <remarks>
    /// This factory method uses the <see cref="LogWriterType"/> enumeration to determine which concrete implementation of <see cref="ILogWriter"/> to create.
    /// The <paramref name="outputPath"/> parameter is used only when creating a <see cref="LogWriterType.FileWriter"/>.
    /// </remarks>
    public class LogWriterFactory
    {
        /// <summary>
        /// Creates an instance of an <see cref="ILogWriter"/> based on the provided <see cref="LogWriterType"/> and optional output path.
        /// </summary>
        /// <param name="writerType">
        /// The type of log writer to create. This parameter determines which concrete implementation of <see cref="ILogWriter"/> will be returned.
        /// Valid values include:
        /// <list type="bullet">
        /// <item><description><see cref="LogWriterType.ConsoleWriter"/>: Creates an instance of <see cref="UnityConsoleLogWriter"/>.</description></item>
        /// <item><description><see cref="LogWriterType.FileWriter"/>: Creates an instance of <see cref="FileLogWriter"/> with the specified <paramref name="outputPath"/>.</description></item>
        /// </list>
        /// </param>
        /// <param name="outputPath">
        /// The file path where logs will be written. This parameter is used only when creating a <see cref="LogWriterType.FileWriter"/>. 
        /// If <c>null</c>, a default file path may be used if defined in the <see cref="FileLogWriter"/> implementation.
        /// </param>
        /// <returns>
        /// An instance of <see cref="ILogWriter"/> corresponding to the specified <paramref name="writerType"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown when the <paramref name="writerType"/> is not recognized.
        /// </exception>
        public static ILogWriter Create(LogWriterType writerType, string outputPath = null)
        {
            return writerType switch
            { 
                LogWriterType.ConsoleWriter => new UnityConsoleLogWriter(),
                LogWriterType.FileWriter => new FileLogWriter(outputPath),
                _=> throw new ArgumentException("Invalid log writer type provided.", nameof(writerType))
            };
        }
    }
}
