using UnityEngine;

public class InventorySwitch : MonoBehaviour
{
    public GameObject weaponPanel, itemsPanel, combinePanel;
    
    void Start()
    {
        weaponPanel.SetActive(true);
        itemsPanel.SetActive(false);
    }

    public void SwitchItemsOn()
    {
        weaponPanel.SetActive(false);
        itemsPanel.SetActive(true);
        combinePanel.SetActive(false);
    }

    public void SwitchWeaponsOn()
    {
        weaponPanel.SetActive(true);
        itemsPanel.SetActive(false);
        combinePanel.SetActive(false);
    }
}
