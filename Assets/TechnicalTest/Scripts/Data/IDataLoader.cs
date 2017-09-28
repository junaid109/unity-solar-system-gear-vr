using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TechTest.SolarSystem
{
    public interface IDataLoader
    {
        void Initialise(SolarSystemContainer systemCreatorData);

        SolarSystemContainer ProcessJsonData(SolarSystemContainer systemCreatorData, string jsonData);
    }
}