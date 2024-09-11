using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupsScript : MonoBehaviour
{
    private RaycastHit hit;
    public LayerMask excludeLayers;
    private int objID = 0;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        if (Physics.SphereCast(transform.position, 0.5f, transform.forward, out hit, 30, ~excludeLayers))
        {
            if (hit.transform.gameObject.CompareTag("weapon"))
            {
                // this is how to cast the enum to the int to recognize the weapon number
                objID = (int)hit.transform.gameObject.GetComponent<WeaponType>().chooseWeapon;
                Debug.Log(objID);
            }
        }
    }
}
