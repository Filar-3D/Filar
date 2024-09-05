using Common;
using UnityEngine;

namespace Extensions
{
    /// <summary>
    /// Provides extension methods for the <see cref="string"/> class.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Formats the given string by applying color and optional bold formatting.
        /// </summary>
        /// <param name="str">The string to be formatted.</param>
        /// <param name="color">The <see cref="ColorRef"/> enumeration value representing the color to apply to the string.</param>
        /// <param name="isBold">A boolean value indicating whether the string should be rendered in bold. Defaults to <c>false</c>.</param>
        /// <returns>A formatted string with the specified color and optional bold styling applied.</returns>
        /// <remarks>
        /// This method wraps the input string with Unity's rich text color tags and optionally with bold tags based on the 
        /// <paramref name="isBold"/> parameter. The color is determined by the <paramref name="color"/> parameter, which is 
        /// converted to its lowercase string representation using the <see cref="ColorRef"/> extension method <see cref="GetColorValue"/>.
        /// </remarks>
        public static string FormatString(this string str, ColorRef color, bool isBold = false)
        {
            string stringWithFontWeight = isBold ? $"<b>{str}</b>" : str;
            string newString = $"<color={color.GetColorValue()}>{stringWithFontWeight}</color>";

            return newString;
        }

        public static string FormatString(this string str, Color32 color, bool isBold = false)
        {
            string stringWithFontWeight = isBold ? $"<b>{str}</b>" : str;
            string newString = $"<color={color}>{stringWithFontWeight}</color>";

            return newString;
        }
    }
}
