using System;
using UnityEngine;

namespace Common
{
    /// <summary>
    /// This class contains extension methods for working with enums.
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="ColorRef"/> enumeration value to a lowercase string representation.
        /// </summary>
        /// <param name="color">The <see cref="ColorRef"/> enumeration value to be converted.</param>
        /// <returns>A lowercase string representation of the <see cref="ColorRef"/> value.</returns>
        /// <remarks>
        /// This method converts the enumeration value to its string representation using <see cref="Enum.ToString"/> 
        /// and then transforms it to lowercase. This is useful for scenarios where color names need 
        /// to be standardized or compared in a case-insensitive manner.
        /// </remarks>
        public static string GetColorValue(this ColorRef color)
        {
            return color.ToString().ToLower();
        }

        /// <summary>
        /// Converts a <see cref="ColorRef"/> enumeration value to a corresponding <see cref="Color"/>.
        /// </summary>
        /// <param name="color">The <see cref="ColorRef"/> value to convert.</param>
        /// <returns>The <see cref="Color"/> that corresponds to the specified <see cref="ColorRef"/> value.</returns>
        /// <remarks>
        /// This method maps the <see cref="ColorRef"/> enumeration values to the standard Unity <see cref="Color"/> values.
        /// If the <paramref name="color"/> parameter does not match any defined <see cref="ColorRef"/> value, <see cref="Color.clear"/> is returned.
        /// </remarks>
        /// <example>
        /// <code>
        /// ColorRef colorRef = ColorRef.Red;
        /// Color color = colorRef.GetColor();
        /// // color will be Color.red
        /// </code>
        /// </example>
        /// <seealso cref="ColorRef"/>
        public static Color GetColor(this ColorRef color)
        {
            return color switch
            {
                ColorRef.Red => Color.red,
                ColorRef.Green => Color.green,
                ColorRef.Blue => Color.blue,
                ColorRef.Yellow => Color.yellow,
                ColorRef.Magenta => Color.magenta,
                ColorRef.Cyan => Color.cyan,
                ColorRef.Gray => Color.gray,
                ColorRef.Grey => Color.grey,
                ColorRef.Black => Color.black,
                ColorRef.White => Color.white,
                _=> Color.clear
            };
        }
    }
}
