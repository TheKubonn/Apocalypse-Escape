using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighterScript : MonoBehaviour
{
    public GameObject lighterObject;
    
    void OnEnable()
    {
        lighterObject.SetActive(true);
    }
    
    void OnDisable()
    {
        lighterObject.SetActive(false);
    }
}
