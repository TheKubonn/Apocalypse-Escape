using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScale : MonoBehaviour
{
    private float scaleValue = 1;
    void Start()
    {
        if (Screen.width > 1920)
        {
            scaleValue = 2;
        }
        this.transform.localScale = new Vector3(scaleValue, scaleValue, scaleValue);
    }
}
