using System;
using System.Collections.Generic;
using System.Linq;
using Common;

namespace Debugger.Services
{
    /// <summary>
    /// Provides a collection for managing <see cref="ILogWriter"/> services.
    /// Implements the <see cref="IServiceCollection{IWriter}"/> interface.
    /// </summary>
    public class LoggingServices: IServiceCollection<ILogWriter>
    {
        private List<ILogWriter> logWriters;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoggingServices"/> class with an optional set of initial services.
        /// </summary>
        /// <param name="args">An array of <see cref="ILogWriter"/> instances to initialize the collection with.</param>
        public LoggingServices(params ILogWriter[] args)
        {
            logWriters = args.ToList();
        }

        /// <summary>
        /// Adds a service to the collection.
        /// </summary>
        /// <param name="value">The <see cref="ILogWriter"/> service to add. Must not be null.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is null.</exception>
        public void AddService(ILogWriter value)
        {
            if(value == null)
            {
                throw new ArgumentNullException(nameof(value), "Service value cannot be null.");
            }
 
            logWriters.Add(value);
        }

        /// <summary>
        /// Removes a service from the collection.
        /// </summary>
        /// <param name="value">The <see cref="ILogWriter"/> service to remove. Must not be null.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when <paramref name="value"/> is not found in the collection.</exception>
        public void RemoveService(ILogWriter value)
        {
            if (value == null)
            {
                    throw new ArgumentNullException(nameof(value), "Service value cannot be null.");
            }

            if(!logWriters.Contains(value))
            {
                throw new InvalidOperationException("Service value not found in the collection.");
            }

            logWriters.Remove(value);
        }

        /// <summary>
        /// Retrieves a read-only collection of all services.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{IWriter}"/> containing all services in the collection.</returns>
        public IEnumerable<ILogWriter> GetServices()
        {
            return logWriters;
        }


        /// <summary>
        /// Clears all services from the collection.
        /// </summary>
        public void ClearServices()
        {
            logWriters.Clear();
        }
    }
}
