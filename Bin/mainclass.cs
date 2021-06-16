using System;
using BepInEx;
using UnityEngine;
namespace MuckZoom
{
    [BepInPlugin("org.P0pMan20.plugins.MuckZoom", "MuckZoom", "1.0.0.0")]
    public class ZoomPlugin : BaseUnityPlugin
    {
        float m_FOV;
        float savedFOV;
        void Awake()
        {
            UnityEngine.Debug.Log("Hello World!! Dab");
            m_FOV = 85.0f;
            savedFOV = 370.0f;
        }
        void Update()
        {
            if (savedFOV == 370.0f){
                savedFOV = Camera.main.fieldOfView;
            }
            Camera.main.fieldOfView = m_FOV;
            if (Input.GetKeyDown(KeyCode.V)){
                UnityEngine.Debug.Log("ZoomIn");
                m_FOV = 30.0f;
                

            }
            if (Input.GetKeyUp(KeyCode.V)){
                UnityEngine.Debug.Log("ZoomOut");
                m_FOV = savedFOV;
                }
            // credit : https://answers.unity.com/questions/897268/mouse-scroll-up-or-down.html
            if (Input.GetKey(KeyCode.V)){
                if (Input.GetAxis("Mouse ScrollWheel") > 0f) //mouse goo forward
                {
                    m_FOV = m_FOV - 5.0f;
                }
                if (Input.GetAxis("Mouse ScrollWheel") < 0f) //mouse goo back
                {
                    m_FOV = m_FOV +5.0f;
                }
                if (m_FOV <= 0f){
                    m_FOV = 1.0f;
                }
            }
        }
    }
}