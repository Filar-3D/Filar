using Common;
using Debugger;
using UnityEngine;

namespace Native
{
    /// <summary>
    /// A generic singleton base class for MonoBehaviour types.
    /// <para>Provides a singleton instance of the derived class.</para>
    /// <para>For more information on singletons, see <a href="https://en.wikipedia.org/wiki/Singleton_pattern">Singleton Pattern on Wikipedia</a>.</para>
    /// </summary>
    /// <typeparam name="T">The type of the singleton instance, which must be a MonoBehaviour.</typeparam>
    public abstract class Singleton<T>: BaseLogBehaviour where T : MonoBehaviour
    {
        private static T instance;

        /// <summary>
        /// Gets the singleton instance of the specified type.
        /// <para>Finds the singleton instance if it does not already exist.</para>
        /// <para>For more information on finding objects of a type, see <a href="https://docs.unity3d.com/ScriptReference/Object.FindObjectOfType.html">FindObjectOfType in Unity Documentation</a>.</para>
        /// </summary>
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<T>();
                }

                return instance;
            }
        }

        /// <summary>
        /// Indicates whether the singleton instance should not be destroyed on scene load.
        /// <para>If set to true, the instance will persist between scenes.</para>
        /// <para>For more information on this behavior, see <a href="https://docs.unity3d.com/ScriptReference/Object.DontDestroyOnLoad.html">DontDestroyOnLoad in Unity Documentation</a>.</para>
        /// </summary>
        [field: SerializeField]
        public bool DoNotDestroyOnLoad { get; set; }

        /// <summary>
        /// Initializes the singleton instance and handles persistence across scene loads if <see cref="DoNotDestroyOnLoad"/> is true.
        /// <para>Also ensures that only one instance of the singleton exists in the scene. If another instance is found, it will be destroyed.</para>
        /// </summary>
        /// <param name="loggingService">An instance of <see cref="IServiceCollection{ILogWriter}"/> used for logging.</param>
        public override void Init(IServiceCollection<ILogWriter> loggingService)
        {
            base.Init(loggingService);

            if(DoNotDestroyOnLoad)
            {
                DontDestroyOnLoad(this);

                if (instance != null && instance != this)
                {
                    Destroy(instance.gameObject);
                }
                else
                {
                    instance = this as T;
                }
            }
        }
    }
}
