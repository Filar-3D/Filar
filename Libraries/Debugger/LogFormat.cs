using Common;
using Extensions;
using System;
using System.Text.RegularExpressions;
using UnityEngine;

namespace Debugger
{
    /// <summary>
    /// Provides utility methods for formatting log messages with verbosity and color.
    /// </summary>
    /// <remarks>
    /// This class contains methods to format log messages with color coding and verbosity levels. 
    /// It helps in creating consistent and visually distinguishable log messages based on the verbosity level.
    /// </remarks>
    public static class LogFormat
    {
        /// Formats a log message with verbosity, message content, and an optional root class name.
        /// </summary>
        /// <typeparam name="T">The type of the root class. Must be a class.</typeparam>
        /// <param name="verbosity">The level of verbosity for the log message.</param>
        /// <param name="message">The message to be logged.</param>
        /// <param name="rootClass">An optional root class providing context for the log message. Can be <c>null</c>.</param>
        /// <returns>A formatted log message string with verbosity, message, and root class information, all color-coded appropriately.</returns>
        /// <remarks>
        /// This method generates a formatted log message string that includes:
        /// <list type="bullet">
        /// <item><description>The verbosity level in color and bold formatting.</description></item>
        /// <item><description>The log message in white color and bold formatting.</description></item>
        /// <item><description>The root class name in magenta color and bold formatting, or a placeholder if the root class is <c>null</c>.</description></item>
        /// </list>
        /// The verbosity level's color is determined by the <see cref="GetLogVerbosityColor"/> method.
        /// </remarks>
        public static string GetConsoleLogFormatedString<T>(LogVerbosity verbosity, string message, T rootClass = null) where T : class
        {
            string rootName = (rootClass != null) ? rootClass.ToString() : "[Root class unassigned]";
            string formattedLogText = $"Log: [{verbosity.ToString().FormatString(color: GetLogVerbosityColor(verbosity), isBold: true)}] Message: {message.FormatString(color: ColorRef.White, isBold: true)} Root: {rootName.FormatString(color: ColorRef.Magenta, isBold: true)}";

            return formattedLogText;
        }

        /// <summary>
        /// Determines the color to be used for the log verbosity level.
        /// </summary>
        /// <param name="verbosity">The verbosity level to determine the color for.</param>
        /// <returns>The <see cref="ColorRef"/> representing the color associated with the specified verbosity level.</returns>
        /// <remarks>
        /// This method returns a <see cref="ColorRef"/> value that represents the color associated with the given verbosity level.
        /// The colors are used to visually distinguish between different log levels in the formatted output.
        /// </remarks>
        private static ColorRef GetLogVerbosityColor(LogVerbosity verbosity)
        {
            return verbosity switch
            {
                LogVerbosity.Info => ColorRef.Cyan,
                LogVerbosity.Warning => ColorRef.Yellow,
                LogVerbosity.Error => ColorRef.Red,
                LogVerbosity.Exception => ColorRef.Red,
                _=> ColorRef.White
            };
        }

        public static string GetFileLogFormatedString(string log)
        {
            string regexPattern = @"^[<color=/>\b]$";
            Regex regex = new Regex(regexPattern);

            return regex.Replace(log, string.Empty);
        }

        public static string GetFileLogFormatHeaderTemplate(LogFileFormatTemplate template, string dateTimeFormat = null)
        {
            string dateTimeStamp = DateTime.Now.ToString(dateTimeFormat);

            // TODO: Add more tamplates to choose from.
            switch (template)
            {
                case LogFileFormatTemplate.Default:

                    return $"[Log File] [{dateTimeStamp}]\n________________________________________________\n\n" +
                        $"[Runtime Info] - Product: {Application.productName}\n\t\t Company: {Application.companyName}\n\t\t Version: {Application.version}\n\t\t Platform: {Application.platform}\n\n" +
                        $"Tip - Trace: [GameObject][Class][Method][Line]\n________________________________________________\n\n[Logs generated from Unity version: {Application.unityVersion}]\n\n";
                default:
                    return $"Template header format: {template} is not found - TODO: Not yet implemented.";
            }
        }

        public static string GetFileLogFormatTemplate(string gameObjectName, LogVerbosity verbosity, LogFileFormatTemplate template, string dateTimeFormat, string logMessage, params object[] args)
        {
            string dateTimeStamp = DateTime.Now.ToString(dateTimeFormat);
            var classInfo = LogUtility.GetLogInfo();

            // TODO: Add more tamplates to choose from.
            switch (template)
            {
                case LogFileFormatTemplate.Default:
                  
                    string defaultLogMessageFormat = string.Format(logMessage, args);

                    return $"[{dateTimeStamp}] [{verbosity}]: {defaultLogMessageFormat} \n\t   [Trace]: GameObject={gameObjectName} Class={classInfo.fileName} Function={classInfo.methodName} Line=({classInfo.lineNumber})\n\t   " +
                        $"[Directory]: {classInfo.filePath}\n";
                case LogFileFormatTemplate.Standard:
                    string standardLogMessageFormat = string.Format(logMessage, args);

                    return $"[{dateTimeStamp}] {verbosity}: [{standardLogMessageFormat}]\n\t   Trace: [{gameObjectName}][{classInfo.fileName}][{classInfo.methodName}][{classInfo.lineNumber}]\n\t   " +
                        $"File Path: [{classInfo.filePath}]\n";
                default:
                    return $"Template content format: {template} is not found - TODO: Not yet implemented.";
            }
        }
    }
}
