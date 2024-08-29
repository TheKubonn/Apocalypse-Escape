using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class SaveScript : MonoBehaviour
{
    public static bool inventoryOpen = false;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        if (FirstPersonController.inventorySwitchedOn)
        {
            inventoryOpen = true;
        }
        if (FirstPersonController.inventorySwitchedOn == false)
        {
            inventoryOpen = false;
        }
    }
}
