using System;
using System.Text;
using System.IO;
using UnityEngine;

namespace Debugger
{
    public class FileLogWriter : ILogWriter
    {
        private string _outputPath;

        public string OutputPath
        {
            get
            {
                if (_outputPath == null)
                {
                    string directory = Path.Combine(Environment.CurrentDirectory, "Logs");

                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }

                    string fileName = $"{Application.productName}-Logs.txt";
                    _outputPath = Path.Combine(directory, fileName); ;
                }

                return _outputPath;
            }
            set 
            {
                // TODO - Validate directory  first.
                _outputPath = value;
            }
        }

        public FileLogWriter(string outputPath = null)
        {
            if(!string.IsNullOrEmpty(outputPath))
            {
                OutputPath = outputPath;
            }
        }

        public void Write(LogVerbosity verbosity, string log, params object[] args)
        {
          
        }


        public void Write(string gameObjectName, LogVerbosity verbosity, string log, params object[] args)
        {
            if (!File.Exists(OutputPath))
            {
                using (FileStream stream = new FileStream(OutputPath, FileMode.Create, FileAccess.ReadWrite))
                {
                    using (StreamWriter writer = new StreamWriter(stream))
                    {
                        string logHeaderTemplate = LogFormat.GetFileLogFormatHeaderTemplate(template: LogFileFormatTemplate.Default, dateTimeFormat: "D");

                        writer.WriteLine(logHeaderTemplate);
                        writer.Close();
                    }

                    stream.Close();
                };
            }

            // Write log message to a file.
            using (var streamWriter = new StreamWriter(path: OutputPath, append: true, encoding: Encoding.UTF8))
            {
                string logContentTemplate = LogFormat.GetFileLogFormatTemplate(gameObjectName, verbosity: verbosity, template: LogFileFormatTemplate.Standard, dateTimeFormat: "hh:mm:ss", logMessage: log, args);

                streamWriter.WriteLine(logContentTemplate);
                streamWriter.Close();
            }
        }

        public void Clear()
        {
            if (File.Exists(OutputPath))
            {
                File.Delete(OutputPath);
            }
        }
    }
}
