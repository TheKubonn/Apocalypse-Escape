using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class SaveScript : MonoBehaviour
{
    public static bool inventoryOpen = false;
    public static int weaponID = 0;
    public static int itemID = 0;
    public static bool[] weaponsPickedUp = new bool[8];
    public static bool[] itemsPickedUp = new bool[13];
    
    void Start()
    {
        // 0 is knife, default starting weapon
        weaponsPickedUp[0] = true;
        
        // 0 is flashlight 1 is night vision, default starting items  for now
        itemsPickedUp[0] = true;
        itemsPickedUp[1] = true;
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
