using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NightVisionScript : MonoBehaviour
{
    private Image zoomBar;
    private Image batteryChunks;
    private Camera cam;
    public float batteryPower = 1.0f;
    public float drainTime = 60f;
    
    void Start()
    {
        zoomBar = GameObject.Find("ZoomBar").GetComponent<Image>();
        cam = GameObject.Find("FirstPersonCharacter").GetComponent<Camera>();
        batteryChunks = GameObject.Find("BatteryChunks").GetComponent<Image>();
        InvokeRepeating("BatteryDrain", drainTime, drainTime);
    }
    
    private void OnEnable()
    {
        if (zoomBar != null)
        {
            zoomBar.fillAmount = 0.6f;
        }
    }
    
    void Update()
    {
        ZoomIn();
    }

    private void ZoomIn()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (cam.fieldOfView > 10)
            {
                cam.fieldOfView -= 5;
                zoomBar.fillAmount = cam.fieldOfView / 100;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (cam.fieldOfView < 60)
            {
                cam.fieldOfView += 5;
                zoomBar.fillAmount = cam.fieldOfView / 100;
            }
        }
        batteryChunks.fillAmount = batteryPower;
    }

    private void BatteryDrain()
    {
        if (batteryPower > 0.0f)
        {
            batteryPower -= 0.25f;
        }
    }
}
