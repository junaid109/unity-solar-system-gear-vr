using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

namespace TechTest.SolarSystem
{
    /// <summary>
    /// Utiltie class to contain static and constant data types
    /// </summary>
    public static class Utils
    {
        // Url of data source
        public const string dataURL = "https://api.myjson.com/bins/wz78j";

        public static readonly float rotationRange = UnityEngine.Random.Range(0.001f,0.01f);

        public static readonly float sunRotation = 0.13f;

        public const string sunMaterial = "Sun/SunBaseMat";

        public const string mercuryMaterial = "Planets/Mercury/MercuryBaseMat";

        public const string venusMaterial = "Planets/Venus/VenusBaseMat";

        public const string earthMaterial = "Planets/Earth/EarthBaseMat";

        public const string marsMaterial = "Planets/Mars/MarsBaseMat";

        public const string jupiterMaterial = "Planets/Jupiter/JupiterBaseMat";

        public const string saturnMaterial = "Planets/Saturn/SaturnBaseMat";

        public const string uranusMaterial = "Planets/Uranus/UranusBaseMat";

        public const string neptuneMaterial = "Planets/Neptune/NeptuneBaseMat";

        /// <summary>
        /// http://www.bugstacker.com/15/how-to-parse-a-hex-color-string-in-unity-c%23
        /// </summary>
        /// <param name="hexstring"></param>
        /// <returns></returns>
        public static Color Parse(string hexstring)
        {
            if (hexstring.StartsWith("#"))
            {
                hexstring = hexstring.Substring(1);
            }

            if (hexstring.StartsWith("0x"))
            {
                hexstring = hexstring.Substring(2);
            }

            if (hexstring.Length != 6)
            {
                throw new Exception(string.Format("{0} is not a valid color string.", hexstring));
            }

            byte r = byte.Parse(hexstring.Substring(0, 2), NumberStyles.HexNumber);

            byte g = byte.Parse(hexstring.Substring(2, 2), NumberStyles.HexNumber);

            byte b = byte.Parse(hexstring.Substring(4, 2), NumberStyles.HexNumber);

            return new Color32(r, g, b, 1);
        }

        /// <summary>
        /// Method to parse vector from a string file
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public static Vector3 ParseVector(string vector)
        {
            string[] vals = vector.Split(new char[] { ',', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);

            Vector3 myVec = new Vector3(
                float.Parse(vals[0]), 
                float.Parse(vals[1]), 
                float.Parse(vals[2])
                );

            return myVec;
        }
    }
}
