using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponType : MonoBehaviour
{
    public enum TypeOfWeapon
    {
        Knife,
        Cleaver,
        Bat,
        Axe,
        Pistol,
        Shotgun,
        SprayCan,
        Bottle
    }

    public TypeOfWeapon chooseWeapon;
    
}
