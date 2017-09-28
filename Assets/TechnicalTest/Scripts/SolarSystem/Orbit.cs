using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TechTest.SolarSystem
{
    /// <summary>
    /// Class responsible for handling orbit of planet around a center object
    /// </summary>
    public class Orbit : MonoBehaviour
    {
        [HideInInspector]
        public GameObject orbitAroundObject;

        [HideInInspector]
        public float orbitVelcityRatio;

        [HideInInspector]
        public float rotationRate;

        [HideInInspector]
        public float radius;

        [HideInInspector]
        private float angle;

        void Start()
        {
            orbitAroundObject = GameObject.Find("Sun");

            angle = Random.Range(0, 360);
        }

        void Update()
        {
            float originX = orbitAroundObject.transform.localPosition.x;

            float originY = orbitAroundObject.transform.localPosition.z;

            // The X and Y coordinates of this object in a 2D space, calculated using the polar coordinates (Radius and Angle) of this object
            float circleX = (originX + (radius * Mathf.Cos(angle)));

            float circleY = (originY + (radius * Mathf.Sin(angle)));

            // Update this object to its new position and rotation
            transform.localPosition = new Vector3(circleX, orbitAroundObject.transform.localPosition.y, circleY);

            transform.Rotate(new Vector3(0, -rotationRate, 0));

            // Increase the angle according to the given Orbit Speed
            angle += (orbitVelcityRatio/1000 * Time.deltaTime) / 10;
        }
    }
}
