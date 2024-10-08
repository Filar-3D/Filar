﻿using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using Debugger;
using Debugger.Services;
using UnityEngine;

namespace Native
{
    /// <summary>
    /// Handles logging for the game by using a list of <see cref="ILogWriter"/> instances.
    /// Provides methods to log messages with different verbosity levels, including <see cref="LogVerbosity"/> levels.
    /// </summary>
    public class BaseLogBehaviour: MonoBehaviour, Debugger.ILogger
    {
        private List<ILogWriter> logWriters;

        /// <summary>
        /// Gets or sets the list of <see cref="ILogWriter"/> instances used to handle log output.
        /// If not set, a default <see cref="UnityConsoleLogWriter"/> is used.
        /// </summary>
        public List<ILogWriter> LogWriters
        {
            get
            {
                if(logWriters == null)
                {
                    // Creating a default log writer incase there's no value assigned.
                    logWriters = new List<ILogWriter> { new UnityConsoleLogWriter() };
                }

                return logWriters;
            }
            set
            {
                if(value != null)
                {
                    logWriters = value;
                }
            }
        }

        /// <summary>
        /// Gets the verbosity level for logging. Only logs with a verbosity level
        /// equal to or higher than this value will be processed.
        /// </summary>
        [field: SerializeField]
        public LogVerbosity EnabledLogVerbosity { get; private set; }

        private void Awake()
        {
            LoggingServiceBuilder serviceBuilder = new LoggingServiceBuilder();
            IServiceCollection<ILogWriter> service = serviceBuilder.WithUnityConsoleLogger().WithFileLogger().Build();
            Init(service);
        }

        /// <summary>
        /// Initializes the log writers using the provided logging service collection.
        /// </summary>
        /// <param name="loggingService">An instance of <see cref="IServiceCollection{ILogWriter}"/> from which to initialize log writers.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="loggingService"/> is null.</exception>
        /// <exception cref="InvalidCastException">Thrown when <paramref name="loggingService"/> is not an instance of <see cref="LoggingServices"/>.</exception>
        public virtual void Init(IServiceCollection<ILogWriter> loggingService)
        {
            if (loggingService == null)
            {
                ThrowException(new ArgumentNullException(nameof(loggingService), "Logging service collection cannot be null."));
            }

            LoggingServices loggingServices = loggingService as LoggingServices;

            if (loggingServices == null)
            {
                ThrowException(new InvalidCastException("The provided logging service collection is not of type LoggingServices."));
            }

            logWriters = loggingServices.GetServices().ToList();

            if(logWriters == null)
            {
                ThrowException(new InvalidOperationException("There were no log writers found."));
            }

            // Clear previous logs if any.
            foreach (ILogWriter logWriter in logWriters)
            {
                logWriter.Clear();
            }
        }

        /// <summary>
        /// Logs a message with the specified <see cref="LogVerbosity"/> level.
        /// </summary>
        /// <param name="verbosity">The verbosity level of the log.</param>
        /// <param name="message">The message to log.</param>
        /// <param name="args">Arguments to format the log message.</param>
        public void Log(LogVerbosity verbosity, string message, params object[] args)
        {
            if (EnabledLogVerbosity < verbosity)
            {
                return;
            }


            foreach (ILogWriter writer in LogWriters)
            {
                writer.Write(gameObject.name, verbosity, message, args);
            }
        }

        /// <summary>
        /// Logs an informational message.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="args">Arguments to format the log message.</param>
        public void LogInfo(string message, params object[] args)
        {
            LogVerbosity verbosity = LogVerbosity.Info;

            if (EnabledLogVerbosity < verbosity)
            {
                return;
            }

            foreach (ILogWriter writer in LogWriters)
            {
                writer.Write(gameObject.name, verbosity, message, args);
            }
        }

        /// <summary>
        /// Logs a warning message.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="args">Arguments to format the log message.</param>
        public void LogWarning(string message, params object[] args)
        {
            LogVerbosity verbosity = LogVerbosity.Warning;

            if (EnabledLogVerbosity < verbosity)
            {
                return;
            }

            foreach (ILogWriter writer in LogWriters)
            {
                writer.Write(gameObject.name, verbosity, message, args);
            }
        }

        /// <summary>
        /// Logs an error message.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="args">Arguments to format the log message.</param>
        public void LogError(string message, params object[] args)
        {
            LogVerbosity verbosity = LogVerbosity.Error;

            if (EnabledLogVerbosity < verbosity)
            {
                return;
            }

            foreach (ILogWriter writer in LogWriters)
            {
                writer.Write(gameObject.name, verbosity, message, args);
            }
        }

        /// <summary>
        /// Logs an exception and then throws it.
        /// </summary>
        /// <param name="exception">The exception to log and throw.</param>
        public void ThrowException(Exception exception)
        {
            LogVerbosity verbosity = LogVerbosity.Exception;

            foreach (ILogWriter writer in LogWriters)
            {
                writer.Write(gameObject.name, verbosity, exception.Message);
            }

            throw exception;
        }
    }
}
