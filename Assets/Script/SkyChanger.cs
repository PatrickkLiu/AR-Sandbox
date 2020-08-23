using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Funly.SkyStudio
{
    public class SkyChanger : MonoBehaviour
    {
        public SkyProfile Sunny;
        public SkyProfile Nighty;
        public SkyProfile Cloudy;
        public SkyProfile Rainy;
        public SkyProfile Lightning;
        
        //we define the skycontroller here so that it could be used under both of the function below 
        private TimeOfDayController skycontroller;

        void Start()
        {
            skycontroller = GetComponent<TimeOfDayController>();
        }
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                skycontroller.skyProfile = Sunny;
            }
            
            if (Input.GetKeyDown(KeyCode.Keypad2))
            {
                skycontroller.skyProfile = Nighty;
            }

            if (Input.GetKeyDown(KeyCode.Keypad3))
            {
                skycontroller.skyProfile = Cloudy;
            }

            if (Input.GetKeyDown(KeyCode.Keypad4))
            {
                skycontroller.skyProfile = Rainy;
            }

            if (Input.GetKeyDown(KeyCode.Keypad5))
            {
                skycontroller.skyProfile = Lightning;
            }                                    
        }
    }    
}

