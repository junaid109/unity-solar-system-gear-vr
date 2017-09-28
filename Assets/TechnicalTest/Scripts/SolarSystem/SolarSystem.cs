using System.Collections.Generic;
using System;

namespace TechTest.SolarSystem
{
    [Serializable]
    public class SolarSystem
    {
        public string name;

        public Star Star;

        public List<Planet> Planets;

        public List<CameraPos> CameraPos;
    }
}
