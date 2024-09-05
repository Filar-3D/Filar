using System;
using System.Linq;
using Common;

namespace Debugger.Services
{
    /// <summary>
    /// Provides a builder for configuring and creating instances of <see cref="IServiceCollection{ILogWriter}"/>.
    /// </summary>
    public class LoggingServiceBuilder
    {
        private readonly IServiceCollection<ILogWriter> loggingServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoggingServiceBuilder"/> class.
        /// </summary>
        public LoggingServiceBuilder()
        {
            loggingServices = new LoggingServices();
        }

        /// <summary>
        /// Configures the logging services to use a console logger.
        /// </summary>
        /// <returns>The current <see cref="LoggingServiceBuilder"/> instance for method chaining.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the <see cref="ILogWriter"/> created is null.</exception>
        public LoggingServiceBuilder WithUnityConsoleLogger() 
        {
            ILogWriter writer = LogWriterFactory.Create(LogWriterType.ConsoleWriter);

            if(writer == null)
            {
                throw new InvalidOperationException("Failed to create ConsoleLogger. The returned ILogWriter is null.");
            }

            loggingServices.AddService(writer);

            return this;
        }

        /// <summary>
        /// Configures the logging services to use a file logger with an optional output path.
        /// </summary>
        /// <param name="outputPath">The file path where logs will be written. If null, default behavior will be used.</param>
        /// <returns>The current <see cref="LoggingServiceBuilder"/> instance for method chaining.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the <see cref="ILogWriter"/> created is null.</exception>
        public LoggingServiceBuilder WithFileLogger(string outputPath = null)
        {
            ILogWriter writer = LogWriterFactory.Create(LogWriterType.FileWriter, outputPath);

            if (writer == null)
            {
                throw new InvalidOperationException("Failed to create FileLogger. The returned ILogWriter is null.");
            }

            loggingServices.AddService(writer);

            return this;
        }

        /// <summary>
        /// Builds and returns an instance of <see cref="IServiceCollection{ILogWriter}"/> containing the configured log writers.
        /// </summary>
        /// <returns>An <see cref="IServiceCollection{ILogWriter}"/> instance with the configured log writers.</returns>
        /// <exception cref="InvalidOperationException">Thrown when no services have been added.</exception>
        public IServiceCollection<ILogWriter> Build()
        {
            if (loggingServices.GetServices().Count() == 0)
            {
                throw new InvalidOperationException("No log writers have been added. Please add at least one log writer before building.");
            }

            return loggingServices;
        }
    }
}
