using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class LookModePostProcess : MonoBehaviour
{
    private PostProcessVolume volume;
    public PostProcessProfile firstPersonProfile;
    public PostProcessProfile nightVisionProfile;
    public PostProcessProfile inventoryProfile;
    public GameObject nightVisionOverlay;
    public GameObject flashLightOverlay;
    public GameObject inventoryMenu;
    private Light flashLight;
    private bool nightVisionOn = false;
    private bool flashLightOn = false;
    
    void Start()
    {
        volume = GetComponent<PostProcessVolume>();
        flashLight = GameObject.Find("FlashLight").GetComponent<Light>();
        flashLight.enabled = false;
        nightVisionOverlay.SetActive(false);
        flashLightOverlay.SetActive(false);
        inventoryMenu.SetActive(false);
        volume.profile = firstPersonProfile;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            if (nightVisionOn == false && SaveScript.inventoryOpen == false)
            {
                volume.profile = nightVisionProfile;
                nightVisionOverlay.SetActive(true);
                nightVisionOn = true;
                NightVisionOff();
            }
            else if (nightVisionOn)
            {
                volume.profile = firstPersonProfile;
                nightVisionOverlay.SetActive(false);
                nightVisionOverlay.GetComponent<NightVisionScript>().StopDrain();
                this.gameObject.GetComponent<Camera>().fieldOfView = 60;
                nightVisionOn = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (flashLightOn == false && SaveScript.inventoryOpen == false)
            {
                flashLightOverlay.SetActive(true);
                flashLight.enabled = true;
                flashLightOn = true;
                FlashLightOff();
            }
            else if (flashLightOn)
            {
                flashLightOverlay.SetActive(false);
                flashLight.enabled = false;
                flashLightOverlay.GetComponent<FlashLightScript>().StopDrain();
                flashLightOn = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            if (SaveScript.inventoryOpen == false)
            {
                volume.profile = inventoryProfile;
                inventoryMenu.SetActive(true);

                if (flashLightOn)
                {
                    flashLightOverlay.SetActive(false);
                    flashLight.enabled = false;
                    flashLightOverlay.GetComponent<FlashLightScript>().StopDrain();
                    flashLightOn = false;
                }

                if (nightVisionOn)
                {
                    nightVisionOverlay.SetActive(false);
                    nightVisionOverlay.GetComponent<NightVisionScript>().StopDrain();
                    this.gameObject.GetComponent<Camera>().fieldOfView = 60;
                    nightVisionOn = false;
                }
            }
            else if (SaveScript.inventoryOpen)
            {
                volume.profile = firstPersonProfile;
                inventoryMenu.SetActive(false);
            }
        }

        if (nightVisionOn == true)
        {
            NightVisionOff();
        }

        if (flashLightOn == true)
        {
            FlashLightOff();
        }
    }

    private void NightVisionOff()
    {
        if (nightVisionOverlay.GetComponent<NightVisionScript>().batteryPower <= 0)
        {
            volume.profile = firstPersonProfile;
            nightVisionOverlay.SetActive(false);
            this.gameObject.GetComponent<Camera>().fieldOfView = 60;
            nightVisionOn = false;
        }
    }

    private void FlashLightOff()
    {
        if (flashLightOverlay.GetComponent<FlashLightScript>().batteryPower <= 0)
        {
            flashLightOverlay.SetActive(false);
            flashLightOn = false;
            flashLight.enabled = false;
            flashLightOverlay.GetComponent<FlashLightScript>().StopDrain();
        }
    }
    
}
