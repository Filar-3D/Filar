using System;
using System.Collections.Generic;

namespace Common
{
    /// <summary>
    /// Defines a contract for managing a collection of <typeparamref name="T"/> instances.
    /// </summary>
    /// <typeparam name="T">The type of service to manage.</typeparam>
    public interface IServiceCollection<T> where T : class
    {
        /// <summary>
        /// Adds a service to the collection.
        /// </summary>
        /// <param name="value">The service to add. Must be of type <typeparamref name="T"/>.</param>
        void AddService(T value);

        /// <summary>
        /// Removes a service from the collection.
        /// </summary>
        /// <param name="value">The service to remove. Must be of type <typeparamref name="T"/>.</param>
        void RemoveService(T value);

        /// <summary>
        /// Retrieves a collection of all services of type <typeparamref name="T"/>.
        /// </summary>
        /// <returns>An enumerable collection of services of type <typeparamref name="T"/>.</returns>
        IEnumerable<T> GetServices();

        /// <summary>
        /// Clears all services from the collection.
        /// </summary>
        void ClearServices();
    }
}
