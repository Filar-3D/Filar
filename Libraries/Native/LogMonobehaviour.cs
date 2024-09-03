using Debugger;
using UnityEngine;

namespace Native
{
    /// <summary>
    /// 
    /// </summary>
    public class LogMonoBehaviour: MonoBehaviour, Debugger.ILogger
    {
        [field: SerializeField]
        public Debugger.LogVerbosity EnabledLogVerbosity { get; private set; }

        public void Log()
        {

        }
    }
}
