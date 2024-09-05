using UnityEngine;

namespace Common
{
    /// <summary>
    /// Provides a collection of predefined colors for use in Unity.
    /// </summary>
    /// <remarks>
    /// The colors are defined using the <see cref="Color32"/> structure, which uses RGBA values ranging from 0 to 255.
    /// </remarks>
    public static class ColorUtility
    {
        /// <summary>
        /// The color red. Represents the color with maximum red and no green or blue.
        /// </summary>
        /// <remarks>
        /// <see cref="Color32"/> values: (255, 0, 0, 255)
        /// </remarks>
        public static Color32 Red = new Color32(0xFF, 0x00, 0x00, 0xFF);

        /// <summary>
        /// The color green. Represents the color with maximum green and no red or blue.
        /// </summary>
        /// <remarks>
        /// <see cref="Color32"/> values: (0, 255, 0, 255)
        /// </remarks>
        public static Color32 Green = new Color32(0x00, 0xFF, 0x00, 0xFF);

        /// <summary>
        /// The color blue. Represents the color with maximum blue and no red or green.
        /// </summary>
        /// <remarks>
        /// <see cref="Color32"/> values: (0, 0, 255, 255)
        /// </remarks>
        public static Color32 Blue = new Color32(0x00, 0x00, 0xFF, 0xFF);

        /// <summary>
        /// The color white. Represents the color with maximum red, green, and blue.
        /// </summary>
        /// <remarks>
        /// <see cref="Color32"/> values: (255, 255, 255, 255)
        /// </remarks>
        public static Color32 White = new Color32(0xFF, 0xFF, 0xFF, 0xFF);

        /// <summary>
        /// The color black. Represents the color with no red, green, or blue.
        /// </summary>
        /// <remarks>
        /// <see cref="Color32"/> values: (0, 0, 0, 255)
        /// </remarks>
        public static Color32 Black = new Color32(0x00, 0x00, 0x00, 0xFF);

        /// <summary>
        /// The color yellow. Represents the color with maximum red and green, and no blue.
        /// </summary>
        /// <remarks>
        /// <see cref="Color32"/> values: (255, 255, 0, 255)
        /// </remarks>
        public static Color32 Yellow = new Color32(0xFF, 0xFF, 0x00, 0xFF);

        /// <summary>
        /// The color cyan. Represents the color with maximum green and blue, and no red.
        /// </summary>
        /// <remarks>
        /// <see cref="Color32"/> values: (0, 255, 255, 255)
        /// </remarks>
        public static Color32 Cyan = new Color32(0x00, 0xFF, 0xFF, 0xFF);

        /// <summary>
        /// The color magenta. Represents the color with maximum red and blue, and no green.
        /// </summary>
        /// <remarks>
        /// <see cref="Color32"/> values: (255, 0, 255, 255)
        /// </remarks>
        public static Color32 Magenta = new Color32(0xFF, 0x00, 0xFF, 0xFF);

        /// <summary>
        /// The color gray. Represents a neutral color with equal red, green, and blue values.
        /// </summary>
        /// <remarks>
        /// <see cref="Color32"/> values: (128, 128, 128, 255)
        /// </remarks>
        public static Color32 Gray = new Color32(0x80, 0x80, 0x80, 0xFF);

        /// <summary>
        /// The color light gray. Represents a lighter shade of gray.
        /// </summary>
        /// <remarks>
        /// <see cref="Color32"/> values: (211, 211, 211, 255)
        /// </remarks>
        public static Color32 LightGray = new Color32(0xD3, 0xD3, 0xD3, 0xFF);

        /// <summary>
        /// The color dark gray. Represents a darker shade of gray.
        /// </summary>
        /// <remarks>
        /// <see cref="Color32"/> values: (169, 169, 169, 255)
        /// </remarks>
        public static Color32 DarkGray = new Color32(0xA9, 0xA9, 0xA9, 0xFF);

        /// <summary>
        /// The color orange. Represents a color with maximum red and moderate green, and no blue.
        /// </summary>
        /// <remarks>
        /// <see cref="Color32"/> values: (255, 165, 0, 255)
        /// </remarks>
        public static Color32 Orange = new Color32(0xFF, 0xA5, 0x00, 0xFF);

        /// <summary>
        /// The color purple. Represents a color with maximum blue and moderate red, and no green.
        /// </summary>
        /// <remarks>
        /// <see cref="Color32"/> values: (128, 0, 128, 255)
        /// </remarks>
        public static Color32 Purple = new Color32(0x80, 0x00, 0x80, 0xFF);

        /// <summary>
        /// The color pink. Represents a color with maximum red and moderate blue, and no green.
        /// </summary>
        /// <remarks>
        /// <see cref="Color32"/> values: (255, 192, 203, 255)
        /// </remarks>
        public static Color32 Pink = new Color32(0xFF, 0xC0, 0xCB, 0xFF);

        /// <summary>
        /// The color brown. Represents a color with high red and green, and a moderate amount of blue.
        /// </summary>
        /// <remarks>
        /// <see cref="Color32"/> values: (165, 42, 42, 255)
        /// </remarks>
        public static Color32 Brown = new Color32(0xA5, 0x2A, 0x2A, 0xFF);
    }
}
