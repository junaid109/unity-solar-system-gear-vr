using System;
using UnityEngine;

namespace TechTest.SolarSystem
{
    [Serializable]
    public class Planet
    {
        [SerializeField]
        public string name;

        [SerializeField]
        public string colour;

        [SerializeField]
        public float earthSizeRatio;

        [SerializeField]
        public float earthOrbitalVelocityRatio;

        [SerializeField]
        public float distanceFromSun;

        [SerializeField]
        public string distanceUnits;

        [SerializeField]
        public string text;
    }
}
