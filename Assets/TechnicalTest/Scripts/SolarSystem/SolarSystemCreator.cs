using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TechTest.SolarSystem
{
    /// <summary>
    /// This class is resonsible for creation of the solar system
    /// </summary>
    public class SolarSystemCreator : MonoBehaviour
    {
        private DataLoader dataLoader;

        private SolarSystemContainer creationData;

        private void Start()
        {
            creationData = new SolarSystemContainer();

            dataLoader = GetComponentInChildren<DataLoader>();

            dataLoader.Initialise(creationData);
        }

        /// <summary>
        /// Method to initialise creation of celestial objects
        /// </summary>
        /// <param name="creationData"></param>
        public void Initialise(SolarSystemContainer creationData)
        {
            CreateSun(creationData);

            CreatePlanets(creationData);

        }

        /// <summary>
        /// Mehtod to create instance of sun & assign its attributes
        /// </summary>
        /// <param name="creator"></param>
        public void CreateSun(SolarSystemContainer creationData)
        {
            var sunData = creationData.SolarSystem.Star;

            GameObject sun = GameObject.CreatePrimitive(PrimitiveType.Sphere);

            sun.gameObject.name = sunData.name.ToString();

            sun.gameObject.GetComponent<Renderer>().material.color = Utils.Parse(sunData.colour);

            sun.GetComponent<Renderer>().material = Resources.Load(Utils.sunMaterial) as Material;

            sun.gameObject.transform.localScale = Vector3.one * sunData.earthSizeRatio;

            sun.AddComponent<Orbit>();

            sun.GetComponent<Orbit>().orbitVelcityRatio = 0;

            sun.GetComponent<Orbit>().rotationRate = Utils.sunRotation;

            sun.GetComponent<Orbit>().radius = 0;

        }

        /// <summary>
        /// We create our plantes from json data provided and add orbit script to each object
        /// </summary>  
        /// <param name="creationData"></param>
        public void CreatePlanets(SolarSystemContainer creationData)
        {
            List<GameObject> planet = new List<GameObject>();

            var planetData = creationData.SolarSystem.Planets;

            for (int i = 0; i < planetData.Count; i++)
            {
                planet.Add(GameObject.CreatePrimitive(PrimitiveType.Sphere));

                planet[i].gameObject.transform.position = Vector3.forward * (planetData[i].distanceFromSun);

                planet[i].gameObject.name = planetData[i].name.ToString();

                planet[i].GetComponent<Renderer>().material.color = Utils.Parse(planetData[i].colour);

                planet[i].AddComponent<Orbit>();

                planet[i].GetComponent<Orbit>().orbitVelcityRatio = planetData[i].earthOrbitalVelocityRatio * 50;

                planet[i].GetComponent<Orbit>().rotationRate = Utils.rotationRange;

                planet[i].GetComponent<Orbit>().radius = planetData[i].earthSizeRatio * 100;
            }
            AssignPlanetMaterials(planet);
        }

        /// <summary>
        /// We load material onto planet stored in resources folder
        /// </summary>
        /// <param name="planets"></param>
        public void AssignPlanetMaterials(List<GameObject> planets)
        {

            planets[0].GetComponent<Renderer>().material = Resources.Load(Utils.mercuryMaterial) as Material;

            planets[1].GetComponent<Renderer>().material = Resources.Load(Utils.venusMaterial) as Material;      
            
            planets[2].GetComponent<Renderer>().material = Resources.Load(Utils.earthMaterial) as Material;

            planets[3].GetComponent<Renderer>().material = Resources.Load(Utils.marsMaterial) as Material;

            planets[4].GetComponent<Renderer>().material = Resources.Load(Utils.jupiterMaterial) as Material;

            planets[5].GetComponent<Renderer>().material = Resources.Load(Utils.saturnMaterial) as Material;

            planets[6].GetComponent<Renderer>().material = Resources.Load(Utils.uranusMaterial) as Material;

            planets[7].GetComponent<Renderer>().material = Resources.Load(Utils.neptuneMaterial) as Material;
        }
    }
}
