using System.Runtime.InteropServices;

namespace Debugger
{
    public class LogFileWriter : ILogWriter
    {
        public string OutputPath{ get; set; }

        public LogFileWriter(string outputPath)
        {
            if(outputPath != null)
            {
                OutputPath = outputPath;
            }
            else
            {
                OutputPath = RuntimeEnvironment.GetRuntimeDirectory()?.ToString();
            }
        }

        public void Write(LogVerbosity verbosity, string log, params object[] args)
        {
            string path = !string.IsNullOrEmpty(OutputPath)? OutputPath : RuntimeEnvironment.GetRuntimeDirectory()?.ToString();

            UnityEngine.Debug.LogFormat($"Creating log file at path", path);
        }
    }
}
