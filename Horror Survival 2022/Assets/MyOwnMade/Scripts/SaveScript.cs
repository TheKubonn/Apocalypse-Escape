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
        weaponsPickedUp[1] = true;
        
        // 0 is flashlight 1 is night vision, default starting items  for now
        itemsPickedUp[0] = true;
        itemsPickedUp[1] = true;
        itemsPickedUp[2] = true;
        itemsPickedUp[3] = true;
        itemsPickedUp[4] = true;
        itemsPickedUp[5] = true;
        itemsPickedUp[6] = true;
        itemsPickedUp[7] = true;
        itemsPickedUp[8] = true;
        itemsPickedUp[9] = true;
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
