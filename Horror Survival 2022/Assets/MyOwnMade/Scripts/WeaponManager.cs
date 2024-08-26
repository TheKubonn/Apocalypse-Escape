using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public enum weaponSelect
    {
        Knife,
        Cleaver,
        Bat,
        Pistol,
        Shotgun
    }

    // Exposing the enum in the editor
    public weaponSelect chosenWeapon;
    public GameObject[] weapons;
    
    private int weaponID = 0;
    private Animator anim;
    
    void Start()
    {
        weaponID = (int)chosenWeapon;
        //Debug.Log(weaponID);
        anim = GetComponent<Animator>();
        ChangeWeapons();
    }
    
    void Update()
    {
        
    }

    private void ChangeWeapons()
    {
        foreach (GameObject weapon in weapons)
        {
            weapon.SetActive(false);
        }
        weapons[weaponID].SetActive(true);
        chosenWeapon = (weaponSelect)weaponID;
        anim.SetInteger("WeaponID", weaponID);
    }
}
