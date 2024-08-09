using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashLightScript : MonoBehaviour
{
    private Image batteryChunks;
    public float batteryPower = 1.0f;
    public float drainTime = 2.0f;
    
    void OnEnable()
    {
        batteryChunks = GameObject.Find("FlashLightBatteryChunks").GetComponent<Image>();
        InvokeRepeating("FLBatteryDrain", drainTime, drainTime);
    }
    
    void Update()
    {
        batteryChunks.fillAmount = batteryPower;
    }

    private void FLBatteryDrain()
    {
        if (batteryPower > 0.0f)
        {
            batteryPower -= 0.25f;
        }
    }

    public void StopDrain()
    {
        CancelInvoke("FLBatteryDrain");
    }
    
}
