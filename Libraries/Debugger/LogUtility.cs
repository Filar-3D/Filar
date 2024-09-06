using System;
using System.Diagnostics;
using System.IO;

namespace Debugger
{
    public static class LogUtility
    {
        public static (string filePath, string fileName, string methodName, int lineNumber) GetLogInfo()
        {
            // Create a stack trace from the current context.
            StackTrace stackTrace = new StackTrace(true);
            StackFrame[] stackFrames = stackTrace.GetFrames();

            if( stackFrames == null )
            {
                throw new InvalidOperationException("Couldn't get frames from a stack trace.");
            }

            string filePath = string.Empty;
            string fileName =  string.Empty;
            string methodName = string.Empty;
            int lineNumber = 0;

            // Filtering the stack frames to find the matching stack frame for the calling class file.
            foreach (var frame in stackFrames)
            {
                if(frame != null && IsApplicationFile(frame: frame))
                {
                    // Get file directory information.
                    filePath = frame.GetFileName();
                    fileName = Path.GetFileName(filePath);

                    // Get file log position.
                    methodName = frame.GetMethod()?.Name ?? string.Empty;
                    lineNumber = frame.GetFileLineNumber();

                    break;
                }
            }

            return (filePath: filePath, fileName: fileName, methodName: methodName, lineNumber: lineNumber);

        }

        private static bool IsApplicationFile(StackFrame frame)
        {
            string fileName = frame.GetFileName();

            return !string.IsNullOrEmpty(fileName) && 
                fileName.Contains(Environment.CurrentDirectory) &&
                !fileName.Contains("Libraries");
        }
    }
}
