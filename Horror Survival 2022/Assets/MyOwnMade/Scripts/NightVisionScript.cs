using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NightVisionScript : MonoBehaviour
{
    private Image zoomBar;
    private Camera cam;
    
    void Start()
    {
        zoomBar = GameObject.Find("ZoomBar").GetComponent<Image>();
        cam = GameObject.Find("FirstPersonCharacter").GetComponent<Camera>();
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
    }

    private void OnEnable()
    {
        if (zoomBar != null)
            zoomBar.fillAmount = 0.6f;
    }
}
