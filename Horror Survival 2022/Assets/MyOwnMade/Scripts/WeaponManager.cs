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
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (weaponID < weapons.Length - 1)
            {
                weaponID++;
                ChangeWeapons();
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (weaponID > 0)
            {
                weaponID--;
                ChangeWeapons();
            }
        }
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
        anim.SetBool("weaponChanged", true);
        Move();
        StartCoroutine(WeaponReset());
    }

    private void Move()
    {
        switch (chosenWeapon)
        {
            case weaponSelect.Knife:
                transform.localPosition = new Vector3(0.02f, -0.193f, 0.66f);
                break;
            case weaponSelect.Cleaver:
                transform.localPosition = new Vector3(0.02f, -0.193f, 0.66f);
                break;
            case weaponSelect.Bat:
                transform.localPosition = new Vector3(0.02f, -0.193f, 0.66f);
                break;
            case weaponSelect.Pistol:
                transform.localPosition = new Vector3(0.02f, -0.193f, 0.66f);
                break;
            case weaponSelect.Shotgun:
                transform.localPosition = new Vector3(0.02f, -0.193f, 0.46f);
                break;
        }
    }

    private IEnumerator WeaponReset()
    {
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("weaponChanged", false);
    }
}
