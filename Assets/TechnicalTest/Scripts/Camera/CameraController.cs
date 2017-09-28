using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

namespace TechTest.SolarSystem
{
    /// <summary>
    /// This class controls navigation between camera positions
    /// </summary>
    public class CameraController : MonoBehaviour
    {
        // Public reference to camera prefab
        public GameObject camera;

        // List of gameobjects to hold cameras
        private List<GameObject> cameraList = new List<GameObject>();

        // Referenc to input script
        private VRInput input;

        // Our current camera index
        private int curCamera;

        public int CurCamera
        {
            get
            {
                return curCamera;
            }

            set
            {
                curCamera = value;
            }
        }

        private void Awake()
        {
            input = GetComponent<VRInput>();    
        }

        private void Start()
        {

            CurCamera = 0;     
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                NextCamera();
            }

            if (Input.GetKeyDown(KeyCode.V))
            {
                PreviousCamera();
            }
        }


        public void Initialise(SolarSystemContainer creationData)
        {
            CreateCameras(creationData);
        }

        /// <summary>
        /// On Enable we subscribe delegate onswipe to method
        /// </summary>
        private void OnEnable()
        {
            input.OnSwipe += HandleSwipe;
        }

        /// <summary>
        /// On Enable we unsubscribe delegate onswipe to method
        /// </summary>
        private void OnDisable()
        {
            input.OnSwipe -= HandleSwipe;
        }

        /// <summary>
        /// Method to handle swipe input from user
        /// </summary>
        /// <param name="swipeDirection"></param>
        private void HandleSwipe(VRInput.SwipeDirection swipeDirection)
        {
            switch (swipeDirection)
            {
                case VRInput.SwipeDirection.NONE:
                    break;

                case VRInput.SwipeDirection.UP:
                    PreviousCamera();
                    break;

                case VRInput.SwipeDirection.DOWN:
                    NextCamera();
                    break;

                case VRInput.SwipeDirection.LEFT:
                    break;

                case VRInput.SwipeDirection.RIGHT:
                    break;
            }
        }


        /// <summary>
        /// Method instantiates camera and assigns the positoin and rotation
        /// </summary>
        /// <param name="creationData"></param>
        private void CreateCameras(SolarSystemContainer creationData)
        {
            var cameraPositions = creationData.SolarSystem.CameraPos;

            for (int i = 0; i < cameraPositions.Count; i++)
            {
                Quaternion rotations = Quaternion.Euler(cameraPositions[i].Rotation);

                cameraList.Add(Instantiate(camera, cameraPositions[i].Position, rotations));

                cameraList[i].transform.parent = transform.parent;

                for (int x = 0; x < cameraList.Count; x++)
                {
                    cameraList[i].gameObject.SetActive(false);
                }

                if (cameraList.Count > 0)
                {
                    cameraList[0].gameObject.SetActive(true);
                }
            }
        }

        /// <summary>
        /// We activate the next camera in list
        /// </summary>
        public void NextCamera()
        {
            CurCamera++;

            if (CurCamera < cameraList.Count)
            {
                cameraList[CurCamera - 1].gameObject.SetActive(false);

                cameraList[CurCamera].gameObject.SetActive(true);
            }
            else
            {
                cameraList[CurCamera - 1].gameObject.SetActive(false);

                CurCamera = 0;

                cameraList[CurCamera].gameObject.SetActive(true);
            }
        }

        /// <summary>
        /// We activate previous cmera in the list
        /// </summary>
        public void PreviousCamera()
        {
            if (curCamera > 0)
            {
                cameraList[CurCamera].gameObject.SetActive(false);

                CurCamera -= 1;

                cameraList[CurCamera].gameObject.SetActive(true);
            }
         
        }
    }
}
