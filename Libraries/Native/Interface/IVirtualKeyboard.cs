using UnityEngine;

namespace Native
{
    /// <summary>
    /// Represents an interface for a virtual keyboard used in Unity applications.
    /// </summary>
    /// <remarks>
    /// This interface is intended for use with Unity's touch keyboard functionality. 
    /// For more information on Unity's touch keyboard, refer to the 
    /// <a href="https://docs.unity3d.com/Manual/script-TouchKeyboard.html">Unity Touch Keyboard Documentation</a>.
    /// </remarks>
    public interface IVirtualKeyboard
    {
        /// <summary>
        /// Displays the virtual keyboard to the user with various customization options.
        /// </summary>
        /// <param name="prompt">
        /// The prompt text to display to the user. If <c>null</c>, no prompt will be shown.
        /// </param>
        /// <param name="keyboardType">
        /// The type of keyboard to display. Defaults to <see cref="TouchScreenKeyboardType.Default"/>.
        /// For more options, refer to the 
        /// <a href="https://docs.unity3d.com/ScriptReference/TouchScreenKeyboardType.html">TouchScreenKeyboardType Documentation</a>.
        /// </param>
        /// <param name="enableAutoCorrection">
        /// Whether to enable auto-correction. Defaults to <c>false</c>.
        /// </param>
        /// <param name="useMultiLines">
        /// Whether to allow multiple lines of input. Defaults to <c>false</c>.
        /// </param>
        /// <param name="secure">
        /// Whether to use secure input mode (e.g., for password input). Defaults to <c>false</c>.
        /// </param>
        /// <param name="enableAlert">
        /// Whether to enable an alert message. Defaults to <c>false</c>.
        /// </param>
        /// <param name="initialText">
        /// The initial text to display in the input field. If <c>null</c>, no initial text will be shown.
        /// </param>
        /// <param name="maxTextLength">
        /// The maximum length of the input text. Defaults to <c>100</c>.
        /// </param>
        /// <remarks>
        /// For additional details on using these parameters with Unity's touch keyboard, refer to the
        /// <a href="https://docs.unity3d.com/Manual/script-TouchKeyboard.html">Unity Touch Keyboard Documentation</a>.
        /// </remarks>
        void Show(string prompt = null, TouchScreenKeyboardType keyboardType = TouchScreenKeyboardType.Default, 
            bool enableAutoCorrection = false, bool useMultiLines = false, bool secure = false, bool enableAlert = false, 
            string initialText = null, int maxTextLength = 100);
    }
}
