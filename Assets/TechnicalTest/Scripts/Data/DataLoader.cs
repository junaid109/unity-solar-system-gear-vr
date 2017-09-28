using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TechTest.SolarSystem
{
    /// <summary>
    /// This class loads data from a url, which is the processed from json
    /// </summary>
    public class DataLoader : MonoBehaviour, IDataLoader
    {
        private SolarSystemCreator systemCreator;

        private CameraController cameraController;

        void Start()
        {
            systemCreator = GetComponentInParent<SolarSystemCreator>();

            cameraController = GetComponentInChildren<CameraController>();
        }

        public void Initialise(SolarSystemContainer creationData)
        {
            StartCoroutine("LoadResourceData", creationData);
        }

        /// <summary>
        /// Method loads data from url
        /// </summary>
        /// <param name="systemCreatorData"></param>
        /// <returns></returns>
        IEnumerator LoadResourceData(SolarSystemContainer systemCreatorData)
        {
            WWW www = new WWW(Utils.dataURL);

            yield return www;
            try
            {
                if (www.error == null)
                {
                    ProcessJsonData(systemCreatorData, www.text);
                }
            }
            catch (Exception ex)
            {
                Debug.Log("Error: Failed to load data from URL " + ex);
            }
            finally
            {
                www.Dispose();
            }
        }

        /// <summary>
        /// Method of type solar system container to proecss data
        /// </summary>
        /// <param name="systemCreatorData"></param>
        /// <param name="jsonData"></param>
        /// <returns></returns>
        public SolarSystemContainer ProcessJsonData(SolarSystemContainer systemCreatorData, string jsonData)
        {
            systemCreatorData = JsonUtility.FromJson<SolarSystemContainer>(jsonData);

            systemCreator.Initialise(systemCreatorData);

            cameraController.Initialise(systemCreatorData);

            return systemCreatorData;
       }
    }
}
