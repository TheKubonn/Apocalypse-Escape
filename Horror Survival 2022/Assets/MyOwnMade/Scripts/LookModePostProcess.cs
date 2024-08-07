using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class LookModePostProcess : MonoBehaviour
{
    private PostProcessVolume volume;
    public PostProcessProfile firstPersonProfile;
    public PostProcessProfile nightVisionProfile;
    public GameObject nightVisionOverlay;
    private bool nightVisionOn = false;
    
    void Start()
    {
        volume = GetComponent<PostProcessVolume>();
        nightVisionOverlay.SetActive(false);
        volume.profile = firstPersonProfile;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            if (nightVisionOn == false)
            {
                volume.profile = nightVisionProfile;
                nightVisionOverlay.SetActive(true);
                nightVisionOn = true;
                NightVisionOff();
            }
            else if (nightVisionOn == true)
            {
                volume.profile = firstPersonProfile;
                nightVisionOverlay.SetActive(false);
                this.gameObject.GetComponent<Camera>().fieldOfView = 60;
                nightVisionOn = false;
            }
        }

        if (nightVisionOn == true)
        {
            NightVisionOff();
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
    
}
