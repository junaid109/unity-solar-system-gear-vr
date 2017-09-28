using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

namespace TechTest.SolarSystem
{
    /// <summary>
    /// Input controller handles input from user headset and keyboard
    /// </summary>
    public class InputController : MonoBehaviour
    {
        [Tooltip("The rate at which the camera will move/rotate")]
        public float speed = 1.5f;

        private void Update()
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(new Vector3(0, speed * Time.deltaTime, 0));
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(new Vector3(0, -speed * Time.deltaTime, 0));
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(new Vector3(0, 0, -speed * Time.deltaTime));
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
            }
        }
    }
}

